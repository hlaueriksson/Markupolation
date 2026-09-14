# Migrating to Markupolation 3.0

Three breaking changes: text is encoded by default, rendering markup to a `string` is now explicit,
and the packages target `netstandard2.1` instead of `netstandard2.0`.

## Text is encoded

A `string` that becomes `Content` now has its `&`, `<`, `>` and `"` encoded, and so does every
attribute value. Content that a user supplies can no longer break out of the markup around it:

```cs
var name = "<script>alert('xss')</script>";

div(name)
// 2.x  <div><script>alert('xss')</script></div>
// 3.0  <div>&lt;script&gt;alert('xss')&lt;/script&gt;</div>

a(href("/search?q=\" onmouseover=\"alert(1)"))
// 2.x  <a href="/search?q=" onmouseover="alert(1)"></a>     <-- broke out of the attribute
// 3.0  <a href="/search?q=&quot; onmouseover=&quot;alert(1)"></a>
```

Elements and attributes are already markup and are never re-encoded, so composing them is
unchanged. Ordinary prose is unchanged — encoding only touches those four characters, and returns
the original string when none are present.

### Interpolation still works

`Content` is an interpolated string handler, so the compiler hands it the pieces of an
interpolated string separately. The literal parts are written by you and stay raw; an element or
attribute in a hole is already markup and stays raw; every other hole is encoded:

```cs
div($"<i>{name}</i>")            // <div><i>&lt;script&gt;</i></div>
div($"see {b("bold")} here")     // <div>see <b>bold</b> here</div>
p($"Read the {b($"HTML {i("Living")}")} Standard")   // unchanged from 2.x
items.Each(x => li($"<b>{x}</b>"))                   // literal <b> raw, x encoded
```

### The case that changes silently

Build markup into a `string` first and the library can no longer tell which parts you wrote:

```cs
var markup = $"<i>{name}</i>";
div(markup)                  // encodes the <i> too
div(Content.Raw(markup))     // opt out
```

An HTML **comment** is the same case, and an easy one to miss — it looks like text but is markup:

```cs
body("<!-- content here -->")     // shows up on the page as literal text
body(comment("content here"))     // a comment
```

`comment` is the one to reach for rather than `raw`, because encoding cannot make comment text safe:
character references are not decoded inside a comment, so an escaped `-->` would still end it early.
`comment` breaks up the forbidden sequences instead, so it is safe for text you did not write.

A **character reference** is the third of these, and the most common one in an existing template:
`&` is encoded, so `&nbsp;` arrives on the page as the literal text `&nbsp;`.

```cs
div("&nbsp;")
// 2.x  a non-breaking space
// 3.0  &amp;nbsp;   <-- reads as "&nbsp;" on the page
```

Write the character instead. Encoding only touches `&`, `<`, `>` and `"`, so `—`, `©` and `×` pass
through untouched, and a non-breaking space is `"\u00a0"`. `raw("&nbsp;")` also works, but keep it
for text you wrote yourself.

### Opting out

| | |
|---|---|
| `raw(s)` | the string is already markup — use as is |
| `Content.Raw(s)` | the same thing, qualified — `raw` is just the unqualified spelling |
| `new Content(s)` | raw, like `Raw` — this is how `Element` wraps markup verbatim |
| `new Element(s)`, `new Attribute(n, v)` | the escape hatches stay raw |

A quick way to find what needs attention: search for string variables passed into element or
attribute calls. Anything that is prose, a name, a URL or a number needs no change. Anything that
is *markup you assembled yourself* needs `Content.Raw`.

## Markup to `string` is explicit

`Content`, `Element` and `Attribute` no longer convert to `string` implicitly. The conversion is
still there, it just has to be asked for — `(string)content`, or `content.ToString()`:

```cs
string s = div("x");            // 2.x  fine
                                // 3.0  CS0266
string s = div("x").ToString(); // 3.0
```

This is what makes the rest of the encoding model hold together. Markup that slips into a `string`
is indistinguishable from text, and is encoded the next time it reaches an element. Removing the
implicit conversion means that can no longer happen by accident — and it fixes two traps outright.

### `element + element` composes siblings

`Content` now declares `operator +`. Several siblings without a wrapper element is what you would
write anyway, and it now means what it looks like:

```cs
Content Card(Item x) => h3(x.Title) + p(x.Body);

div(class_("cards"), items.Each(Card))
// 2.x  <div class="cards">&lt;h3&gt;T1&lt;/h3&gt;…      <-- the + produced a string, then encoded
// 3.0  <div class="cards"><h3>T1</h3><p>B1</p>…
```

The result is `Content`, and each side keeps its own rule: an element stays markup, a `string` is
text and is encoded. `Content.Raw` is the opt-out, as everywhere else.

```cs
"<b>" + p("x")              // &lt;b&gt;<p>x</p>
Content.Raw("<b>") + p("x") // <b><p>x</p>
```

`DOCTYPE()` returns `Content` rather than `string` for this reason, so `DOCTYPE() + html(...)` still
composes as markup. If you assigned it to a `string`, add `.ToString()`. It has also **moved from
`Elements` to `Contents`** — it is a document type declaration, not an element. Unqualified
`DOCTYPE()` is unaffected as long as you have the standard using directives; only
`Elements.DOCTYPE()` or `e.DOCTYPE()` need changing.

**Accumulating in a `string` no longer compiles**, which is deliberate — it used to re-encode
everything it had already collected on each pass. Accumulate in a `Content`:

```cs
var html = "";                      // 2.x
foreach (var i in items) html += li(i);

Content html = Content.Empty;    // 3.0
foreach (var i in items) html += li(i);
```

### A ternary mixing an element with text now works

A conditional used to take `string` as its natural type as soon as one branch was a string, because
`Element` converted to `string` and not the reverse — the element was rendered and then encoded as
text, silently. With no implicit conversion the branches have no common type, so the conditional is
target-typed to `Content` and each branch converts on its own:

```cs
numbers.Each(i => li(Fizz(i) ? strong("Fizz") : i.ToString()))
// 2.x  <li>&lt;strong&gt;Fizz&lt;/strong&gt;</li>
// 3.0  <li><strong>Fizz</strong></li>
```

The `If*` / `IfMatch` family takes `Content` parameters and always behaved this way. It is still
worth preferring inside a template, for how it reads rather than for correctness:

```cs
numbers.Each(i => li(Fizz(i).If(strong("Fizz"), "not fizz")))
```

### Passing a document to something that wants a `string`

`Markupolation.AspNetCore` takes `Content` now, so `Results.Extensions.Html(...)`, `HtmlResults` and
`HtmlResult` all take the document directly. For any other API that wants a `string` — a
`ContentResult`, Blazor's `MarkupString` — add `.ToString()`. Going the other way, a `string` that
already holds rendered markup becomes `Content` through `Content.Raw(s)`.

## netstandard2.1

`netstandard2.0` is gone, so **.NET Framework is no longer supported**. The packages target
`netstandard2.1` and `net10.0`. `netstandard2.1` is what makes `Span<T>` and `string.Create`
available; `net10.0` additionally gets `SearchValues` for the encoder and is AOT-compatible.

Consumers on .NET Core 3.0+, .NET 5+, Mono 6.4+, Xamarin and Unity 2021.2+ are unaffected.

## Also new

- New tool **`Markupolation.Cli`**: `dotnet tool install --global Markupolation.Cli`, then
  `markupolation convert index.html` to turn existing HTML into Markupolation source.
- New package **`Markupolation.Htmx`**: the htmx attributes as `hx_get`, `hx_target`, `hx_swap` and
  the rest, imported as `hx`.
- New package **`Markupolation.AspNetCore`**: `Results.Extensions.Html(...)`, `HtmlResults`, `HtmlResult`
  (usable as both `IResult` and `IActionResult`), `ToHtmlContent()` for Razor, and htmx request and
  response headers.
- Value types convert to `Content` implicitly: every numeric type, `char`, `bool`, `DateTime`, `DateTimeOffset`, `TimeSpan`, `Guid` and any `enum`.
- `Content` supports `+`, so siblings compose without a wrapper element, and `+=` accumulates.
- New `Contents` static class, imported like `Elements` and `Attributes`, holding the markup that is
  neither an element nor an attribute: `DOCTYPE()`, `comment(s)`, and `raw(s)`, the unqualified
  spelling of `Content.Raw(s)`. Add `<Using Include="Markupolation.Contents" Static="True" />` if you list the
  using directives yourself instead of enabling `ImplicitUsings`.
- `Markupolation.Extensions` gained `If` on `bool`, and a lazy `Func<Content>` form of every
  conditional so an unused branch is not built. See the README.

## Not changed

Rendering output for well-formed markup is byte for byte what 2.1 produced — the test suite and a
4 KB document exercising the whole API surface confirm it. Performance is unchanged apart from the
encoder's scan, which returns the input untouched when there is nothing to encode.
