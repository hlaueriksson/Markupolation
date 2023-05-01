# Markupolation <📜><!-- omit in toc -->

[![build](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml)
[![CodeFactor](https://codefactor.io/repository/github/hlaueriksson/markupolation/badge)](https://codefactor.io/repository/github/hlaueriksson/markupolation)

[![Markupolation](https://img.shields.io/nuget/v/Markupolation.svg?label=Markupolation)](https://www.nuget.org/packages/Markupolation)
[![Markupolation.Extensions](https://img.shields.io/nuget/v/Markupolation.Extensions.svg?label=Markupolation.Extensions)](https://www.nuget.org/packages/Markupolation.Extensions)

> Markupolation = Markup + String Interpolation

## Content<!-- omit in toc -->

- [Installation](#installation)
- [Introduction](#introduction)
- [When should I use Markupolation?](#when-should-i-use-markupolation)
- [Markupolation](#markupolation)
- [Markupolation.Extensions](#markupolationextensions)
- [Using directives](#using-directives)
- [Performance](#performance)
- [Samples](#samples)

## Installation

Install via [NuGet](https://www.nuget.org/packages/Markupolation):

```
PM> Install-Package Markupolation
```

Enable `ImplicitUsings` in the `.csproj` file:

```xml
<PropertyGroup>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

## Introduction

📦 [`Markupolation`](https://www.nuget.org/packages/Markupolation) is a library for HTML templating in C# with a fluent API.

An expression like this:

```cs
DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")))
```

generates the following result:

```html
<!DOCTYPE html><html><head><title>Markupolation</title></head><body><h1>Hello, World!</h1></body></html>
```

📦 [`Markupolation.Extensions`](https://www.nuget.org/packages/Markupolation.Extensions) adds extension methods to control flow.

Expressions like these:

```cs
var links = new[] { new { Url = "#", Title = "Foo", Active = true }, new { Url = "#", Title = "Bar", Active = false } };
links.Each((x, index) => a(href(x.Url), id($"link{index}"), x.IfMatch(x => x.Active, x => class_("active")), x.Title));
```

generates the following result:

```html
<a href="#" id="link0" class="active">Foo</a><a href="#" id="link1">Bar</a>
```

## When should I use Markupolation?

In some situations, you don't have access or don't want to use a template/view engine like [Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-6.0).

Maybe you are building

- a _Minimal API_, or
- _Azure Functions_

to deliver

- **`HTML` Over The Wire**
- instead of ~~`JSON`~~

to

- a _Blazor WebAssembly_ app, or
- an _Azure Static Web App_ site with `Hotwire` or `HTMX`?

In cases like these, `Markupolation` could be a good fit to generate HTML for you.

### Hotwire (`HTML` Over The Wire)?<!-- omit in toc -->

> Hotwire is an alternative approach to building modern web applications without using much JavaScript by sending HTML instead of JSON over the wire. This makes for fast first-load pages, keeps template rendering on the server, and allows for a simpler, more productive development experience in any programming language, without sacrificing any of the speed or responsiveness associated with a traditional single-page application.
>
> -- <cite>[hotwired.dev](https://hotwired.dev/)</cite>

### HTMX?<!-- omit in toc -->

> htmx is a library that allows you to access modern browser features directly from HTML, rather than using javascript.
>
> Note that when you are using htmx, on the server side you typically respond with HTML, not JSON.
>
> htmx expects responses to the AJAX requests it makes to be HTML, typically HTML fragments.
> 
> htmx will then swap the returned HTML into the document at the target specified and with the swap strategy specified.
>
> -- <cite>[htmx.org](https://htmx.org/)</cite>

## Markupolation

Interpolate strings with HTML elements and attributes:

```cs
$@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        e.title("Markupolation"),
        meta(name("description"), content("Sample of how to use Markupolation")),
        meta(name("viewport"), content("width=device-width, initial-scale=1"))
    ),
    body(
        h1("Hello, World!"),
        p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
    )
)}";
```

Result (formatted):

```html
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <title>Markupolation</title>
  <meta name="description" content="Sample of how to use Markupolation" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>

<body>
  <h1>Hello, World!</h1>
  <p>This is <mark title="Markup with string interpolation">Markupolation</mark> in action.</p>
</body>

</html>
```

ℹ️ The names of
[element](https://github.com/hlaueriksson/Markupolation/blob/main/src/Markupolation/Generated/Elements.cs),
[attribute](https://github.com/hlaueriksson/Markupolation/blob/main/src/Markupolation/Generated/Attributes.cs) and
[event handler content attribute](https://github.com/hlaueriksson/Markupolation/blob/main/src/Markupolation/Generated/EventHandlerContentAttributes.cs)
methods are in _lowercase_ to reflect the [HTML specification](https://html.spec.whatwg.org/).

ℹ️ Names that conflict with the [C# keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/) are suffixed with a `_`.

Elements:

- `base_`
- `object_`

Attributes:

- `as_`
- `checked_`
- `class_`
- `default_`
- `for_`
- `is_`
- `readonly_`

ℹ️ Attributes that contain hyphen (`-`) are converted to [snake_case](https://en.wikipedia.org/wiki/Snake_case):

- `accept_charset`
- `http_equiv`

⚠️ Nine methods are _ambiguous_ and are defined for both elements and attributes:

- `abbr`
- `cite`
- `data`
- `form`
- `label`
- `slot`
- `span`
- `style`
- `title`

Use the predefined aliases as shorthands for the methods:

- `e.title("Title element")`
- `a.title("Title attribute")`

ℹ️ Custom elements that are not available in the API can be created with the `Element` class:

```cs
new Element("""
  <svg width="100" height="100">
    <circle cx="50" cy="50" r="40" fill="blue" />
  </svg>
""")
```

Or via the `E` alias:

```cs
new E("""
  <svg width="100" height="100">
    <circle cx="50" cy="50" r="40" fill="blue" />
  </svg>
""")
```

ℹ️ Custom attributes that are not available in the API can be created with the `Attribute` class:

```cs
new Attribute("property", "og:title")
```

Or via the `A` alias:

```cs
new A("property", "og:title")
```

## Markupolation.Extensions

📦 Available via NuGet as a separate package: [`Markupolation.Extensions`](https://www.nuget.org/packages/Markupolation.Extensions)

Use lambda expressions to control flow:

```cs
Func<int, bool> fizz = (int i) => i % 3 == 0;
Func<int, bool> buzz = (int i) => i % 5 == 0;
var numbers = Enumerable.Range(1, 15);
$@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        e.title("Markupolation.Extensions"),
        meta(name("description"), content("Sample of how to use Markupolation.Extensions")),
        meta(name("viewport"), content("width=device-width, initial-scale=1"))
    ),
    body(
        ul(
            numbers.Each(x => li(
                x.IfMatch(i => fizz(i) && buzz(i), i => strong("FizzBuzz")),
                x.IfMatch(i => fizz(i) && !buzz(i), i => em("Fizz")),
                x.IfMatch(i => !fizz(i) && buzz(i), i => em("Buzz")),
                x.IfMatch(i => !fizz(i) && !buzz(i), i => i.ToString())
            ))
        )
    )
)}";
```

Result (formatted):

```html
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <title>Markupolation.Extensions</title>
  <meta name="description" content="Sample of how to use Markupolation.Extensions" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>

<body>
  <ul>
    <li>1</li>
    <li>2</li>
    <li><em>Fizz</em></li>
    <li>4</li>
    <li><em>Buzz</em></li>
    <li><em>Fizz</em></li>
    <li>7</li>
    <li>8</li>
    <li><em>Fizz</em></li>
    <li><em>Buzz</em></li>
    <li>11</li>
    <li><em>Fizz</em></li>
    <li>13</li>
    <li>14</li>
    <li><strong>FizzBuzz</strong></li>
  </ul>
</body>

</html>
```

Looping on `IEnumerable<T>`:

- `Each<T>`

Conditionals on `IEnumerable<T>`:

- `IfEmpty<T>`
- `IfNotEmpty<T>`

Conditionals on `T`:

- `IfNull<T>`
- `IfNotNull<T>`
- `IfMatch<T>`

Conditionals on `string`:

- `IfNullOrEmpty`
- `IfNotNullOrEmpty`

Conditionals on `T?`:

- `IfHasValue<T>`

## Using directives

When `ImplicitUsings` are enabled:

```xml
<PropertyGroup>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

These using directives are applied automatically:

```xml
<ItemGroup>
  <Using Include="Markupolation" />
  <Using Include="Markupolation.Elements" Static="True" />
  <Using Include="Markupolation.Elements" Alias="e" />
  <Using Include="Markupolation.Element" Alias="E" />
  <Using Include="Markupolation.Attributes" Static="True" />
  <Using Include="Markupolation.Attributes" Alias="a" />
  <Using Include="Markupolation.Attribute" Alias="A" />
  <Using Include="Markupolation.EventHandlerContentAttributes" Static="True" />
</ItemGroup>
```

If you do not want to enable `ImplicitUsings` in your project, you can copy and paste the above into your `.csproj` file.

Alternatively you can add the following using directives in a `.cs` file:

```cs
global using Markupolation;
global using static Markupolation.Elements;
global using e = Markupolation.Elements;
global using E = Markupolation.Element;
global using static Markupolation.Attributes;
global using a = Markupolation.Attributes;
global using A = Markupolation.Attribute;
global using static Markupolation.EventHandlerContentAttributes;
```

## Performance

String concatenation in C# can be done in [different](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings) ways.
Conventional wisdom is to use the `StringBuilder` class.
Jon Skeet offers advice on [Concatenating Strings Efficiently](https://jonskeet.uk/csharp/stringbuilder.html).

C# 10 offers
[improved](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/improved-interpolated-strings)
and
[constant](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/constant_interpolated_strings)
interpolated strings that you can benefit from when using `Markupolation`.

The tests folder contains some [benchmarks](/tests/Markupolation.Benchmark).

## Samples

The [samples](/samples) folder contains examples with:

- Minimal API
- Azure Functions
- Blazor WebAssembly and HTML Over The Wire
- HTMX and HTML Over The Wire
