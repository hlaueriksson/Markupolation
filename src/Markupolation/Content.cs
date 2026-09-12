using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Markupolation;

/// <summary>
/// HTML content.
/// </summary>
/// <remarks>
/// <para>
/// Text is encoded. A <see cref="string"/> converted to <see cref="Content"/> has its
/// <c>&amp;</c>, <c>&lt;</c>, <c>&gt;</c> and <c>"</c> encoded, so a value coming from a user
/// cannot break out of the markup around it. Use <see cref="Raw"/> for a string that is already
/// markup.
/// </para>
/// <para>
/// <see cref="Content"/> is also an interpolated string handler, which is what keeps
/// <c>$"Read the {b("HTML")} standard"</c> working: the literal parts of an interpolated string
/// are written by the author and stay raw, an <see cref="Element"/> or <see cref="Attribute"/>
/// in a hole is already markup and stays raw, and every other hole is encoded. Only a
/// <see cref="string"/> built up separately and then converted is encoded whole.
/// </para>
/// </remarks>
[DebuggerDisplay("{ToString()}")]
[InterpolatedStringHandler]
public record Content
{
    private readonly StringBuilder? _builder;

    private string? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Content"/> class.
    /// </summary>
    /// <remarks>The value is used as it is; it is not encoded.</remarks>
    /// <param name="value">Content value.</param>
    public Content(string? value)
    {
        _value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Content"/> class from an interpolated string.
    /// </summary>
    /// <remarks>Called by the compiler. Write an interpolated string instead of calling this.</remarks>
    /// <param name="literalLength">Length of the literal parts.</param>
    /// <param name="formattedCount">Number of interpolation holes.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Content(int literalLength, int formattedCount)
    {
        _builder = new StringBuilder(literalLength + (formattedCount * 8));
    }

    /// <summary>
    /// Gets content value.
    /// </summary>
    public string? Value => _builder == null ? _value : (_value ??= _builder.ToString());

    /// <summary>
    /// Converts <see cref="Content"/> to <see cref="string"/>.
    /// </summary>
    /// <param name="value">The content.</param>
    public static implicit operator string(Content value)
    {
        return value != null ? value.ToString() : string.Empty;
    }

    /// <summary>
    /// Converts <see cref="string"/> to <see cref="Content"/>, encoding it as text.
    /// </summary>
    /// <param name="value">The string.</param>
    public static implicit operator Content(string value)
    {
        return new Content(HtmlEncoder.Encode(value));
    }

    /// <summary>
    /// Converts <see cref="int"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(int value)
    {
        return new Content(HtmlEncoder.Encode(value.ToString(CultureInfo.CurrentCulture)));
    }

    /// <summary>
    /// Converts <see cref="long"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(long value)
    {
        return new Content(HtmlEncoder.Encode(value.ToString(CultureInfo.CurrentCulture)));
    }

    /// <summary>
    /// Converts <see cref="double"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(double value)
    {
        return new Content(HtmlEncoder.Encode(value.ToString(CultureInfo.CurrentCulture)));
    }

    /// <summary>
    /// Converts <see cref="decimal"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(decimal value)
    {
        return new Content(HtmlEncoder.Encode(value.ToString(CultureInfo.CurrentCulture)));
    }

    /// <summary>
    /// Converts <see cref="DateTime"/> to <see cref="Content"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Content(DateTime value)
    {
        return new Content(HtmlEncoder.Encode(value.ToString(CultureInfo.CurrentCulture)));
    }

    /// <summary>
    /// Wraps a string that is already markup, without encoding it.
    /// </summary>
    /// <param name="value">Markup.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content Raw(string? value) => new(value);

    /// <summary>
    /// Encodes a string as text.
    /// </summary>
    /// <remarks>The same as converting a <see cref="string"/> to <see cref="Content"/>.</remarks>
    /// <param name="value">Text.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content Text(string? value) => new(HtmlEncoder.Encode(value));

    /// <summary>
    /// Appends a literal part of an interpolated string. Author-written, so it stays raw.
    /// </summary>
    /// <remarks>Called by the compiler.</remarks>
    /// <param name="value">The literal.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AppendLiteral(string value) => _builder?.Append(value);

    /// <summary>
    /// Appends content in an interpolation hole. Already markup, so it stays raw.
    /// </summary>
    /// <remarks>Called by the compiler.</remarks>
    /// <param name="value">The content.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AppendFormatted(Content value) => _builder?.Append(value?.Value);

    /// <summary>
    /// Appends a string in an interpolation hole, encoded as text.
    /// </summary>
    /// <remarks>Called by the compiler.</remarks>
    /// <param name="value">The string.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AppendFormatted(string value) => _builder?.Append(HtmlEncoder.Encode(value));

    /// <summary>
    /// Appends a value in an interpolation hole, encoded as text unless it is already content.
    /// </summary>
    /// <remarks>Called by the compiler.</remarks>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">The value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AppendFormatted<T>(T value) => AppendFormatted(value, null);

    /// <summary>
    /// Appends a formatted value in an interpolation hole, encoded as text unless it is already
    /// content.
    /// </summary>
    /// <remarks>Called by the compiler.</remarks>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="format">Format string.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AppendFormatted<T>(T value, string? format)
    {
        if (_builder == null)
        {
            return;
        }

        // An Element or Attribute in a hole binds here rather than to AppendFormatted(Content),
        // because an identity conversion beats an implicit reference conversion. Recognise it.
        if (value is Content content)
        {
            _builder.Append(content.Value);
            return;
        }

        var text = value is IFormattable formattable ? formattable.ToString(format, null) : value?.ToString();

        _builder.Append(HtmlEncoder.Encode(text));
    }

    /// <summary>
    /// Writes the content to a <see cref="TextWriter"/>.
    /// </summary>
    /// <param name="writer">The writer. Ignored when <c>null</c>.</param>
    public void WriteTo(TextWriter writer)
    {
        writer?.Write(Value);
    }

    /// <summary>
    /// Writes the content to a <see cref="StringBuilder"/>.
    /// </summary>
    /// <param name="builder">The builder. Ignored when <c>null</c>.</param>
    public void WriteTo(StringBuilder builder)
    {
        builder?.Append(Value);
    }

    /// <summary>
    /// Determines whether two pieces of content have the same value.
    /// </summary>
    /// <remarks>
    /// Hand-written because synthesized record equality compares fields, and content built from
    /// an interpolated string holds a builder rather than a value until it is first read.
    /// </remarks>
    /// <param name="other">The content to compare with.</param>
    /// <returns><c>true</c> if the content is equal; otherwise, <c>false</c>.</returns>
    public virtual bool Equals(Content? other)
    {
        return other is not null
            && EqualityContract == other.EqualityContract
            && string.Equals(Value, other.Value, StringComparison.Ordinal);
    }

    /// <inheritdoc/>
    public override int GetHashCode() => Value == null ? 0 : StringComparer.Ordinal.GetHashCode(Value);

    /// <inheritdoc/>
    public override string ToString() => Value ?? string.Empty;
}
