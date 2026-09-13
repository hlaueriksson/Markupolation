namespace Markupolation;

/// <summary>
/// HTML content helpers.
/// </summary>
/// <remarks>
/// Imported with a static using alongside <see cref="Elements"/> and <see cref="Attributes"/>, so
/// that opting out of encoding reads inline with the rest of the API:
/// <c>body(raw("&lt;!-- content here --&gt;"), p("Hello"))</c>.
/// </remarks>
public static class Contents
{
    /// <summary>
    /// Wraps a string that is already markup, without encoding it.
    /// </summary>
    /// <remarks>
    /// The unqualified spelling of <see cref="Content.Raw(string?)"/>, the way <c>div</c> is the
    /// unqualified spelling of <see cref="Elements"/>.<c>div</c>.
    /// </remarks>
    /// <param name="value">Markup.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content raw(string? value) => Content.Raw(value);
}
