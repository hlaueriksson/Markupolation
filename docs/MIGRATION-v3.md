# Migrating to Markupolation 3.0

Two breaking changes: text is encoded by default, and the packages target `netstandard2.1`
instead of `netstandard2.0`.

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
unchanged. `DOCTYPE() + html(...)` is unchanged. Ordinary prose is unchanged — encoding only
touches those four characters, and returns the original string when none are present.

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

### Opting out

| | |
|---|---|
| `Content.Raw(s)` | the string is already markup — use as is |
| `Content.Text(s)` | encode explicitly; the same as converting a string to `Content` |
| `new Content(s)` | raw, like `Raw` — this is how `Element` wraps markup verbatim |
| `new Element(s)`, `new Attribute(n, v)` | the escape hatches stay raw |

A quick way to find what needs attention: search for string variables passed into element or
attribute calls. Anything that is prose, a name, a URL or a number needs no change. Anything that
is *markup you assembled yourself* needs `Content.Raw`.

### The other case: a conditional mixing an element with text

A conditional takes `string` as its natural type as soon as one branch is a string, because
`Element` converts to `string` and not the reverse. The element is rendered and then encoded as
text — and nothing warns about it:

```cs
numbers.Each(i => li(Fizz(i) ? strong("Fizz") : i.ToString()))
// <li>&lt;strong&gt;Fizz&lt;/strong&gt;</li>
```

**Use `If` instead of a ternary.** It takes `Content` parameters, so each branch converts on its
own and there is no common type to infer — the element stays markup and the text is encoded:

```cs
numbers.Each(i => li(Fizz(i).If(strong("Fizz"), "not fizz")))
// <li>not fizz</li><li><strong>Fizz</strong></li>
```

The same holds for the whole `If*` / `IfMatch` family, which all take `Content` or
`Func<T, Content>`. This is the recommended shape for any conditional that mixes elements and text.

If you would rather keep the ternary, either branch being `Content` is enough. `int`, `long`,
`double`, `decimal` and `DateTime` now convert to `Content` directly, so with a numeric branch
dropping the `ToString()` is the whole fix:

```cs
numbers.Each(i => li(Fizz(i) ? strong("Fizz") : i))       // <li><strong>Fizz</strong></li>
numbers.Each(i => li(Fizz(i) ? strong("Fizz") : text))    // still collapses to string
```

For anything else, cast the text branch: `(Content)value`.

## netstandard2.1

`netstandard2.0` is gone, so **.NET Framework is no longer supported**. The packages target
`netstandard2.1` and `net10.0`. `netstandard2.1` is what makes `Span<T>` and `string.Create`
available; `net10.0` additionally gets `SearchValues` for the encoder and is AOT-compatible.

Consumers on .NET Core 3.0+, .NET 5+, Mono 6.4+, Xamarin and Unity 2021.2+ are unaffected.

## Also new

- Value types convert to `Content` implicitly: every numeric type, `char`, `bool`, `DateTime`, `DateTimeOffset`, `TimeSpan`, `Guid` and any `enum`.
- `Markupolation.Extensions` gained `If` on `bool`, and a lazy `Func<Content>` form of every
  conditional so an unused branch is not built. See the README.

## Not changed

Rendering output for well-formed markup is byte for byte what 2.1 produced — the test suite and a
4 KB document exercising the whole API surface confirm it. Performance is unchanged apart from the
encoder's scan, which returns the input untouched when there is nothing to encode.
