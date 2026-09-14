using System;
using System.Diagnostics;
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
public partial record Content
{
    // A Content is in exactly one of three states, and never changes after it is constructed:
    //
    //   markup        _value      set up front - new Content(string?), Raw, Element, Attribute
    //   text          _unencoded  set by FromText - every implicit conversion
    //   interpolated  _builder    filled by the interpolated string handler
    //
    // The last two render lazily into _value, which is the memo rather than a fourth state.
    private readonly StringBuilder? _builder;
    private string? _unencoded;
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

    // The text and interpolated states fill a field after construction, rather than passing a
    // rendered value in the way the raw constructor above does.
    private Content()
    {
    }

    /// <summary>
    /// Gets empty content.
    /// </summary>
    /// <remarks>
    /// One shared instance. <see cref="Content"/> never changes after it is constructed, so every
    /// branch that renders nothing can return this rather than allocate another - which is what the
    /// whole <c>If*</c> family does for the branch it does not take.
    /// </remarks>
    public static Content Empty { get; } = new(string.Empty);

    /// <summary>
    /// Gets content value.
    /// </summary>
    /// <remarks>
    /// Rendered once and remembered: an interpolated builder is flushed, text is encoded, and markup
    /// is already here. Null content stays null - re-encoding null costs nothing.
    /// </remarks>
    public string? Value => _value ??= _builder?.ToString() ?? HtmlEncoder.Encode(_unencoded);

    /// <summary>
    /// Gets the text this content was created from, before encoding, or <c>null</c> when the
    /// content is already markup.
    /// </summary>
    /// <remarks>
    /// Two readers, and no others. Raw text elements (<c>script</c>, <c>style</c>) render this instead
    /// of <see cref="Value"/>, because the HTML parser does not decode character references inside
    /// them; and <c>+</c> keeps it when both operands are still text, so that the fallback survives
    /// concatenation. Everywhere else the answer is <see cref="Value"/>.
    /// </remarks>
    internal string? Unencoded => _unencoded;

    /// <summary>
    /// Wraps a string that is already markup, without encoding it.
    /// </summary>
    /// <param name="value">Markup.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content Raw(string? value) => new(value);

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

    /// <summary>
    /// Creates content from text, encoding it lazily so that a raw text element can render the
    /// original instead.
    /// </summary>
    /// <remarks>
    /// Why it exists: encoding up front and handing the result to the raw constructor would leave
    /// <see cref="Unencoded"/> null, and <c>script</c>/<c>style</c> would then render the encoded
    /// form. Why it is private: the raw constructor is already the public way in, and a public
    /// <c>Text</c> helper was removed once for naming the default - it is exactly <c>(Content)s</c>.
    /// </remarks>
    /// <param name="text">Text.</param>
    /// <returns><see cref="Content"/></returns>
    private static Content FromText(string? text) => new() { _unencoded = text };
}
