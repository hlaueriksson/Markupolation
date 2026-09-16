using System;
using System.Globalization;

namespace Markupolation;

/// <summary>
/// Turns a value into the text that goes into the markup.
/// </summary>
/// <remarks>
/// The single definition of how a value renders, the way <see cref="NameExtensions"/> is the single
/// definition of the naming convention. Three paths reach it - the implicit conversions in
/// <see cref="Content"/>, the interpolated string handler, and the generated <see langword="object"/> overloads
/// on <see cref="Elements"/> and <see cref="Attributes"/> - and they have to agree, because
/// <c>div(true)</c>, <c>div((Content)true)</c> and <c>div($"{true}")</c> are the same thing to the
/// person writing them.
/// <para>
/// Everything here is culture invariant. A server's culture is a deployment detail, and a decimal
/// comma or a localised date silently breaks a numeric attribute, embedded JSON, or anything
/// JavaScript parses back.
/// </para>
/// </remarks>
internal static class ValueFormatter
{
    // ISO 8601, which is what HTML's date and time attributes are defined in terms of. Not the
    // round-trip "O" format: that writes seven fractional digits, and HTML's time-of-day string
    // allows at most three, so <time datetime="..."> would be invalid.
    private const string DateTimeFormat = "s";

    // "s" drops the offset, which is the whole point of DateTimeOffset, so the offset is spelled
    // out instead - giving HTML's "global date and time string".
    private const string DateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:sszzz";

    /// <summary>
    /// Renders a <see cref="bool"/> as lowercase <c>true</c>/<c>false</c>.
    /// </summary>
    /// <remarks>
    /// Not <see cref="bool.ToString()"/>, which returns <c>True</c>/<c>False</c>. HTML's own
    /// enumerated attributes happen to match those case-insensitively, but anything that reads the
    /// value back as a string does not: <c>dataset.on === "true"</c> is false for <c>"True"</c>,
    /// and htmx, Alpine and Stimulus all compare the same way.
    /// </remarks>
    /// <param name="value">The value.</param>
    /// <returns>The text.</returns>
    internal static string Format(bool value) => value ? "true" : "false";

    /// <inheritdoc cref="Format(bool)"/>
    internal static string Format(DateTime value) => value.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

    /// <inheritdoc cref="Format(bool)"/>
    internal static string Format(DateTimeOffset value) => value.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture);

    /// <summary>
    /// Renders any value, for the paths that have only boxed it as <see cref="object"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The text, or <see langword="null"/> when the value is.</returns>
    internal static string? Format(object? value)
    {
        return value switch
        {
            null => null,
            string text => text,
            bool flag => Format(flag),
            DateTime date => Format(date),
            DateTimeOffset offset => Format(offset),
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString(),
        };
    }
}
