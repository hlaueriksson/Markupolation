namespace Markupolation;

/// <content>
/// Operators on <see cref="Content"/>.
/// </content>
/// <remarks>
/// <c>+</c> is how several siblings are written without a wrapper element. It concatenates each
/// side's rendered <see cref="Content.Value"/>, so every operand is still encoded by its own rule:
/// an element or attribute is already markup and stays raw, and a <see cref="string"/> is text and
/// is encoded. Use <see cref="Content.Raw(string?)"/> for a string that is already markup.
/// <para>
/// A user-defined <c>+</c> removes the predefined string concatenation from the candidate set, so
/// this operator is what <c>element + element</c> binds to instead of <c>string + string</c>. That
/// is the point: the result stays <see cref="Content"/> rather than becoming a
/// <see cref="string"/> that is encoded again the next time it reaches an element.
/// </para>
/// </remarks>
public partial record Content
{
    /// <summary>
    /// Concatenates two pieces of content, so several siblings can be written without a wrapper
    /// element.
    /// </summary>
    /// <remarks>
    /// Each side is rendered by its own rule. A <c>null</c> operand, and one whose
    /// <see cref="Value"/> is empty (such as <see cref="Empty"/> or <c>Raw(null)</c>), contributes
    /// nothing and is returned as the other side, untouched - so whichever side still carries
    /// <see cref="Unencoded"/> keeps it, including when accumulating with <c>+=</c> from an empty
    /// seed.
    /// </remarks>
    /// <param name="left">Left content.</param>
    /// <param name="right">Right content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content operator +(Content? left, Content? right)
    {
        if (left is null)
        {
            return right ?? Raw(null);
        }

        if (right is null)
        {
            return left;
        }

        // Both sides are still text, so keep the original for a raw text element to fall back to.
        // This comes first because it is the only branch that needs neither side's Value: reading
        // Value encodes, and the combined text is encoded again below, so testing it here would
        // encode three times where one will do.
        if (left.Unencoded is { } leftText && right.Unencoded is { } rightText)
        {
            return FromText(leftText + rightText);
        }

        // "" is the additive identity for +, so concatenating with it must be a genuine no-op -
        // returning the other side untouched, not a new Content that has lost whichever side still
        // carried Unencoded. Content.Raw(null) and Content.Empty both render as "" here, but are
        // real Content instances rather than a C# null, so the null checks above do not catch them.
        if (string.IsNullOrEmpty(left.Value))
        {
            return right;
        }

        if (string.IsNullOrEmpty(right.Value))
        {
            return left;
        }

        return new Content(string.Concat(left.Value, right.Value));
    }
}
