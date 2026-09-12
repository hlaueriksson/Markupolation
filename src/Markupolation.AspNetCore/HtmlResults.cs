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
    /// Returns rendered markup with <c>200 OK</c>.
    /// </summary>
    /// <param name="html">Rendered markup.</param>
    /// <returns><see cref="HtmlResult"/></returns>
    public static HtmlResult Ok(string html) => new(html);

    /// <summary>
    /// Returns rendered markup with <c>404 Not Found</c>.
    /// </summary>
    /// <param name="html">Rendered markup.</param>
    /// <returns><see cref="HtmlResult"/></returns>
    public static HtmlResult NotFound(string html) => new(html, 404);

    /// <summary>
    /// Returns rendered markup with the given status code.
    /// </summary>
    /// <param name="statusCode">Status code.</param>
    /// <param name="html">Rendered markup.</param>
    /// <returns><see cref="HtmlResult"/></returns>
    public static HtmlResult StatusCode(int statusCode, string html) => new(html, statusCode);
}
