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
    /// Each side is rendered by its own rule. A <c>null</c> operand contributes nothing.
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
        if (left.Unencoded is { } leftText && right.Unencoded is { } rightText)
        {
            return FromText(leftText + rightText);
        }

        return new Content(string.Concat(left.Value, right.Value));
    }
}
