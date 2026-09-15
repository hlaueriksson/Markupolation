using System;
using System.Globalization;

namespace Markupolation;

/// <content>
/// Conversions to and from <see cref="Content"/>.
/// </content>
/// <remarks>
/// Value types convert directly, rather than through <see cref="object.ToString()"/>, so that a
/// conditional mixing an element with a value has no natural type and is target-typed to
/// <see cref="Content"/> — which keeps the element as markup instead of rendering it and encoding
/// the result as text.
/// <para>
/// The numeric set has to stay complete. Once <see cref="ulong"/> is declared, <see cref="int"/>
/// and <see cref="ulong"/> are incomparable, so the smaller integer types no longer have a unique
/// conversion to widen through and become ambiguous. <see cref="char"/> would otherwise widen to
/// <see cref="int"/> and render as a numeric code, and <see cref="float"/> would widen to
/// <see cref="double"/> and render its binary artefacts.
/// </para>
/// </remarks>
public partial record Content
{
    /// <summary>
    /// Converts <see cref="Content"/> to <see cref="string"/>.
    /// </summary>
    /// <remarks>
    /// Explicit on purpose. Markup that leaves <see cref="Content"/> for a <see cref="string"/> has
    /// lost what the library knows about it, and is encoded as text the next time it reaches an
    /// element - so saying so is part of the API. <see cref="object.ToString()"/> does the same.
    /// </remarks>
    /// <param name="value">The content.</param>
    public static explicit operator string(Content value)
    {
        return value != null ? value.ToString() : string.Empty;
    }

    /// <summary>
    /// Converts <see cref="string"/> to <see cref="Content"/>, encoding it as text.
    /// </summary>
    /// <param name="value">The string.</param>
    public static implicit operator Content(string value)
    {
        return FromText(value);
    }

    /// <summary>
    /// Converts <see cref="int"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(int value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="long"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(long value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="double"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(double value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="decimal"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(decimal value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="DateTime"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>
    /// ISO 8601 (<c>2026-09-15T13:45:00</c>), because that is what HTML's date and time attributes
    /// are defined in terms of - an invariant <see cref="DateTime.ToString()"/> would render
    /// <c>09/15/2026 13:45:00</c>, which <c>&lt;time datetime&gt;</c> does not accept.
    /// </remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(DateTime value)
    {
        return FromText(ValueFormatter.Format(value));
    }

    /// <summary>
    /// Converts <see cref="char"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>Without this a char would widen to <see cref="int"/> and render as its numeric code.</remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(char value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="float"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>Without this a float would widen to <see cref="double"/> and render its binary artefacts.</remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(float value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="ulong"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>Without this a ulong is ambiguous between the <see cref="double"/> and <see cref="decimal"/> conversions.</remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(ulong value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="bool"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>
    /// Renders lowercase <c>true</c> or <c>false</c>, not the <c>True</c>/<c>False</c> of
    /// <see cref="bool.ToString()"/> - see <see cref="ValueFormatter.Format(bool)"/> for why. A
    /// conditional usually reads better as <c>flag.If(...)</c> than as a rendered bool.
    /// </remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(bool value)
    {
        return FromText(ValueFormatter.Format(value));
    }

    /// <summary>
    /// Converts <see cref="DateTimeOffset"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>
    /// ISO 8601 with the offset spelled out (<c>2026-09-15T13:45:00+02:00</c>), which is HTML's
    /// global date and time string.
    /// </remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(DateTimeOffset value)
    {
        return FromText(ValueFormatter.Format(value));
    }

    /// <summary>
    /// Converts <see cref="TimeSpan"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(TimeSpan value)
    {
        return FromText(value.ToString(null, CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="Guid"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(Guid value)
    {
        return FromText(value.ToString("D", CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="Enum"/> to <see cref="Content"/>.
    /// </summary>
    /// <remarks>One conversion covers every enum; the value is boxed.</remarks>
    /// <param name="value">The value.</param>
    public static implicit operator Content(Enum value)
    {
        return FromText(value?.ToString());
    }

    /// <summary>
    /// Converts <see cref="sbyte"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(sbyte value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="byte"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(byte value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="short"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(short value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="ushort"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(ushort value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts <see cref="uint"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(uint value)
    {
        return FromText(value.ToString(CultureInfo.InvariantCulture));
    }
}
