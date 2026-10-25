### Markupolation.AspNetCore.Htmx <📜>

[htmx](https://htmx.org) request and response headers for ASP.NET Core, from
[Markupolation](https://github.com/hlaueriksson/Markupolation).

### Installation

```
PM> Install-Package Markupolation.AspNetCore.Htmx
```

### Request headers

```cs
app.MapGet("/counter/{count}", (HttpRequest request, int count) =>
    Results.Extensions.Html(request.IsHtmx()
        ? mark(count)
        : html(body(mark(count)))));
```

`HttpRequestExtensions`: `IsHtmx()`, `IsHtmxBoosted()`, `IsHtmxHistoryRestore()`, `HtmxTarget()`,
`HtmxTrigger()`, `HtmxTriggerName()`, `HtmxCurrentUrl()`, `HtmxPrompt()`.

### Response headers

`HttpResponseExtensions`: `HxTrigger()`, `HxTriggerAfterSettle()`, `HxTriggerAfterSwap()`,
`HxRetarget()`, `HxReswap()`, `HxReselect()`, `HxPushUrl()`, `HxPreventPushUrl()`, `HxReplaceUrl()`,
`HxPreventReplaceUrl()`, `HxRedirect()`, `HxLocation()`, `HxRefresh()`.

`HX-Push-Url` and `HX-Replace-Url` read a url or `false`, and nothing else — unlike the
`hx-push-url` attribute, there is no `true`, and htmx treats anything that is not the literal
`false` as the url. `HxPreventPushUrl()` and `HxPreventReplaceUrl()` set that `false`:

```cs
response.HxPushUrl("/page/2");   // HX-Push-Url: /page/2
response.HxPreventPushUrl();     // HX-Push-Url: false
```

### Related packages

- [Markupolation.AspNetCore](https://www.nuget.org/packages/Markupolation.AspNetCore) for `Results.Extensions.Html(...)`
- [Markupolation.Htmx](https://www.nuget.org/packages/Markupolation.Htmx) for the `hx_*` attributes

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
