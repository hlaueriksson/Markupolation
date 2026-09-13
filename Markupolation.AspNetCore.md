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

Request: `IsHtmx()`, `IsHtmxHistoryRestore()`, `HtmxTarget()`, `HtmxTrigger()`.

Response: `HxTrigger()`, `HxRetarget()`, `HxReswap()`, `HxReselect()`, `HxPushUrl()`,
`HxReplaceUrl()`, `HxRedirect()`, `HxRefresh()`.

### A note on encoding

These methods take `Content`, so an element or `DOCTYPE() + html(...)` fits directly. Encoding has
already happened inside the elements, and the result writes what they produced without a second
pass. A `string` that already holds rendered markup goes in through `Content.Raw(s)` — anything
else is text, and is encoded.

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
