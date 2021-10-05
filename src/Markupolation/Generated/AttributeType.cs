namespace Markupolation
{
    internal enum AttributeType
    {
        [Attribute("Alternative label to use for the header cell when referencing the cell in other contexts", false, false, "th")]
        abbr,

        [Attribute("Hint for expected file type in file upload controls", false, false, "input")]
        accept,

        [Attribute("Character encodings to use for form submission", false, false, "form")]
        accept_charset,

        [Attribute("Keyboard shortcut to activate or focus element", true, false)]
        accesskey,

        [Attribute("URL to use for form submission", false, false, "form")]
        action,

        [Attribute("Permissions policy to be applied to the iframe's contents", false, false, "iframe")]
        allow,

        [Attribute("Whether to allow the iframe's contents to use requestFullscreen()", false, true, "iframe")]
        allowfullscreen,

        [Attribute("Replacement text for use when images are not available", false, false, "area", "img", "input")]
        alt,

        [Attribute("Potential destination for a preload request (for rel=\"preload\" and rel=\"modulepreload\")", false, false, "link")]
        as_,

        [Attribute("Execute script when available, without blocking while fetching", false, true, "script")]
        async,

        [Attribute("Recommended autocapitalization behavior (for supported input methods)", true, false)]
        autocapitalize,

        [Attribute("Default setting for autofill feature for controls in the form", false, false, "form")]
        [Attribute("Hint for form autofill feature", false, false, "input", "select", "textarea")]
        autocomplete,

        [Attribute("Automatically focus the element when the page is loaded", true, true)]
        autofocus,

        [Attribute("Hint that the media resource can be started automatically when the page is loaded", false, true, "audio", "video")]
        autoplay,

        [Attribute("Character encoding declaration", false, false, "meta")]
        charset,

        [Attribute("Whether the control is checked", false, true, "input")]
        checked_,

        [Attribute("Link to the source of the quotation or more information about the edit", false, false, "blockquote", "del", "ins", "q")]
        cite,

        [Attribute("Classes to which the element belongs", false, false)]
        class_,

        [Attribute("Color to use when customizing a site's icon (for rel=\"mask-icon\")", false, false, "link")]
        color,

        [Attribute("Maximum number of characters per line", false, false, "textarea")]
        cols,

        [Attribute("Number of columns that the cell is to span", false, false, "td", "th")]
        colspan,

        [Attribute("Value of the element", false, false, "meta")]
        content,

        [Attribute("Whether the element is editable", true, false)]
        contenteditable,

        [Attribute("Show user agent controls", false, true, "audio", "video")]
        controls,

        [Attribute("Coordinates for the shape to be created in an image map", false, false, "area")]
        coords,

        [Attribute("How the element handles crossorigin requests", false, false, "audio", "img", "link", "script", "video")]
        crossorigin,

        [Attribute("Address of the resource", false, false, "object_")]
        data,

        [Attribute("Date and (optionally) time of the change", false, false, "del", "ins")]
        [Attribute("Machine-readable value", false, false, "time")]
        datetime,

        [Attribute("Decoding hint to use when processing this image for presentation", false, false, "img")]
        decoding,

        [Attribute("Enable the track if no other text track is more suitable", false, true, "track")]
        default_,

        [Attribute("Defer script execution", false, true, "script")]
        defer,

        [Attribute("The text directionality of the element", true, false)]
        [Attribute("The text directionality of the element", true, false)]
        dir,

        [Attribute("Name of form control to use for sending the element's directionality in form submission", false, false, "input", "textarea")]
        dirname,

        [Attribute("Whether the form control is disabled", false, true, "button", "input", "optgroup", "option", "select", "textarea")]
        [Attribute("Whether the descendant form controls, except any inside legend, are disabled", false, true, "fieldset")]
        [Attribute("Whether the link is disabled", false, true, "link")]
        disabled,

        [Attribute("Whether to download the resource instead of navigating to it, and its filename if so", false, false, "a", "area")]
        download,

        [Attribute("Whether the element is draggable", true, false)]
        draggable,

        [Attribute("Entry list encoding type to use for form submission", false, false, "form")]
        enctype,

        [Attribute("Hint for selecting an enter key action", true, false)]
        enterkeyhint,

        [Attribute("Associate the label with form control", false, false, "label")]
        [Attribute("Specifies controls from which the output was calculated", false, false, "output")]
        for_,

        [Attribute("Associates the element with a form element", false, false, "button", "fieldset", "input", "object_", "output", "select", "textarea")]
        form,

        [Attribute("URL to use for form submission", false, false, "button", "input")]
        formaction,

        [Attribute("Entry list encoding type to use for form submission", false, false, "button", "input")]
        formenctype,

        [Attribute("Variant to use for form submission", false, false, "button", "input")]
        formmethod,

        [Attribute("Bypass form control validation for form submission", false, true, "button", "input")]
        formnovalidate,

        [Attribute("Browsing context for form submission", false, false, "button", "input")]
        formtarget,

        [Attribute("The header cells for this cell", false, false, "td", "th")]
        headers,

        [Attribute("Vertical dimension", false, false, "canvas", "embed", "iframe", "img", "input", "object_", "source", "video")]
        height,

        [Attribute("Whether the element is relevant", true, true)]
        hidden,

        [Attribute("Low limit of high range", false, false, "meter")]
        high,

        [Attribute("Address of the hyperlink", false, false, "a", "area")]
        [Attribute("Address of the hyperlink", false, false, "link")]
        [Attribute("Document base URL", false, false, "base_")]
        href,

        [Attribute("Language of the linked resource", false, false, "a", "link")]
        hreflang,

        [Attribute("Pragma directive", false, false, "meta")]
        http_equiv,

        [Attribute("The element's ID", false, false)]
        id,

        [Attribute("Image sizes for different page layouts (for rel=\"preload\")", false, false, "link")]
        imagesizes,

        [Attribute("Images to use in different situations, e.g., high-resolution displays, small monitors, etc. (for rel=\"preload\")", false, false, "link")]
        imagesrcset,

        [Attribute("Hint for selecting an input modality", true, false)]
        inputmode,

        [Attribute("Integrity metadata used in Subresource Integrity checks [SRI]", false, false, "link", "script")]
        integrity,

        [Attribute("Creates a customized built-in element", true, false)]
        is_,

        [Attribute("Whether the image is a server-side image map", false, true, "img")]
        ismap,

        [Attribute("Global identifier for a microdata item", true, false)]
        itemid,

        [Attribute("Property names of a microdata item", true, false)]
        itemprop,

        [Attribute("Referenced elements", true, false)]
        itemref,

        [Attribute("Introduces a microdata item", true, true)]
        itemscope,

        [Attribute("Item types of a microdata item", true, false)]
        itemtype,

        [Attribute("The type of text track", false, false, "track")]
        kind,

        [Attribute("User-visible label", false, false, "optgroup", "option", "track")]
        label,

        [Attribute("Language of the element", true, false)]
        lang,

        [Attribute("List of autocomplete options", false, false, "input")]
        list,

        [Attribute("Used when determining loading deferral", false, false, "img", "iframe")]
        loading,

        [Attribute("Whether to loop the media resource", false, true, "audio", "video")]
        loop,

        [Attribute("High limit of low range", false, false, "meter")]
        low,

        [Attribute("Maximum value", false, false, "input")]
        [Attribute("Upper bound of range", false, false, "meter", "progress")]
        max,

        [Attribute("Maximum length of value", false, false, "input", "textarea")]
        maxlength,

        [Attribute("Applicable media", false, false, "link", "meta", "source", "style")]
        media,

        [Attribute("Variant to use for form submission", false, false, "form")]
        method,

        [Attribute("Minimum value", false, false, "input")]
        [Attribute("Lower bound of range", false, false, "meter")]
        min,

        [Attribute("Minimum length of value", false, false, "input", "textarea")]
        minlength,

        [Attribute("Whether to allow multiple values", false, true, "input", "select")]
        multiple,

        [Attribute("Whether to mute the media resource by default", false, true, "audio", "video")]
        muted,

        [Attribute("Name of the element to use for form submission and in the form.elements API", false, false, "button", "fieldset", "input", "output", "select", "textarea")]
        [Attribute("Name of form to use in the document.forms API", false, false, "form")]
        [Attribute("Name of nested browsing context", false, false, "iframe", "object_")]
        [Attribute("Name of image map to reference from the usemap attribute", false, false, "map")]
        [Attribute("Metadata name", false, false, "meta")]
        [Attribute("Name of parameter", false, false, "param")]
        [Attribute("Name of shadow tree slot", false, false, "slot")]
        name,

        [Attribute("Prevents execution in user agents that support module scripts", false, true, "script")]
        nomodule,

        [Attribute("Cryptographic nonce used in Content Security Policy checks [CSP]", true, false)]
        nonce,

        [Attribute("Bypass form control validation for form submission", false, true, "form")]
        novalidate,

        [Attribute("Whether the details are visible", false, true, "details")]
        [Attribute("Whether the dialog box is showing", false, true, "dialog")]
        open,

        [Attribute("Optimum value in gauge", false, false, "meter")]
        optimum,

        [Attribute("Pattern to be matched by the form control's value", false, false, "input")]
        pattern,

        [Attribute("URLs to ping", false, false)]
        ping,

        [Attribute("User-visible label to be placed within the form control", false, false, "input", "textarea")]
        placeholder,

        [Attribute("Encourage the user agent to display video content within the element's playback area", false, true, "video")]
        playsinline,

        [Attribute("Poster frame to show prior to video playback", false, false, "video")]
        poster,

        [Attribute("Hints how much buffering the media resource will likely need", false, false, "audio", "video")]
        preload,

        [Attribute("Whether to allow the value to be edited by the user", false, true, "input", "textarea")]
        [Attribute("Affects willValidate, plus any behavior added by the custom element author", false, true)]
        readonly_,

        [Attribute("Referrer policy for fetches initiated by the element", false, false, "a", "area", "iframe", "img", "link", "script")]
        referrerpolicy,

        [Attribute("Relationship between the location in the document containing the hyperlink and the destination resource", false, false, "a", "area")]
        [Attribute("Relationship between the document containing the hyperlink and the destination resource", false, false, "link")]
        rel,

        [Attribute("Whether the control is required for form submission", false, true, "input", "select", "textarea")]
        required,

        [Attribute("Number the list backwards", false, true, "ol")]
        reversed,

        [Attribute("Number of lines to show", false, false, "textarea")]
        rows,

        [Attribute("Number of rows that the cell is to span", false, false, "td", "th")]
        rowspan,

        [Attribute("Security rules for nested content", false, false, "iframe")]
        sandbox,

        [Attribute("Specifies which cells the header cell applies to", false, false, "th")]
        scope,

        [Attribute("Whether the option is selected by default", false, true, "option")]
        selected,

        [Attribute("The kind of shape to be created in an image map", false, false, "area")]
        shape,

        [Attribute("Size of the control", false, false, "input", "select")]
        size,

        [Attribute("Sizes of the icons (for rel=\"icon\")", false, false, "link")]
        [Attribute("Image sizes for different page layouts", false, false, "img", "source")]
        sizes,

        [Attribute("The element's desired slot", false, false)]
        slot,

        [Attribute("Number of columns spanned by the element", false, false, "col", "colgroup")]
        span,

        [Attribute("Whether the element is to have its spelling and grammar checked", true, false)]
        spellcheck,

        [Attribute("Address of the resource", false, false, "audio", "embed", "iframe", "img", "input", "script", "source", "track", "video")]
        src,

        [Attribute("A document to render in the iframe", false, false, "iframe")]
        srcdoc,

        [Attribute("Language of the text track", false, false, "track")]
        srclang,

        [Attribute("Images to use in different situations, e.g., high-resolution displays, small monitors, etc.", false, false, "img", "source")]
        srcset,

        [Attribute("Starting value of the list", false, false, "ol")]
        start,

        [Attribute("Granularity to be matched by the form control's value", false, false, "input")]
        step,

        [Attribute("Presentational and formatting instructions", true, false)]
        style,

        [Attribute("Whether the element is focusable and sequentially focusable, and the relative order of the element for the purposes of sequential focus navigation", true, false)]
        tabindex,

        [Attribute("Browsing context for hyperlink navigation", false, false, "a", "area")]
        [Attribute("Default browsing context for hyperlink navigation and form submission", false, false, "base_")]
        [Attribute("Browsing context for form submission", false, false, "form")]
        target,

        [Attribute("Advisory information for the element", true, false)]
        [Attribute("Full term or expansion of abbreviation", true, false, "abbr", "dfn")]
        [Attribute("Description of pattern (when used with pattern attribute)", true, false, "input")]
        [Attribute("Title of the link", true, false, "link")]
        [Attribute("CSS style sheet set name", true, false, "link", "style")]
        title,

        [Attribute("Whether the element is to be translated when the page is localized", true, false)]
        translate,

        [Attribute("Hint for the type of the referenced resource", false, false, "a", "link")]
        [Attribute("Type of button", false, false, "button")]
        [Attribute("Type of embedded resource", false, false, "embed", "object_", "source")]
        [Attribute("Type of form control", false, false, "input")]
        [Attribute("Kind of list marker", false, false, "ol")]
        [Attribute("Type of script", false, false, "script")]
        type,

        [Attribute("Name of image map to use", false, false, "img")]
        usemap,

        [Attribute("Value to be used for form submission", false, false, "button", "option")]
        [Attribute("Machine-readable value", false, false, "data")]
        [Attribute("Value of the form control", false, false, "input")]
        [Attribute("Ordinal value of the list item", false, false, "li")]
        [Attribute("Current value of the element", false, false, "meter", "progress")]
        [Attribute("Value of parameter", false, false, "param")]
        value,

        [Attribute("Horizontal dimension", false, false, "canvas", "embed", "iframe", "img", "input", "object_", "source", "video")]
        width,

        [Attribute("How the value of the form control is to be wrapped for form submission", false, false, "textarea")]
        wrap,
    }
}
