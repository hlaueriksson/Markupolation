# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Markupolation (Markup + String Interpolation) is a C# library for generating HTML with a fluent API of
chainable static methods (`html(head(e.title("x")), body(h1("Hello")))`). The element/attribute API is
*generated from the WHATWG HTML specification*, not hand-written.

Six packages ship from `src/`:

- `Markupolation` — elements, attributes, event handler content attributes
- `Markupolation.Extensions` — `Each` / `If*` extension methods for loops and conditionals
- `Markupolation.AspNetCore` — `HtmlResult`, `Results.Extensions.Html(...)`, htmx request/response headers
- `Markupolation.Htmx` — hand-written htmx attributes
- `Markupolation.Converter` — HTML back into Markupolation source
- `Markupolation.Cli` — the `markupolation convert` dotnet tool over the converter

## Commands

```powershell
dotnet build                                   # whole solution (Markupolation.slnx)
dotnet test tests/Markupolation.Tests          # the unit tests (test.bat does the same)
dotnet test tests/Markupolation.Tests --filter "FullyQualifiedName~ElementsTests.VoidElement"   # a single test
coverage.bat                                   # test with coverage -> HTML + text summary report
pack.bat                                       # dotnet build -c Release /p:TF_BUILD=true -> NuGet packages
nuget-local.bat                                # publish built packages into a local ./packages feed
dotnet run --project tests/Markupolation.Benchmark -c Release   # vs Razor Slices, HtmlTags, HyperTextExpression
```

`GenerateTests` and `PlaygroundTests` are `[Explicit]` and are skipped by a normal test run. CI
(`.github/workflows/build.yml`) restores, builds and runs only `tests/Markupolation.Tests`.

## Architecture

### The string pipeline

Everything is a string under the hood; there is no DOM or tree. The *why* behind each rule below is
written up in the XML doc remarks on the types themselves — read `Content.cs`, `Content.Operators.cs`,
`Content.Conversions.cs`, `Contents.cs`, `Attribute.cs` and `ValueFormatter.cs` before changing them.

- `Content` (record, split across `Content*.cs` partials) wraps a `string?` and is in one of three
  states: **markup** (raw constructor, `Raw`, `Element`, `Attribute`), **text** (every implicit
  conversion, encoded lazily in `Value`) or **interpolated** (a `StringBuilder` filled by the
  interpolated string handler). It never changes after construction.
- `string` converts to `Content` implicitly (as text, encoded); the way back out is **explicit**
  (`(string)content` / `ToString()`). That asymmetry is the invariant the design rests on: markup never
  becomes a `string` by accident, so it can never be re-encoded by accident.
- **Text is encoded** — `& < > "`, by the hand-rolled `HtmlEncoder`. `'` is absent because attribute
  values are always double-quoted; if that changes, add it. `Encode` returns the input instance when
  there is nothing to encode — keep that fast path.
- Text must go through `Content.FromText` (private; every implicit conversion uses it), which keeps the
  original in `Unencoded` and encodes lazily. Encoding a string yourself and handing it to the raw
  constructor looks equivalent but leaves `Unencoded` null, and `script`/`style` then render the encoded
  form.
- `<script>` and `<style>` are raw text elements: `Element` renders `Unencoded` for them and `Value`
  everywhere else, via the generated `ElementRawText.Get`. `<title>` and `<textarea>` are *escapable* raw
  text and keep encoding. Attribute values on script/style are still encoded. Pinned by `EncodingTests`.
- `Contents` is the hand-written markup that is neither element nor attribute: `DOCTYPE()`,
  `comment(string?)`, `raw(string?)`. It is imported by a static using next to `Elements` and
  `Attributes`, so its members arrive unqualified and can collide with a generated name — see
  *Adding to `Contents`* below.
- `Element` and `Attribute` are sealed records deriving from `Content`. Their constructors render the
  final string immediately (`Element` computes the exact length and writes one span — `Length` must skip
  exactly what `Write` skips), so composition is plain string concatenation. `Element` separates its
  `params Content[]` into `Attribute`s (inside the tag) and everything else (children) by runtime type;
  void elements discard children.
- **Attribute arity carries bare-vs-omitted.** `internal Attribute(AttributeType)` always renders bare
  (`required()`, `hidden()`); `internal Attribute(AttributeType, string?)` omits the attribute entirely
  when the value is null, so `href(null)` renders nothing and `progress(value(null))` is indeterminate
  rather than zero. The name-based public paths have no metadata to consult and keep the old
  null-is-bare meaning: `new Attribute("href")` and `data("foo", null)` render bare.
- `Content.operator +` writes siblings without a wrapper (`h1("a") + p("b")`). It concatenates each
  side's rendered `Value`, so every operand keeps its own rule. Do **not** add
  `operator +(Content, string)` overloads — they would make a `string` operand raw and reopen
  `userName + b("x")` as an injection. Accumulate into a `Content`, never a `string`.
- `Content.Empty` is the shared "renders nothing" instance and what every untaken `ContentExtensions`
  branch returns; `data` keeps a private empty `Attribute` of its own for a name that sanitises to
  nothing. Use `Content.Empty` as a `+=` seed.
- Anything that accumulates rendered markup must return `Content.Raw(...)`, not a `string`, or the
  implicit conversion encodes it a second time (this is what `Each` does).
- The implicit conversions in `Content.Conversions.cs` cover
  `sbyte byte short ushort int uint long ulong float double decimal char string bool DateTime
  DateTimeOffset TimeSpan Guid Enum`. The **numeric set must stay complete**: once `ulong` is declared
  the smaller types have no unique conversion to widen through and become `CS0457`; without `char`,
  `'a'` renders as `97`; without `float`, `0.1f` renders with `double` artefacts. `DateOnly`/`TimeOnly`/
  `Half`/`Int128` are deliberately absent — not in `netstandard2.1`, and the public API must not differ
  per target framework. Nullable value types work through the underlying type.
- `ValueFormatter` is the single definition of how a *value* renders, the way `NameExtensions.CleanName`
  is for names. Three paths reach it and must agree — the implicit conversions, the interpolated string
  handler, and the generated `object` overloads — because `div(true)`, `div((Content)true)` and
  `div($"{true}")` are the same thing to whoever writes them. Everything is `InvariantCulture`; `bool` is
  lowercase; dates are ISO 8601. An explicit format in a hole (`$"{price:N2}"`) wins.
- `AppendFormatted<T>` must keep its runtime `is Content` check: an `Element` hole binds there rather
  than to `AppendFormatted(Content)`, because an identity conversion beats an implicit reference
  conversion. `InterpolatedStringHandlerAttribute.cs` polyfills the attribute for `netstandard2.1`.
- `Attributes.data(name, value)` and the public `Element(string)` / `Attribute(string, string?)`
  constructors are the escape hatches for anything outside the spec (SVG, Open Graph, htmx). `data`
  sanitises its *name*: a name is never quoted, so encoding cannot save it — the characters that end a
  name in the tokenizer become `-`, the separator a `data-*` name is spelled with, so
  `data("foo bar", "x")` is `data-foo-bar="x"` and reaches JavaScript as `dataset.fooBar`. One
  argument is the *spec* attribute instead, and is not sanitised: `data("foo bar")` is
  `data="foo bar"`. A run collapses to one `-` and a run at either end is dropped; a `-` the caller
  wrote is never touched. A name that is nothing but those characters sanitises to nothing, so
  `data` tests the name *after* replacing rather than before — the public
  `Attribute(string, string?)` constructor stays raw and sanitises nothing.
- The whole library is null tolerant rather than throwing: a null name, value, sequence or delegate
  yields empty content.

### Code generation (important)

`src/Markupolation/Generated/*.cs` is ~4,300 lines of generated code. **Never hand-edit it** — regenerate.

The generator is `tests/Markupolation.Tests/GenerateTests.cs`: `[Explicit]` NUnit tests that scrape
<https://html.spec.whatwg.org> with Playwright and write back into `src/Markupolation/Generated/` via a
relative path. It is a two-stage bootstrap, because stage 2 reflects over the enums stage 1 produced:

1. Build, then install Playwright: `pwsh tests/Markupolation.Tests/bin/Debug/net10.0/playwright.ps1 install`
2. Run `All_enums` → `ElementType.cs`, `AttributeType.cs`, `EventHandlerContentAttributeType.cs`. These
   enums carry all spec metadata as `[Element]` / `[Attribute]` / `[EventHandlerContentAttribute]`.
3. **Compile** (so the new enum members exist).
4. Run `All_classes` → `Elements.cs`, `Attributes.cs`, `EventHandlerContentAttributes.cs` (with XML docs),
   plus the `ElementNames` / `AttributeNames` / `ElementRawText` lookup tables.
5. `dotnet format analyzers --diagnostics RS0016 --severity info` to update the PublicAPI files.
6. Run `All_markdown` → prints the `<details>` API tables; paste them into `README.md`.

Details worth knowing:

- Every metadata flag is a **named argument emitted only when true**
  (`[Attribute("...", ElementType.iframe, IsBooleanAttribute = true)]`), which is why the flags follow
  the `params` array of related elements. Do not move one back to a positional `bool`.
- Two flags produce the no-argument spelling. `IsBooleanAttribute` is the specification's boolean
  attribute — present means true, so the generator emits **only** `disabled()`. `IsEmptyStringValid`
  means the index's Value column lists *"the empty string"* (`autocorrect`, `contenteditable`,
  `crossorigin`, `hidden`, `popover`, `preload`, `spellcheck`, `translate`, `writingsuggestions`); those
  get the no-argument overload **in addition** to the value ones, because `hidden("until-found")` is a
  real state a boolean attribute could not express. `lang` also lists the empty string and is excluded in
  the scraper on purpose — `lang=""` asserts *unknown language*, so `lang()` would read as nonsense.
- Name mangling is precomputed into the generated lookup tables, so no `Enum.ToString()` runs while
  rendering. `NameExtensions.CleanName` is the single definition of the convention (`-` → `_`, trailing
  `_` for a C# keyword) and is shared by the generator, the converter and the runtime.
- `src/Markupolation/Attributes.cs` (outside `Generated/`) is the hand-written `partial` half of a
  generated class — `data(name, value)` is an attribute and belongs there. `Elements` has no hand-written
  half: `DOCTYPE()` is not an element, so it lives in `Contents`.
- The converter reads the same generated metadata rather than restating the specification — the two
  enums for what exists, `IsVoidElement`, `IsBooleanAttribute`, and their intersection for the ambiguous
  names. It needs `InternalsVisibleTo`.

### Naming convention consequences

- Method names are lowercase to mirror the spec — this trips CS8981, disabled via `.editorconfig` in
  `tests/` and `samples/`.
- Nine names exist as both element and attribute (`abbr`, `cite`, `data`, `form`, `label`, `slot`,
  `span`, `style`, `title`). The static using resolves them to the *attribute*; `e.` / `a.` disambiguate.
  `MethodConflictTests` pins the list.
- Consumers get the aliases automatically: `src/Markupolation/buildTransitive/Markupolation.props`
  injects `<Using>` items (`e`, `a`, `E`, `A` + static usings) when `ImplicitUsings` is enabled.

### Adding to `Contents`

A new `Contents` member adds an unqualified name to every consumer's file scope and can collide with a
generated element or attribute exactly as the nine ambiguous names do.
`MethodConflictTests.Contents_does_not_collide_with_the_specification` pins the member list and asserts
no ordinal overlap with the three enums, so a spec addition fails the build instead of quietly changing
what an unqualified call binds to. Keep the lowercase spelling: the `_` suffix means "collided with a
**C# keyword**", and PascalCase `Raw` would duplicate `Content.Raw` and lose the inline reading.

Seven places list the imports by hand and all need updating: `buildTransitive/Markupolation.props`,
`tests/Markupolation.Tests`, the three samples that render markup (`Sample.Api`, `Sample.Examples`,
`Sample.Functions`), `tests/Markupolation.Benchmark` (**conditioned on `MarkupolationLocal`** — the
2.1.0 package it otherwise references has no `Contents`), and `HtmlConverterTests.Usings`, the list the
round-trip test compiles emitted source against.

## Conventions and constraints

- `src/` multi-targets `netstandard2.1;net10.0` and does **not** enable `ImplicitUsings` — explicit
  `using System.Linq;` etc. `netstandard2.1` covers `Span<T>` and `string.Create`, so `Element` renders
  through one span path on every target with no `#if`. The `net10.0` target exists for exactly two
  things: `SearchValues<char>` in `HtmlEncoder`/`Attributes` and `IsAotCompatible`. It is **not** needed
  for the interpolated string handler. `tests/Markupolation.Tests` multi-targets `net8.0;net10.0` so the
  suite runs against **both** library builds (a `net8.0` consumer resolves the `netstandard2.1` asset),
  and excludes `AspNetCore/**` and `Converter/**` on the `net8.0` leg because those packages are
  net10.0 only.
- `Analyzers.props` (imported by the `src/` projects only) sets `TreatWarningsAsErrors`,
  `AnalysisMode=AllEnabledByDefault`, `EnablePackageValidation`, StyleCop, Roslynator, Meziantou and
  the PublicApiAnalyzers; `GenerateDocumentationFile` is set per project. Any new public member in
  `src/` needs full XML docs **and** a line in `PublicAPI.Unshipped.txt`, or the build fails (RS0016
  — `dotnet format analyzers --diagnostics RS0016 --severity info` writes them). `Markupolation`
  keeps those files in per-TFM folders under `PublicAPI/`, because records get covariant `<Clone>$`
  return types on some runtimes; the other projects keep them in the project directory.
- `src/.editorconfig` turns off rules that conflict with the spec-mirroring API: CA1707 (underscored
  names), CA1711 (the public type named `Attribute`), CA2225 (implicit operators), SA1309 (`_field`) and
  CA1055 (`Uri` return types in the htmx package). Do not "fix" the code to satisfy them.
- `CompatibilitySuppressions.xml` in `Markupolation` and `Markupolation.Extensions` records one
  deliberate break — PKV006, dropping `netstandard2.0`. Delete both once
  `PackageValidationBaselineVersion` moves past the release that drops it; do not add suppressions to
  silence unintended breaks.
- Every conditional in `ContentExtensions` comes in two forms: an eager `Content` parameter and a lazy
  `Func<Content>` one. Positions that already take a value-carrying delegate (`Func<T, Content>`) are
  lazy as they are. Keep both forms when adding a conditional. The cost is that a bare `null` in an eager
  position is `CS0121` and needs `(Content)null`.
- File-scoped namespaces are enforced (`csharp_style_namespace_declarations = file_scoped:warning` +
  warnings-as-errors in `src/`).
- Tests use NUnit + FluentAssertions (pinned to `[7.2.2]`), asserting on exact output strings;
  AngleSharp.Diffing where HTML equivalence rather than string equality matters.
- `Markupolation.AspNetCore`'s API takes **`Content`**, not `string`: encoding has happened inside the
  elements by the time a document reaches the response boundary, and `DOCTYPE() + html(...)` is already
  `Content`. A caller holding rendered markup in a `string` passes `Content.Raw(s)`.
- `Markupolation.Htmx` is hand-written on purpose — the set is short and stable, and scraping htmx's docs
  would add a second fragile Playwright dependency. `hx_disable`, `hx_history_elt` and `hx_preserve`
  render bare; `hx_on(name, value)` prefixes `hx-on:`, so an htmx event needs a leading colon
  (`":after-request"` → `hx-on::after-request`). Response headers belong in `Markupolation.AspNetCore`,
  and are not the same shape as the attributes: `HX-Push-Url` and `HX-Replace-Url` read a url or `false`
  and have no `true`, so `HtmxResponseExtensions` spells the `false` as `HxPreventPushUrl()` /
  `HxPreventReplaceUrl()` instead of the `bool` overload `hx_push_url` / `hx_replace_url` have — htmx
  special-cases only the literal `false`, so `HxPushUrl(true)` would have pushed the url `/true`.
- The samples all use `ProjectReference` and declare their own `<Using>` items (`buildTransitive` props
  only apply to package references). `tests/Markupolation.Benchmark` is the one project still on the
  published 2.1.0 package; set the `MarkupolationLocal` **environment variable** (not `-p:`, which
  BenchmarkDotNet's child-process build does not inherit) to measure the working tree.

## Traps

- Giving an ambiguous name more arguments than its *attribute* takes silently reaches the **element**.
  `title("a", "b")` compiles and renders `<title>ab</title>`, because `Attributes.title` takes one
  argument and `Elements.title(params Content[])` takes any number. Nothing catches this. `data` is the
  one exception: `data("on", true)` is `CS0121` since `data(string, object)` exists — write
  `a.data("on", true)`.
- Script and style bodies are unencoded, so never build one from user data — an interpolation hole there
  is encoded (which breaks the script) and `Content.Raw` there is an injection risk. Serialise to JSON.
- Markup assembled into a `string` before it reaches an element is encoded whole; `Content.Raw` opts out.
- `comment()` neutralises rather than encodes, and that is why it exists: the parser does not decode
  character references inside a comment, so an encoded `--&gt;` would still end it early. It is safe for
  user text where `raw` is not.
- There is deliberately no `CDATA` helper. `<![CDATA[` is only honoured in foreign content; in HTML it
  becomes a bogus comment ending at the first `>`. Foreign content (SVG/MathML) is reached through
  `new E("<svg ...>")`, where the caller is writing raw markup anyway.
- No URL encoding, deliberately: the caller composes the URL, the library encodes it for placement.
  Encoding does not make `href("javascript:...")` safe.
