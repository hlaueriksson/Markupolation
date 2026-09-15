namespace Markupolation;

internal enum ElementType
{
    [Element("Hyperlink", AttributeType.href, AttributeType.target, AttributeType.download, AttributeType.rel, AttributeType.hreflang, AttributeType.type, AttributeType.referrerpolicy)]
    a,

    [Element("Abbreviation")]
    abbr,

    [Element("Contact information for a page or article element")]
    address,

    [Element("Hyperlink or dead area on an image map", AttributeType.alt, AttributeType.coords, AttributeType.shape, AttributeType.href, AttributeType.target, AttributeType.download, AttributeType.rel, AttributeType.referrerpolicy, IsVoidElement = true)]
    area,

    [Element("Self-contained syndicatable or reusable composition")]
    article,

    [Element("Sidebar for tangentially related content")]
    aside,

    [Element("Audio player", AttributeType.src, AttributeType.crossorigin, AttributeType.preload, AttributeType.autoplay, AttributeType.loading, AttributeType.loop, AttributeType.muted, AttributeType.controls)]
    audio,

    [Element("Keywords")]
    b,

    [Element("Base URL and default target navigable for hyperlinks and forms", AttributeType.href, AttributeType.target, IsVoidElement = true)]
    base_,

    [Element("Text directionality isolation")]
    bdi,

    [Element("Text directionality formatting")]
    bdo,

    [Element("A section quoted from another source", AttributeType.cite)]
    blockquote,

    [Element("Document body")]
    body,

    [Element("Line break, e.g. in poem or postal address", IsVoidElement = true)]
    br,

    [Element("Button control", AttributeType.command, AttributeType.commandfor, AttributeType.disabled, AttributeType.form, AttributeType.formaction, AttributeType.formenctype, AttributeType.formmethod, AttributeType.formnovalidate, AttributeType.formtarget, AttributeType.name, AttributeType.popovertarget, AttributeType.popovertargetaction, AttributeType.type, AttributeType.value)]
    button,

    [Element("Scriptable bitmap canvas", AttributeType.width, AttributeType.height)]
    canvas,

    [Element("Table caption")]
    caption,

    [Element("Title of a work")]
    cite,

    [Element("Computer code")]
    code,

    [Element("Table column", AttributeType.span, IsVoidElement = true)]
    col,

    [Element("Group of columns in a table", AttributeType.span)]
    colgroup,

    [Element("Machine-readable equivalent", AttributeType.value)]
    data,

    [Element("Container for options for combo box control")]
    datalist,

    [Element("Content for corresponding dt element(s)")]
    dd,

    [Element("A removal from the document", AttributeType.cite, AttributeType.datetime)]
    del,

    [Element("Disclosure control for hiding details", AttributeType.name, AttributeType.open)]
    details,

    [Element("Defining instance")]
    dfn,

    [Element("Dialog box or window", AttributeType.open)]
    dialog,

    [Element("Generic flow container, or container for name-value groups in dl elements")]
    div,

    [Element("Association list consisting of zero or more name-value groups")]
    dl,

    [Element("Legend for corresponding dd element(s)")]
    dt,

    [Element("Stress emphasis")]
    em,

    [Element("Plugin", AttributeType.src, AttributeType.type, AttributeType.width, AttributeType.height, IsVoidElement = true)]
    embed,

    [Element("Group of form controls", AttributeType.disabled, AttributeType.form, AttributeType.name)]
    fieldset,

    [Element("Caption for figure")]
    figcaption,

    [Element("Figure with optional caption")]
    figure,

    [Element("Footer for a page or section")]
    footer,

    [Element("User-submittable form", AttributeType.accept_charset, AttributeType.action, AttributeType.autocomplete, AttributeType.enctype, AttributeType.method, AttributeType.name, AttributeType.novalidate, AttributeType.rel, AttributeType.target)]
    form,

    [Element("Heading")]
    h1,

    [Element("Heading")]
    h2,

    [Element("Heading")]
    h3,

    [Element("Heading")]
    h4,

    [Element("Heading")]
    h5,

    [Element("Heading")]
    h6,

    [Element("Container for document metadata")]
    head,

    [Element("Introductory or navigational aids for a page or section")]
    header,

    [Element("Heading container")]
    hgroup,

    [Element("Thematic break", IsVoidElement = true)]
    hr,

    [Element("Root element")]
    html,

    [Element("Alternate voice")]
    i,

    [Element("Child navigable", AttributeType.src, AttributeType.srcdoc, AttributeType.name, AttributeType.sandbox, AttributeType.allow, AttributeType.allowfullscreen, AttributeType.width, AttributeType.height, AttributeType.referrerpolicy, AttributeType.loading)]
    iframe,

    [Element("Image", AttributeType.alt, AttributeType.src, AttributeType.srcset, AttributeType.sizes, AttributeType.crossorigin, AttributeType.usemap, AttributeType.ismap, AttributeType.controls, AttributeType.width, AttributeType.height, AttributeType.referrerpolicy, AttributeType.decoding, AttributeType.loading, AttributeType.fetchpriority, IsVoidElement = true)]
    img,

    [Element("Form control", AttributeType.accept, AttributeType.alpha, AttributeType.alt, AttributeType.autocomplete, AttributeType.checked_, AttributeType.colorspace, AttributeType.dirname, AttributeType.disabled, AttributeType.form, AttributeType.formaction, AttributeType.formenctype, AttributeType.formmethod, AttributeType.formnovalidate, AttributeType.formtarget, AttributeType.height, AttributeType.list, AttributeType.max, AttributeType.maxlength, AttributeType.min, AttributeType.minlength, AttributeType.multiple, AttributeType.name, AttributeType.pattern, AttributeType.placeholder, AttributeType.popovertarget, AttributeType.popovertargetaction, AttributeType.readonly_, AttributeType.required, AttributeType.size, AttributeType.src, AttributeType.step, AttributeType.type, AttributeType.value, AttributeType.width, IsVoidElement = true)]
    input,

    [Element("An addition to the document", AttributeType.cite, AttributeType.datetime)]
    ins,

    [Element("User input")]
    kbd,

    [Element("Caption for a form control", AttributeType.for_)]
    label,

    [Element("Caption for fieldset")]
    legend,

    [Element("List item", AttributeType.value)]
    li,

    [Element("Link metadata", AttributeType.href, AttributeType.crossorigin, AttributeType.rel, AttributeType.as_, AttributeType.media, AttributeType.hreflang, AttributeType.type, AttributeType.sizes, AttributeType.imagesrcset, AttributeType.imagesizes, AttributeType.referrerpolicy, AttributeType.integrity, AttributeType.blocking, AttributeType.color, AttributeType.disabled, AttributeType.fetchpriority, IsVoidElement = true)]
    link,

    [Element("Container for the dominant contents of the document")]
    main,

    [Element("Image map", AttributeType.name)]
    map,

    [Element("Highlight")]
    mark,

    [Element("Menu of commands")]
    menu,

    [Element("Text metadata", AttributeType.name, AttributeType.http_equiv, AttributeType.content, AttributeType.charset, AttributeType.media, IsVoidElement = true)]
    meta,

    [Element("Gauge", AttributeType.value, AttributeType.min, AttributeType.max, AttributeType.low, AttributeType.high, AttributeType.optimum)]
    meter,

    [Element("Section with navigational links")]
    nav,

    [Element("Fallback content for script")]
    noscript,

    [Element("Image, child navigable, or plugin", AttributeType.data, AttributeType.type, AttributeType.name, AttributeType.form, AttributeType.width, AttributeType.height)]
    object_,

    [Element("Ordered list", AttributeType.reversed, AttributeType.start, AttributeType.type)]
    ol,

    [Element("Group of options in a list box", AttributeType.disabled, AttributeType.label)]
    optgroup,

    [Element("Option in a list box or combo box control", AttributeType.disabled, AttributeType.label, AttributeType.selected, AttributeType.value)]
    option,

    [Element("Calculated output value", AttributeType.for_, AttributeType.form, AttributeType.name)]
    output,

    [Element("Paragraph")]
    p,

    [Element("Image")]
    picture,

    [Element("Block of preformatted text")]
    pre,

    [Element("Progress bar", AttributeType.value, AttributeType.max)]
    progress,

    [Element("Quotation", AttributeType.cite)]
    q,

    [Element("Parenthesis for ruby annotation text")]
    rp,

    [Element("Ruby annotation text")]
    rt,

    [Element("Ruby annotation(s)")]
    ruby,

    [Element("Inaccurate text")]
    s,

    [Element("Computer output")]
    samp,

    [Element("Embedded script", AttributeType.src, AttributeType.type, AttributeType.nomodule, AttributeType.async, AttributeType.defer, AttributeType.crossorigin, AttributeType.integrity, AttributeType.referrerpolicy, AttributeType.blocking, AttributeType.fetchpriority)]
    script,

    [Element("Container for search controls")]
    search,

    [Element("Generic document or application section")]
    section,

    [Element("List box control", AttributeType.autocomplete, AttributeType.disabled, AttributeType.form, AttributeType.multiple, AttributeType.name, AttributeType.required, AttributeType.size)]
    select,

    [Element("Mirrors content from an option")]
    selectedcontent,

    [Element("Shadow tree slot", AttributeType.name)]
    slot,

    [Element("Side comment")]
    small,

    [Element("Image source for img or media source for video or audio", AttributeType.type, AttributeType.media, AttributeType.src, AttributeType.srcset, AttributeType.sizes, AttributeType.width, AttributeType.height, IsVoidElement = true)]
    source,

    [Element("Generic phrasing container")]
    span,

    [Element("Importance")]
    strong,

    [Element("Embedded styling information", AttributeType.media, AttributeType.blocking)]
    style,

    [Element("Subscript")]
    sub,

    [Element("Caption for details")]
    summary,

    [Element("Superscript")]
    sup,

    [Element("Table")]
    table,

    [Element("Group of rows in a table")]
    tbody,

    [Element("Table cell", AttributeType.colspan, AttributeType.rowspan, AttributeType.headers)]
    td,

    [Element("Template", AttributeType.for_, AttributeType.shadowrootmode, AttributeType.shadowrootdelegatesfocus, AttributeType.shadowrootserializable, AttributeType.shadowrootslotassignment, AttributeType.shadowrootclonable, AttributeType.shadowrootcustomelementregistry)]
    template,

    [Element("Multiline text controls", AttributeType.autocomplete, AttributeType.cols, AttributeType.dirname, AttributeType.disabled, AttributeType.form, AttributeType.maxlength, AttributeType.minlength, AttributeType.name, AttributeType.placeholder, AttributeType.readonly_, AttributeType.required, AttributeType.rows, AttributeType.wrap)]
    textarea,

    [Element("Group of footer rows in a table")]
    tfoot,

    [Element("Table header cell", AttributeType.colspan, AttributeType.rowspan, AttributeType.headers, AttributeType.scope, AttributeType.abbr)]
    th,

    [Element("Group of heading rows in a table")]
    thead,

    [Element("Machine-readable equivalent of date- or time-related data", AttributeType.datetime)]
    time,

    [Element("Document title")]
    title,

    [Element("Table row")]
    tr,

    [Element("Timed text track", AttributeType.default_, AttributeType.kind, AttributeType.label, AttributeType.src, AttributeType.srclang, IsVoidElement = true)]
    track,

    [Element("Unarticulated annotation")]
    u,

    [Element("List")]
    ul,

    [Element("Variable")]
    var,

    [Element("Video player", AttributeType.src, AttributeType.crossorigin, AttributeType.poster, AttributeType.preload, AttributeType.autoplay, AttributeType.playsinline, AttributeType.loading, AttributeType.loop, AttributeType.muted, AttributeType.controls, AttributeType.width, AttributeType.height)]
    video,

    [Element("Line breaking opportunity", IsVoidElement = true)]
    wbr,
}
