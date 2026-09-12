using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Markupolation.AspNetCore;

/// <summary>
/// An HTML response.
/// </summary>
/// <remarks>
/// Implements both <see cref="IResult"/> and <see cref="IActionResult"/>, so the same type serves
/// a Minimal API endpoint and an MVC action. The content type is <c>text/html; charset=utf-8</c>,
/// and the body is encoded straight into the response's <c>PipeWriter</c> with
/// <c>Content-Length</c> set, so the response is not chunked.
/// </remarks>
public sealed class HtmlResult : IResult, IActionResult, IStatusCodeHttpResult, IContentTypeHttpResult
{
    private readonly string _html;

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlResult"/> class.
    /// </summary>
    /// <remarks>
    /// Takes the rendered markup. <see cref="Content"/>, <see cref="Element"/> and
    /// <see cref="Attribute"/> all convert to <see cref="string"/> implicitly, and so does
    /// <c>DOCTYPE() + html(...)</c>, so every shape of a finished document fits. The value is
    /// written as it is — encoding already happened inside the elements — so do not pass text
    /// that came from a user straight into this.
    /// </remarks>
    /// <param name="html">Rendered markup.</param>
    public HtmlResult(string html)
        : this(html, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlResult"/> class with a status code.
    /// </summary>
    /// <remarks>The value is written as it is; see the other constructor.</remarks>
    /// <param name="html">Rendered markup.</param>
    /// <param name="statusCode">Status code.</param>
    public HtmlResult(string html, int statusCode)
        : this(html, (int?)statusCode)
    {
    }

    private HtmlResult(string html, int? statusCode)
    {
        _html = html;
        StatusCode = statusCode;
    }

    /// <inheritdoc/>
    public int? StatusCode { get; }

    /// <inheritdoc/>
    public string? ContentType => "text/html; charset=utf-8";

    /// <inheritdoc/>
    public Task ExecuteAsync(HttpContext httpContext)
    {
        return httpContext == null ? Task.CompletedTask : WriteAsync(httpContext.Response);
    }

    /// <inheritdoc/>
    public Task ExecuteResultAsync(ActionContext context)
    {
        return context == null ? Task.CompletedTask : WriteAsync(context.HttpContext.Response);
    }

    private Task WriteAsync(HttpResponse response)
    {
        var value = _html ?? string.Empty;

        response.Headers[HeaderNames.ContentType] = ContentType;

        if (StatusCode.HasValue)
        {
            response.StatusCode = StatusCode.Value;
        }

        var length = Encoding.UTF8.GetByteCount(value);
        response.ContentLength = length;

        if (length == 0)
        {
            return Task.CompletedTask;
        }

        // Encode once, into the response's own buffer.
        var writer = response.BodyWriter;
        var written = Encoding.UTF8.GetBytes(value.AsSpan(), writer.GetSpan(length));
        writer.Advance(written);

        return writer.FlushAsync().AsTask();
    }
}
