namespace Markupolation
{
    public static partial class Elements
    {
        /// <summary>Hyperlink.</summary>
        /// <remarks>Attributes: <see cref="Attributes.href"/>, <see cref="Attributes.target"/>, <see cref="Attributes.download"/>, <see cref="Attributes.rel"/>, <see cref="Attributes.hreflang"/>, <see cref="Attributes.type"/>, <see cref="Attributes.referrerpolicy"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<a></a>]]></code></returns>
        public static Element a(params Content[] content) => NormalElement(ElementType.a, content);

        /// <summary>Abbreviation.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<abbr></abbr>]]></code></returns>
        public static Element abbr(params Content[] content) => NormalElement(ElementType.abbr, content);

        /// <summary>Contact information for a page or article element.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<address></address>]]></code></returns>
        public static Element address(params Content[] content) => NormalElement(ElementType.address, content);

        /// <summary>Hyperlink or dead area on an image map.</summary>
        /// <remarks>Attributes: <see cref="Attributes.alt"/>, <see cref="Attributes.coords"/>, <see cref="Attributes.shape"/>, <see cref="Attributes.href"/>, <see cref="Attributes.target"/>, <see cref="Attributes.download"/>, <see cref="Attributes.rel"/>, <see cref="Attributes.referrerpolicy"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<area />]]></code></returns>
        public static Element area(params Content[] content) => VoidElement(ElementType.area, content);

        /// <summary>Self-contained syndicatable or reusable composition.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<article></article>]]></code></returns>
        public static Element article(params Content[] content) => NormalElement(ElementType.article, content);

        /// <summary>Sidebar for tangentially related content.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<aside></aside>]]></code></returns>
        public static Element aside(params Content[] content) => NormalElement(ElementType.aside, content);

        /// <summary>Audio player.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.preload"/>, <see cref="Attributes.autoplay"/>, <see cref="Attributes.loop"/>, <see cref="Attributes.muted"/>, <see cref="Attributes.controls"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<audio></audio>]]></code></returns>
        public static Element audio(params Content[] content) => NormalElement(ElementType.audio, content);

        /// <summary>Keywords.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<b></b>]]></code></returns>
        public static Element b(params Content[] content) => NormalElement(ElementType.b, content);

        /// <summary>Base URL and default target browsing context for hyperlinks and forms.</summary>
        /// <remarks>Attributes: <see cref="Attributes.href"/>, <see cref="Attributes.target"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<base_ />]]></code></returns>
        public static Element base_(params Content[] content) => VoidElement(ElementType.base_, content);

        /// <summary>Text directionality isolation.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<bdi></bdi>]]></code></returns>
        public static Element bdi(params Content[] content) => NormalElement(ElementType.bdi, content);

        /// <summary>Text directionality formatting.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<bdo></bdo>]]></code></returns>
        public static Element bdo(params Content[] content) => NormalElement(ElementType.bdo, content);

        /// <summary>A section quoted from another source.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<blockquote></blockquote>]]></code></returns>
        public static Element blockquote(params Content[] content) => NormalElement(ElementType.blockquote, content);

        /// <summary>Document body.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<body></body>]]></code></returns>
        public static Element body(params Content[] content) => NormalElement(ElementType.body, content);

        /// <summary>Line break, e.g. in poem or postal address.</summary>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<br />]]></code></returns>
        public static Element br(params Content[] content) => VoidElement(ElementType.br, content);

        /// <summary>Button control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.formaction"/>, <see cref="Attributes.formenctype"/>, <see cref="Attributes.formmethod"/>, <see cref="Attributes.formnovalidate"/>, <see cref="Attributes.formtarget"/>, <see cref="Attributes.name"/>, <see cref="Attributes.type"/>, <see cref="Attributes.value"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<button></button>]]></code></returns>
        public static Element button(params Content[] content) => NormalElement(ElementType.button, content);

        /// <summary>Scriptable bitmap canvas.</summary>
        /// <remarks>Attributes: <see cref="Attributes.width"/>, <see cref="Attributes.height"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<canvas></canvas>]]></code></returns>
        public static Element canvas(params Content[] content) => NormalElement(ElementType.canvas, content);

        /// <summary>Table caption.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<caption></caption>]]></code></returns>
        public static Element caption(params Content[] content) => NormalElement(ElementType.caption, content);

        /// <summary>Title of a work.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<cite></cite>]]></code></returns>
        public static Element cite(params Content[] content) => NormalElement(ElementType.cite, content);

        /// <summary>Computer code.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<code></code>]]></code></returns>
        public static Element code(params Content[] content) => NormalElement(ElementType.code, content);

        /// <summary>Table column.</summary>
        /// <remarks>Attributes: <see cref="Attributes.span"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<col />]]></code></returns>
        public static Element col(params Content[] content) => VoidElement(ElementType.col, content);

        /// <summary>Group of columns in a table.</summary>
        /// <remarks>Attributes: <see cref="Attributes.span"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<colgroup></colgroup>]]></code></returns>
        public static Element colgroup(params Content[] content) => NormalElement(ElementType.colgroup, content);

        /// <summary>Machine-readable equivalent.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<data></data>]]></code></returns>
        public static Element data(params Content[] content) => NormalElement(ElementType.data, content);

        /// <summary>Container for options for combo box control.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<datalist></datalist>]]></code></returns>
        public static Element datalist(params Content[] content) => NormalElement(ElementType.datalist, content);

        /// <summary>Content for corresponding dt element(s).</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dd></dd>]]></code></returns>
        public static Element dd(params Content[] content) => NormalElement(ElementType.dd, content);

        /// <summary>A removal from the document.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/>, <see cref="Attributes.datetime"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<del></del>]]></code></returns>
        public static Element del(params Content[] content) => NormalElement(ElementType.del, content);

        /// <summary>Disclosure control for hiding details.</summary>
        /// <remarks>Attributes: <see cref="Attributes.open"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<details></details>]]></code></returns>
        public static Element details(params Content[] content) => NormalElement(ElementType.details, content);

        /// <summary>Defining instance.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dfn></dfn>]]></code></returns>
        public static Element dfn(params Content[] content) => NormalElement(ElementType.dfn, content);

        /// <summary>Dialog box or window.</summary>
        /// <remarks>Attributes: <see cref="Attributes.open"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dialog></dialog>]]></code></returns>
        public static Element dialog(params Content[] content) => NormalElement(ElementType.dialog, content);

        /// <summary>Generic flow container, or container for name-value groups in dl elements.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<div></div>]]></code></returns>
        public static Element div(params Content[] content) => NormalElement(ElementType.div, content);

        /// <summary>Association list consisting of zero or more name-value groups.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dl></dl>]]></code></returns>
        public static Element dl(params Content[] content) => NormalElement(ElementType.dl, content);

        /// <summary>Legend for corresponding dd element(s).</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<dt></dt>]]></code></returns>
        public static Element dt(params Content[] content) => NormalElement(ElementType.dt, content);

        /// <summary>Stress emphasis.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<em></em>]]></code></returns>
        public static Element em(params Content[] content) => NormalElement(ElementType.em, content);

        /// <summary>Plugin.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.type"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<embed />]]></code></returns>
        public static Element embed(params Content[] content) => VoidElement(ElementType.embed, content);

        /// <summary>Group of form controls.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.name"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<fieldset></fieldset>]]></code></returns>
        public static Element fieldset(params Content[] content) => NormalElement(ElementType.fieldset, content);

        /// <summary>Caption for figure.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<figcaption></figcaption>]]></code></returns>
        public static Element figcaption(params Content[] content) => NormalElement(ElementType.figcaption, content);

        /// <summary>Figure with optional caption.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<figure></figure>]]></code></returns>
        public static Element figure(params Content[] content) => NormalElement(ElementType.figure, content);

        /// <summary>Footer for a page or section.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<footer></footer>]]></code></returns>
        public static Element footer(params Content[] content) => NormalElement(ElementType.footer, content);

        /// <summary>User-submittable form.</summary>
        /// <remarks>Attributes: <see cref="Attributes.accept_charset"/>, <see cref="Attributes.action"/>, <see cref="Attributes.autocomplete"/>, <see cref="Attributes.enctype"/>, <see cref="Attributes.method"/>, <see cref="Attributes.name"/>, <see cref="Attributes.novalidate"/>, <see cref="Attributes.target"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<form></form>]]></code></returns>
        public static Element form(params Content[] content) => NormalElement(ElementType.form, content);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h1></h1>]]></code></returns>
        public static Element h1(params Content[] content) => NormalElement(ElementType.h1, content);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h2></h2>]]></code></returns>
        public static Element h2(params Content[] content) => NormalElement(ElementType.h2, content);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h3></h3>]]></code></returns>
        public static Element h3(params Content[] content) => NormalElement(ElementType.h3, content);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h4></h4>]]></code></returns>
        public static Element h4(params Content[] content) => NormalElement(ElementType.h4, content);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h5></h5>]]></code></returns>
        public static Element h5(params Content[] content) => NormalElement(ElementType.h5, content);

        /// <summary>Section heading.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<h6></h6>]]></code></returns>
        public static Element h6(params Content[] content) => NormalElement(ElementType.h6, content);

        /// <summary>Container for document metadata.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<head></head>]]></code></returns>
        public static Element head(params Content[] content) => NormalElement(ElementType.head, content);

        /// <summary>Introductory or navigational aids for a page or section.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<header></header>]]></code></returns>
        public static Element header(params Content[] content) => NormalElement(ElementType.header, content);

        /// <summary>heading group.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<hgroup></hgroup>]]></code></returns>
        public static Element hgroup(params Content[] content) => NormalElement(ElementType.hgroup, content);

        /// <summary>Thematic break.</summary>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<hr />]]></code></returns>
        public static Element hr(params Content[] content) => VoidElement(ElementType.hr, content);

        /// <summary>Root element.</summary>
        /// <remarks>Attributes: <see cref="Attributes.manifest"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<html></html>]]></code></returns>
        public static Element html(params Content[] content) => NormalElement(ElementType.html, content);

        /// <summary>Alternate voice.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<i></i>]]></code></returns>
        public static Element i(params Content[] content) => NormalElement(ElementType.i, content);

        /// <summary>Nested browsing context.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.srcdoc"/>, <see cref="Attributes.name"/>, <see cref="Attributes.sandbox"/>, <see cref="Attributes.allow"/>, <see cref="Attributes.allowfullscreen"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>, <see cref="Attributes.referrerpolicy"/>, <see cref="Attributes.loading"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<iframe></iframe>]]></code></returns>
        public static Element iframe(params Content[] content) => NormalElement(ElementType.iframe, content);

        /// <summary>Image.</summary>
        /// <remarks>Attributes: <see cref="Attributes.alt"/>, <see cref="Attributes.src"/>, <see cref="Attributes.srcset"/>, <see cref="Attributes.sizes"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.usemap"/>, <see cref="Attributes.ismap"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/>, <see cref="Attributes.referrerpolicy"/>, <see cref="Attributes.decoding"/>, <see cref="Attributes.loading"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<img />]]></code></returns>
        public static Element img(params Content[] content) => VoidElement(ElementType.img, content);

        /// <summary>Form control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.accept"/>, <see cref="Attributes.alt"/>, <see cref="Attributes.autocomplete"/>, <see cref="Attributes.checked_"/>, <see cref="Attributes.dirname"/>, <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.formaction"/>, <see cref="Attributes.formenctype"/>, <see cref="Attributes.formmethod"/>, <see cref="Attributes.formnovalidate"/>, <see cref="Attributes.formtarget"/>, <see cref="Attributes.height"/>, <see cref="Attributes.list"/>, <see cref="Attributes.max"/>, <see cref="Attributes.maxlength"/>, <see cref="Attributes.min"/>, <see cref="Attributes.minlength"/>, <see cref="Attributes.multiple"/>, <see cref="Attributes.name"/>, <see cref="Attributes.pattern"/>, <see cref="Attributes.placeholder"/>, <see cref="Attributes.readonly_"/>, <see cref="Attributes.required"/>, <see cref="Attributes.size"/>, <see cref="Attributes.src"/>, <see cref="Attributes.step"/>, <see cref="Attributes.type"/>, <see cref="Attributes.value"/>, <see cref="Attributes.width"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<input />]]></code></returns>
        public static Element input(params Content[] content) => VoidElement(ElementType.input, content);

        /// <summary>An addition to the document.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/>, <see cref="Attributes.datetime"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ins></ins>]]></code></returns>
        public static Element ins(params Content[] content) => NormalElement(ElementType.ins, content);

        /// <summary>User input.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<kbd></kbd>]]></code></returns>
        public static Element kbd(params Content[] content) => NormalElement(ElementType.kbd, content);

        /// <summary>Caption for a form control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.for_"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<label></label>]]></code></returns>
        public static Element label(params Content[] content) => NormalElement(ElementType.label, content);

        /// <summary>Caption for fieldset.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<legend></legend>]]></code></returns>
        public static Element legend(params Content[] content) => NormalElement(ElementType.legend, content);

        /// <summary>List item.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<li></li>]]></code></returns>
        public static Element li(params Content[] content) => NormalElement(ElementType.li, content);

        /// <summary>Link metadata.</summary>
        /// <remarks>Attributes: <see cref="Attributes.href"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.rel"/>, <see cref="Attributes.as_"/>, <see cref="Attributes.media"/>, <see cref="Attributes.hreflang"/>, <see cref="Attributes.type"/>, <see cref="Attributes.sizes"/>, <see cref="Attributes.imagesrcset"/>, <see cref="Attributes.imagesizes"/>, <see cref="Attributes.referrerpolicy"/>, <see cref="Attributes.integrity"/>, <see cref="Attributes.color"/>, <see cref="Attributes.disabled"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<link />]]></code></returns>
        public static Element link(params Content[] content) => VoidElement(ElementType.link, content);

        /// <summary>Container for the dominant contents of the document.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<main></main>]]></code></returns>
        public static Element main(params Content[] content) => NormalElement(ElementType.main, content);

        /// <summary>Image map.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<map></map>]]></code></returns>
        public static Element map(params Content[] content) => NormalElement(ElementType.map, content);

        /// <summary>Highlight.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<mark></mark>]]></code></returns>
        public static Element mark(params Content[] content) => NormalElement(ElementType.mark, content);

        /// <summary>Menu of commands.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<menu></menu>]]></code></returns>
        public static Element menu(params Content[] content) => NormalElement(ElementType.menu, content);

        /// <summary>Text metadata.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/>, <see cref="Attributes.http_equiv"/>, <see cref="Attributes.content"/>, <see cref="Attributes.charset"/>, <see cref="Attributes.media"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<meta />]]></code></returns>
        public static Element meta(params Content[] content) => VoidElement(ElementType.meta, content);

        /// <summary>Gauge.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/>, <see cref="Attributes.min"/>, <see cref="Attributes.max"/>, <see cref="Attributes.low"/>, <see cref="Attributes.high"/>, <see cref="Attributes.optimum"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<meter></meter>]]></code></returns>
        public static Element meter(params Content[] content) => NormalElement(ElementType.meter, content);

        /// <summary>Section with navigational links.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<nav></nav>]]></code></returns>
        public static Element nav(params Content[] content) => NormalElement(ElementType.nav, content);

        /// <summary>Fallback content for script.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<noscript></noscript>]]></code></returns>
        public static Element noscript(params Content[] content) => NormalElement(ElementType.noscript, content);

        /// <summary>Image, nested browsing context, or plugin.</summary>
        /// <remarks>Attributes: <see cref="Attributes.data"/>, <see cref="Attributes.type"/>, <see cref="Attributes.name"/>, <see cref="Attributes.form"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<object_></object_>]]></code></returns>
        public static Element object_(params Content[] content) => NormalElement(ElementType.object_, content);

        /// <summary>Ordered list.</summary>
        /// <remarks>Attributes: <see cref="Attributes.reversed"/>, <see cref="Attributes.start"/>, <see cref="Attributes.type"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ol></ol>]]></code></returns>
        public static Element ol(params Content[] content) => NormalElement(ElementType.ol, content);

        /// <summary>Group of options in a list box.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.label"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<optgroup></optgroup>]]></code></returns>
        public static Element optgroup(params Content[] content) => NormalElement(ElementType.optgroup, content);

        /// <summary>Option in a list box or combo box control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.disabled"/>, <see cref="Attributes.label"/>, <see cref="Attributes.selected"/>, <see cref="Attributes.value"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<option></option>]]></code></returns>
        public static Element option(params Content[] content) => NormalElement(ElementType.option, content);

        /// <summary>Calculated output value.</summary>
        /// <remarks>Attributes: <see cref="Attributes.for_"/>, <see cref="Attributes.form"/>, <see cref="Attributes.name"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<output></output>]]></code></returns>
        public static Element output(params Content[] content) => NormalElement(ElementType.output, content);

        /// <summary>Paragraph.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<p></p>]]></code></returns>
        public static Element p(params Content[] content) => NormalElement(ElementType.p, content);

        /// <summary>Parameter for object.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/>, <see cref="Attributes.value"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<param />]]></code></returns>
        public static Element param(params Content[] content) => VoidElement(ElementType.param, content);

        /// <summary>Image.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<picture></picture>]]></code></returns>
        public static Element picture(params Content[] content) => NormalElement(ElementType.picture, content);

        /// <summary>Block of preformatted text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<pre></pre>]]></code></returns>
        public static Element pre(params Content[] content) => NormalElement(ElementType.pre, content);

        /// <summary>Progress bar.</summary>
        /// <remarks>Attributes: <see cref="Attributes.value"/>, <see cref="Attributes.max"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<progress></progress>]]></code></returns>
        public static Element progress(params Content[] content) => NormalElement(ElementType.progress, content);

        /// <summary>Quotation.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cite"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<q></q>]]></code></returns>
        public static Element q(params Content[] content) => NormalElement(ElementType.q, content);

        /// <summary>Parenthesis for ruby annotation text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<rp></rp>]]></code></returns>
        public static Element rp(params Content[] content) => NormalElement(ElementType.rp, content);

        /// <summary>Ruby annotation text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<rt></rt>]]></code></returns>
        public static Element rt(params Content[] content) => NormalElement(ElementType.rt, content);

        /// <summary>Ruby annotation(s).</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ruby></ruby>]]></code></returns>
        public static Element ruby(params Content[] content) => NormalElement(ElementType.ruby, content);

        /// <summary>Inaccurate text.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<s></s>]]></code></returns>
        public static Element s(params Content[] content) => NormalElement(ElementType.s, content);

        /// <summary>Computer output.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<samp></samp>]]></code></returns>
        public static Element samp(params Content[] content) => NormalElement(ElementType.samp, content);

        /// <summary>Embedded script.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.type"/>, <see cref="Attributes.async"/>, <see cref="Attributes.defer"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.integrity"/>, <see cref="Attributes.referrerpolicy"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<script></script>]]></code></returns>
        public static Element script(params Content[] content) => NormalElement(ElementType.script, content);

        /// <summary>Generic document or application section.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<section></section>]]></code></returns>
        public static Element section(params Content[] content) => NormalElement(ElementType.section, content);

        /// <summary>List box control.</summary>
        /// <remarks>Attributes: <see cref="Attributes.autocomplete"/>, <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.multiple"/>, <see cref="Attributes.name"/>, <see cref="Attributes.required"/>, <see cref="Attributes.size"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<select></select>]]></code></returns>
        public static Element select(params Content[] content) => NormalElement(ElementType.select, content);

        /// <summary>Shadow tree slot.</summary>
        /// <remarks>Attributes: <see cref="Attributes.name"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<slot></slot>]]></code></returns>
        public static Element slot(params Content[] content) => NormalElement(ElementType.slot, content);

        /// <summary>Side comment.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<small></small>]]></code></returns>
        public static Element small(params Content[] content) => NormalElement(ElementType.small, content);

        /// <summary>Image source for img or media source for video or audio.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.type"/>, <see cref="Attributes.srcset"/>, <see cref="Attributes.sizes"/>, <see cref="Attributes.media"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<source />]]></code></returns>
        public static Element source(params Content[] content) => VoidElement(ElementType.source, content);

        /// <summary>Generic phrasing container.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<span></span>]]></code></returns>
        public static Element span(params Content[] content) => NormalElement(ElementType.span, content);

        /// <summary>Importance.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<strong></strong>]]></code></returns>
        public static Element strong(params Content[] content) => NormalElement(ElementType.strong, content);

        /// <summary>Embedded styling information.</summary>
        /// <remarks>Attributes: <see cref="Attributes.media"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<style></style>]]></code></returns>
        public static Element style(params Content[] content) => NormalElement(ElementType.style, content);

        /// <summary>Subscript.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<sub></sub>]]></code></returns>
        public static Element sub(params Content[] content) => NormalElement(ElementType.sub, content);

        /// <summary>Caption for details.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<summary></summary>]]></code></returns>
        public static Element summary(params Content[] content) => NormalElement(ElementType.summary, content);

        /// <summary>Superscript.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<sup></sup>]]></code></returns>
        public static Element sup(params Content[] content) => NormalElement(ElementType.sup, content);

        /// <summary>Table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<table></table>]]></code></returns>
        public static Element table(params Content[] content) => NormalElement(ElementType.table, content);

        /// <summary>Group of rows in a table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<tbody></tbody>]]></code></returns>
        public static Element tbody(params Content[] content) => NormalElement(ElementType.tbody, content);

        /// <summary>Table cell.</summary>
        /// <remarks>Attributes: <see cref="Attributes.colspan"/>, <see cref="Attributes.rowspan"/>, <see cref="Attributes.headers"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<td></td>]]></code></returns>
        public static Element td(params Content[] content) => NormalElement(ElementType.td, content);

        /// <summary>Template.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<template></template>]]></code></returns>
        public static Element template(params Content[] content) => NormalElement(ElementType.template, content);

        /// <summary>Multiline text controls.</summary>
        /// <remarks>Attributes: <see cref="Attributes.cols"/>, <see cref="Attributes.dirname"/>, <see cref="Attributes.disabled"/>, <see cref="Attributes.form"/>, <see cref="Attributes.maxlength"/>, <see cref="Attributes.minlength"/>, <see cref="Attributes.name"/>, <see cref="Attributes.placeholder"/>, <see cref="Attributes.readonly_"/>, <see cref="Attributes.required"/>, <see cref="Attributes.rows"/>, <see cref="Attributes.wrap"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<textarea></textarea>]]></code></returns>
        public static Element textarea(params Content[] content) => NormalElement(ElementType.textarea, content);

        /// <summary>Group of footer rows in a table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<tfoot></tfoot>]]></code></returns>
        public static Element tfoot(params Content[] content) => NormalElement(ElementType.tfoot, content);

        /// <summary>Table header cell.</summary>
        /// <remarks>Attributes: <see cref="Attributes.colspan"/>, <see cref="Attributes.rowspan"/>, <see cref="Attributes.headers"/>, <see cref="Attributes.scope"/>, <see cref="Attributes.abbr"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<th></th>]]></code></returns>
        public static Element th(params Content[] content) => NormalElement(ElementType.th, content);

        /// <summary>Group of heading rows in a table.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<thead></thead>]]></code></returns>
        public static Element thead(params Content[] content) => NormalElement(ElementType.thead, content);

        /// <summary>Machine-readable equivalent of date- or time-related data.</summary>
        /// <remarks>Attributes: <see cref="Attributes.datetime"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<time></time>]]></code></returns>
        public static Element time(params Content[] content) => NormalElement(ElementType.time, content);

        /// <summary>Document title.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<title></title>]]></code></returns>
        public static Element title(params Content[] content) => NormalElement(ElementType.title, content);

        /// <summary>Table row.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<tr></tr>]]></code></returns>
        public static Element tr(params Content[] content) => NormalElement(ElementType.tr, content);

        /// <summary>Timed text track.</summary>
        /// <remarks>Attributes: <see cref="Attributes.default_"/>, <see cref="Attributes.kind"/>, <see cref="Attributes.label"/>, <see cref="Attributes.src"/>, <see cref="Attributes.srclang"/></remarks>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<track />]]></code></returns>
        public static Element track(params Content[] content) => VoidElement(ElementType.track, content);

        /// <summary>Unarticulated annotation.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<u></u>]]></code></returns>
        public static Element u(params Content[] content) => NormalElement(ElementType.u, content);

        /// <summary>List.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<ul></ul>]]></code></returns>
        public static Element ul(params Content[] content) => NormalElement(ElementType.ul, content);

        /// <summary>Variable.</summary>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<var></var>]]></code></returns>
        public static Element var(params Content[] content) => NormalElement(ElementType.var, content);

        /// <summary>Video player.</summary>
        /// <remarks>Attributes: <see cref="Attributes.src"/>, <see cref="Attributes.crossorigin"/>, <see cref="Attributes.poster"/>, <see cref="Attributes.preload"/>, <see cref="Attributes.autoplay"/>, <see cref="Attributes.playsinline"/>, <see cref="Attributes.loop"/>, <see cref="Attributes.muted"/>, <see cref="Attributes.controls"/>, <see cref="Attributes.width"/>, <see cref="Attributes.height"/></remarks>
        /// <param name="content">Attributes, elements and content.</param>
        /// <returns><code><![CDATA[<video></video>]]></code></returns>
        public static Element video(params Content[] content) => NormalElement(ElementType.video, content);

        /// <summary>Line breaking opportunity.</summary>
        /// <param name="content">Attributes.</param>
        /// <returns><code><![CDATA[<wbr />]]></code></returns>
        public static Element wbr(params Content[] content) => VoidElement(ElementType.wbr, content);
    }
}
