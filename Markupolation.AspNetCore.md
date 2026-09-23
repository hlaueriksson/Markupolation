### Markupolation.AspNetCore <📜>

ASP.NET Core integration for [Markupolation](https://github.com/hlaueriksson/Markupolation).

### Installation

```
PM> Install-Package Markupolation.AspNetCore
```

### Minimal APIs

```cs
app.MapGet("/", () => Results.Extensions.Html(
    DOCTYPE() +
    html(body(h1("Hello, World!")))
));
```

Or typed, so the endpoint's return type stays concrete:

```cs
app.MapGet("/", () => HtmlResults.Ok(html(body(h1("Hello, World!")))));
app.MapGet("/missing", () => HtmlResults.NotFound(html(body(h1("Not found")))));
```

`Content-Type` is `text/html; charset=utf-8`, and `Content-Length` is set, so the response is not
chunked. The body is UTF-8 encoded straight into the response's `PipeWriter`.

### MVC

`HtmlResult` is also an `IActionResult`:

```cs
public IActionResult Index() => new HtmlResult(html(body(h1("Hello, World!"))));
```

### Razor

```cshtml
@content.ToHtmlContent()
```

Markupolation has already encoded the content, so this stops Razor encoding it a second time.

### htmx

```cs
app.MapGet("/counter/{count}", (HttpRequest request, int count) =>
    Results.Extensions.Html(request.IsHtmx()
        ? mark(count)
        : html(body(mark(count)))));
```

Request: `IsHtmx()`, `IsHtmxBoosted()`, `IsHtmxHistoryRestore()`, `HtmxTarget()`, `HtmxTrigger()`,
`HtmxTriggerName()`, `HtmxCurrentUrl()`, `HtmxPrompt()`.

Response: `HxTrigger()`, `HxTriggerAfterSettle()`, `HxTriggerAfterSwap()`, `HxRetarget()`,
`HxReswap()`, `HxReselect()`, `HxPushUrl()`, `HxPreventPushUrl()`, `HxReplaceUrl()`,
`HxPreventReplaceUrl()`, `HxRedirect()`, `HxLocation()`, `HxRefresh()`.

`HX-Push-Url` and `HX-Replace-Url` read a url or `false`, and nothing else — unlike the
`hx-push-url` attribute, there is no `true`, and htmx treats anything that is not the literal
`false` as the url. `HxPreventPushUrl()` and `HxPreventReplaceUrl()` set that `false`:

```cs
response.HxPushUrl("/page/2");   // HX-Push-Url: /page/2
response.HxPreventPushUrl();     // HX-Push-Url: false
```

### A note on encoding

These methods take `Content`, so an element or `DOCTYPE() + html(...)` fits directly. Encoding has
already happened inside the elements, and the result writes what they produced without a second
pass. A `string` that already holds rendered markup goes in through `Content.Raw(s)` — anything
else is text, and is encoded.

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
