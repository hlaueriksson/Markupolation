namespace Markupolation.Converter;

/// <summary>
/// How to convert HTML into Markupolation source.
/// </summary>
public sealed record ConvertOptions
{
    /// <summary>
    /// Gets a value indicating whether to emit only the nodes given, without the
    /// <c>DOCTYPE</c> / <c>html</c> / <c>head</c> / <c>body</c> wrapper the parser adds.
    /// </summary>
    /// <remarks>
    /// <c>null</c>, the default, decides from the input: a whole document if it has a doctype or
    /// an <c>html</c> element, a fragment otherwise.
    /// </remarks>
    public bool? Fragment { get; init; }

    /// <summary>
    /// Gets a value indicating whether to qualify the names that exist as both an element and an
    /// attribute with <c>e.</c> and <c>a.</c>.
    /// </summary>
    /// <remarks>
    /// Nine names collide — <c>abbr</c>, <c>cite</c>, <c>data</c>, <c>form</c>, <c>label</c>,
    /// <c>slot</c>, <c>span</c>, <c>style</c> and <c>title</c>. Unqualified they resolve to the
    /// attribute, so an element of that name needs <c>e.</c> to compile. That is why this defaults
    /// to <c>true</c>.
    /// </remarks>
    public bool Aliases { get; init; } = true;

    /// <summary>
    /// Gets the number of spaces per indentation level.
    /// </summary>
    public int Indent { get; init; } = 4;
}
