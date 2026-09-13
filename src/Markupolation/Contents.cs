namespace Markupolation;

/// <summary>
/// HTML content.
/// </summary>
/// <remarks>
/// The markup that is neither an element nor an attribute, and so is hand-written rather than
/// generated from the specification. Imported with a static using alongside <see cref="Elements"/>
/// and <see cref="Attributes"/>, so it reads inline with the rest of the API:
/// <c>DOCTYPE() + html(body(raw("&lt;!-- content here --&gt;"), p("Hello")))</c>.
/// </remarks>
public static class Contents
{
    private static readonly Content Doctype = Content.Raw("<!DOCTYPE html>");

    /// <summary>
    /// DOCTYPE.
    /// </summary>
    /// <remarks>
    /// Not an element - it is a document type declaration, and not in the element index the rest of
    /// <see cref="Elements"/> is generated from. <see cref="Content"/> rather than
    /// <see cref="string"/>, so that <c>DOCTYPE() + html(...)</c> composes as markup; a raw
    /// <see cref="string"/> here would be text, and encoded.
    /// </remarks>
    /// <returns><c><![CDATA[<!DOCTYPE html>]]></c></returns>
    public static Content DOCTYPE() => Doctype;

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
