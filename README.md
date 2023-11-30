# Markupolation <📜><!-- omit in toc -->

[![build](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml)
[![CodeFactor](https://codefactor.io/repository/github/hlaueriksson/markupolation/badge)](https://codefactor.io/repository/github/hlaueriksson/markupolation)

[![Markupolation](https://img.shields.io/nuget/v/Markupolation.svg?label=Markupolation)](https://www.nuget.org/packages/Markupolation)
[![Markupolation.Extensions](https://img.shields.io/nuget/v/Markupolation.Extensions.svg?label=Markupolation.Extensions)](https://www.nuget.org/packages/Markupolation.Extensions)

> <📜> Markupolation = Markup + String Interpolation

A library for generating `HTML` in `C#`

- It uses chainable methods to represent HTML elements and attributes
- The methods are generated from the HTML specification
  - <https://html.spec.whatwg.org>
- Perfect for your APIs that sends HTML Over The Wire

## Content<!-- omit in toc -->

- [Installation](#installation)
- [Introduction](#introduction)
- [When should I use Markupolation?](#when-should-i-use-markupolation)
- [Markupolation](#markupolation)
- [Markupolation.Extensions](#markupolationextensions)
- [String interpolation](#string-interpolation)
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

Also via [NuGet](https://www.nuget.org/packages/Markupolation.Extensions):

```
PM> Install-Package Markupolation.Extensions
```

## Introduction

This project consist of two packages:

- 📦 [Markupolation](https://www.nuget.org/packages/Markupolation)
- 📦 [Markupolation.Extensions](https://www.nuget.org/packages/Markupolation.Extensions)

`Markupolation` is a library for generating `HTML` in `C#` with a fluent API.
It can be used to create *templates* that render markup from your *data*.

An expression like this:

```cs
DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")))
```

generates the following result:

```html
<!DOCTYPE html><html><head><title>Markupolation</title></head><body><h1>Hello, World!</h1></body></html>
```

`Markupolation.Extensions` adds extension methods to control flow with loops and conditionals.

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

In some situations, you don't have access or don't want to use a template/view engine like [Razor](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor).

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

This is a library for generating `HTML` in `C#`.
It uses chainable methods to represent HTML elements and attributes.

The methods are generated from the HTML Specification:

- <https://html.spec.whatwg.org>

Input:

```cs
DOCTYPE() +
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
);
```

Output (formatted):

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

The `Markupolation` API consists of static methods for `HTML` elements and attributes.
These methods are chainable and together they can be used to generate whole or parts of `HTML` documents.
The `C#` compiler makes sure that the generated `HTML` is well-formed.

The API:

> Click to expand the sections 👆

<details>

<summary>View all Elements</summary>

### Elements<!-- omit in toc -->

Code:

- [`Elements.cs`](https://github.com/hlaueriksson/Markupolation/blob/main/src/Markupolation/Generated/Elements.cs)

| Element | Description | Attributes |
| --- | --- | --- |
| `a` | Hyperlink | `href`, `target`, `download`, `rel`, `hreflang`, `type`, `referrerpolicy` |
| `abbr` | Abbreviation |  |
| `address` | Contact information for a page or article element |  |
| `area` | Hyperlink or dead area on an image map | `alt`, `coords`, `shape`, `href`, `target`, `download`, `rel`, `referrerpolicy` |
| `article` | Self-contained syndicatable or reusable composition |  |
| `aside` | Sidebar for tangentially related content |  |
| `audio` | Audio player | `src`, `crossorigin`, `preload`, `autoplay`, `loop`, `muted`, `controls` |
| `b` | Keywords |  |
| `base_` | Base URL and default target navigable for hyperlinks and forms | `href`, `target` |
| `bdi` | Text directionality isolation |  |
| `bdo` | Text directionality formatting |  |
| `blockquote` | A section quoted from another source | `cite` |
| `body` | Document body |  |
| `br` | Line break, e.g. in poem or postal address |  |
| `button` | Button control | `disabled`, `form`, `formaction`, `formenctype`, `formmethod`, `formnovalidate`, `formtarget`, `name`, `popovertarget`, `popovertargetaction`, `type`, `value` |
| `canvas` | Scriptable bitmap canvas | `width`, `height` |
| `caption` | Table caption |  |
| `cite` | Title of a work |  |
| `code` | Computer code |  |
| `col` | Table column | `span` |
| `colgroup` | Group of columns in a table | `span` |
| `data` | Machine-readable equivalent | `value` |
| `datalist` | Container for options for combo box control |  |
| `dd` | Content for corresponding dt element(s) |  |
| `del` | A removal from the document | `cite`, `datetime` |
| `details` | Disclosure control for hiding details | `name`, `open` |
| `dfn` | Defining instance |  |
| `dialog` | Dialog box or window | `open` |
| `div` | Generic flow container, or container for name-value groups in dl elements |  |
| `dl` | Association list consisting of zero or more name-value groups |  |
| `dt` | Legend for corresponding dd element(s) |  |
| `em` | Stress emphasis |  |
| `embed` | Plugin | `src`, `type`, `width`, `height` |
| `fieldset` | Group of form controls | `disabled`, `form`, `name` |
| `figcaption` | Caption for figure |  |
| `figure` | Figure with optional caption |  |
| `footer` | Footer for a page or section |  |
| `form` | User-submittable form | `accept_charset`, `action`, `autocomplete`, `enctype`, `method`, `name`, `novalidate`, `rel`, `target` |
| `h1` | Heading |  |
| `h2` | Heading |  |
| `h3` | Heading |  |
| `h4` | Heading |  |
| `h5` | Heading |  |
| `h6` | Heading |  |
| `head` | Container for document metadata |  |
| `header` | Introductory or navigational aids for a page or section |  |
| `hgroup` | Heading container |  |
| `hr` | Thematic break |  |
| `html` | Root element |  |
| `i` | Alternate voice |  |
| `iframe` | Child navigable | `src`, `srcdoc`, `name`, `sandbox`, `allow`, `allowfullscreen`, `width`, `height`, `referrerpolicy`, `loading` |
| `img` | Image | `alt`, `src`, `srcset`, `sizes`, `crossorigin`, `usemap`, `ismap`, `width`, `height`, `referrerpolicy`, `decoding`, `loading`, `fetchpriority` |
| `input` | Form control | `accept`, `alt`, `autocomplete`, `checked_`, `dirname`, `disabled`, `form`, `formaction`, `formenctype`, `formmethod`, `formnovalidate`, `formtarget`, `height`, `list`, `max`, `maxlength`, `min`, `minlength`, `multiple`, `name`, `pattern`, `placeholder`, `popovertarget`, `popovertargetaction`, `readonly_`, `required`, `size`, `src`, `step`, `type`, `value`, `width` |
| `ins` | An addition to the document | `cite`, `datetime` |
| `kbd` | User input |  |
| `label` | Caption for a form control | `for_` |
| `legend` | Caption for fieldset |  |
| `li` | List item | `value` |
| `link` | Link metadata | `href`, `crossorigin`, `rel`, `as_`, `media`, `hreflang`, `type`, `sizes`, `imagesrcset`, `imagesizes`, `referrerpolicy`, `integrity`, `blocking`, `color`, `disabled`, `fetchpriority` |
| `main` | Container for the dominant contents of the document |  |
| `map` | Image map | `name` |
| `mark` | Highlight |  |
| `menu` | Menu of commands |  |
| `meta` | Text metadata | `name`, `http_equiv`, `content`, `charset`, `media` |
| `meter` | Gauge | `value`, `min`, `max`, `low`, `high`, `optimum` |
| `nav` | Section with navigational links |  |
| `noscript` | Fallback content for script |  |
| `object_` | Image, child navigable, or plugin | `data`, `type`, `name`, `form`, `width`, `height` |
| `ol` | Ordered list | `reversed`, `start`, `type` |
| `optgroup` | Group of options in a list box | `disabled`, `label` |
| `option` | Option in a list box or combo box control | `disabled`, `label`, `selected`, `value` |
| `output` | Calculated output value | `for_`, `form`, `name` |
| `p` | Paragraph |  |
| `picture` | Image |  |
| `pre` | Block of preformatted text |  |
| `progress` | Progress bar | `value`, `max` |
| `q` | Quotation | `cite` |
| `rp` | Parenthesis for ruby annotation text |  |
| `rt` | Ruby annotation text |  |
| `ruby` | Ruby annotation(s) |  |
| `s` | Inaccurate text |  |
| `samp` | Computer output |  |
| `script` | Embedded script | `src`, `type`, `nomodule`, `async`, `defer`, `crossorigin`, `integrity`, `referrerpolicy`, `blocking`, `fetchpriority` |
| `search` | Container for search controls |  |
| `section` | Generic document or application section |  |
| `select` | List box control | `autocomplete`, `disabled`, `form`, `multiple`, `name`, `required`, `size` |
| `slot` | Shadow tree slot | `name` |
| `small` | Side comment |  |
| `source` | Image source for img or media source for video or audio | `type`, `media`, `src`, `srcset`, `sizes`, `width`, `height` |
| `span` | Generic phrasing container |  |
| `strong` | Importance |  |
| `style` | Embedded styling information | `media`, `blocking` |
| `sub` | Subscript |  |
| `summary` | Caption for details |  |
| `sup` | Superscript |  |
| `table` | Table |  |
| `tbody` | Group of rows in a table |  |
| `td` | Table cell | `colspan`, `rowspan`, `headers` |
| `template` | Template |  |
| `textarea` | Multiline text controls | `autocomplete`, `cols`, `dirname`, `disabled`, `form`, `maxlength`, `minlength`, `name`, `placeholder`, `readonly_`, `required`, `rows`, `wrap` |
| `tfoot` | Group of footer rows in a table |  |
| `th` | Table header cell | `colspan`, `rowspan`, `headers`, `scope`, `abbr` |
| `thead` | Group of heading rows in a table |  |
| `time` | Machine-readable equivalent of date- or time-related data | `datetime` |
| `title` | Document title |  |
| `tr` | Table row |  |
| `track` | Timed text track | `default_`, `kind`, `label`, `src`, `srclang` |
| `u` | Unarticulated annotation |  |
| `ul` | List |  |
| `var` | Variable |  |
| `video` | Video player | `src`, `crossorigin`, `poster`, `preload`, `autoplay`, `playsinline`, `loop`, `muted`, `controls`, `width`, `height` |
| `wbr` | Line breaking opportunity |  |

</details>

<details>

<summary>View all Attributes</summary>

### Attributes<!-- omit in toc -->

Code:

- [`Attributes.cs`](https://github.com/hlaueriksson/Markupolation/blob/main/src/Markupolation/Generated/Attributes.cs)

| Attribute | Description | Elements |
| --- | --- | --- |
| `abbr` | Alternative label to use for the header cell when referencing the cell in other contexts | `th` |
| `accept` | Hint for expected file type in file upload controls | `input` |
| `accept_charset` | Character encodings to use for form submission | `form` |
| `accesskey` | Keyboard shortcut to activate or focus element |  |
| `action` | URL to use for form submission | `form` |
| `allow` | Permissions policy to be applied to the iframe's contents | `iframe` |
| `allowfullscreen` | Whether to allow the iframe's contents to use requestFullscreen() | `iframe` |
| `alt` | Replacement text for use when images are not available | `area`, `img`, `input` |
| `as_` | Potential destination for a preload request (for rel="preload" and rel="modulepreload") | `link` |
| `async` | Execute script when available, without blocking while fetching | `script` |
| `autocapitalize` | Recommended autocapitalization behavior (for supported input methods) |  |
| `autocomplete` | Default setting for autofill feature for controls in the form<br/>Hint for form autofill feature | `form`, `input`, `select`, `textarea` |
| `autofocus` | Automatically focus the element when the page is loaded |  |
| `autoplay` | Hint that the media resource can be started automatically when the page is loaded | `audio`, `video` |
| `blocking` | Whether the element is potentially render-blocking | `link`, `script`, `style` |
| `charset` | Character encoding declaration | `meta` |
| `checked_` | Whether the control is checked | `input` |
| `cite` | Link to the source of the quotation or more information about the edit | `blockquote`, `del`, `ins`, `q` |
| `class_` | Classes to which the element belongs |  |
| `color` | Color to use when customizing a site's icon (for rel="mask-icon") | `link` |
| `cols` | Maximum number of characters per line | `textarea` |
| `colspan` | Number of columns that the cell is to span | `td`, `th` |
| `content` | Value of the element | `meta` |
| `contenteditable` | Whether the element is editable |  |
| `controls` | Show user agent controls | `audio`, `video` |
| `coords` | Coordinates for the shape to be created in an image map | `area` |
| `crossorigin` | How the element handles crossorigin requests | `audio`, `img`, `link`, `script`, `video` |
| `data` | Address of the resource | `object_` |
| `datetime` | Date and (optionally) time of the change<br/>Machine-readable value | `del`, `ins`, `time` |
| `decoding` | Decoding hint to use when processing this image for presentation | `img` |
| `default_` | Enable the track if no other text track is more suitable | `track` |
| `defer` | Defer script execution | `script` |
| `dir` | The text directionality of the element<br/>The text directionality of the element |  |
| `dirname` | Name of form control to use for sending the element's directionality in form submission | `input`, `textarea` |
| `disabled` | Whether the form control is disabled<br/>Whether the descendant form controls, except any inside legend, are disabled<br/>Whether the link is disabled | `button`, `input`, `optgroup`, `option`, `select`, `textarea`, `fieldset`, `link` |
| `download` | Whether to download the resource instead of navigating to it, and its filename if so | `a`, `area` |
| `draggable` | Whether the element is draggable |  |
| `enctype` | Entry list encoding type to use for form submission | `form` |
| `enterkeyhint` | Hint for selecting an enter key action |  |
| `fetchpriority` | Sets the priority for fetches initiated by the element | `img`, `link`, `script` |
| `for_` | Associate the label with form control<br/>Specifies controls from which the output was calculated | `label`, `output` |
| `form` | Associates the element with a form element | `button`, `fieldset`, `input`, `object_`, `output`, `select`, `textarea` |
| `formaction` | URL to use for form submission | `button`, `input` |
| `formenctype` | Entry list encoding type to use for form submission | `button`, `input` |
| `formmethod` | Variant to use for form submission | `button`, `input` |
| `formnovalidate` | Bypass form control validation for form submission | `button`, `input` |
| `formtarget` | Navigable for form submission | `button`, `input` |
| `headers` | The header cells for this cell | `td`, `th` |
| `height` | Vertical dimension | `canvas`, `embed`, `iframe`, `img`, `input`, `object_`, `source`, `video` |
| `hidden` | Whether the element is relevant |  |
| `high` | Low limit of high range | `meter` |
| `href` | Address of the hyperlink<br/>Address of the hyperlink<br/>Document base URL | `a`, `area`, `link`, `base_` |
| `hreflang` | Language of the linked resource | `a`, `link` |
| `http_equiv` | Pragma directive | `meta` |
| `id` | The element's ID |  |
| `imagesizes` | Image sizes for different page layouts (for rel="preload") | `link` |
| `imagesrcset` | Images to use in different situations, e.g., high-resolution displays, small monitors, etc. (for rel="preload") | `link` |
| `inert` | Whether the element is inert |  |
| `inputmode` | Hint for selecting an input modality |  |
| `integrity` | Integrity metadata used in Subresource Integrity checks [SRI] | `link`, `script` |
| `is_` | Creates a customized built-in element |  |
| `ismap` | Whether the image is a server-side image map | `img` |
| `itemid` | Global identifier for a microdata item |  |
| `itemprop` | Property names of a microdata item |  |
| `itemref` | Referenced elements |  |
| `itemscope` | Introduces a microdata item |  |
| `itemtype` | Item types of a microdata item |  |
| `kind` | The type of text track | `track` |
| `label` | User-visible label | `optgroup`, `option`, `track` |
| `lang` | Language of the element |  |
| `list` | List of autocomplete options | `input` |
| `loading` | Used when determining loading deferral | `iframe`, `img` |
| `loop` | Whether to loop the media resource | `audio`, `video` |
| `low` | High limit of low range | `meter` |
| `max` | Maximum value<br/>Upper bound of range | `input`, `meter`, `progress` |
| `maxlength` | Maximum length of value | `input`, `textarea` |
| `media` | Applicable media | `link`, `meta`, `source`, `style` |
| `method` | Variant to use for form submission | `form` |
| `min` | Minimum value<br/>Lower bound of range | `input`, `meter` |
| `minlength` | Minimum length of value | `input`, `textarea` |
| `multiple` | Whether to allow multiple values | `input`, `select` |
| `muted` | Whether to mute the media resource by default | `audio`, `video` |
| `name` | Name of the element to use for form submission and in the form.elements API<br/>Name of group of mutually-exclusive details elements<br/>Name of form to use in the document.forms API<br/>Name of content navigable<br/>Name of image map to reference from the usemap attribute<br/>Metadata name<br/>Name of shadow tree slot | `button`, `fieldset`, `input`, `output`, `select`, `textarea`, `details`, `form`, `iframe`, `object_`, `map`, `meta`, `slot` |
| `nomodule` | Prevents execution in user agents that support module scripts | `script` |
| `nonce` | Cryptographic nonce used in Content Security Policy checks [CSP] |  |
| `novalidate` | Bypass form control validation for form submission | `form` |
| `open` | Whether the details are visible<br/>Whether the dialog box is showing | `details`, `dialog` |
| `optimum` | Optimum value in gauge | `meter` |
| `pattern` | Pattern to be matched by the form control's value | `input` |
| `ping` | URLs to ping |  |
| `placeholder` | User-visible label to be placed within the form control | `input`, `textarea` |
| `playsinline` | Encourage the user agent to display video content within the element's playback area | `video` |
| `popover` | Makes the element a popover element |  |
| `popovertarget` | Targets a popover element to toggle, show, or hide | `input`, `button` |
| `popovertargetaction` | Indicates whether a targeted popover element is to be toggled, shown, or hidden | `input`, `button` |
| `poster` | Poster frame to show prior to video playback | `video` |
| `preload` | Hints how much buffering the media resource will likely need | `audio`, `video` |
| `readonly_` | Whether to allow the value to be edited by the user<br/>Affects willValidate, plus any behavior added by the custom element author | `input`, `textarea` |
| `referrerpolicy` | Referrer policy for fetches initiated by the element | `a`, `area`, `iframe`, `img`, `link`, `script` |
| `rel` | Relationship between the location in the document containing the hyperlink and the destination resource<br/>Relationship between the document containing the hyperlink and the destination resource | `a`, `area`, `link` |
| `required` | Whether the control is required for form submission | `input`, `select`, `textarea` |
| `reversed` | Number the list backwards | `ol` |
| `rows` | Number of lines to show | `textarea` |
| `rowspan` | Number of rows that the cell is to span | `td`, `th` |
| `sandbox` | Security rules for nested content | `iframe` |
| `scope` | Specifies which cells the header cell applies to | `th` |
| `selected` | Whether the option is selected by default | `option` |
| `shadowrootmode` | Enables streaming declarative shadow roots | `template` |
| `shadowrootdelegatesfocus` | Sets delegates focus on a declarative shadow root | `template` |
| `shape` | The kind of shape to be created in an image map | `area` |
| `size` | Size of the control | `input`, `select` |
| `sizes` | Sizes of the icons (for rel="icon")<br/>Image sizes for different page layouts | `link`, `img`, `source` |
| `slot` | The element's desired slot |  |
| `span` | Number of columns spanned by the element | `col`, `colgroup` |
| `spellcheck` | Whether the element is to have its spelling and grammar checked |  |
| `src` | Address of the resource | `audio`, `embed`, `iframe`, `img`, `input`, `script`, `source`, `track`, `video` |
| `srcdoc` | A document to render in the iframe | `iframe` |
| `srclang` | Language of the text track | `track` |
| `srcset` | Images to use in different situations, e.g., high-resolution displays, small monitors, etc | `img`, `source` |
| `start` | Starting value of the list | `ol` |
| `step` | Granularity to be matched by the form control's value | `input` |
| `style` | Presentational and formatting instructions |  |
| `tabindex` | Whether the element is focusable and sequentially focusable, and the relative order of the element for the purposes of sequential focus navigation |  |
| `target` | Navigable for hyperlink navigation<br/>Default navigable for hyperlink navigation and form submission<br/>Navigable for form submission | `a`, `area`, `base_`, `form` |
| `title` | Advisory information for the element<br/>Full term or expansion of abbreviation<br/>Description of pattern (when used with pattern attribute)<br/>Title of the link<br/>CSS style sheet set name | `abbr`, `dfn`, `input`, `link`, `link`, `style` |
| `translate` | Whether the element is to be translated when the page is localized |  |
| `type` | Hint for the type of the referenced resource<br/>Type of button<br/>Type of embedded resource<br/>Type of form control<br/>Kind of list marker<br/>Type of script | `a`, `link`, `button`, `embed`, `object_`, `source`, `input`, `ol`, `script` |
| `usemap` | Name of image map to use | `img` |
| `value` | Value to be used for form submission<br/>Machine-readable value<br/>Value of the form control<br/>Ordinal value of the list item<br/>Current value of the element | `button`, `option`, `data`, `input`, `li`, `meter`, `progress` |
| `width` | Horizontal dimension | `canvas`, `embed`, `iframe`, `img`, `input`, `object_`, `source`, `video` |
| `wrap` | How the value of the form control is to be wrapped for form submission | `textarea` |

</details>

<details>

<summary>View all EventHandlerContentAttributes</summary>

### EventHandlerContentAttributes<!-- omit in toc -->

Code:

- [`EventHandlerContentAttributes.cs`](https://github.com/hlaueriksson/Markupolation/blob/main/src/Markupolation/Generated/EventHandlerContentAttributes.cs)

| Attribute | Description | Elements |
| --- | --- | --- |
| `onauxclick` | auxclick event handler |  |
| `onafterprint` | afterprint event handler for Window object | `body` |
| `onbeforematch` | beforematch event handler |  |
| `onbeforeprint` | beforeprint event handler for Window object | `body` |
| `onbeforeunload` | beforeunload event handler for Window object | `body` |
| `onbeforetoggle` | beforetoggle event handler |  |
| `onblur` | blur event handler |  |
| `oncancel` | cancel event handler |  |
| `oncanplay` | canplay event handler |  |
| `oncanplaythrough` | canplaythrough event handler |  |
| `onchange` | change event handler |  |
| `onclick` | click event handler |  |
| `onclose` | close event handler |  |
| `oncontextlost` | contextlost event handler |  |
| `oncontextmenu` | contextmenu event handler |  |
| `oncontextrestored` | contextrestored event handler |  |
| `oncopy` | copy event handler |  |
| `oncuechange` | cuechange event handler |  |
| `oncut` | cut event handler |  |
| `ondblclick` | dblclick event handler |  |
| `ondrag` | drag event handler |  |
| `ondragend` | dragend event handler |  |
| `ondragenter` | dragenter event handler |  |
| `ondragleave` | dragleave event handler |  |
| `ondragover` | dragover event handler |  |
| `ondragstart` | dragstart event handler |  |
| `ondrop` | drop event handler |  |
| `ondurationchange` | durationchange event handler |  |
| `onemptied` | emptied event handler |  |
| `onended` | ended event handler |  |
| `onerror` | error event handler |  |
| `onfocus` | focus event handler |  |
| `onformdata` | formdata event handler |  |
| `onhashchange` | hashchange event handler for Window object | `body` |
| `oninput` | input event handler |  |
| `oninvalid` | invalid event handler |  |
| `onkeydown` | keydown event handler |  |
| `onkeypress` | keypress event handler |  |
| `onkeyup` | keyup event handler |  |
| `onlanguagechange` | languagechange event handler for Window object | `body` |
| `onload` | load event handler |  |
| `onloadeddata` | loadeddata event handler |  |
| `onloadedmetadata` | loadedmetadata event handler |  |
| `onloadstart` | loadstart event handler |  |
| `onmessage` | message event handler for Window object | `body` |
| `onmessageerror` | messageerror event handler for Window object | `body` |
| `onmousedown` | mousedown event handler |  |
| `onmouseenter` | mouseenter event handler |  |
| `onmouseleave` | mouseleave event handler |  |
| `onmousemove` | mousemove event handler |  |
| `onmouseout` | mouseout event handler |  |
| `onmouseover` | mouseover event handler |  |
| `onmouseup` | mouseup event handler |  |
| `onoffline` | offline event handler for Window object | `body` |
| `ononline` | online event handler for Window object | `body` |
| `onpagehide` | pagehide event handler for Window object | `body` |
| `onpageshow` | pageshow event handler for Window object | `body` |
| `onpaste` | paste event handler |  |
| `onpause` | pause event handler |  |
| `onplay` | play event handler |  |
| `onplaying` | playing event handler |  |
| `onpopstate` | popstate event handler for Window object | `body` |
| `onprogress` | progress event handler |  |
| `onratechange` | ratechange event handler |  |
| `onreset` | reset event handler |  |
| `onresize` | resize event handler |  |
| `onrejectionhandled` | rejectionhandled event handler for Window object | `body` |
| `onscroll` | scroll event handler |  |
| `onscrollend` | scrollend event handler |  |
| `onsecuritypolicyviolation` | securitypolicyviolation event handler |  |
| `onseeked` | seeked event handler |  |
| `onseeking` | seeking event handler |  |
| `onselect` | select event handler |  |
| `onslotchange` | slotchange event handler |  |
| `onstalled` | stalled event handler |  |
| `onstorage` | storage event handler for Window object | `body` |
| `onsubmit` | submit event handler |  |
| `onsuspend` | suspend event handler |  |
| `ontimeupdate` | timeupdate event handler |  |
| `ontoggle` | toggle event handler |  |
| `onunhandledrejection` | unhandledrejection event handler for Window object | `body` |
| `onunload` | unload event handler for Window object | `body` |
| `onvolumechange` | volumechange event handler |  |
| `onwaiting` | waiting event handler |  |
| `onwheel` | wheel event handler |  |

</details>

- ℹ️ The names of element and attribut methods are in *lowercase* to reflect the `HTML` Specification:
  - <https://html.spec.whatwg.org>
- ℹ️ Names that conflict with the [`C#` keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/) are suffixed with an underscore (`_`)
- ℹ️ Attributes that contain hyphen (`-`) are converted to [snake_case](https://en.wikipedia.org/wiki/Snake_case)
- ⚠️ Some methods are *ambiguous* and are defined for both elements and attributes

Elements suffixed with `_`:

- `base_`
- `object_`

Attributes suffixed with `_`:

- `as_`
- `checked_`
- `class_`
- `default_`
- `for_`
- `is_`
- `readonly_`

Attributes converted to `snake_case`:

- `accept_charset`
- `http_equiv`

Ambiguous methods for both elements and attributes:

- `abbr`
- `cite`
- `data`
- `form`
- `label`
- `slot`
- `span`
- `style`
- `title`

Use the predefined `e` and `a` aliases as shorthands for these methods:

- `e.title("Title element")`
- `a.title("Title attribute")`

### Custom Elements and Attributes<!-- omit in toc -->

Custom elements and attributes that are not available in the API (not part of the HTML Specification) can be instantiated from the `Element` and `Attribute` classes.
Use the predefined `E` and `A` aliases as shorthands for these classes.

Scalable Vector Graphics element:

```cs
new Element("""
  <svg width="100" height="100">
    <circle cx="50" cy="50" r="40" fill="blue" />
  </svg>
""")
```

The `E` alias:

```cs
new E("""
  <svg width="100" height="100">
    <circle cx="50" cy="50" r="40" fill="blue" />
  </svg>
""")
```

Open Graph attribute:

```cs
new Attribute("property", "og:title")
```

The `A` alias:

```cs
new A("property", "og:title")
```

## Markupolation.Extensions

This is a library for controlling the flow when writing templates.
Use lambda expressions for loops and conditionals.

Input:

```cs
bool Fizz(int i) => i % 3 == 0;
bool Buzz(int i) => i % 5 == 0;
var numbers = Enumerable.Range(1, 15);

DOCTYPE() +
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
                x.IfMatch(i => Fizz(i) && Buzz(i), i => strong("FizzBuzz")),
                x.IfMatch(i => Fizz(i) && !Buzz(i), i => em("Fizz")),
                x.IfMatch(i => !Fizz(i) && Buzz(i), i => em("Buzz")),
                x.IfMatch(i => !Fizz(i) && !Buzz(i), i => i.ToString())
            ))
        )
    )
);
```

Output (formatted):

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

## String interpolation

You can interpolate strings and string literals with the methods of `Markupolation`.

These concepts in .NET are of interest:

- [String interpolation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)
- [String literals](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#string-literals)
- [Verbatim text](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/verbatim)
- [Raw string literal text](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/raw-string)

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

The [samples](/samples) folder contains examples of `Markupolation` together with:

- Blazor + Functions + Tye
- HTMX + Api + YARP + Aspire
- Console + Playwright

The [PlaygroundTests](/tests/Markupolation.Tests/PlaygroundTests.cs) also contains some templating code that you may find interesting.
