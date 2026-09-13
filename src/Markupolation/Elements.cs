namespace Markupolation;

/// <summary>
/// HTML elements.
/// </summary>
public static partial class Elements
{
    private static readonly Content Doctype = Content.Raw("<!DOCTYPE html>");

    /// <summary>
    /// DOCTYPE.
    /// </summary>
    /// <remarks>
    /// <see cref="Content"/> rather than <see cref="string"/>, so that <c>DOCTYPE() + html(...)</c>
    /// composes as markup. A raw <see cref="string"/> here would be text, and encoded.
    /// </remarks>
    /// <returns><c><![CDATA[<!DOCTYPE html>]]></c></returns>
    public static Content DOCTYPE() => Doctype;
}
