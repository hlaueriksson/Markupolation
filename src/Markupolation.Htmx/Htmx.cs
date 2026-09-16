namespace Markupolation;

/// <summary>
/// htmx attributes.
/// </summary>
/// <remarks>
/// See <see href="https://htmx.org/reference/#attributes"/>.
/// </remarks>
public static class Htmx
{
    /// <summary>
    /// Issues a GET to the specified URL.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-get="{value}"</c></returns>
    public static Attribute hx_get(string value) => new("hx-get", value);

    /// <summary>
    /// Issues a POST to the specified URL.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-post="{value}"</c></returns>
    public static Attribute hx_post(string value) => new("hx-post", value);

    /// <summary>
    /// Issues a PUT to the specified URL.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-put="{value}"</c></returns>
    public static Attribute hx_put(string value) => new("hx-put", value);

    /// <summary>
    /// Issues a PATCH to the specified URL.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-patch="{value}"</c></returns>
    public static Attribute hx_patch(string value) => new("hx-patch", value);

    /// <summary>
    /// Issues a DELETE to the specified URL.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-delete="{value}"</c></returns>
    public static Attribute hx_delete(string value) => new("hx-delete", value);

    /// <summary>
    /// Adds progressive enhancement for links and forms.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-boost="{value}"</c></returns>
    public static Attribute hx_boost(bool value) => new("hx-boost", value ? "true" : "false");

    /// <summary>
    /// Shows a confirm dialog before issuing a request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-confirm="{value}"</c></returns>
    public static Attribute hx_confirm(string value) => new("hx-confirm", value);

    /// <summary>
    /// Adds the disabled attribute to the specified elements while a request is in flight.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-disabled-elt="{value}"</c></returns>
    public static Attribute hx_disabled_elt(string value) => new("hx-disabled-elt", value);

    /// <summary>
    /// Controls and disables automatic attribute inheritance for child nodes.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-disinherit="{value}"</c></returns>
    public static Attribute hx_disinherit(string value) => new("hx-disinherit", value);

    /// <summary>
    /// Changes the request encoding type.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-encoding="{value}"</c></returns>
    public static Attribute hx_encoding(string value) => new("hx-encoding", value);

    /// <summary>
    /// Extensions to use for this element.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-ext="{value}"</c></returns>
    public static Attribute hx_ext(string value) => new("hx-ext", value);

    /// <summary>
    /// Adds to the headers that will be submitted with the request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-headers="{value}"</c></returns>
    public static Attribute hx_headers(string value) => new("hx-headers", value);

    /// <summary>
    /// Prevents sensitive data being saved to the history cache.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-history="{value}"</c></returns>
    public static Attribute hx_history(bool value) => new("hx-history", value ? "true" : "false");

    /// <summary>
    /// Includes additional data in requests.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-include="{value}"</c></returns>
    public static Attribute hx_include(string value) => new("hx-include", value);

    /// <summary>
    /// The element to put the <c>htmx-request</c> class on during the request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-indicator="{value}"</c></returns>
    public static Attribute hx_indicator(string value) => new("hx-indicator", value);

    /// <summary>
    /// Controls and enables automatic attribute inheritance for child nodes.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-inherit="{value}"</c></returns>
    public static Attribute hx_inherit(string value) => new("hx-inherit", value);

    /// <summary>
    /// Filters the parameters that will be submitted with a request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-params="{value}"</c></returns>
    public static Attribute hx_params(string value) => new("hx-params", value);

    /// <summary>
    /// Shows a prompt before submitting a request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-prompt="{value}"</c></returns>
    public static Attribute hx_prompt(string value) => new("hx-prompt", value);

    /// <summary>
    /// Pushes the URL into the browser location bar, creating a new history entry.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-push-url="{value}"</c></returns>
    public static Attribute hx_push_url(string value) => new("hx-push-url", value);

    /// <inheritdoc cref="hx_push_url(string)" />
    public static Attribute hx_push_url(bool value) => new("hx-push-url", value ? "true" : "false");

    /// <summary>
    /// Replaces the URL in the browser location bar.
    /// </summary>
    /// <inheritdoc cref="hx_push_url(string)" path="/remarks" />
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-replace-url="{value}"</c></returns>
    public static Attribute hx_replace_url(string value) => new("hx-replace-url", value);

    /// <inheritdoc cref="hx_replace_url(string)" />
    public static Attribute hx_replace_url(bool value) => new("hx-replace-url", value ? "true" : "false");

    /// <summary>
    /// Configures various aspects of the request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-request="{value}"</c></returns>
    public static Attribute hx_request(string value) => new("hx-request", value);

    /// <summary>
    /// Selects content to swap in from a response.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-select="{value}"</c></returns>
    public static Attribute hx_select(string value) => new("hx-select", value);

    /// <summary>
    /// Selects content to swap in from a response, somewhere other than the target.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-select-oob="{value}"</c></returns>
    public static Attribute hx_select_oob(string value) => new("hx-select-oob", value);

    /// <summary>
    /// Controls how content is swapped in, such as <c>outerHTML</c> or <c>beforeend</c>.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-swap="{value}"</c></returns>
    public static Attribute hx_swap(string value) => new("hx-swap", value);

    /// <summary>
    /// Marks element to swap in from a response, somewhere other than the target.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-swap-oob="{value}"</c></returns>
    public static Attribute hx_swap_oob(string value) => new("hx-swap-oob", value);

    /// <summary>
    /// Controls how requests made by different elements are synchronized.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-sync="{value}"</c></returns>
    public static Attribute hx_sync(string value) => new("hx-sync", value);

    /// <summary>
    /// Specifies the target element to be swapped.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-target="{value}"</c></returns>
    public static Attribute hx_target(string value) => new("hx-target", value);

    /// <summary>
    /// Specifies the event that triggers the request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-trigger="{value}"</c></returns>
    public static Attribute hx_trigger(string value) => new("hx-trigger", value);

    /// <summary>
    /// Adds values to submit with the request, as JSON.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-vals="{value}"</c></returns>
    public static Attribute hx_vals(string value) => new("hx-vals", value);

    /// <summary>
    /// Adds values dynamically to parameters. Deprecated in htmx in favor of <see cref="hx_vals"/>.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-vars="{value}"</c></returns>
    public static Attribute hx_vars(string value) => new("hx-vars", value);

    /// <summary>
    /// Forces elements to validate themselves before a request.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hx-validate="{value}"</c></returns>
    public static Attribute hx_validate(bool value) => new("hx-validate", value ? "true" : "false");

    /// <summary>
    /// Disables htmx processing for this node and its children.
    /// </summary>
    /// <returns><c>hx-disable</c></returns>
    public static Attribute hx_disable() => new("hx-disable");

    /// <summary>
    /// The element to snapshot and restore during history navigation.
    /// </summary>
    /// <returns><c>hx-history-elt</c></returns>
    public static Attribute hx_history_elt() => new("hx-history-elt");

    /// <summary>
    /// Keeps this element unchanged between requests.
    /// </summary>
    /// <returns><c>hx-preserve</c></returns>
    public static Attribute hx_preserve() => new("hx-preserve");

    /// <summary>
    /// Handles an event inline, as <c>hx-on:name</c>.
    /// </summary>
    /// <param name="name">Event name.</param>
    /// <param name="value">Script to run.</param>
    /// <returns><c>hx-on:{name}="{value}"</c></returns>
    public static Attribute hx_on(string name, string value) => new("hx-on:" + name, value);
}
