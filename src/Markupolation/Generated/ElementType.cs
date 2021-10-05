namespace Markupolation
{
    internal enum ElementType
    {
        [Element("Hyperlink", false, "href", "target", "download", "rel", "hreflang", "type", "referrerpolicy")]
        a,

        [Element("Abbreviation", false)]
        abbr,

        [Element("Contact information for a page or article element", false)]
        address,

        [Element("Hyperlink or dead area on an image map", true, "alt", "coords", "shape", "href", "target", "download", "rel", "referrerpolicy")]
        area,

        [Element("Self-contained syndicatable or reusable composition", false)]
        article,

        [Element("Sidebar for tangentially related content", false)]
        aside,

        [Element("Audio player", false, "src", "crossorigin", "preload", "autoplay", "loop", "muted", "controls")]
        audio,

        [Element("Keywords", false)]
        b,

        [Element("Base URL and default target browsing context for hyperlinks and forms", true, "href", "target")]
        base_,

        [Element("Text directionality isolation", false)]
        bdi,

        [Element("Text directionality formatting", false)]
        bdo,

        [Element("A section quoted from another source", false, "cite")]
        blockquote,

        [Element("Document body", false)]
        body,

        [Element("Line break, e.g. in poem or postal address", true)]
        br,

        [Element("Button control", false, "disabled", "form", "formaction", "formenctype", "formmethod", "formnovalidate", "formtarget", "name", "type", "value")]
        button,

        [Element("Scriptable bitmap canvas", false, "width", "height")]
        canvas,

        [Element("Table caption", false)]
        caption,

        [Element("Title of a work", false)]
        cite,

        [Element("Computer code", false)]
        code,

        [Element("Table column", true, "span")]
        col,

        [Element("Group of columns in a table", false, "span")]
        colgroup,

        [Element("Machine-readable equivalent", false, "value")]
        data,

        [Element("Container for options for combo box control", false)]
        datalist,

        [Element("Content for corresponding dt element(s)", false)]
        dd,

        [Element("A removal from the document", false, "cite", "datetime")]
        del,

        [Element("Disclosure control for hiding details", false, "open")]
        details,

        [Element("Defining instance", false)]
        dfn,

        [Element("Dialog box or window", false, "open")]
        dialog,

        [Element("Generic flow container, or container for name-value groups in dl elements", false)]
        div,

        [Element("Association list consisting of zero or more name-value groups", false)]
        dl,

        [Element("Legend for corresponding dd element(s)", false)]
        dt,

        [Element("Stress emphasis", false)]
        em,

        [Element("Plugin", true, "src", "type", "width", "height")]
        embed,

        [Element("Group of form controls", false, "disabled", "form", "name")]
        fieldset,

        [Element("Caption for figure", false)]
        figcaption,

        [Element("Figure with optional caption", false)]
        figure,

        [Element("Footer for a page or section", false)]
        footer,

        [Element("User-submittable form", false, "accept-charset", "action", "autocomplete", "enctype", "method", "name", "novalidate", "target")]
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

        [Element("Root element", false, "manifest")]
        html,

        [Element("Alternate voice", false)]
        i,

        [Element("Nested browsing context", false, "src", "srcdoc", "name", "sandbox", "allow", "allowfullscreen", "width", "height", "referrerpolicy", "loading")]
        iframe,

        [Element("Image", true, "alt", "src", "srcset", "sizes", "crossorigin", "usemap", "ismap", "width", "height", "referrerpolicy", "decoding", "loading")]
        img,

        [Element("Form control", true, "accept", "alt", "autocomplete", "checked", "dirname", "disabled", "form", "formaction", "formenctype", "formmethod", "formnovalidate", "formtarget", "height", "list", "max", "maxlength", "min", "minlength", "multiple", "name", "pattern", "placeholder", "readonly", "required", "size", "src", "step", "type", "value", "width")]
        input,

        [Element("An addition to the document", false, "cite", "datetime")]
        ins,

        [Element("User input", false)]
        kbd,

        [Element("Caption for a form control", false, "for")]
        label,

        [Element("Caption for fieldset", false)]
        legend,

        [Element("List item", false, "value")]
        li,

        [Element("Link metadata", true, "href", "crossorigin", "rel", "as", "media", "hreflang", "type", "sizes", "imagesrcset", "imagesizes", "referrerpolicy", "integrity", "color", "disabled")]
        link,

        [Element("Container for the dominant contents of the document", false)]
        main,

        [Element("Image map", false, "name")]
        map,

        [Element("Highlight", false)]
        mark,

        [Element("Menu of commands", false)]
        menu,

        [Element("Text metadata", true, "name", "http-equiv", "content", "charset", "media")]
        meta,

        [Element("Gauge", false, "value", "min", "max", "low", "high", "optimum")]
        meter,

        [Element("Section with navigational links", false)]
        nav,

        [Element("Fallback content for script", false)]
        noscript,

        [Element("Image, nested browsing context, or plugin", false, "data", "type", "name", "form", "width", "height")]
        object_,

        [Element("Ordered list", false, "reversed", "start", "type")]
        ol,

        [Element("Group of options in a list box", false, "disabled", "label")]
        optgroup,

        [Element("Option in a list box or combo box control", false, "disabled", "label", "selected", "value")]
        option,

        [Element("Calculated output value", false, "for", "form", "name")]
        output,

        [Element("Paragraph", false)]
        p,

        [Element("Parameter for object", true, "name", "value")]
        param,

        [Element("Image", false)]
        picture,

        [Element("Block of preformatted text", false)]
        pre,

        [Element("Progress bar", false, "value", "max")]
        progress,

        [Element("Quotation", false, "cite")]
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

        [Element("Embedded script", false, "src", "type", "async", "defer", "crossorigin", "integrity", "referrerpolicy")]
        script,

        [Element("Generic document or application section", false)]
        section,

        [Element("List box control", false, "autocomplete", "disabled", "form", "multiple", "name", "required", "size")]
        select,

        [Element("Shadow tree slot", false, "name")]
        slot,

        [Element("Side comment", false)]
        small,

        [Element("Image source for img or media source for video or audio", true, "src", "type", "srcset", "sizes", "media", "width", "height")]
        source,

        [Element("Generic phrasing container", false)]
        span,

        [Element("Importance", false)]
        strong,

        [Element("Embedded styling information", false, "media")]
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

        [Element("Table cell", false, "colspan", "rowspan", "headers")]
        td,

        [Element("Template", false)]
        template,

        [Element("Multiline text controls", false, "cols", "dirname", "disabled", "form", "maxlength", "minlength", "name", "placeholder", "readonly", "required", "rows", "wrap")]
        textarea,

        [Element("Group of footer rows in a table", false)]
        tfoot,

        [Element("Table header cell", false, "colspan", "rowspan", "headers", "scope", "abbr")]
        th,

        [Element("Group of heading rows in a table", false)]
        thead,

        [Element("Machine-readable equivalent of date- or time-related data", false, "datetime")]
        time,

        [Element("Document title", false)]
        title,

        [Element("Table row", false)]
        tr,

        [Element("Timed text track", true, "default", "kind", "label", "src", "srclang")]
        track,

        [Element("Unarticulated annotation", false)]
        u,

        [Element("List", false)]
        ul,

        [Element("Variable", false)]
        var,

        [Element("Video player", false, "src", "crossorigin", "poster", "preload", "autoplay", "playsinline", "loop", "muted", "controls", "width", "height")]
        video,

        [Element("Line breaking opportunity", true)]
        wbr,
    }
}
