using Microsoft.AspNetCore.Http;

namespace Markupolation.AspNetCore;

/// <summary>
/// HTML results for Minimal APIs, reached through <c>Results.Extensions.Html(...)</c>.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Returns the document as an HTML response.
    /// </summary>
    /// <remarks>
    /// Pass the document directly - an element, or <c>DOCTYPE() + html(...)</c>, is already
    /// <see cref="Content"/>. Encoding happened inside the elements. A <see cref="string"/> that is
    /// already rendered markup goes through <see cref="Content.Raw(string?)"/>.
    /// </remarks>
    /// <param name="resultExtensions">The extension point.</param>
    /// <param name="html">The document.</param>
    /// <returns><see cref="IResult"/></returns>
    public static IResult Html(this IResultExtensions resultExtensions, Content html)
    {
        _ = resultExtensions;

        return new HtmlResult(html);
    }

    /// <summary>
    /// Returns the document as an HTML response, with a status code.
    /// </summary>
    /// <param name="resultExtensions">The extension point.</param>
    /// <param name="html">The document.</param>
    /// <param name="statusCode">Status code.</param>
    /// <returns><see cref="IResult"/></returns>
    public static IResult Html(this IResultExtensions resultExtensions, Content html, int statusCode)
    {
        _ = resultExtensions;

        return new HtmlResult(html, statusCode);
    }
}
