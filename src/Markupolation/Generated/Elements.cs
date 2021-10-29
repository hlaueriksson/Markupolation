namespace Markupolation
{
    /// <summary>HTML elements.</summary>
    public static partial class Elements
    {
        /// <summary>Hyperlink.</summary>
        /// <remarks>Attributes: <see cref="Attributes.href"/>, <see cref="Attributes.target"/>, <see cref="Attributes.download"/>, <see cref="Attributes.rel"/>, <see cref="Attributes.hreflang"/>, <see cref="Attributes.type"/>, <see cref="Attributes.referrerpolicy"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<a></a>]]></code></returns>
        public static Element a(params Content[] content) => new(ElementType.a, false, content);

        /// <inheritdoc cref="a" />
        public static Element a(object content) => new(ElementType.a, false, content?.ToString()!);

        /// <summary>Abbreviation.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<abbr></abbr>]]></code></returns>
        public static Element abbr(params Content[] content) => new(ElementType.abbr, false, content);

        /// <inheritdoc cref="abbr" />
        public static Element abbr(object content) => new(ElementType.abbr, false, content?.ToString()!);

        /// <summary>Contact information for a page or article element.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<address></address>]]></code></returns>
        public static Element address(params Content[] content) => new(ElementType.address, false, content);

        /// <inheritdoc cref="address" />
        public static Element address(object content) => new(ElementType.address, false, content?.ToString()!);

        /// <summary>Hyperlink or dead area on an image map.</summary>
        /// <remarks>Attributes: <see cref="Attributes.alt"/>, <see cref="Attributes.coords"/>, <see cref="Attributes.shape"/>, <see cref="Attributes.href"/>, <see cref="Attributes.target"/>, <see cref="Attributes.download"/>, <see cref="Attributes.rel"/>, <see cref="Attributes.referrerpolicy"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<area />]]></code></returns>
        public static Element area(params Content[] content) => new(ElementType.area, true, content);

        /// <summary>Self-contained syndicatable or reusable composition.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<article></article>]]></code></returns>
        public static Element article(params Content[] content) => new(ElementType.article, false, content);

        /// <inheritdoc cref="article" />
        public static Element article(object content) => new(ElementType.article, false, content?.ToString()!);

        /// <summary>Sidebar for tangentially related content.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<aside></aside>]]></code></returns>
        public static Element aside(params Content[] content) => new(ElementType.aside, false, content);

        /// <inheritdoc cref="aside" />
        public static Element aside(object content) => new(ElementType.aside, false, content?.ToString()!);

        /// <summary>Audio player.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.preload"/>, <see cref="Attributes.autoplay"/>, <see cref="Attributes.loop"/>, <see cref="Attributes.muted"/>, <see cref="Attributes.controls"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<audio></audio>]]></code></returns>
        public static Element audio(params Content[] content) => new(ElementType.audio, false, content);

        /// <inheritdoc cref="audio" />
        public static Element audio(object content) => new(ElementType.audio, false, content?.ToString()!);

        /// <summary>Keywords.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<b></b>]]></code></returns>
        public static Element b(params Content[] content) => new(ElementType.b, false, content);

        /// <inheritdoc cref="b" />
        public static Element b(object content) => new(ElementType.b, false, content?.ToString()!);

        /// <summary>Base URL and default target browsing context for hyperlinks and forms.</summary>
        /// <remarks>Attributes: <see cref="Attributes.href"/>, <see cref="Attributes.target"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<base_ />]]></code></returns>
        public static Element base_(params Content[] content) => new(ElementType.base_, true, content);

        /// <summary>Text directionality isolation.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<bdi></bdi>]]></code></returns>
        public static Element bdi(params Content[] content) => new(ElementType.bdi, false, content);

        /// <inheritdoc cref="bdi" />
        public static Element bdi(object content) => new(ElementType.bdi, false, content?.ToString()!);

        /// <summary>Text directionality formatting.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<bdo></bdo>]]></code></returns>
        public static Element bdo(params Content[] content) => new(ElementType.bdo, false, content);

        /// <inheritdoc cref="bdo" />
        public static Element bdo(object content) => new(ElementType.bdo, false, content?.ToString()!);

        /// <summary>A section quoted from another source.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<blockquote></blockquote>]]></code></returns>
        public static Element blockquote(params Content[] content) => new(ElementType.blockquote, false, content);

        /// <inheritdoc cref="blockquote" />
        public static Element blockquote(object content) => new(ElementType.blockquote, false, content?.ToString()!);

        /// <summary>Document body.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<body></body>]]></code></returns>
        public static Element body(params Content[] content) => new(ElementType.body, false, content);

        /// <inheritdoc cref="body" />
        public static Element body(object content) => new(ElementType.body, false, content?.ToString()!);

        /// <summary>Line break, e.g. in poem or postal address.</summary>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<br />]]></code></returns>
        public static Element br(params Content[] content) => new(ElementType.br, true, content);

        /// <summary>Button control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.formaction"/>, <see cref="Attributes.formenctype"/>, <see cref="Attributes.formmethod"/>, <see cref="Attributes.formnovalidate"/>, <see cref="Attributes.formtarget"/>, <see cref="Attributes.name"/>, <see cref="Attributes.type"/>, <see cref="Attributes.value"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<button></button>]]></code></returns>
        public static Element button(params Content[] content) => new(ElementType.button, false, content);

        /// <inheritdoc cref="button" />
        public static Element button(object content) => new(ElementType.button, false, content?.ToString()!);

        /// <summary>Scriptable bitmap canvas.</summary>
        /// <remarks>Attributes: <see cref="Attributes.width"/>, <see cref="Attributes.height"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<canvas></canvas>]]></code></returns>
        public static Element canvas(params Content[] content) => new(ElementType.canvas, false, content);

        /// <inheritdoc cref="canvas" />
        public static Element canvas(object content) => new(ElementType.canvas, false, content?.ToString()!);

        /// <summary>Table caption.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<caption></caption>]]></code></returns>
        public static Element caption(params Content[] content) => new(ElementType.caption, false, content);

        /// <inheritdoc cref="caption" />
        public static Element caption(object content) => new(ElementType.caption, false, content?.ToString()!);

        /// <summary>Title of a work.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<cite></cite>]]></code></returns>
        public static Element cite(params Content[] content) => new(ElementType.cite, false, content);

        /// <inheritdoc cref="cite" />
        public static Element cite(object content) => new(ElementType.cite, false, content?.ToString()!);

        /// <summary>Computer code.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<code></code>]]></code></returns>
        public static Element code(params Content[] content) => new(ElementType.code, false, content);

        /// <inheritdoc cref="code" />
        public static Element code(object content) => new(ElementType.code, false, content?.ToString()!);

        /// <summary>Table column.</summary>
        /// <remarks>Attributes: <see cref="Attributes.span"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<col />]]></code></returns>
        public static Element col(params Content[] content) => new(ElementType.col, true, content);

        /// <summary>Group of columns in a table.</summary>
        /// <remarks>Attributes: <see cref="Attributes.span"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<colgroup></colgroup>]]></code></returns>
        public static Element colgroup(params Content[] content) => new(ElementType.colgroup, false, content);

        /// <inheritdoc cref="colgroup" />
        public static Element colgroup(object content) => new(ElementType.colgroup, false, content?.ToString()!);

        /// <summary>Machine-readable equivalent.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<data></data>]]></code></returns>
        public static Element data(params Content[] content) => new(ElementType.data, false, content);

        /// <inheritdoc cref="data" />
        public static Element data(object content) => new(ElementType.data, false, content?.ToString()!);

        /// <summary>Container for options for combo box control.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<datalist></datalist>]]></code></returns>
        public static Element datalist(params Content[] content) => new(ElementType.datalist, false, content);

        /// <inheritdoc cref="datalist" />
        public static Element datalist(object content) => new(ElementType.datalist, false, content?.ToString()!);

        /// <summary>Content for corresponding dt element(s).</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dd></dd>]]></code></returns>
        public static Element dd(params Content[] content) => new(ElementType.dd, false, content);

        /// <inheritdoc cref="dd" />
        public static Element dd(object content) => new(ElementType.dd, false, content?.ToString()!);

        /// <summary>A removal from the document.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/>, <see cref="Attributes.datetime"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<del></del>]]></code></returns>
        public static Element del(params Content[] content) => new(ElementType.del, false, content);

        /// <inheritdoc cref="del" />
        public static Element del(object content) => new(ElementType.del, false, content?.ToString()!);

        /// <summary>Disclosure control for hiding details.</summary>
        /// <remarks>Attributes: <see cref="Attributes.open"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<details></details>]]></code></returns>
        public static Element details(params Content[] content) => new(ElementType.details, false, content);

        /// <inheritdoc cref="details" />
        public static Element details(object content) => new(ElementType.details, false, content?.ToString()!);

        /// <summary>Defining instance.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dfn></dfn>]]></code></returns>
        public static Element dfn(params Content[] content) => new(ElementType.dfn, false, content);

        /// <inheritdoc cref="dfn" />
        public static Element dfn(object content) => new(ElementType.dfn, false, content?.ToString()!);

        /// <summary>Dialog box or window.</summary>
        /// <remarks>Attributes: <see cref="Attributes.open"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dialog></dialog>]]></code></returns>
        public static Element dialog(params Content[] content) => new(ElementType.dialog, false, content);

        /// <inheritdoc cref="dialog" />
        public static Element dialog(object content) => new(ElementType.dialog, false, content?.ToString()!);

        /// <summary>Generic flow container, or container for name-value groups in dl elements.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<div></div>]]></code></returns>
        public static Element div(params Content[] content) => new(ElementType.div, false, content);

        /// <inheritdoc cref="div" />
        public static Element div(object content) => new(ElementType.div, false, content?.ToString()!);

        /// <summary>Association list consisting of zero or more name-value groups.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dl></dl>]]></code></returns>
        public static Element dl(params Content[] content) => new(ElementType.dl, false, content);

        /// <inheritdoc cref="dl" />
        public static Element dl(object content) => new(ElementType.dl, false, content?.ToString()!);

        /// <summary>Legend for corresponding dd element(s).</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dt></dt>]]></code></returns>
        public static Element dt(params Content[] content) => new(ElementType.dt, false, content);

        /// <inheritdoc cref="dt" />
        public static Element dt(object content) => new(ElementType.dt, false, content?.ToString()!);

        /// <summary>Stress emphasis.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<em></em>]]></code></returns>
        public static Element em(params Content[] content) => new(ElementType.em, false, content);

        /// <inheritdoc cref="em" />
        public static Element em(object content) => new(ElementType.em, false, content?.ToString()!);

        /// <summary>Plugin.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.type"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<embed />]]></code></returns>
        public static Element embed(params Content[] content) => new(ElementType.embed, true, content);

        /// <summary>Group of form controls.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.name"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<fieldset></fieldset>]]></code></returns>
        public static Element fieldset(params Content[] content) => new(ElementType.fieldset, false, content);

        /// <inheritdoc cref="fieldset" />
        public static Element fieldset(object content) => new(ElementType.fieldset, false, content?.ToString()!);

        /// <summary>Caption for figure.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<figcaption></figcaption>]]></code></returns>
        public static Element figcaption(params Content[] content) => new(ElementType.figcaption, false, content);

        /// <inheritdoc cref="figcaption" />
        public static Element figcaption(object content) => new(ElementType.figcaption, false, content?.ToString()!);

        /// <summary>Figure with optional caption.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<figure></figure>]]></code></returns>
        public static Element figure(params Content[] content) => new(ElementType.figure, false, content);

        /// <inheritdoc cref="figure" />
        public static Element figure(object content) => new(ElementType.figure, false, content?.ToString()!);

        /// <summary>Footer for a page or section.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<footer></footer>]]></code></returns>
        public static Element footer(params Content[] content) => new(ElementType.footer, false, content);

        /// <inheritdoc cref="footer" />
        public static Element footer(object content) => new(ElementType.footer, false, content?.ToString()!);

        /// <summary>User-submittable form.</summary>
        /// <remarks>Attributes: <see cref="Attributes.accept_charset"/>, <see cref="Attributes.action"/>, <see cref="Attributes.autocomplete"/>, <see cref="Attributes.enctype"/>, <see cref="Attributes.method"/>, <see cref="Attributes.name"/>, <see cref="Attributes.novalidate"/>, <see cref="Attributes.target"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<form></form>]]></code></returns>
        public static Element form(params Content[] content) => new(ElementType.form, false, content);

        /// <inheritdoc cref="form" />
        public static Element form(object content) => new(ElementType.form, false, content?.ToString()!);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h1></h1>]]></code></returns>
        public static Element h1(params Content[] content) => new(ElementType.h1, false, content);

        /// <inheritdoc cref="h1" />
        public static Element h1(object content) => new(ElementType.h1, false, content?.ToString()!);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h2></h2>]]></code></returns>
        public static Element h2(params Content[] content) => new(ElementType.h2, false, content);

        /// <inheritdoc cref="h2" />
        public static Element h2(object content) => new(ElementType.h2, false, content?.ToString()!);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h3></h3>]]></code></returns>
        public static Element h3(params Content[] content) => new(ElementType.h3, false, content);

        /// <inheritdoc cref="h3" />
        public static Element h3(object content) => new(ElementType.h3, false, content?.ToString()!);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h4></h4>]]></code></returns>
        public static Element h4(params Content[] content) => new(ElementType.h4, false, content);

        /// <inheritdoc cref="h4" />
        public static Element h4(object content) => new(ElementType.h4, false, content?.ToString()!);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h5></h5>]]></code></returns>
        public static Element h5(params Content[] content) => new(ElementType.h5, false, content);

        /// <inheritdoc cref="h5" />
        public static Element h5(object content) => new(ElementType.h5, false, content?.ToString()!);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h6></h6>]]></code></returns>
        public static Element h6(params Content[] content) => new(ElementType.h6, false, content);

        /// <inheritdoc cref="h6" />
        public static Element h6(object content) => new(ElementType.h6, false, content?.ToString()!);

        /// <summary>Container for document metadata.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<head></head>]]></code></returns>
        public static Element head(params Content[] content) => new(ElementType.head, false, content);

        /// <inheritdoc cref="head" />
        public static Element head(object content) => new(ElementType.head, false, content?.ToString()!);

        /// <summary>Introductory or navigational aids for a page or section.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<header></header>]]></code></returns>
        public static Element header(params Content[] content) => new(ElementType.header, false, content);

        /// <inheritdoc cref="header" />
        public static Element header(object content) => new(ElementType.header, false, content?.ToString()!);

        /// <summary>heading group.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<hgroup></hgroup>]]></code></returns>
        public static Element hgroup(params Content[] content) => new(ElementType.hgroup, false, content);

        /// <inheritdoc cref="hgroup" />
        public static Element hgroup(object content) => new(ElementType.hgroup, false, content?.ToString()!);

        /// <summary>Thematic break.</summary>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<hr />]]></code></returns>
        public static Element hr(params Content[] content) => new(ElementType.hr, true, content);

        /// <summary>Root element.</summary>
        /// <remarks>Attributes: <see cref="Attributes.manifest"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<html></html>]]></code></returns>
        public static Element html(params Content[] content) => new(ElementType.html, false, content);

        /// <inheritdoc cref="html" />
        public static Element html(object content) => new(ElementType.html, false, content?.ToString()!);

        /// <summary>Alternate voice.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<i></i>]]></code></returns>
        public static Element i(params Content[] content) => new(ElementType.i, false, content);

        /// <inheritdoc cref="i" />
        public static Element i(object content) => new(ElementType.i, false, content?.ToString()!);

        /// <summary>Nested browsing context.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.srcdoc"/>, <see cref="Attributes.name"/>, <see cref="Attributes.sandbox"/>, <see cref="Attributes.allow"/>, <see cref="Attributes.allowfullscreen"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>, <see cref="Attributes.referrerpolicy"/>, <see cref="Attributes.loading"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<iframe></iframe>]]></code></returns>
        public static Element iframe(params Content[] content) => new(ElementType.iframe, false, content);

        /// <inheritdoc cref="iframe" />
        public static Element iframe(object content) => new(ElementType.iframe, false, content?.ToString()!);

        /// <summary>Image.</summary>
        /// <remarks>Attributes: <see cref="Attributes.alt"/>, <see cref="Attributes.src"/>, <see cref="Attributes.srcset"/>, <see cref="Attributes.sizes"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.usemap"/>, <see cref="Attributes.ismap"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>, <see cref="Attributes.referrerpolicy"/>, <see cref="Attributes.decoding"/>, <see cref="Attributes.loading"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<img />]]></code></returns>
        public static Element img(params Content[] content) => new(ElementType.img, true, content);

        /// <summary>Form control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.accept"/>, <see cref="Attributes.alt"/>, <see cref="Attributes.autocomplete"/>, <see cref="Attributes.checked_"/>, <see cref="Attributes.dirname"/>, <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.formaction"/>, <see cref="Attributes.formenctype"/>, <see cref="Attributes.formmethod"/>, <see cref="Attributes.formnovalidate"/>, <see cref="Attributes.formtarget"/>, <see cref="Attributes.height"/>, <see cref="Attributes.list"/>, <see cref="Attributes.max"/>, <see cref="Attributes.maxlength"/>, <see cref="Attributes.min"/>, <see cref="Attributes.minlength"/>, <see cref="Attributes.multiple"/>, <see cref="Attributes.name"/>, <see cref="Attributes.pattern"/>, <see cref="Attributes.placeholder"/>, <see cref="Attributes.readonly_"/>, <see cref="Attributes.required"/>, <see cref="Attributes.size"/>, <see cref="Attributes.src"/>, <see cref="Attributes.step"/>, <see cref="Attributes.type"/>, <see cref="Attributes.value"/>, <see cref="Attributes.width"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<input />]]></code></returns>
        public static Element input(params Content[] content) => new(ElementType.input, true, content);

        /// <summary>An addition to the document.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/>, <see cref="Attributes.datetime"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ins></ins>]]></code></returns>
        public static Element ins(params Content[] content) => new(ElementType.ins, false, content);

        /// <inheritdoc cref="ins" />
        public static Element ins(object content) => new(ElementType.ins, false, content?.ToString()!);

        /// <summary>User input.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<kbd></kbd>]]></code></returns>
        public static Element kbd(params Content[] content) => new(ElementType.kbd, false, content);

        /// <inheritdoc cref="kbd" />
        public static Element kbd(object content) => new(ElementType.kbd, false, content?.ToString()!);

        /// <summary>Caption for a form control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.for_"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<label></label>]]></code></returns>
        public static Element label(params Content[] content) => new(ElementType.label, false, content);

        /// <inheritdoc cref="label" />
        public static Element label(object content) => new(ElementType.label, false, content?.ToString()!);

        /// <summary>Caption for fieldset.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<legend></legend>]]></code></returns>
        public static Element legend(params Content[] content) => new(ElementType.legend, false, content);

        /// <inheritdoc cref="legend" />
        public static Element legend(object content) => new(ElementType.legend, false, content?.ToString()!);

        /// <summary>List item.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<li></li>]]></code></returns>
        public static Element li(params Content[] content) => new(ElementType.li, false, content);

        /// <inheritdoc cref="li" />
        public static Element li(object content) => new(ElementType.li, false, content?.ToString()!);

        /// <summary>Link metadata.</summary>
        /// <remarks>Attributes: <see cref="Attributes.href"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.rel"/>, <see cref="Attributes.as_"/>, <see cref="Attributes.media"/>, <see cref="Attributes.hreflang"/>, <see cref="Attributes.type"/>, <see cref="Attributes.sizes"/>, <see cref="Attributes.imagesrcset"/>, <see cref="Attributes.imagesizes"/>, <see cref="Attributes.referrerpolicy"/>, <see cref="Attributes.integrity"/>, <see cref="Attributes.color"/>, <see cref="Attributes.disabled"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<link />]]></code></returns>
        public static Element link(params Content[] content) => new(ElementType.link, true, content);

        /// <summary>Container for the dominant contents of the document.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<main></main>]]></code></returns>
        public static Element main(params Content[] content) => new(ElementType.main, false, content);

        /// <inheritdoc cref="main" />
        public static Element main(object content) => new(ElementType.main, false, content?.ToString()!);

        /// <summary>Image map.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<map></map>]]></code></returns>
        public static Element map(params Content[] content) => new(ElementType.map, false, content);

        /// <inheritdoc cref="map" />
        public static Element map(object content) => new(ElementType.map, false, content?.ToString()!);

        /// <summary>Highlight.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<mark></mark>]]></code></returns>
        public static Element mark(params Content[] content) => new(ElementType.mark, false, content);

        /// <inheritdoc cref="mark" />
        public static Element mark(object content) => new(ElementType.mark, false, content?.ToString()!);

        /// <summary>Menu of commands.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<menu></menu>]]></code></returns>
        public static Element menu(params Content[] content) => new(ElementType.menu, false, content);

        /// <inheritdoc cref="menu" />
        public static Element menu(object content) => new(ElementType.menu, false, content?.ToString()!);

        /// <summary>Text metadata.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/>, <see cref="Attributes.http_equiv"/>, <see cref="Attributes.content"/>, <see cref="Attributes.charset"/>, <see cref="Attributes.media"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<meta />]]></code></returns>
        public static Element meta(params Content[] content) => new(ElementType.meta, true, content);

        /// <summary>Gauge.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/>, <see cref="Attributes.min"/>, <see cref="Attributes.max"/>, <see cref="Attributes.low"/>, <see cref="Attributes.high"/>, <see cref="Attributes.optimum"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<meter></meter>]]></code></returns>
        public static Element meter(params Content[] content) => new(ElementType.meter, false, content);

        /// <inheritdoc cref="meter" />
        public static Element meter(object content) => new(ElementType.meter, false, content?.ToString()!);

        /// <summary>Section with navigational links.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<nav></nav>]]></code></returns>
        public static Element nav(params Content[] content) => new(ElementType.nav, false, content);

        /// <inheritdoc cref="nav" />
        public static Element nav(object content) => new(ElementType.nav, false, content?.ToString()!);

        /// <summary>Fallback content for script.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<noscript></noscript>]]></code></returns>
        public static Element noscript(params Content[] content) => new(ElementType.noscript, false, content);

        /// <inheritdoc cref="noscript" />
        public static Element noscript(object content) => new(ElementType.noscript, false, content?.ToString()!);

        /// <summary>Image, nested browsing context, or plugin.</summary>
        /// <remarks>Attributes: <see cref="Attributes.data"/>, <see cref="Attributes.type"/>, <see cref="Attributes.name"/>, <see cref="Attributes.form"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<object_></object_>]]></code></returns>
        public static Element object_(params Content[] content) => new(ElementType.object_, false, content);

        /// <inheritdoc cref="object_" />
        public static Element object_(object content) => new(ElementType.object_, false, content?.ToString()!);

        /// <summary>Ordered list.</summary>
        /// <remarks>Attributes: <see cref="Attributes.reversed"/>, <see cref="Attributes.start"/>, <see cref="Attributes.type"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ol></ol>]]></code></returns>
        public static Element ol(params Content[] content) => new(ElementType.ol, false, content);

        /// <inheritdoc cref="ol" />
        public static Element ol(object content) => new(ElementType.ol, false, content?.ToString()!);

        /// <summary>Group of options in a list box.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.label"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<optgroup></optgroup>]]></code></returns>
        public static Element optgroup(params Content[] content) => new(ElementType.optgroup, false, content);

        /// <inheritdoc cref="optgroup" />
        public static Element optgroup(object content) => new(ElementType.optgroup, false, content?.ToString()!);

        /// <summary>Option in a list box or combo box control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.label"/>, <see cref="Attributes.selected"/>, <see cref="Attributes.value"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<option></option>]]></code></returns>
        public static Element option(params Content[] content) => new(ElementType.option, false, content);

        /// <inheritdoc cref="option" />
        public static Element option(object content) => new(ElementType.option, false, content?.ToString()!);

        /// <summary>Calculated output value.</summary>
        /// <remarks>Attributes: <see cref="Attributes.for_"/>, <see cref="Attributes.form"/>, <see cref="Attributes.name"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<output></output>]]></code></returns>
        public static Element output(params Content[] content) => new(ElementType.output, false, content);

        /// <inheritdoc cref="output" />
        public static Element output(object content) => new(ElementType.output, false, content?.ToString()!);

        /// <summary>Paragraph.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<p></p>]]></code></returns>
        public static Element p(params Content[] content) => new(ElementType.p, false, content);

        /// <inheritdoc cref="p" />
        public static Element p(object content) => new(ElementType.p, false, content?.ToString()!);

        /// <summary>Parameter for object.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/>, <see cref="Attributes.value"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<param />]]></code></returns>
        public static Element param(params Content[] content) => new(ElementType.param, true, content);

        /// <summary>Image.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<picture></picture>]]></code></returns>
        public static Element picture(params Content[] content) => new(ElementType.picture, false, content);

        /// <inheritdoc cref="picture" />
        public static Element picture(object content) => new(ElementType.picture, false, content?.ToString()!);

        /// <summary>Block of preformatted text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<pre></pre>]]></code></returns>
        public static Element pre(params Content[] content) => new(ElementType.pre, false, content);

        /// <inheritdoc cref="pre" />
        public static Element pre(object content) => new(ElementType.pre, false, content?.ToString()!);

        /// <summary>Progress bar.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/>, <see cref="Attributes.max"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<progress></progress>]]></code></returns>
        public static Element progress(params Content[] content) => new(ElementType.progress, false, content);

        /// <inheritdoc cref="progress" />
        public static Element progress(object content) => new(ElementType.progress, false, content?.ToString()!);

        /// <summary>Quotation.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<q></q>]]></code></returns>
        public static Element q(params Content[] content) => new(ElementType.q, false, content);

        /// <inheritdoc cref="q" />
        public static Element q(object content) => new(ElementType.q, false, content?.ToString()!);

        /// <summary>Parenthesis for ruby annotation text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<rp></rp>]]></code></returns>
        public static Element rp(params Content[] content) => new(ElementType.rp, false, content);

        /// <inheritdoc cref="rp" />
        public static Element rp(object content) => new(ElementType.rp, false, content?.ToString()!);

        /// <summary>Ruby annotation text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<rt></rt>]]></code></returns>
        public static Element rt(params Content[] content) => new(ElementType.rt, false, content);

        /// <inheritdoc cref="rt" />
        public static Element rt(object content) => new(ElementType.rt, false, content?.ToString()!);

        /// <summary>Ruby annotation(s).</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ruby></ruby>]]></code></returns>
        public static Element ruby(params Content[] content) => new(ElementType.ruby, false, content);

        /// <inheritdoc cref="ruby" />
        public static Element ruby(object content) => new(ElementType.ruby, false, content?.ToString()!);

        /// <summary>Inaccurate text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<s></s>]]></code></returns>
        public static Element s(params Content[] content) => new(ElementType.s, false, content);

        /// <inheritdoc cref="s" />
        public static Element s(object content) => new(ElementType.s, false, content?.ToString()!);

        /// <summary>Computer output.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<samp></samp>]]></code></returns>
        public static Element samp(params Content[] content) => new(ElementType.samp, false, content);

        /// <inheritdoc cref="samp" />
        public static Element samp(object content) => new(ElementType.samp, false, content?.ToString()!);

        /// <summary>Embedded script.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.type"/>, <see cref="Attributes.async"/>, <see cref="Attributes.defer"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.integrity"/>, <see cref="Attributes.referrerpolicy"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<script></script>]]></code></returns>
        public static Element script(params Content[] content) => new(ElementType.script, false, content);

        /// <inheritdoc cref="script" />
        public static Element script(object content) => new(ElementType.script, false, content?.ToString()!);

        /// <summary>Generic document or application section.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<section></section>]]></code></returns>
        public static Element section(params Content[] content) => new(ElementType.section, false, content);

        /// <inheritdoc cref="section" />
        public static Element section(object content) => new(ElementType.section, false, content?.ToString()!);

        /// <summary>List box control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.autocomplete"/>, <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.multiple"/>, <see cref="Attributes.name"/>, <see cref="Attributes.required"/>, <see cref="Attributes.size"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<select></select>]]></code></returns>
        public static Element select(params Content[] content) => new(ElementType.select, false, content);

        /// <inheritdoc cref="select" />
        public static Element select(object content) => new(ElementType.select, false, content?.ToString()!);

        /// <summary>Shadow tree slot.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<slot></slot>]]></code></returns>
        public static Element slot(params Content[] content) => new(ElementType.slot, false, content);

        /// <inheritdoc cref="slot" />
        public static Element slot(object content) => new(ElementType.slot, false, content?.ToString()!);

        /// <summary>Side comment.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<small></small>]]></code></returns>
        public static Element small(params Content[] content) => new(ElementType.small, false, content);

        /// <inheritdoc cref="small" />
        public static Element small(object content) => new(ElementType.small, false, content?.ToString()!);

        /// <summary>Image source for img or media source for video or audio.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.type"/>, <see cref="Attributes.srcset"/>, <see cref="Attributes.sizes"/>, <see cref="Attributes.media"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<source />]]></code></returns>
        public static Element source(params Content[] content) => new(ElementType.source, true, content);

        /// <summary>Generic phrasing container.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<span></span>]]></code></returns>
        public static Element span(params Content[] content) => new(ElementType.span, false, content);

        /// <inheritdoc cref="span" />
        public static Element span(object content) => new(ElementType.span, false, content?.ToString()!);

        /// <summary>Importance.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<strong></strong>]]></code></returns>
        public static Element strong(params Content[] content) => new(ElementType.strong, false, content);

        /// <inheritdoc cref="strong" />
        public static Element strong(object content) => new(ElementType.strong, false, content?.ToString()!);

        /// <summary>Embedded styling information.</summary>
        /// <remarks>Attributes: <see cref="Attributes.media"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<style></style>]]></code></returns>
        public static Element style(params Content[] content) => new(ElementType.style, false, content);

        /// <inheritdoc cref="style" />
        public static Element style(object content) => new(ElementType.style, false, content?.ToString()!);

        /// <summary>Subscript.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<sub></sub>]]></code></returns>
        public static Element sub(params Content[] content) => new(ElementType.sub, false, content);

        /// <inheritdoc cref="sub" />
        public static Element sub(object content) => new(ElementType.sub, false, content?.ToString()!);

        /// <summary>Caption for details.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<summary></summary>]]></code></returns>
        public static Element summary(params Content[] content) => new(ElementType.summary, false, content);

        /// <inheritdoc cref="summary" />
        public static Element summary(object content) => new(ElementType.summary, false, content?.ToString()!);

        /// <summary>Superscript.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<sup></sup>]]></code></returns>
        public static Element sup(params Content[] content) => new(ElementType.sup, false, content);

        /// <inheritdoc cref="sup" />
        public static Element sup(object content) => new(ElementType.sup, false, content?.ToString()!);

        /// <summary>Table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<table></table>]]></code></returns>
        public static Element table(params Content[] content) => new(ElementType.table, false, content);

        /// <inheritdoc cref="table" />
        public static Element table(object content) => new(ElementType.table, false, content?.ToString()!);

        /// <summary>Group of rows in a table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<tbody></tbody>]]></code></returns>
        public static Element tbody(params Content[] content) => new(ElementType.tbody, false, content);

        /// <inheritdoc cref="tbody" />
        public static Element tbody(object content) => new(ElementType.tbody, false, content?.ToString()!);

        /// <summary>Table cell.</summary>
        /// <remarks>Attributes: <see cref="Attributes.colspan"/>, <see cref="Attributes.rowspan"/>, <see cref="Attributes.headers"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<td></td>]]></code></returns>
        public static Element td(params Content[] content) => new(ElementType.td, false, content);

        /// <inheritdoc cref="td" />
        public static Element td(object content) => new(ElementType.td, false, content?.ToString()!);

        /// <summary>Template.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<template></template>]]></code></returns>
        public static Element template(params Content[] content) => new(ElementType.template, false, content);

        /// <inheritdoc cref="template" />
        public static Element template(object content) => new(ElementType.template, false, content?.ToString()!);

        /// <summary>Multiline text controls.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cols"/>, <see cref="Attributes.dirname"/>, <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.maxlength"/>, <see cref="Attributes.minlength"/>, <see cref="Attributes.name"/>, <see cref="Attributes.placeholder"/>, <see cref="Attributes.readonly_"/>, <see cref="Attributes.required"/>, <see cref="Attributes.rows"/>, <see cref="Attributes.wrap"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<textarea></textarea>]]></code></returns>
        public static Element textarea(params Content[] content) => new(ElementType.textarea, false, content);

        /// <inheritdoc cref="textarea" />
        public static Element textarea(object content) => new(ElementType.textarea, false, content?.ToString()!);

        /// <summary>Group of footer rows in a table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<tfoot></tfoot>]]></code></returns>
        public static Element tfoot(params Content[] content) => new(ElementType.tfoot, false, content);

        /// <inheritdoc cref="tfoot" />
        public static Element tfoot(object content) => new(ElementType.tfoot, false, content?.ToString()!);

        /// <summary>Table header cell.</summary>
        /// <remarks>Attributes: <see cref="Attributes.colspan"/>, <see cref="Attributes.rowspan"/>, <see cref="Attributes.headers"/>, <see cref="Attributes.scope"/>, <see cref="Attributes.abbr"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<th></th>]]></code></returns>
        public static Element th(params Content[] content) => new(ElementType.th, false, content);

        /// <inheritdoc cref="th" />
        public static Element th(object content) => new(ElementType.th, false, content?.ToString()!);

        /// <summary>Group of heading rows in a table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<thead></thead>]]></code></returns>
        public static Element thead(params Content[] content) => new(ElementType.thead, false, content);

        /// <inheritdoc cref="thead" />
        public static Element thead(object content) => new(ElementType.thead, false, content?.ToString()!);

        /// <summary>Machine-readable equivalent of date- or time-related data.</summary>
        /// <remarks>Attributes: <see cref="Attributes.datetime"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<time></time>]]></code></returns>
        public static Element time(params Content[] content) => new(ElementType.time, false, content);

        /// <inheritdoc cref="time" />
        public static Element time(object content) => new(ElementType.time, false, content?.ToString()!);

        /// <summary>Document title.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<title></title>]]></code></returns>
        public static Element title(params Content[] content) => new(ElementType.title, false, content);

        /// <inheritdoc cref="title" />
        public static Element title(object content) => new(ElementType.title, false, content?.ToString()!);

        /// <summary>Table row.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<tr></tr>]]></code></returns>
        public static Element tr(params Content[] content) => new(ElementType.tr, false, content);

        /// <inheritdoc cref="tr" />
        public static Element tr(object content) => new(ElementType.tr, false, content?.ToString()!);

        /// <summary>Timed text track.</summary>
        /// <remarks>Attributes: <see cref="Attributes.default_"/>, <see cref="Attributes.kind"/>, <see cref="Attributes.label"/>, <see cref="Attributes.src"/>, <see cref="Attributes.srclang"/>.</remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<track />]]></code></returns>
        public static Element track(params Content[] content) => new(ElementType.track, true, content);

        /// <summary>Unarticulated annotation.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<u></u>]]></code></returns>
        public static Element u(params Content[] content) => new(ElementType.u, false, content);

        /// <inheritdoc cref="u" />
        public static Element u(object content) => new(ElementType.u, false, content?.ToString()!);

        /// <summary>List.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ul></ul>]]></code></returns>
        public static Element ul(params Content[] content) => new(ElementType.ul, false, content);

        /// <inheritdoc cref="ul" />
        public static Element ul(object content) => new(ElementType.ul, false, content?.ToString()!);

        /// <summary>Variable.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<var></var>]]></code></returns>
        public static Element var(params Content[] content) => new(ElementType.var, false, content);

        /// <inheritdoc cref="var" />
        public static Element var(object content) => new(ElementType.var, false, content?.ToString()!);

        /// <summary>Video player.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.poster"/>, <see cref="Attributes.preload"/>, <see cref="Attributes.autoplay"/>, <see cref="Attributes.playsinline"/>, <see cref="Attributes.loop"/>, <see cref="Attributes.muted"/>, <see cref="Attributes.controls"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>.</remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<video></video>]]></code></returns>
        public static Element video(params Content[] content) => new(ElementType.video, false, content);

        /// <inheritdoc cref="video" />
        public static Element video(object content) => new(ElementType.video, false, content?.ToString()!);

        /// <summary>Line breaking opportunity.</summary>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<wbr />]]></code></returns>
        public static Element wbr(params Content[] content) => new(ElementType.wbr, true, content);
    }
}
