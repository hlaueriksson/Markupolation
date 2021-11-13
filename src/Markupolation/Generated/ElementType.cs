namespace Markupolation
{
    internal enum ElementType
    {
        [Element("Hyperlink", false, AttributeType.href, AttributeType.target, AttributeType.download, AttributeType.rel, AttributeType.hreflang, AttributeType.type, AttributeType.referrerpolicy)]
        a,

        [Element("Abbreviation", false)]
        abbr,

        [Element("Contact information for a page or article element", false)]
        address,

        [Element("Hyperlink or dead area on an image map", true, AttributeType.alt, AttributeType.coords, AttributeType.shape, AttributeType.href, AttributeType.target, AttributeType.download, AttributeType.rel, AttributeType.referrerpolicy)]
        area,

        [Element("Self-contained syndicatable or reusable composition", false)]
        article,

        [Element("Sidebar for tangentially related content", false)]
        aside,

        [Element("Audio player", false, AttributeType.src, AttributeType.crossorigin, AttributeType.preload, AttributeType.autoplay, AttributeType.loop, AttributeType.muted, AttributeType.controls)]
        audio,

        [Element("Keywords", false)]
        b,

        [Element("Base URL and default target browsing context for hyperlinks and forms", true, AttributeType.href, AttributeType.target)]
        base_,

        [Element("Text directionality isolation", false)]
        bdi,

        [Element("Text directionality formatting", false)]
        bdo,

        [Element("A section quoted from another source", false, AttributeType.cite)]
        blockquote,

        [Element("Document body", false)]
        body,

        [Element("Line break, e.g. in poem or postal address", true)]
        br,

        [Element("Button control", false, AttributeType.disabled, AttributeType.form, AttributeType.formaction, AttributeType.formenctype, AttributeType.formmethod, AttributeType.formnovalidate, AttributeType.formtarget, AttributeType.name, AttributeType.type, AttributeType.value)]
        button,

        [Element("Scriptable bitmap canvas", false, AttributeType.width, AttributeType.height)]
        canvas,

        [Element("Table caption", false)]
        caption,

        [Element("Title of a work", false)]
        cite,

        [Element("Computer code", false)]
        code,

        [Element("Table column", true, AttributeType.span)]
        col,

        [Element("Group of columns in a table", false, AttributeType.span)]
        colgroup,

        [Element("Machine-readable equivalent", false, AttributeType.value)]
        data,

        [Element("Container for options for combo box control", false)]
        datalist,

        [Element("Content for corresponding dt element(s)", false)]
        dd,

        [Element("A removal from the document", false, AttributeType.cite, AttributeType.datetime)]
        del,

        [Element("Disclosure control for hiding details", false, AttributeType.open)]
        details,

        [Element("Defining instance", false)]
        dfn,

        [Element("Dialog box or window", false, AttributeType.open)]
        dialog,

        [Element("Generic flow container, or container for name-value groups in dl elements", false)]
        div,

        [Element("Association list consisting of zero or more name-value groups", false)]
        dl,

        [Element("Legend for corresponding dd element(s)", false)]
        dt,

        [Element("Stress emphasis", false)]
        em,

        [Element("Plugin", true, AttributeType.src, AttributeType.type, AttributeType.width, AttributeType.height)]
        embed,

        [Element("Group of form controls", false, AttributeType.disabled, AttributeType.form, AttributeType.name)]
        fieldset,

        [Element("Caption for figure", false)]
        figcaption,

        [Element("Figure with optional caption", false)]
        figure,

        [Element("Footer for a page or section", false)]
        footer,

        [Element("User-submittable form", false, AttributeType.accept_charset, AttributeType.action, AttributeType.autocomplete, AttributeType.enctype, AttributeType.method, AttributeType.name, AttributeType.novalidate, AttributeType.target)]
        form,

        [Element("Section heading", false)]
        h1,

        [Element("Section heading", false)]
        h2,

        [Element("Section heading", false)]
        h3,

        [Element("Section heading", false)]
        h4,

        [Element("Section heading", false)]
        h5,

        [Element("Section heading", false)]
        h6,

        [Element("Container for document metadata", false)]
        head,

        [Element("Introductory or navigational aids for a page or section", false)]
        header,

        [Element("heading group", false)]
        hgroup,

        [Element("Thematic break", true)]
        hr,

        [Element("Root element", false)]
        html,

        [Element("Alternate voice", false)]
        i,

        [Element("Nested browsing context", false, AttributeType.src, AttributeType.srcdoc, AttributeType.name, AttributeType.sandbox, AttributeType.allow, AttributeType.allowfullscreen, AttributeType.width, AttributeType.height, AttributeType.referrerpolicy, AttributeType.loading)]
        iframe,

        [Element("Image", true, AttributeType.alt, AttributeType.src, AttributeType.srcset, AttributeType.sizes, AttributeType.crossorigin, AttributeType.usemap, AttributeType.ismap, AttributeType.width, AttributeType.height, AttributeType.referrerpolicy, AttributeType.decoding, AttributeType.loading)]
        img,

        [Element("Form control", true, AttributeType.accept, AttributeType.alt, AttributeType.autocomplete, AttributeType.checked_, AttributeType.dirname, AttributeType.disabled, AttributeType.form, AttributeType.formaction, AttributeType.formenctype, AttributeType.formmethod, AttributeType.formnovalidate, AttributeType.formtarget, AttributeType.height, AttributeType.list, AttributeType.max, AttributeType.maxlength, AttributeType.min, AttributeType.minlength, AttributeType.multiple, AttributeType.name, AttributeType.pattern, AttributeType.placeholder, AttributeType.readonly_, AttributeType.required, AttributeType.size, AttributeType.src, AttributeType.step, AttributeType.type, AttributeType.value, AttributeType.width)]
        input,

        [Element("An addition to the document", false, AttributeType.cite, AttributeType.datetime)]
        ins,

        [Element("User input", false)]
        kbd,

        [Element("Caption for a form control", false, AttributeType.for_)]
        label,

        [Element("Caption for fieldset", false)]
        legend,

        [Element("List item", false, AttributeType.value)]
        li,

        [Element("Link metadata", true, AttributeType.href, AttributeType.crossorigin, AttributeType.rel, AttributeType.as_, AttributeType.media, AttributeType.hreflang, AttributeType.type, AttributeType.sizes, AttributeType.imagesrcset, AttributeType.imagesizes, AttributeType.referrerpolicy, AttributeType.integrity, AttributeType.color, AttributeType.disabled)]
        link,

        [Element("Container for the dominant contents of the document", false)]
        main,

        [Element("Image map", false, AttributeType.name)]
        map,

        [Element("Highlight", false)]
        mark,

        [Element("Menu of commands", false)]
        menu,

        [Element("Text metadata", true, AttributeType.name, AttributeType.http_equiv, AttributeType.content, AttributeType.charset, AttributeType.media)]
        meta,

        [Element("Gauge", false, AttributeType.value, AttributeType.min, AttributeType.max, AttributeType.low, AttributeType.high, AttributeType.optimum)]
        meter,

        [Element("Section with navigational links", false)]
        nav,

        [Element("Fallback content for script", false)]
        noscript,

        [Element("Image, nested browsing context, or plugin", false, AttributeType.data, AttributeType.type, AttributeType.name, AttributeType.form, AttributeType.width, AttributeType.height)]
        object_,

        [Element("Ordered list", false, AttributeType.reversed, AttributeType.start, AttributeType.type)]
        ol,

        [Element("Group of options in a list box", false, AttributeType.disabled, AttributeType.label)]
        optgroup,

        [Element("Option in a list box or combo box control", false, AttributeType.disabled, AttributeType.label, AttributeType.selected, AttributeType.value)]
        option,

        [Element("Calculated output value", false, AttributeType.for_, AttributeType.form, AttributeType.name)]
        output,

        [Element("Paragraph", false)]
        p,

        [Element("Parameter for object", true, AttributeType.name, AttributeType.value)]
        param,

        [Element("Image", false)]
        picture,

        [Element("Block of preformatted text", false)]
        pre,

        [Element("Progress bar", false, AttributeType.value, AttributeType.max)]
        progress,

        [Element("Quotation", false, AttributeType.cite)]
        q,

        [Element("Parenthesis for ruby annotation text", false)]
        rp,

        [Element("Ruby annotation text", false)]
        rt,

        [Element("Ruby annotation(s)", false)]
        ruby,

        [Element("Inaccurate text", false)]
        s,

        [Element("Computer output", false)]
        samp,

        [Element("Embedded script", false, AttributeType.src, AttributeType.type, AttributeType.async, AttributeType.defer, AttributeType.crossorigin, AttributeType.integrity, AttributeType.referrerpolicy)]
        script,

        [Element("Generic document or application section", false)]
        section,

        [Element("List box control", false, AttributeType.autocomplete, AttributeType.disabled, AttributeType.form, AttributeType.multiple, AttributeType.name, AttributeType.required, AttributeType.size)]
        select,

        [Element("Shadow tree slot", false, AttributeType.name)]
        slot,

        [Element("Side comment", false)]
        small,

        [Element("Image source for img or media source for video or audio", true, AttributeType.src, AttributeType.type, AttributeType.srcset, AttributeType.sizes, AttributeType.media, AttributeType.width, AttributeType.height)]
        source,

        [Element("Generic phrasing container", false)]
        span,

        [Element("Importance", false)]
        strong,

        [Element("Embedded styling information", false, AttributeType.media)]
        style,

        [Element("Subscript", false)]
        sub,

        [Element("Caption for details", false)]
        summary,

        [Element("Superscript", false)]
        sup,

        [Element("Table", false)]
        table,

        [Element("Group of rows in a table", false)]
        tbody,

        [Element("Table cell", false, AttributeType.colspan, AttributeType.rowspan, AttributeType.headers)]
        td,

        [Element("Template", false)]
        template,

        [Element("Multiline text controls", false, AttributeType.cols, AttributeType.dirname, AttributeType.disabled, AttributeType.form, AttributeType.maxlength, AttributeType.minlength, AttributeType.name, AttributeType.placeholder, AttributeType.readonly_, AttributeType.required, AttributeType.rows, AttributeType.wrap)]
        textarea,

        [Element("Group of footer rows in a table", false)]
        tfoot,

        [Element("Table header cell", false, AttributeType.colspan, AttributeType.rowspan, AttributeType.headers, AttributeType.scope, AttributeType.abbr)]
        th,

        [Element("Group of heading rows in a table", false)]
        thead,

        [Element("Machine-readable equivalent of date- or time-related data", false, AttributeType.datetime)]
        time,

        [Element("Document title", false)]
        title,

        [Element("Table row", false)]
        tr,

        [Element("Timed text track", true, AttributeType.default_, AttributeType.kind, AttributeType.label, AttributeType.src, AttributeType.srclang)]
        track,

        [Element("Unarticulated annotation", false)]
        u,

        [Element("List", false)]
        ul,

        [Element("Variable", false)]
        var,

        [Element("Video player", false, AttributeType.src, AttributeType.crossorigin, AttributeType.poster, AttributeType.preload, AttributeType.autoplay, AttributeType.playsinline, AttributeType.loop, AttributeType.muted, AttributeType.controls, AttributeType.width, AttributeType.height)]
        video,

        [Element("Line breaking opportunity", true)]
        wbr,
    }
}
