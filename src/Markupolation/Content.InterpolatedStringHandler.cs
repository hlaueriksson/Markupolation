using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Markupolation;

/// <content>
/// The interpolated string handler.
/// </content>
/// <remarks>
/// Every member here is called by the compiler when it lowers an interpolated string, not by hand.
/// They have to be public for the compiler to bind to them, which is why they are hidden from
/// IntelliSense instead. See <see cref="Content"/> for what the handler is for.
/// </remarks>
[InterpolatedStringHandler]
public partial record Content
{
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
}
