# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Markupolation (Markup + String Interpolation) is a C# library for generating HTML with a fluent API of chainable static methods (`html(head(e.title("x")), body(h1("Hello")))`). The element/attribute API is *generated from the WHATWG HTML specification*, not hand-written.

Two NuGet packages ship from `src/`:

- `Markupolation` — elements, attributes, event handler content attributes
- `Markupolation.Extensions` — `Each`/`If*` extension methods for loops and conditionals in templates

## Commands

```powershell
dotnet build                                   # build the solution (Markupolation.slnx)
dotnet test tests/Markupolation.Tests          # run the unit tests (test.bat does the same)
dotnet test tests/Markupolation.Tests --filter "FullyQualifiedName~ElementsTests.VoidElement"   # a single test
pack.bat                                       # dotnet build -c Release /p:TF_BUILD=true -> NuGet packages
nuget-local.bat                                # publish built packages into a local ./packages feed
dotnet run --project tests/Markupolation.Benchmark -c Release   # BenchmarkDotNet comparison vs Razor Slices, HtmlTags, HyperTextExpression
```

`GenerateTests` and `PlaygroundTests` are `[Explicit]` and are skipped by a normal test run.

## Architecture

### The string pipeline

Everything is a string under the hood; there is no DOM or tree.

- `Content` (record, `src/Markupolation/Content.cs`) wraps a `string?` with implicit conversions both ways. This is what makes `"text"`, `$"interpolated {x}"`, elements and attributes all mix freely in the same `params Content[]`.
- **Text is encoded** (`HtmlEncoder`, `& < > "`). Encoding happens at the boundary where a `string` becomes `Content` — the implicit conversion — and in `Attribute.ToString`. It never happens during element rendering, because children are already `Content`. `HtmlEncoder.Encode` returns the input instance when there is nothing to encode, which is the common case; keep that fast path.
- Everything that is *text* must go through `Content.FromText`, which stores the original and encodes lazily in `Value`. That is what gives raw text elements something to fall back to. Building a pre-encoded string and passing it to the raw constructor looks equivalent but is not: it leaves `Unencoded` null, so `script`/`style` would render the encoded form. `Content.Text` had that bug.
- The `Content(string?)` constructor, `Content.Raw`, `Element(string)` and `Attribute(string, string?)` are **raw** — they exist so the library and its users can wrap markup verbatim. `Content.Text` encodes explicitly.
- `Content` is also an `[InterpolatedStringHandler]`, which is what keeps interpolation working under encoding: `AppendLiteral` stays raw (author-written), a `Content` hole stays raw, everything else is encoded. The generic `AppendFormatted<T>` must keep its runtime `is Content` check — an `Element` hole binds there rather than to `AppendFormatted(Content)`, because an identity conversion beats an implicit reference conversion. `InterpolatedStringHandlerAttribute.cs` polyfills the attribute for `netstandard2.1`.
- `HtmlEncoder` is hand-rolled rather than `WebUtility.HtmlEncode` for one reason: `WebUtility` encodes Latin-1 non-ASCII as numeric references (`Göteborg` -> `G&#246;teborg`), which is bigger and unreadable in a UTF-8 document. It also encodes `'`, which is unnecessary here because attribute values are always double-quoted. Speed is a wash. `System.Web.HttpUtility` is not in `netstandard2.1`, and `System.Text.Encodings.Web` would be the package's only dependency.
- `& < > "` is the right set *because attribute values are always double-quoted* (`Attribute.ToString`). If that ever changes, `'` has to be added.
- `<script>` and `<style>` are raw text elements — the parser never decodes references inside them — so their content is rendered unencoded. This works because `Content` keeps the text it was built from (`Content.Unencoded`, `null` once the content is markup) and encodes it lazily in `Value`; `Element` renders `Unencoded` for those two elements and `Value` everywhere else. `ElementRawText.Get` is the generated lookup, emitted by `GenerateTests.ElementRawText` from a hardcoded set — the parsing spec (13.2.5) defines it, not the element index the other generators scrape. `<title>` and `<textarea>` are *escapable* raw text and must keep encoding. Attribute values on script/style are still encoded. Pinned by `EncodingTests`.
- Consequence worth knowing: script and style bodies are unencoded, so never build one from user data — an interpolation hole there is encoded (which breaks the script) and `Content.Raw` there is an injection risk. Serialise to JSON instead.
- No URL encoding, deliberately: the caller composes the URL, the library encodes it for placement. Encoding does not make `href("javascript:...")` safe.
- Two places encoding can surprise, both covered by `EncodingTests`. Markup assembled into a `string` before it reaches an element is encoded whole (`Content.Raw` opts out). And a conditional takes `string` as its natural type as soon as one branch is a string — because `Element` converts to `string` and not the reverse — so the element is rendered and then encoded as text, silently.
- The `If*` / `IfMatch` family does not have that problem, because the parameters are declared `Content`: each argument converts on its own, with no common type to infer. `cond.If(strong("Fizz"), "not fizz")` is correct where the equivalent ternary is not, so recommend `If` for conditionals that mix elements and text.
- Value types convert to `Content` directly so that `cond ? element : value` has no natural type and is target-typed to `Content`. The **numeric set must stay complete** (`sbyte byte short ushort int uint long ulong float double decimal char`): once `ulong` is declared, `int` and `ulong` are incomparable, so the smaller types no longer have a unique conversion to widen through and become `CS0457`. Omitting `char` renders `'a'` as `97`, and omitting `float` renders `0.1f` with `double` artefacts. The rest of the set is `string bool DateTime DateTimeOffset TimeSpan Guid Enum` — one `Enum` conversion covers every enum, by boxing. `DateOnly`/`TimeOnly`/`Half`/`Int128` are deliberately absent: they are not in `netstandard2.1` and would make the public API differ per target framework. Nullable value types do convert: the lookup uses the underlying type, so `int?` reaches `operator Content(int)`, and the compiler emits the `HasValue` check so a null yields null content instead of throwing. The conversions live in `Content.Conversions.cs`, a partial of the same record. This does not help when a branch is a `string`. Making the conversion to `string` explicit would fix the string case too, but it was tried and reverted — it breaks `string s = div("x")`, `element + element` and passing an element to a `string` parameter, which cost seven call sites in this repo against the one it protected. A Roslyn analyzer is the only approach that would fix it without that cost.
- Do **not** add `Content.operator +`. A user-defined `+` on an operand type removes the built-in string concatenation from the candidate set, so `DOCTYPE() + html(...)` would route through the encoding conversion and encode the doctype. This was tried and reverted.
- Anything in `ContentExtensions` that accumulates rendered markup must return `Content.Raw(...)`, not a `string`, or the implicit conversion encodes it a second time (this is what `Each` does).
- `Element` and `Attribute` are sealed records deriving from `Content`. Their constructors render the final string immediately (`Element.ToString(name, isVoidElement, content)`), so composition is plain string concatenation.
- `Element` separates its `params Content[]` into `Attribute`s (rendered inside the tag) and everything else (rendered as children) by runtime type. Void elements discard children.
- Name mangling is precomputed into generated lookup tables — `ElementNames.Get(type)` / `AttributeNames.Get(type)`, indexed by the enum value. Enum names are trimmed of a trailing `_` (keyword escape) and, for attributes, `_` becomes `-` (`http_equiv` → `http-equiv`). This happens at generation time, so no `Enum.ToString()` runs on the rendering path.
- `Attributes.data(name, value)` and the public `Element(string)` / `Attribute(string, string?)` constructors are the escape hatches for anything outside the spec (SVG, Open Graph, htmx).

### Code generation (important)

`src/Markupolation/Generated/*.cs` is ~4,300 lines of generated code. **Never hand-edit it** — regenerate instead.

The generator is `tests/Markupolation.Tests/GenerateTests.cs`: `[Explicit]` NUnit tests that scrape <https://html.spec.whatwg.org> with Playwright and write files back into `src/Markupolation/Generated/` via a relative path. It is a two-stage bootstrap, because stage 2 reflects over the enums produced by stage 1:

1. Build, then install Playwright: `pwsh tests/Markupolation.Tests/bin/Debug/net10.0/playwright.ps1 install`
2. Run `All_enums` → writes `ElementType.cs`, `AttributeType.cs`, `EventHandlerContentAttributeType.cs`. These enums carry all spec metadata (description, void-ness, boolean-ness, global-ness, related elements/attributes) as `[Element]`/`[Attribute]`/`[EventHandlerContentAttribute]` attributes.
3. **Compile** (so the new enum members exist).
4. Run `All_classes` → reflects over the enums to write `Elements.cs`, `Attributes.cs`, `EventHandlerContentAttributes.cs` (including XML doc comments) plus `ElementNames.cs` and `AttributeNames.cs` (the name lookup tables).
5. Run `All_markdown` → prints the `<details>` API tables to stdout; paste them into `README.md` (the Elements/Attributes/EventHandlerContentAttributes sections).

`NameExtensions.CleanName` is the single place that applies the naming convention: `-` → `_`, and a `_` suffix for C# keywords.

`Elements.cs` and `Attributes.cs` in `src/Markupolation/` (outside `Generated/`) are the hand-written `partial` halves — `DOCTYPE()` and `data(name, value)`.

### Naming convention consequences

- Method names are lowercase to mirror the spec — this trips analyzer CS8981, disabled via `.editorconfig` in `tests/` and `samples/`.
- Nine names exist as both element and attribute (`abbr`, `cite`, `data`, `form`, `label`, `slot`, `span`, `style`, `title`). The static-using import resolves them to the *attribute*; use the `e.` / `a.` aliases to disambiguate. `MethodConflictTests` asserts this list stays correct.
- Consumers get the aliases automatically: `src/Markupolation/buildTransitive/Markupolation.props` injects `<Using>` items (`e`, `a`, `E`, `A` + static usings) when `ImplicitUsings` is enabled.

## Conventions and constraints

- `src/` multi-targets `netstandard2.1;net10.0` and does **not** enable `ImplicitUsings` — explicit `using System.Linq;` etc. is required. `netstandard2.1` covers `Span<T>` and `string.Create`, so `Element` renders through one span path on every target with no `#if`. The `net10.0` target exists for exactly two things: `SearchValues<char>` in `HtmlEncoder` (measured at 2-4x the scan speed of `string.IndexOfAny(char[])`, worth roughly 15% on the `AdvancedUsage` benchmark) and `IsAotCompatible`. It is **not** needed for the interpolated string handler — that is our own type plus a polyfilled attribute, and works on `netstandard2.1`. Benchmarks and samples target `net10.0`; `tests/Markupolation.Tests` multi-targets `net8.0;net10.0` so the suite runs against **both** library builds (a `net8.0` consumer resolves the `netstandard2.1` asset).
- `Analyzers.props` (imported by both `src/` projects only) sets `TreatWarningsAsErrors`, `AnalysisMode=AllEnabledByDefault`, StyleCop + Roslynator, and `GenerateDocumentationFile`. Any new public member in `src/` needs full XML docs or the build fails. The generator emits these docs for generated code.
- `src/.editorconfig` turns off three CA rules that multi-targeting switched on and that conflict with the spec-mirroring API: CA1707 (underscored member names), CA1711 (the public type named `Attribute`) and CA2225 (implicit operators without named alternates). Do not "fix" the code to satisfy them.
- `CompatibilitySuppressions.xml` in each `src/` project records one deliberate break — PKV006, dropping `netstandard2.0`. Delete both files once `PackageValidationBaselineVersion` moves past the release that drops it; do not add suppressions to silence unintended breaks.
- The whole `ContentExtensions` family is null-tolerant: a null sequence, value or delegate yields empty content rather than throwing.
- Every conditional in `ContentExtensions` comes in two forms: an eager `Content` parameter and a lazy `Func<Content>` one, so an unused branch need not be built. Positions that already take a value-carrying delegate (`Func<T, Content>`) are lazy as they are and get no second overload. Keep both forms when adding a conditional. The one call shape this costs is a bare `null` in an eager position (`x.IfNull(null)`), which is now CS0121 and needs `(Content)null`.
- File-scoped namespaces are enforced (`csharp_style_namespace_declarations = file_scoped:warning` + warnings-as-errors in `src/`).
- Tests use NUnit + FluentAssertions (pinned to `[7.2.2]`), asserting on exact output strings; AngleSharp.Diffing is used where HTML-equivalence rather than string-equality matters.
- `src/Markupolation.AspNetCore` (net10.0 only) is the ASP.NET Core integration: `HtmlResult` (both `IResult` and `IActionResult`), `Results.Extensions.Html(...)`, `HtmlResults`, `ToHtmlContent()` for Razor, and the htmx request/response headers. Its API takes a **`string`**, not `Content`: the two are implicitly convertible in both directions, so overloading on both is ambiguous (`CS0121`), and at the response boundary a document is markup — `DOCTYPE() + html(...)` is already a `string`. Encoding has happened inside the elements by then.
- `tests/Markupolation.Tests` excludes `AspNetCore/**` on the `net8.0` leg, because that package is net10.0 only.
- `samples/Markupolation.Sample.Api` is the **exception**: it uses `ProjectReference` so it can consume the unpublished `Markupolation.AspNetCore`, and therefore declares the `<Using>` items itself — `buildTransitive` props only apply to package references. Switch it back to `PackageReference` once 3.0.0 ships.
- `samples/` and `tests/Markupolation.Benchmark` reference the **published NuGet packages** (`Version="2.1.0"`), not the local projects — local `src/` changes do not flow into them until a release or a local feed (`nuget-local.bat`) is used. The benchmark swaps in a `ProjectReference` when the `MarkupolationLocal` environment variable is `true` (an env var, not `-p:`, because BenchmarkDotNet builds a generated project in a child process).
- CI (`.github/workflows/build.yml`) restores, builds and runs only `tests/Markupolation.Tests`.
