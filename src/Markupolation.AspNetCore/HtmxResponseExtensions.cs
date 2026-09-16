using Microsoft.AspNetCore.Http;

namespace Markupolation.AspNetCore;

/// <summary>
/// htmx request and response headers.
/// </summary>
/// <remarks>
/// See <see href="https://htmx.org/reference/#headers"/>.
/// </remarks>
public static class HtmxResponseExtensions
{
    /// <summary>
    /// Whether the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns><c>true</c> when the <c>HX-Request</c> header is present; otherwise, <c>false</c>.</returns>
    public static bool IsHtmx(this HttpRequest request) => request?.Headers.ContainsKey("HX-Request") == true;

    /// <summary>
    /// Whether the request is an htmx history restore.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns><c>true</c> when the <c>HX-History-Restore-Request</c> header is present; otherwise, <c>false</c>.</returns>
    public static bool IsHtmxHistoryRestore(this HttpRequest request) => request?.Headers.ContainsKey("HX-History-Restore-Request") == true;

    /// <summary>
    /// Whether the request came from an element using <c>hx-boost</c>.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns><c>true</c> when the <c>HX-Boosted</c> header is present; otherwise, <c>false</c>.</returns>
    public static bool IsHtmxBoosted(this HttpRequest request) => request?.Headers.ContainsKey("HX-Boosted") == true;

    /// <summary>
    /// Gets the current url of the browser, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Current-URL</c> header, or <c>null</c>.</returns>
    public static string? HtmxCurrentUrl(this HttpRequest request) => Header(request, "HX-Current-URL");

    /// <summary>
    /// Gets the id of the target element, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Target</c> header, or <c>null</c>.</returns>
    public static string? HtmxTarget(this HttpRequest request) => Header(request, "HX-Target");

    /// <summary>
    /// Gets the id of the triggering element, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Trigger</c> header, or <c>null</c>.</returns>
    public static string? HtmxTrigger(this HttpRequest request) => Header(request, "HX-Trigger");

    /// <summary>
    /// Gets the name of the triggering element, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Trigger-Name</c> header, or <c>null</c>.</returns>
    public static string? HtmxTriggerName(this HttpRequest request) => Header(request, "HX-Trigger-Name");

    /// <summary>
    /// Gets the user's response to an <c>hx-prompt</c>, if the request came from htmx.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <c>HX-Prompt</c> header, or <c>null</c>.</returns>
    public static string? HtmxPrompt(this HttpRequest request) => Header(request, "HX-Prompt");

    /// <summary>
    /// Triggers client side events. Sets <c>HX-Trigger</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">Event name, or a JSON object of events.</param>
    public static void HxTrigger(this HttpResponse response, string value) => Set(response, "HX-Trigger", value);

    /// <summary>
    /// Triggers client side events after the settle step. Sets <c>HX-Trigger-After-Settle</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">Event name, or a JSON object of events.</param>
    public static void HxTriggerAfterSettle(this HttpResponse response, string value) => Set(response, "HX-Trigger-After-Settle", value);

    /// <summary>
    /// Triggers client side events after the swap step. Sets <c>HX-Trigger-After-Swap</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">Event name, or a JSON object of events.</param>
    public static void HxTriggerAfterSwap(this HttpResponse response, string value) => Set(response, "HX-Trigger-After-Swap", value);

    /// <summary>
    /// Changes the element the response is swapped into. Sets <c>HX-Retarget</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A CSS selector.</param>
    public static void HxRetarget(this HttpResponse response, string value) => Set(response, "HX-Retarget", value);

    /// <summary>
    /// Changes how the response is swapped in. Sets <c>HX-Reswap</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A swap style, such as <c>outerHTML</c>.</param>
    public static void HxReswap(this HttpResponse response, string value) => Set(response, "HX-Reswap", value);

    /// <summary>
    /// Chooses the part of the response to swap in. Sets <c>HX-Reselect</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A CSS selector.</param>
    public static void HxReselect(this HttpResponse response, string value) => Set(response, "HX-Reselect", value);

    /// <summary>
    /// Pushes a new url into the history stack. Sets <c>HX-Push-Url</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A url, or <c>false</c> to prevent it.</param>
    public static void HxPushUrl(this HttpResponse response, string value) => Set(response, "HX-Push-Url", value);

    /// <summary>
    /// Replaces the current url. Sets <c>HX-Replace-Url</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A url, or <c>false</c> to prevent it.</param>
    public static void HxReplaceUrl(this HttpResponse response, string value) => Set(response, "HX-Replace-Url", value);

    /// <summary>
    /// Makes the client redirect. Sets <c>HX-Redirect</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A url.</param>
    public static void HxRedirect(this HttpResponse response, string value) => Set(response, "HX-Redirect", value);

    /// <summary>
    /// Makes the client redirect, without a full page reload. Sets <c>HX-Location</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="value">A url, or a JSON object with a <c>path</c> and further swap/target options.</param>
    public static void HxLocation(this HttpResponse response, string value) => Set(response, "HX-Location", value);

    /// <summary>
    /// Makes the client do a full refresh. Sets <c>HX-Refresh</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    public static void HxRefresh(this HttpResponse response) => Set(response, "HX-Refresh", "true");

    private static string? Header(HttpRequest request, string name)
    {
        return request != null && request.Headers.TryGetValue(name, out var value) ? value.ToString() : null;
    }

    private static void Set(HttpResponse response, string name, string value)
    {
        if (response != null)
        {
            response.Headers[name] = value;
        }
    }
}
