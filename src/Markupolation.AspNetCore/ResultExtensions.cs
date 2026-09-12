using Microsoft.AspNetCore.Http;

namespace Markupolation.AspNetCore;

/// <summary>
/// HTML results for Minimal APIs, reached through <c>Results.Extensions.Html(...)</c>.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Returns rendered markup as an HTML response.
    /// </summary>
    /// <remarks>
    /// Elements convert to <see cref="string"/> implicitly, so pass the document directly. The
    /// value is written as it is; encoding already happened inside the elements.
    /// </remarks>
    /// <param name="resultExtensions">The extension point.</param>
    /// <param name="html">Rendered markup.</param>
    /// <returns><see cref="IResult"/></returns>
    public static IResult Html(this IResultExtensions resultExtensions, string html)
    {
        _ = resultExtensions;

        return new HtmlResult(html);
    }

    /// <summary>
    /// Returns rendered markup as an HTML response, with a status code.
    /// </summary>
    /// <remarks>The string is used as it is, not encoded.</remarks>
    /// <param name="resultExtensions">The extension point.</param>
    /// <param name="html">Rendered markup.</param>
    /// <param name="statusCode">Status code.</param>
    /// <returns><see cref="IResult"/></returns>
    public static IResult Html(this IResultExtensions resultExtensions, string html, int statusCode)
    {
        _ = resultExtensions;

        return new HtmlResult(html, statusCode);
    }
}
