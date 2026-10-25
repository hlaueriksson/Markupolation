using Microsoft.AspNetCore.Http;

namespace Markupolation.AspNetCore.Htmx;

/// <summary>
/// htmx request headers.
/// </summary>
/// <remarks>
/// See <see href="https://htmx.org/reference/#request_headers"/>.
/// </remarks>
public static class HttpRequestExtensions
{
    /// <summary>
    /// Whether the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns><see langword="true"/> when the <c>HX-Request</c> header is present; otherwise, <see langword="false"/>.</returns>
    public static bool IsHtmx(this HttpRequest request) => request?.Headers.ContainsKey("HX-Request") == true;

    /// <summary>
    /// Whether the request is an htmx history restore.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns><see langword="true"/> when the <c>HX-History-Restore-Request</c> header is present; otherwise, <see langword="false"/>.</returns>
    public static bool IsHtmxHistoryRestore(this HttpRequest request) => request?.Headers.ContainsKey("HX-History-Restore-Request") == true;

    /// <summary>
    /// Whether the request came from an element using <c>hx-boost</c>.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns><see langword="true"/> when the <c>HX-Boosted</c> header is present; otherwise, <see langword="false"/>.</returns>
    public static bool IsHtmxBoosted(this HttpRequest request) => request?.Headers.ContainsKey("HX-Boosted") == true;

    /// <summary>
    /// Gets the current url of the browser, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Current-URL</c> header, or <see langword="null"/>.</returns>
    public static string? HtmxCurrentUrl(this HttpRequest request) => Header(request, "HX-Current-URL");

    /// <summary>
    /// Gets the id of the target element, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Target</c> header, or <see langword="null"/>.</returns>
    public static string? HtmxTarget(this HttpRequest request) => Header(request, "HX-Target");

    /// <summary>
    /// Gets the id of the triggering element, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Trigger</c> header, or <see langword="null"/>.</returns>
    public static string? HtmxTrigger(this HttpRequest request) => Header(request, "HX-Trigger");

    /// <summary>
    /// Gets the name of the triggering element, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Trigger-Name</c> header, or <see langword="null"/>.</returns>
    public static string? HtmxTriggerName(this HttpRequest request) => Header(request, "HX-Trigger-Name");

    /// <summary>
    /// Gets the user's response to an <c>hx-prompt</c>, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Prompt</c> header, or <see langword="null"/>.</returns>
    public static string? HtmxPrompt(this HttpRequest request) => Header(request, "HX-Prompt");

    private static string? Header(HttpRequest request, string name)
    {
        return request != null && request.Headers.TryGetValue(name, out var value) ? value.ToString() : null;
    }
}
