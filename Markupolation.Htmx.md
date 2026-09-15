### Markupolation.Htmx <📜>

[htmx](https://htmx.org) attributes for [Markupolation](https://github.com/hlaueriksson/Markupolation).

### Installation

```
PM> Install-Package Markupolation.Htmx
```

### Usage

```cs
button(
    class_("btn btn-primary"),
    hx_get($"/api/counter/{count + 1}"),
    hx_target("#result"),
    hx_swap("outerHTML"),
    "Click me"
)
```

```html
<button class="btn btn-primary" hx-get="/api/counter/1" hx-target="#result" hx-swap="outerHTML">Click me</button>
```

Values are encoded like any other attribute value, so JSON in `hx-vals` and `&` in a URL both come
out correct.

### Attributes

Requests: `hx_get`, `hx_post`, `hx_put`, `hx_patch`, `hx_delete`.

Targeting and swapping: `hx_target`, `hx_swap`, `hx_swap_oob`, `hx_select`, `hx_select_oob`.

Everything else: `hx_boost`, `hx_confirm`, `hx_disable`, `hx_disabled_elt`, `hx_disinherit`,
`hx_encoding`, `hx_ext`, `hx_headers`, `hx_history`, `hx_history_elt`, `hx_include`,
`hx_indicator`, `hx_inherit`, `hx_on`, `hx_params`, `hx_preserve`, `hx_prompt`, `hx_push_url`,
`hx_replace_url`, `hx_request`, `hx_sync`, `hx_trigger`, `hx_vals`, `hx_vars`, `hx_validate`.

`hx_vars` is deprecated in htmx in favor of `hx_vals`.

`hx_disable()`, `hx_history_elt()` and `hx_preserve()` take no value and render bare.

`hx_boost`, `hx_history` and `hx_validate` take a `bool` and nothing else, because a bool is all
htmx reads from them. `hx_push_url` and `hx_replace_url` take either, since htmx reads a URL or
`true`/`false` from those:

```cs
hx_boost(false)              // hx-boost="false"
hx_push_url("/page/2")       // hx-push-url="/page/2"
hx_push_url(false)           // hx-push-url="false"
```

The rendered value is always lowercase `true`/`false` — htmx does not recognise the `True`/`False`
that `bool.ToString()` produces, and would have treated it as truthy.

`hx_on` names the event. A DOM event is named directly; an htmx event takes a leading colon:

```cs
hx_on("click", "alert(1)")                  // hx-on:click="alert(1)"
hx_on(":after-request", "this.reset()")     // hx-on::after-request="this.reset()"
```

For anything not here, the escape hatch still works: `new A("hx-whatever", "value")`.

### Response headers

htmx response headers such as `HX-Trigger` and `HX-Retarget` live in
[Markupolation.AspNetCore](https://www.nuget.org/packages/Markupolation.AspNetCore), because they
are response-side rather than markup.

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
