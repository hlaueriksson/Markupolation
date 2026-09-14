using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    private readonly Content _html;

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlResult"/> class.
    /// </summary>
    /// <remarks>
    /// Takes the document as <see cref="Content"/>. <see cref="Element"/>, <see cref="Attribute"/>
    /// and <c>DOCTYPE() + html(...)</c> are all <see cref="Content"/>, so every shape of a finished
    /// document fits, and encoding has already happened inside the elements. A <see cref="string"/>
    /// that is already rendered markup goes through <see cref="Content.Raw(string?)"/>; anything
    /// else is text, and is encoded.
    /// </remarks>
    /// <param name="html">The document.</param>
    public HtmlResult(Content html)
        : this(html, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlResult"/> class with a status code.
    /// </summary>
    /// <remarks>See the other constructor.</remarks>
    /// <param name="html">The document.</param>
    /// <param name="statusCode">Status code.</param>
    public HtmlResult(Content html, int statusCode)
        : this(html, (int?)statusCode)
    {
    }

    private HtmlResult(Content html, int? statusCode)
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
        var value = _html?.Value ?? string.Empty;

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
