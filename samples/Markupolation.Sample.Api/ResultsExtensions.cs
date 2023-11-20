using System.Net.Mime;
using System.Text;

// https://gist.github.com/davidfowl/ff1addd02d239d2d26f4648a06158727#customizing-results

static class ResultsExtensions
{
    public static IResult Html(this IResultExtensions resultExtensions, string html)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions, nameof(resultExtensions));

        return new HtmlResult(html);
    }
}

class HtmlResult(string html) : IResult
{
    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Text.Html;
        httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
        return httpContext.Response.WriteAsync(html);
    }
}
