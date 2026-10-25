using Microsoft.AspNetCore.Http;

namespace Markupolation.AspNetCore.Htmx;

/// <summary>
/// htmx response headers.
/// </summary>
/// <remarks>
/// See <see href="https://htmx.org/reference/#response_headers"/>.
/// </remarks>
public static class HttpResponseExtensions
{
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
    /// <remarks>
    /// Prevent it with <see cref="HxPreventPushUrl(HttpResponse)"/>.
    /// </remarks>
    /// <param name="response">The response.</param>
    /// <param name="value">A url.</param>
    public static void HxPushUrl(this HttpResponse response, string value) => Set(response, "HX-Push-Url", value);

    /// <summary>
    /// Prevents the history stack being updated. Sets <c>HX-Push-Url</c> to <c>false</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    public static void HxPreventPushUrl(this HttpResponse response) => Set(response, "HX-Push-Url", "false");

    /// <summary>
    /// Replaces the current url. Sets <c>HX-Replace-Url</c>.
    /// </summary>
    /// <remarks>
    /// Prevent it with <see cref="HxPreventReplaceUrl(HttpResponse)"/>.
    /// </remarks>
    /// <param name="response">The response.</param>
    /// <param name="value">A url.</param>
    public static void HxReplaceUrl(this HttpResponse response, string value) => Set(response, "HX-Replace-Url", value);

    /// <summary>
    /// Prevents the current url being replaced. Sets <c>HX-Replace-Url</c> to <c>false</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    public static void HxPreventReplaceUrl(this HttpResponse response) => Set(response, "HX-Replace-Url", "false");

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

    private static void Set(HttpResponse response, string name, string value)
    {
        if (response != null)
        {
            response.Headers[name] = value;
        }
    }
}
