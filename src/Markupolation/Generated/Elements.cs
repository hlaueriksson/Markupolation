namespace Markupolation;

/// <summary>HTML elements.</summary>
public static partial class Elements
{
    /// <summary>Hyperlink.</summary>
    /// <remarks>Attributes: <see cref="Attributes.href(string)"/>, <see cref="Attributes.target(string)"/>, <see cref="Attributes.download(string)"/>, <see cref="Attributes.rel(string)"/>, <see cref="Attributes.hreflang(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.referrerpolicy(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<a></a>]]></c></returns>
    public static Element a(params Content[] content) => new(ElementType.a, false, content);

    /// <inheritdoc cref="a(Content[])" />
    public static Element a(object content) => new(ElementType.a, false, content?.ToString()!);

    /// <summary>Abbreviation.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<abbr></abbr>]]></c></returns>
    public static Element abbr(params Content[] content) => new(ElementType.abbr, false, content);

    /// <inheritdoc cref="abbr(Content[])" />
    public static Element abbr(object content) => new(ElementType.abbr, false, content?.ToString()!);

    /// <summary>Contact information for a page or article element.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<address></address>]]></c></returns>
    public static Element address(params Content[] content) => new(ElementType.address, false, content);

    /// <inheritdoc cref="address(Content[])" />
    public static Element address(object content) => new(ElementType.address, false, content?.ToString()!);

    /// <summary>Hyperlink or dead area on an image map.</summary>
    /// <remarks>Attributes: <see cref="Attributes.alt(string)"/>, <see cref="Attributes.coords(string)"/>, <see cref="Attributes.shape(string)"/>, <see cref="Attributes.href(string)"/>, <see cref="Attributes.target(string)"/>, <see cref="Attributes.download(string)"/>, <see cref="Attributes.rel(string)"/>, <see cref="Attributes.referrerpolicy(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<area />]]></c></returns>
    public static Element area(params Content[] content) => new(ElementType.area, true, content);

    /// <summary>Self-contained syndicatable or reusable composition.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<article></article>]]></c></returns>
    public static Element article(params Content[] content) => new(ElementType.article, false, content);

    /// <inheritdoc cref="article(Content[])" />
    public static Element article(object content) => new(ElementType.article, false, content?.ToString()!);

    /// <summary>Sidebar for tangentially related content.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<aside></aside>]]></c></returns>
    public static Element aside(params Content[] content) => new(ElementType.aside, false, content);

    /// <inheritdoc cref="aside(Content[])" />
    public static Element aside(object content) => new(ElementType.aside, false, content?.ToString()!);

    /// <summary>Audio player.</summary>
    /// <remarks>Attributes: <see cref="Attributes.src(string)"/>, <see cref="Attributes.crossorigin(string)"/>, <see cref="Attributes.preload(string)"/>, <see cref="Attributes.autoplay()"/>, <see cref="Attributes.loop()"/>, <see cref="Attributes.muted()"/>, <see cref="Attributes.controls()"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<audio></audio>]]></c></returns>
    public static Element audio(params Content[] content) => new(ElementType.audio, false, content);

    /// <inheritdoc cref="audio(Content[])" />
    public static Element audio(object content) => new(ElementType.audio, false, content?.ToString()!);

    /// <summary>Keywords.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<b></b>]]></c></returns>
    public static Element b(params Content[] content) => new(ElementType.b, false, content);

    /// <inheritdoc cref="b(Content[])" />
    public static Element b(object content) => new(ElementType.b, false, content?.ToString()!);

    /// <summary>Base URL and default target navigable for hyperlinks and forms.</summary>
    /// <remarks>Attributes: <see cref="Attributes.href(string)"/>, <see cref="Attributes.target(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<base_ />]]></c></returns>
    public static Element base_(params Content[] content) => new(ElementType.base_, true, content);

    /// <summary>Text directionality isolation.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<bdi></bdi>]]></c></returns>
    public static Element bdi(params Content[] content) => new(ElementType.bdi, false, content);

    /// <inheritdoc cref="bdi(Content[])" />
    public static Element bdi(object content) => new(ElementType.bdi, false, content?.ToString()!);

    /// <summary>Text directionality formatting.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<bdo></bdo>]]></c></returns>
    public static Element bdo(params Content[] content) => new(ElementType.bdo, false, content);

    /// <inheritdoc cref="bdo(Content[])" />
    public static Element bdo(object content) => new(ElementType.bdo, false, content?.ToString()!);

    /// <summary>A section quoted from another source.</summary>
    /// <remarks>Attributes: <see cref="Attributes.cite(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<blockquote></blockquote>]]></c></returns>
    public static Element blockquote(params Content[] content) => new(ElementType.blockquote, false, content);

    /// <inheritdoc cref="blockquote(Content[])" />
    public static Element blockquote(object content) => new(ElementType.blockquote, false, content?.ToString()!);

    /// <summary>Document body.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<body></body>]]></c></returns>
    public static Element body(params Content[] content) => new(ElementType.body, false, content);

    /// <inheritdoc cref="body(Content[])" />
    public static Element body(object content) => new(ElementType.body, false, content?.ToString()!);

    /// <summary>Line break, e.g. in poem or postal address.</summary>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<br />]]></c></returns>
    public static Element br(params Content[] content) => new(ElementType.br, true, content);

    /// <summary>Button control.</summary>
    /// <remarks>Attributes: <see cref="Attributes.disabled()"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.formaction(string)"/>, <see cref="Attributes.formenctype(string)"/>, <see cref="Attributes.formmethod(string)"/>, <see cref="Attributes.formnovalidate()"/>, <see cref="Attributes.formtarget(string)"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.popovertarget(string)"/>, <see cref="Attributes.popovertargetaction(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.value(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<button></button>]]></c></returns>
    public static Element button(params Content[] content) => new(ElementType.button, false, content);

    /// <inheritdoc cref="button(Content[])" />
    public static Element button(object content) => new(ElementType.button, false, content?.ToString()!);

    /// <summary>Scriptable bitmap canvas.</summary>
    /// <remarks>Attributes: <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<canvas></canvas>]]></c></returns>
    public static Element canvas(params Content[] content) => new(ElementType.canvas, false, content);

    /// <inheritdoc cref="canvas(Content[])" />
    public static Element canvas(object content) => new(ElementType.canvas, false, content?.ToString()!);

    /// <summary>Table caption.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<caption></caption>]]></c></returns>
    public static Element caption(params Content[] content) => new(ElementType.caption, false, content);

    /// <inheritdoc cref="caption(Content[])" />
    public static Element caption(object content) => new(ElementType.caption, false, content?.ToString()!);

    /// <summary>Title of a work.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<cite></cite>]]></c></returns>
    public static Element cite(params Content[] content) => new(ElementType.cite, false, content);

    /// <inheritdoc cref="cite(Content[])" />
    public static Element cite(object content) => new(ElementType.cite, false, content?.ToString()!);

    /// <summary>Computer code.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<code></code>]]></c></returns>
    public static Element code(params Content[] content) => new(ElementType.code, false, content);

    /// <inheritdoc cref="code(Content[])" />
    public static Element code(object content) => new(ElementType.code, false, content?.ToString()!);

    /// <summary>Table column.</summary>
    /// <remarks>Attributes: <see cref="Attributes.span(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<col />]]></c></returns>
    public static Element col(params Content[] content) => new(ElementType.col, true, content);

    /// <summary>Group of columns in a table.</summary>
    /// <remarks>Attributes: <see cref="Attributes.span(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<colgroup></colgroup>]]></c></returns>
    public static Element colgroup(params Content[] content) => new(ElementType.colgroup, false, content);

    /// <inheritdoc cref="colgroup(Content[])" />
    public static Element colgroup(object content) => new(ElementType.colgroup, false, content?.ToString()!);

    /// <summary>Machine-readable equivalent.</summary>
    /// <remarks>Attributes: <see cref="Attributes.value(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<data></data>]]></c></returns>
    public static Element data(params Content[] content) => new(ElementType.data, false, content);

    /// <inheritdoc cref="data(Content[])" />
    public static Element data(object content) => new(ElementType.data, false, content?.ToString()!);

    /// <summary>Container for options for combo box control.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<datalist></datalist>]]></c></returns>
    public static Element datalist(params Content[] content) => new(ElementType.datalist, false, content);

    /// <inheritdoc cref="datalist(Content[])" />
    public static Element datalist(object content) => new(ElementType.datalist, false, content?.ToString()!);

    /// <summary>Content for corresponding dt element(s).</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<dd></dd>]]></c></returns>
    public static Element dd(params Content[] content) => new(ElementType.dd, false, content);

    /// <inheritdoc cref="dd(Content[])" />
    public static Element dd(object content) => new(ElementType.dd, false, content?.ToString()!);

    /// <summary>A removal from the document.</summary>
    /// <remarks>Attributes: <see cref="Attributes.cite(string)"/>, <see cref="Attributes.datetime(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<del></del>]]></c></returns>
    public static Element del(params Content[] content) => new(ElementType.del, false, content);

    /// <inheritdoc cref="del(Content[])" />
    public static Element del(object content) => new(ElementType.del, false, content?.ToString()!);

    /// <summary>Disclosure control for hiding details.</summary>
    /// <remarks>Attributes: <see cref="Attributes.name(string)"/>, <see cref="Attributes.open()"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<details></details>]]></c></returns>
    public static Element details(params Content[] content) => new(ElementType.details, false, content);

    /// <inheritdoc cref="details(Content[])" />
    public static Element details(object content) => new(ElementType.details, false, content?.ToString()!);

    /// <summary>Defining instance.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<dfn></dfn>]]></c></returns>
    public static Element dfn(params Content[] content) => new(ElementType.dfn, false, content);

    /// <inheritdoc cref="dfn(Content[])" />
    public static Element dfn(object content) => new(ElementType.dfn, false, content?.ToString()!);

    /// <summary>Dialog box or window.</summary>
    /// <remarks>Attributes: <see cref="Attributes.open()"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<dialog></dialog>]]></c></returns>
    public static Element dialog(params Content[] content) => new(ElementType.dialog, false, content);

    /// <inheritdoc cref="dialog(Content[])" />
    public static Element dialog(object content) => new(ElementType.dialog, false, content?.ToString()!);

    /// <summary>Generic flow container, or container for name-value groups in dl elements.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<div></div>]]></c></returns>
    public static Element div(params Content[] content) => new(ElementType.div, false, content);

    /// <inheritdoc cref="div(Content[])" />
    public static Element div(object content) => new(ElementType.div, false, content?.ToString()!);

    /// <summary>Association list consisting of zero or more name-value groups.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<dl></dl>]]></c></returns>
    public static Element dl(params Content[] content) => new(ElementType.dl, false, content);

    /// <inheritdoc cref="dl(Content[])" />
    public static Element dl(object content) => new(ElementType.dl, false, content?.ToString()!);

    /// <summary>Legend for corresponding dd element(s).</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<dt></dt>]]></c></returns>
    public static Element dt(params Content[] content) => new(ElementType.dt, false, content);

    /// <inheritdoc cref="dt(Content[])" />
    public static Element dt(object content) => new(ElementType.dt, false, content?.ToString()!);

    /// <summary>Stress emphasis.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<em></em>]]></c></returns>
    public static Element em(params Content[] content) => new(ElementType.em, false, content);

    /// <inheritdoc cref="em(Content[])" />
    public static Element em(object content) => new(ElementType.em, false, content?.ToString()!);

    /// <summary>Plugin.</summary>
    /// <remarks>Attributes: <see cref="Attributes.src(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<embed />]]></c></returns>
    public static Element embed(params Content[] content) => new(ElementType.embed, true, content);

    /// <summary>Group of form controls.</summary>
    /// <remarks>Attributes: <see cref="Attributes.disabled()"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.name(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<fieldset></fieldset>]]></c></returns>
    public static Element fieldset(params Content[] content) => new(ElementType.fieldset, false, content);

    /// <inheritdoc cref="fieldset(Content[])" />
    public static Element fieldset(object content) => new(ElementType.fieldset, false, content?.ToString()!);

    /// <summary>Caption for figure.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<figcaption></figcaption>]]></c></returns>
    public static Element figcaption(params Content[] content) => new(ElementType.figcaption, false, content);

    /// <inheritdoc cref="figcaption(Content[])" />
    public static Element figcaption(object content) => new(ElementType.figcaption, false, content?.ToString()!);

    /// <summary>Figure with optional caption.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<figure></figure>]]></c></returns>
    public static Element figure(params Content[] content) => new(ElementType.figure, false, content);

    /// <inheritdoc cref="figure(Content[])" />
    public static Element figure(object content) => new(ElementType.figure, false, content?.ToString()!);

    /// <summary>Footer for a page or section.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<footer></footer>]]></c></returns>
    public static Element footer(params Content[] content) => new(ElementType.footer, false, content);

    /// <inheritdoc cref="footer(Content[])" />
    public static Element footer(object content) => new(ElementType.footer, false, content?.ToString()!);

    /// <summary>User-submittable form.</summary>
    /// <remarks>Attributes: <see cref="Attributes.accept_charset(string)"/>, <see cref="Attributes.action(string)"/>, <see cref="Attributes.autocomplete(string)"/>, <see cref="Attributes.enctype(string)"/>, <see cref="Attributes.method(string)"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.novalidate()"/>, <see cref="Attributes.rel(string)"/>, <see cref="Attributes.target(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<form></form>]]></c></returns>
    public static Element form(params Content[] content) => new(ElementType.form, false, content);

    /// <inheritdoc cref="form(Content[])" />
    public static Element form(object content) => new(ElementType.form, false, content?.ToString()!);

    /// <summary>Heading.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<h1></h1>]]></c></returns>
    public static Element h1(params Content[] content) => new(ElementType.h1, false, content);

    /// <inheritdoc cref="h1(Content[])" />
    public static Element h1(object content) => new(ElementType.h1, false, content?.ToString()!);

    /// <summary>Heading.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<h2></h2>]]></c></returns>
    public static Element h2(params Content[] content) => new(ElementType.h2, false, content);

    /// <inheritdoc cref="h2(Content[])" />
    public static Element h2(object content) => new(ElementType.h2, false, content?.ToString()!);

    /// <summary>Heading.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<h3></h3>]]></c></returns>
    public static Element h3(params Content[] content) => new(ElementType.h3, false, content);

    /// <inheritdoc cref="h3(Content[])" />
    public static Element h3(object content) => new(ElementType.h3, false, content?.ToString()!);

    /// <summary>Heading.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<h4></h4>]]></c></returns>
    public static Element h4(params Content[] content) => new(ElementType.h4, false, content);

    /// <inheritdoc cref="h4(Content[])" />
    public static Element h4(object content) => new(ElementType.h4, false, content?.ToString()!);

    /// <summary>Heading.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<h5></h5>]]></c></returns>
    public static Element h5(params Content[] content) => new(ElementType.h5, false, content);

    /// <inheritdoc cref="h5(Content[])" />
    public static Element h5(object content) => new(ElementType.h5, false, content?.ToString()!);

    /// <summary>Heading.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<h6></h6>]]></c></returns>
    public static Element h6(params Content[] content) => new(ElementType.h6, false, content);

    /// <inheritdoc cref="h6(Content[])" />
    public static Element h6(object content) => new(ElementType.h6, false, content?.ToString()!);

    /// <summary>Container for document metadata.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<head></head>]]></c></returns>
    public static Element head(params Content[] content) => new(ElementType.head, false, content);

    /// <inheritdoc cref="head(Content[])" />
    public static Element head(object content) => new(ElementType.head, false, content?.ToString()!);

    /// <summary>Introductory or navigational aids for a page or section.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<header></header>]]></c></returns>
    public static Element header(params Content[] content) => new(ElementType.header, false, content);

    /// <inheritdoc cref="header(Content[])" />
    public static Element header(object content) => new(ElementType.header, false, content?.ToString()!);

    /// <summary>Heading container.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<hgroup></hgroup>]]></c></returns>
    public static Element hgroup(params Content[] content) => new(ElementType.hgroup, false, content);

    /// <inheritdoc cref="hgroup(Content[])" />
    public static Element hgroup(object content) => new(ElementType.hgroup, false, content?.ToString()!);

    /// <summary>Thematic break.</summary>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<hr />]]></c></returns>
    public static Element hr(params Content[] content) => new(ElementType.hr, true, content);

    /// <summary>Root element.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<html></html>]]></c></returns>
    public static Element html(params Content[] content) => new(ElementType.html, false, content);

    /// <inheritdoc cref="html(Content[])" />
    public static Element html(object content) => new(ElementType.html, false, content?.ToString()!);

    /// <summary>Alternate voice.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<i></i>]]></c></returns>
    public static Element i(params Content[] content) => new(ElementType.i, false, content);

    /// <inheritdoc cref="i(Content[])" />
    public static Element i(object content) => new(ElementType.i, false, content?.ToString()!);

    /// <summary>Child navigable.</summary>
    /// <remarks>Attributes: <see cref="Attributes.src(string)"/>, <see cref="Attributes.srcdoc(string)"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.sandbox(string)"/>, <see cref="Attributes.allow(string)"/>, <see cref="Attributes.allowfullscreen()"/>, <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>, <see cref="Attributes.referrerpolicy(string)"/>, <see cref="Attributes.loading(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<iframe></iframe>]]></c></returns>
    public static Element iframe(params Content[] content) => new(ElementType.iframe, false, content);

    /// <inheritdoc cref="iframe(Content[])" />
    public static Element iframe(object content) => new(ElementType.iframe, false, content?.ToString()!);

    /// <summary>Image.</summary>
    /// <remarks>Attributes: <see cref="Attributes.alt(string)"/>, <see cref="Attributes.src(string)"/>, <see cref="Attributes.srcset(string)"/>, <see cref="Attributes.sizes(string)"/>, <see cref="Attributes.crossorigin(string)"/>, <see cref="Attributes.usemap(string)"/>, <see cref="Attributes.ismap()"/>, <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>, <see cref="Attributes.referrerpolicy(string)"/>, <see cref="Attributes.decoding(string)"/>, <see cref="Attributes.loading(string)"/>, <see cref="Attributes.fetchpriority(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<img />]]></c></returns>
    public static Element img(params Content[] content) => new(ElementType.img, true, content);

    /// <summary>Form control.</summary>
    /// <remarks>Attributes: <see cref="Attributes.accept(string)"/>, <see cref="Attributes.alt(string)"/>, <see cref="Attributes.autocomplete(string)"/>, <see cref="Attributes.checked_()"/>, <see cref="Attributes.dirname(string)"/>, <see cref="Attributes.disabled()"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.formaction(string)"/>, <see cref="Attributes.formenctype(string)"/>, <see cref="Attributes.formmethod(string)"/>, <see cref="Attributes.formnovalidate()"/>, <see cref="Attributes.formtarget(string)"/>, <see cref="Attributes.height(string)"/>, <see cref="Attributes.list(string)"/>, <see cref="Attributes.max(string)"/>, <see cref="Attributes.maxlength(string)"/>, <see cref="Attributes.min(string)"/>, <see cref="Attributes.minlength(string)"/>, <see cref="Attributes.multiple()"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.pattern(string)"/>, <see cref="Attributes.placeholder(string)"/>, <see cref="Attributes.popovertarget(string)"/>, <see cref="Attributes.popovertargetaction(string)"/>, <see cref="Attributes.readonly_()"/>, <see cref="Attributes.required()"/>, <see cref="Attributes.size(string)"/>, <see cref="Attributes.src(string)"/>, <see cref="Attributes.step(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.value(string)"/>, <see cref="Attributes.width(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<input />]]></c></returns>
    public static Element input(params Content[] content) => new(ElementType.input, true, content);

    /// <summary>An addition to the document.</summary>
    /// <remarks>Attributes: <see cref="Attributes.cite(string)"/>, <see cref="Attributes.datetime(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<ins></ins>]]></c></returns>
    public static Element ins(params Content[] content) => new(ElementType.ins, false, content);

    /// <inheritdoc cref="ins(Content[])" />
    public static Element ins(object content) => new(ElementType.ins, false, content?.ToString()!);

    /// <summary>User input.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<kbd></kbd>]]></c></returns>
    public static Element kbd(params Content[] content) => new(ElementType.kbd, false, content);

    /// <inheritdoc cref="kbd(Content[])" />
    public static Element kbd(object content) => new(ElementType.kbd, false, content?.ToString()!);

    /// <summary>Caption for a form control.</summary>
    /// <remarks>Attributes: <see cref="Attributes.for_(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<label></label>]]></c></returns>
    public static Element label(params Content[] content) => new(ElementType.label, false, content);

    /// <inheritdoc cref="label(Content[])" />
    public static Element label(object content) => new(ElementType.label, false, content?.ToString()!);

    /// <summary>Caption for fieldset.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<legend></legend>]]></c></returns>
    public static Element legend(params Content[] content) => new(ElementType.legend, false, content);

    /// <inheritdoc cref="legend(Content[])" />
    public static Element legend(object content) => new(ElementType.legend, false, content?.ToString()!);

    /// <summary>List item.</summary>
    /// <remarks>Attributes: <see cref="Attributes.value(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<li></li>]]></c></returns>
    public static Element li(params Content[] content) => new(ElementType.li, false, content);

    /// <inheritdoc cref="li(Content[])" />
    public static Element li(object content) => new(ElementType.li, false, content?.ToString()!);

    /// <summary>Link metadata.</summary>
    /// <remarks>Attributes: <see cref="Attributes.href(string)"/>, <see cref="Attributes.crossorigin(string)"/>, <see cref="Attributes.rel(string)"/>, <see cref="Attributes.as_(string)"/>, <see cref="Attributes.media(string)"/>, <see cref="Attributes.hreflang(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.sizes(string)"/>, <see cref="Attributes.imagesrcset(string)"/>, <see cref="Attributes.imagesizes(string)"/>, <see cref="Attributes.referrerpolicy(string)"/>, <see cref="Attributes.integrity(string)"/>, <see cref="Attributes.blocking(string)"/>, <see cref="Attributes.color(string)"/>, <see cref="Attributes.disabled()"/>, <see cref="Attributes.fetchpriority(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<link />]]></c></returns>
    public static Element link(params Content[] content) => new(ElementType.link, true, content);

    /// <summary>Container for the dominant contents of the document.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<main></main>]]></c></returns>
    public static Element main(params Content[] content) => new(ElementType.main, false, content);

    /// <inheritdoc cref="main(Content[])" />
    public static Element main(object content) => new(ElementType.main, false, content?.ToString()!);

    /// <summary>Image map.</summary>
    /// <remarks>Attributes: <see cref="Attributes.name(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<map></map>]]></c></returns>
    public static Element map(params Content[] content) => new(ElementType.map, false, content);

    /// <inheritdoc cref="map(Content[])" />
    public static Element map(object content) => new(ElementType.map, false, content?.ToString()!);

    /// <summary>Highlight.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<mark></mark>]]></c></returns>
    public static Element mark(params Content[] content) => new(ElementType.mark, false, content);

    /// <inheritdoc cref="mark(Content[])" />
    public static Element mark(object content) => new(ElementType.mark, false, content?.ToString()!);

    /// <summary>Menu of commands.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<menu></menu>]]></c></returns>
    public static Element menu(params Content[] content) => new(ElementType.menu, false, content);

    /// <inheritdoc cref="menu(Content[])" />
    public static Element menu(object content) => new(ElementType.menu, false, content?.ToString()!);

    /// <summary>Text metadata.</summary>
    /// <remarks>Attributes: <see cref="Attributes.name(string)"/>, <see cref="Attributes.http_equiv(string)"/>, <see cref="Attributes.content(string)"/>, <see cref="Attributes.charset(string)"/>, <see cref="Attributes.media(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<meta />]]></c></returns>
    public static Element meta(params Content[] content) => new(ElementType.meta, true, content);

    /// <summary>Gauge.</summary>
    /// <remarks>Attributes: <see cref="Attributes.value(string)"/>, <see cref="Attributes.min(string)"/>, <see cref="Attributes.max(string)"/>, <see cref="Attributes.low(string)"/>, <see cref="Attributes.high(string)"/>, <see cref="Attributes.optimum(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<meter></meter>]]></c></returns>
    public static Element meter(params Content[] content) => new(ElementType.meter, false, content);

    /// <inheritdoc cref="meter(Content[])" />
    public static Element meter(object content) => new(ElementType.meter, false, content?.ToString()!);

    /// <summary>Section with navigational links.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<nav></nav>]]></c></returns>
    public static Element nav(params Content[] content) => new(ElementType.nav, false, content);

    /// <inheritdoc cref="nav(Content[])" />
    public static Element nav(object content) => new(ElementType.nav, false, content?.ToString()!);

    /// <summary>Fallback content for script.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<noscript></noscript>]]></c></returns>
    public static Element noscript(params Content[] content) => new(ElementType.noscript, false, content);

    /// <inheritdoc cref="noscript(Content[])" />
    public static Element noscript(object content) => new(ElementType.noscript, false, content?.ToString()!);

    /// <summary>Image, child navigable, or plugin.</summary>
    /// <remarks>Attributes: <see cref="Attributes.data(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<object_></object_>]]></c></returns>
    public static Element object_(params Content[] content) => new(ElementType.object_, false, content);

    /// <inheritdoc cref="object_(Content[])" />
    public static Element object_(object content) => new(ElementType.object_, false, content?.ToString()!);

    /// <summary>Ordered list.</summary>
    /// <remarks>Attributes: <see cref="Attributes.reversed()"/>, <see cref="Attributes.start(string)"/>, <see cref="Attributes.type(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<ol></ol>]]></c></returns>
    public static Element ol(params Content[] content) => new(ElementType.ol, false, content);

    /// <inheritdoc cref="ol(Content[])" />
    public static Element ol(object content) => new(ElementType.ol, false, content?.ToString()!);

    /// <summary>Group of options in a list box.</summary>
    /// <remarks>Attributes: <see cref="Attributes.disabled()"/>, <see cref="Attributes.label(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<optgroup></optgroup>]]></c></returns>
    public static Element optgroup(params Content[] content) => new(ElementType.optgroup, false, content);

    /// <inheritdoc cref="optgroup(Content[])" />
    public static Element optgroup(object content) => new(ElementType.optgroup, false, content?.ToString()!);

    /// <summary>Option in a list box or combo box control.</summary>
    /// <remarks>Attributes: <see cref="Attributes.disabled()"/>, <see cref="Attributes.label(string)"/>, <see cref="Attributes.selected()"/>, <see cref="Attributes.value(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<option></option>]]></c></returns>
    public static Element option(params Content[] content) => new(ElementType.option, false, content);

    /// <inheritdoc cref="option(Content[])" />
    public static Element option(object content) => new(ElementType.option, false, content?.ToString()!);

    /// <summary>Calculated output value.</summary>
    /// <remarks>Attributes: <see cref="Attributes.for_(string)"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.name(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<output></output>]]></c></returns>
    public static Element output(params Content[] content) => new(ElementType.output, false, content);

    /// <inheritdoc cref="output(Content[])" />
    public static Element output(object content) => new(ElementType.output, false, content?.ToString()!);

    /// <summary>Paragraph.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<p></p>]]></c></returns>
    public static Element p(params Content[] content) => new(ElementType.p, false, content);

    /// <inheritdoc cref="p(Content[])" />
    public static Element p(object content) => new(ElementType.p, false, content?.ToString()!);

    /// <summary>Image.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<picture></picture>]]></c></returns>
    public static Element picture(params Content[] content) => new(ElementType.picture, false, content);

    /// <inheritdoc cref="picture(Content[])" />
    public static Element picture(object content) => new(ElementType.picture, false, content?.ToString()!);

    /// <summary>Block of preformatted text.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<pre></pre>]]></c></returns>
    public static Element pre(params Content[] content) => new(ElementType.pre, false, content);

    /// <inheritdoc cref="pre(Content[])" />
    public static Element pre(object content) => new(ElementType.pre, false, content?.ToString()!);

    /// <summary>Progress bar.</summary>
    /// <remarks>Attributes: <see cref="Attributes.value(string)"/>, <see cref="Attributes.max(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<progress></progress>]]></c></returns>
    public static Element progress(params Content[] content) => new(ElementType.progress, false, content);

    /// <inheritdoc cref="progress(Content[])" />
    public static Element progress(object content) => new(ElementType.progress, false, content?.ToString()!);

    /// <summary>Quotation.</summary>
    /// <remarks>Attributes: <see cref="Attributes.cite(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<q></q>]]></c></returns>
    public static Element q(params Content[] content) => new(ElementType.q, false, content);

    /// <inheritdoc cref="q(Content[])" />
    public static Element q(object content) => new(ElementType.q, false, content?.ToString()!);

    /// <summary>Parenthesis for ruby annotation text.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<rp></rp>]]></c></returns>
    public static Element rp(params Content[] content) => new(ElementType.rp, false, content);

    /// <inheritdoc cref="rp(Content[])" />
    public static Element rp(object content) => new(ElementType.rp, false, content?.ToString()!);

    /// <summary>Ruby annotation text.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<rt></rt>]]></c></returns>
    public static Element rt(params Content[] content) => new(ElementType.rt, false, content);

    /// <inheritdoc cref="rt(Content[])" />
    public static Element rt(object content) => new(ElementType.rt, false, content?.ToString()!);

    /// <summary>Ruby annotation(s).</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<ruby></ruby>]]></c></returns>
    public static Element ruby(params Content[] content) => new(ElementType.ruby, false, content);

    /// <inheritdoc cref="ruby(Content[])" />
    public static Element ruby(object content) => new(ElementType.ruby, false, content?.ToString()!);

    /// <summary>Inaccurate text.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<s></s>]]></c></returns>
    public static Element s(params Content[] content) => new(ElementType.s, false, content);

    /// <inheritdoc cref="s(Content[])" />
    public static Element s(object content) => new(ElementType.s, false, content?.ToString()!);

    /// <summary>Computer output.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<samp></samp>]]></c></returns>
    public static Element samp(params Content[] content) => new(ElementType.samp, false, content);

    /// <inheritdoc cref="samp(Content[])" />
    public static Element samp(object content) => new(ElementType.samp, false, content?.ToString()!);

    /// <summary>Embedded script.</summary>
    /// <remarks>Attributes: <see cref="Attributes.src(string)"/>, <see cref="Attributes.type(string)"/>, <see cref="Attributes.nomodule()"/>, <see cref="Attributes.async()"/>, <see cref="Attributes.defer()"/>, <see cref="Attributes.crossorigin(string)"/>, <see cref="Attributes.integrity(string)"/>, <see cref="Attributes.referrerpolicy(string)"/>, <see cref="Attributes.blocking(string)"/>, <see cref="Attributes.fetchpriority(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<script></script>]]></c></returns>
    public static Element script(params Content[] content) => new(ElementType.script, false, content);

    /// <inheritdoc cref="script(Content[])" />
    public static Element script(object content) => new(ElementType.script, false, content?.ToString()!);

    /// <summary>Container for search controls.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<search></search>]]></c></returns>
    public static Element search(params Content[] content) => new(ElementType.search, false, content);

    /// <inheritdoc cref="search(Content[])" />
    public static Element search(object content) => new(ElementType.search, false, content?.ToString()!);

    /// <summary>Generic document or application section.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<section></section>]]></c></returns>
    public static Element section(params Content[] content) => new(ElementType.section, false, content);

    /// <inheritdoc cref="section(Content[])" />
    public static Element section(object content) => new(ElementType.section, false, content?.ToString()!);

    /// <summary>List box control.</summary>
    /// <remarks>Attributes: <see cref="Attributes.autocomplete(string)"/>, <see cref="Attributes.disabled()"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.multiple()"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.required()"/>, <see cref="Attributes.size(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<select></select>]]></c></returns>
    public static Element select(params Content[] content) => new(ElementType.select, false, content);

    /// <inheritdoc cref="select(Content[])" />
    public static Element select(object content) => new(ElementType.select, false, content?.ToString()!);

    /// <summary>Shadow tree slot.</summary>
    /// <remarks>Attributes: <see cref="Attributes.name(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<slot></slot>]]></c></returns>
    public static Element slot(params Content[] content) => new(ElementType.slot, false, content);

    /// <inheritdoc cref="slot(Content[])" />
    public static Element slot(object content) => new(ElementType.slot, false, content?.ToString()!);

    /// <summary>Side comment.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<small></small>]]></c></returns>
    public static Element small(params Content[] content) => new(ElementType.small, false, content);

    /// <inheritdoc cref="small(Content[])" />
    public static Element small(object content) => new(ElementType.small, false, content?.ToString()!);

    /// <summary>Image source for img or media source for video or audio.</summary>
    /// <remarks>Attributes: <see cref="Attributes.type(string)"/>, <see cref="Attributes.media(string)"/>, <see cref="Attributes.src(string)"/>, <see cref="Attributes.srcset(string)"/>, <see cref="Attributes.sizes(string)"/>, <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<source />]]></c></returns>
    public static Element source(params Content[] content) => new(ElementType.source, true, content);

    /// <summary>Generic phrasing container.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<span></span>]]></c></returns>
    public static Element span(params Content[] content) => new(ElementType.span, false, content);

    /// <inheritdoc cref="span(Content[])" />
    public static Element span(object content) => new(ElementType.span, false, content?.ToString()!);

    /// <summary>Importance.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<strong></strong>]]></c></returns>
    public static Element strong(params Content[] content) => new(ElementType.strong, false, content);

    /// <inheritdoc cref="strong(Content[])" />
    public static Element strong(object content) => new(ElementType.strong, false, content?.ToString()!);

    /// <summary>Embedded styling information.</summary>
    /// <remarks>Attributes: <see cref="Attributes.media(string)"/>, <see cref="Attributes.blocking(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<style></style>]]></c></returns>
    public static Element style(params Content[] content) => new(ElementType.style, false, content);

    /// <inheritdoc cref="style(Content[])" />
    public static Element style(object content) => new(ElementType.style, false, content?.ToString()!);

    /// <summary>Subscript.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<sub></sub>]]></c></returns>
    public static Element sub(params Content[] content) => new(ElementType.sub, false, content);

    /// <inheritdoc cref="sub(Content[])" />
    public static Element sub(object content) => new(ElementType.sub, false, content?.ToString()!);

    /// <summary>Caption for details.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<summary></summary>]]></c></returns>
    public static Element summary(params Content[] content) => new(ElementType.summary, false, content);

    /// <inheritdoc cref="summary(Content[])" />
    public static Element summary(object content) => new(ElementType.summary, false, content?.ToString()!);

    /// <summary>Superscript.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<sup></sup>]]></c></returns>
    public static Element sup(params Content[] content) => new(ElementType.sup, false, content);

    /// <inheritdoc cref="sup(Content[])" />
    public static Element sup(object content) => new(ElementType.sup, false, content?.ToString()!);

    /// <summary>Table.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<table></table>]]></c></returns>
    public static Element table(params Content[] content) => new(ElementType.table, false, content);

    /// <inheritdoc cref="table(Content[])" />
    public static Element table(object content) => new(ElementType.table, false, content?.ToString()!);

    /// <summary>Group of rows in a table.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<tbody></tbody>]]></c></returns>
    public static Element tbody(params Content[] content) => new(ElementType.tbody, false, content);

    /// <inheritdoc cref="tbody(Content[])" />
    public static Element tbody(object content) => new(ElementType.tbody, false, content?.ToString()!);

    /// <summary>Table cell.</summary>
    /// <remarks>Attributes: <see cref="Attributes.colspan(string)"/>, <see cref="Attributes.rowspan(string)"/>, <see cref="Attributes.headers(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<td></td>]]></c></returns>
    public static Element td(params Content[] content) => new(ElementType.td, false, content);

    /// <inheritdoc cref="td(Content[])" />
    public static Element td(object content) => new(ElementType.td, false, content?.ToString()!);

    /// <summary>Template.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<template></template>]]></c></returns>
    public static Element template(params Content[] content) => new(ElementType.template, false, content);

    /// <inheritdoc cref="template(Content[])" />
    public static Element template(object content) => new(ElementType.template, false, content?.ToString()!);

    /// <summary>Multiline text controls.</summary>
    /// <remarks>Attributes: <see cref="Attributes.autocomplete(string)"/>, <see cref="Attributes.cols(string)"/>, <see cref="Attributes.dirname(string)"/>, <see cref="Attributes.disabled()"/>, <see cref="Attributes.form(string)"/>, <see cref="Attributes.maxlength(string)"/>, <see cref="Attributes.minlength(string)"/>, <see cref="Attributes.name(string)"/>, <see cref="Attributes.placeholder(string)"/>, <see cref="Attributes.readonly_()"/>, <see cref="Attributes.required()"/>, <see cref="Attributes.rows(string)"/>, <see cref="Attributes.wrap(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<textarea></textarea>]]></c></returns>
    public static Element textarea(params Content[] content) => new(ElementType.textarea, false, content);

    /// <inheritdoc cref="textarea(Content[])" />
    public static Element textarea(object content) => new(ElementType.textarea, false, content?.ToString()!);

    /// <summary>Group of footer rows in a table.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<tfoot></tfoot>]]></c></returns>
    public static Element tfoot(params Content[] content) => new(ElementType.tfoot, false, content);

    /// <inheritdoc cref="tfoot(Content[])" />
    public static Element tfoot(object content) => new(ElementType.tfoot, false, content?.ToString()!);

    /// <summary>Table header cell.</summary>
    /// <remarks>Attributes: <see cref="Attributes.colspan(string)"/>, <see cref="Attributes.rowspan(string)"/>, <see cref="Attributes.headers(string)"/>, <see cref="Attributes.scope(string)"/>, <see cref="Attributes.abbr(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<th></th>]]></c></returns>
    public static Element th(params Content[] content) => new(ElementType.th, false, content);

    /// <inheritdoc cref="th(Content[])" />
    public static Element th(object content) => new(ElementType.th, false, content?.ToString()!);

    /// <summary>Group of heading rows in a table.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<thead></thead>]]></c></returns>
    public static Element thead(params Content[] content) => new(ElementType.thead, false, content);

    /// <inheritdoc cref="thead(Content[])" />
    public static Element thead(object content) => new(ElementType.thead, false, content?.ToString()!);

    /// <summary>Machine-readable equivalent of date- or time-related data.</summary>
    /// <remarks>Attributes: <see cref="Attributes.datetime(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<time></time>]]></c></returns>
    public static Element time(params Content[] content) => new(ElementType.time, false, content);

    /// <inheritdoc cref="time(Content[])" />
    public static Element time(object content) => new(ElementType.time, false, content?.ToString()!);

    /// <summary>Document title.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<title></title>]]></c></returns>
    public static Element title(params Content[] content) => new(ElementType.title, false, content);

    /// <inheritdoc cref="title(Content[])" />
    public static Element title(object content) => new(ElementType.title, false, content?.ToString()!);

    /// <summary>Table row.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<tr></tr>]]></c></returns>
    public static Element tr(params Content[] content) => new(ElementType.tr, false, content);

    /// <inheritdoc cref="tr(Content[])" />
    public static Element tr(object content) => new(ElementType.tr, false, content?.ToString()!);

    /// <summary>Timed text track.</summary>
    /// <remarks>Attributes: <see cref="Attributes.default_()"/>, <see cref="Attributes.kind(string)"/>, <see cref="Attributes.label(string)"/>, <see cref="Attributes.src(string)"/>, <see cref="Attributes.srclang(string)"/>.</remarks>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<track />]]></c></returns>
    public static Element track(params Content[] content) => new(ElementType.track, true, content);

    /// <summary>Unarticulated annotation.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<u></u>]]></c></returns>
    public static Element u(params Content[] content) => new(ElementType.u, false, content);

    /// <inheritdoc cref="u(Content[])" />
    public static Element u(object content) => new(ElementType.u, false, content?.ToString()!);

    /// <summary>List.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<ul></ul>]]></c></returns>
    public static Element ul(params Content[] content) => new(ElementType.ul, false, content);

    /// <inheritdoc cref="ul(Content[])" />
    public static Element ul(object content) => new(ElementType.ul, false, content?.ToString()!);

    /// <summary>Variable.</summary>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<var></var>]]></c></returns>
    public static Element var(params Content[] content) => new(ElementType.var, false, content);

    /// <inheritdoc cref="var(Content[])" />
    public static Element var(object content) => new(ElementType.var, false, content?.ToString()!);

    /// <summary>Video player.</summary>
    /// <remarks>Attributes: <see cref="Attributes.src(string)"/>, <see cref="Attributes.crossorigin(string)"/>, <see cref="Attributes.poster(string)"/>, <see cref="Attributes.preload(string)"/>, <see cref="Attributes.autoplay()"/>, <see cref="Attributes.playsinline()"/>, <see cref="Attributes.loop()"/>, <see cref="Attributes.muted()"/>, <see cref="Attributes.controls()"/>, <see cref="Attributes.width(string)"/>, <see cref="Attributes.height(string)"/>.</remarks>
    /// <param name="content">Attributes, elements and content.</param>
    /// <returns><c><![CDATA[<video></video>]]></c></returns>
    public static Element video(params Content[] content) => new(ElementType.video, false, content);

    /// <inheritdoc cref="video(Content[])" />
    public static Element video(object content) => new(ElementType.video, false, content?.ToString()!);

    /// <summary>Line breaking opportunity.</summary>
    /// <param name="content">Attributes.</param>
    /// <returns><c><![CDATA[<wbr />]]></c></returns>
    public static Element wbr(params Content[] content) => new(ElementType.wbr, true, content);
}
