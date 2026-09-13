namespace Markupolation.AspNetCore;

/// <summary>
/// HTML results, in the style of <c>TypedResults</c>.
/// </summary>
/// <remarks>
/// Returns <see cref="HtmlResult"/> rather than <c>IResult</c>, so an endpoint's return type stays
/// concrete and the response is described to OpenAPI.
/// </remarks>
public static class HtmlResults
{
    /// <summary>
    /// Returns the document with <c>200 OK</c>.
    /// </summary>
    /// <param name="html">The document.</param>
    /// <returns><see cref="HtmlResult"/></returns>
    public static HtmlResult Ok(Content html) => new(html);

    /// <summary>
    /// Returns the document with <c>404 Not Found</c>.
    /// </summary>
    /// <param name="html">The document.</param>
    /// <returns><see cref="HtmlResult"/></returns>
    public static HtmlResult NotFound(Content html) => new(html, 404);

    /// <summary>
    /// Returns the document with the given status code.
    /// </summary>
    /// <param name="statusCode">Status code.</param>
    /// <param name="html">The document.</param>
    /// <returns><see cref="HtmlResult"/></returns>
    public static HtmlResult StatusCode(int statusCode, Content html) => new(html, statusCode);
}
