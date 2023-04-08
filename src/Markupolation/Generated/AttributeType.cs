namespace Markupolation
{
    internal enum AttributeType
    {
        [Attribute("Alternative label to use for the header cell when referencing the cell in other contexts", false, false, ElementType.th)]
        abbr,

        [Attribute("Hint for expected file type in file upload controls", false, false, ElementType.input)]
        accept,

        [Attribute("Character encodings to use for form submission", false, false, ElementType.form)]
        accept_charset,

        [Attribute("Keyboard shortcut to activate or focus element", true, false)]
        accesskey,

        [Attribute("URL to use for form submission", false, false, ElementType.form)]
        action,

        [Attribute("Permissions policy to be applied to the iframe's contents", false, false, ElementType.iframe)]
        allow,

        [Attribute("Whether to allow the iframe's contents to use requestFullscreen()", false, true, ElementType.iframe)]
        allowfullscreen,

        [Attribute("Replacement text for use when images are not available", false, false, ElementType.area, ElementType.img, ElementType.input)]
        alt,

        [Attribute("Potential destination for a preload request (for rel=\"preload\" and rel=\"modulepreload\")", false, false, ElementType.link)]
        as_,

        [Attribute("Execute script when available, without blocking while fetching", false, true, ElementType.script)]
        async,

        [Attribute("Recommended autocapitalization behavior (for supported input methods)", true, false)]
        autocapitalize,

        [Attribute("Default setting for autofill feature for controls in the form", false, false, ElementType.form)]
        [Attribute("Hint for form autofill feature", false, false, ElementType.input, ElementType.select, ElementType.textarea)]
        autocomplete,

        [Attribute("Automatically focus the element when the page is loaded", true, true)]
        autofocus,

        [Attribute("Hint that the media resource can be started automatically when the page is loaded", false, true, ElementType.audio, ElementType.video)]
        autoplay,

        [Attribute("Whether the element is potentially render-blocking", false, false, ElementType.link, ElementType.script, ElementType.style)]
        blocking,

        [Attribute("Character encoding declaration", false, false, ElementType.meta)]
        charset,

        [Attribute("Whether the control is checked", false, true, ElementType.input)]
        checked_,

        [Attribute("Link to the source of the quotation or more information about the edit", false, false, ElementType.blockquote, ElementType.del, ElementType.ins, ElementType.q)]
        cite,

        [Attribute("Classes to which the element belongs", false, false)]
        class_,

        [Attribute("Color to use when customizing a site's icon (for rel=\"mask-icon\")", false, false, ElementType.link)]
        color,

        [Attribute("Maximum number of characters per line", false, false, ElementType.textarea)]
        cols,

        [Attribute("Number of columns that the cell is to span", false, false, ElementType.td, ElementType.th)]
        colspan,

        [Attribute("Value of the element", false, false, ElementType.meta)]
        content,

        [Attribute("Whether the element is editable", true, false)]
        contenteditable,

        [Attribute("Show user agent controls", false, true, ElementType.audio, ElementType.video)]
        controls,

        [Attribute("Coordinates for the shape to be created in an image map", false, false, ElementType.area)]
        coords,

        [Attribute("How the element handles crossorigin requests", false, false, ElementType.audio, ElementType.img, ElementType.link, ElementType.script, ElementType.video)]
        crossorigin,

        [Attribute("Address of the resource", false, false, ElementType.object_)]
        data,

        [Attribute("Date and (optionally) time of the change", false, false, ElementType.del, ElementType.ins)]
        [Attribute("Machine-readable value", false, false, ElementType.time)]
        datetime,

        [Attribute("Decoding hint to use when processing this image for presentation", false, false, ElementType.img)]
        decoding,

        [Attribute("Enable the track if no other text track is more suitable", false, true, ElementType.track)]
        default_,

        [Attribute("Defer script execution", false, true, ElementType.script)]
        defer,

        [Attribute("The text directionality of the element", true, false)]
        [Attribute("The text directionality of the element", true, false)]
        dir,

        [Attribute("Name of form control to use for sending the element's directionality in form submission", false, false, ElementType.input, ElementType.textarea)]
        dirname,

        [Attribute("Whether the form control is disabled", false, true, ElementType.button, ElementType.input, ElementType.optgroup, ElementType.option, ElementType.select, ElementType.textarea)]
        [Attribute("Whether the descendant form controls, except any inside legend, are disabled", false, true, ElementType.fieldset)]
        [Attribute("Whether the link is disabled", false, true, ElementType.link)]
        disabled,

        [Attribute("Whether to download the resource instead of navigating to it, and its filename if so", false, false, ElementType.a, ElementType.area)]
        download,

        [Attribute("Whether the element is draggable", true, false)]
        draggable,

        [Attribute("Entry list encoding type to use for form submission", false, false, ElementType.form)]
        enctype,

        [Attribute("Hint for selecting an enter key action", true, false)]
        enterkeyhint,

        [Attribute("Sets the priority for fetches initiated by the element", false, false, ElementType.img, ElementType.link, ElementType.script)]
        fetchpriority,

        [Attribute("Associate the label with form control", false, false, ElementType.label)]
        [Attribute("Specifies controls from which the output was calculated", false, false, ElementType.output)]
        for_,

        [Attribute("Associates the element with a form element", false, false, ElementType.button, ElementType.fieldset, ElementType.input, ElementType.object_, ElementType.output, ElementType.select, ElementType.textarea)]
        form,

        [Attribute("URL to use for form submission", false, false, ElementType.button, ElementType.input)]
        formaction,

        [Attribute("Entry list encoding type to use for form submission", false, false, ElementType.button, ElementType.input)]
        formenctype,

        [Attribute("Variant to use for form submission", false, false, ElementType.button, ElementType.input)]
        formmethod,

        [Attribute("Bypass form control validation for form submission", false, true, ElementType.button, ElementType.input)]
        formnovalidate,

        [Attribute("Navigable for form submission", false, false, ElementType.button, ElementType.input)]
        formtarget,

        [Attribute("The header cells for this cell", false, false, ElementType.td, ElementType.th)]
        headers,

        [Attribute("Vertical dimension", false, false, ElementType.canvas, ElementType.embed, ElementType.iframe, ElementType.img, ElementType.input, ElementType.object_, ElementType.source, ElementType.video)]
        height,

        [Attribute("Whether the element is relevant", true, false)]
        hidden,

        [Attribute("Low limit of high range", false, false, ElementType.meter)]
        high,

        [Attribute("Address of the hyperlink", false, false, ElementType.a, ElementType.area)]
        [Attribute("Address of the hyperlink", false, false, ElementType.link)]
        [Attribute("Document base URL", false, false, ElementType.base_)]
        href,

        [Attribute("Language of the linked resource", false, false, ElementType.a, ElementType.link)]
        hreflang,

        [Attribute("Pragma directive", false, false, ElementType.meta)]
        http_equiv,

        [Attribute("The element's ID", false, false)]
        id,

        [Attribute("Image sizes for different page layouts (for rel=\"preload\")", false, false, ElementType.link)]
        imagesizes,

        [Attribute("Images to use in different situations, e.g., high-resolution displays, small monitors, etc. (for rel=\"preload\")", false, false, ElementType.link)]
        imagesrcset,

        [Attribute("Whether the element is inert.", true, true)]
        inert,

        [Attribute("Hint for selecting an input modality", true, false)]
        inputmode,

        [Attribute("Integrity metadata used in Subresource Integrity checks [SRI]", false, false, ElementType.link, ElementType.script)]
        integrity,

        [Attribute("Creates a customized built-in element", true, false)]
        is_,

        [Attribute("Whether the image is a server-side image map", false, true, ElementType.img)]
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

        [Attribute("The type of text track", false, false, ElementType.track)]
        kind,

        [Attribute("User-visible label", false, false, ElementType.optgroup, ElementType.option, ElementType.track)]
        label,

        [Attribute("Language of the element", true, false)]
        lang,

        [Attribute("List of autocomplete options", false, false, ElementType.input)]
        list,

        [Attribute("Used when determining loading deferral", false, false, ElementType.iframe, ElementType.img)]
        loading,

        [Attribute("Whether to loop the media resource", false, true, ElementType.audio, ElementType.video)]
        loop,

        [Attribute("High limit of low range", false, false, ElementType.meter)]
        low,

        [Attribute("Maximum value", false, false, ElementType.input)]
        [Attribute("Upper bound of range", false, false, ElementType.meter, ElementType.progress)]
        max,

        [Attribute("Maximum length of value", false, false, ElementType.input, ElementType.textarea)]
        maxlength,

        [Attribute("Applicable media", false, false, ElementType.link, ElementType.meta, ElementType.source, ElementType.style)]
        media,

        [Attribute("Variant to use for form submission", false, false, ElementType.form)]
        method,

        [Attribute("Minimum value", false, false, ElementType.input)]
        [Attribute("Lower bound of range", false, false, ElementType.meter)]
        min,

        [Attribute("Minimum length of value", false, false, ElementType.input, ElementType.textarea)]
        minlength,

        [Attribute("Whether to allow multiple values", false, true, ElementType.input, ElementType.select)]
        multiple,

        [Attribute("Whether to mute the media resource by default", false, true, ElementType.audio, ElementType.video)]
        muted,

        [Attribute("Name of the element to use for form submission and in the form.elements API", false, false, ElementType.button, ElementType.fieldset, ElementType.input, ElementType.output, ElementType.select, ElementType.textarea)]
        [Attribute("Name of form to use in the document.forms API", false, false, ElementType.form)]
        [Attribute("Name of content navigable", false, false, ElementType.iframe, ElementType.object_)]
        [Attribute("Name of image map to reference from the usemap attribute", false, false, ElementType.map)]
        [Attribute("Metadata name", false, false, ElementType.meta)]
        [Attribute("Name of shadow tree slot", false, false, ElementType.slot)]
        name,

        [Attribute("Prevents execution in user agents that support module scripts", false, true, ElementType.script)]
        nomodule,

        [Attribute("Cryptographic nonce used in Content Security Policy checks [CSP]", true, false)]
        nonce,

        [Attribute("Bypass form control validation for form submission", false, true, ElementType.form)]
        novalidate,

        [Attribute("Whether the details are visible", false, true, ElementType.details)]
        [Attribute("Whether the dialog box is showing", false, true, ElementType.dialog)]
        open,

        [Attribute("Optimum value in gauge", false, false, ElementType.meter)]
        optimum,

        [Attribute("Pattern to be matched by the form control's value", false, false, ElementType.input)]
        pattern,

        [Attribute("URLs to ping", false, false)]
        ping,

        [Attribute("User-visible label to be placed within the form control", false, false, ElementType.input, ElementType.textarea)]
        placeholder,

        [Attribute("Encourage the user agent to display video content within the element's playback area", false, true, ElementType.video)]
        playsinline,

        [Attribute("Makes the element a popover element", true, false)]
        popover,

        [Attribute("Targets a popover element to toggle, show, or hide", false, false)]
        popovertarget,

        [Attribute("Indicates whether a targeted popover element is to be toggled, shown, or hidden", false, false)]
        popovertargetaction,

        [Attribute("Poster frame to show prior to video playback", false, false, ElementType.video)]
        poster,

        [Attribute("Hints how much buffering the media resource will likely need", false, false, ElementType.audio, ElementType.video)]
        preload,

        [Attribute("Whether to allow the value to be edited by the user", false, true, ElementType.input, ElementType.textarea)]
        [Attribute("Affects willValidate, plus any behavior added by the custom element author", false, true)]
        readonly_,

        [Attribute("Referrer policy for fetches initiated by the element", false, false, ElementType.a, ElementType.area, ElementType.iframe, ElementType.img, ElementType.link, ElementType.script)]
        referrerpolicy,

        [Attribute("Relationship between the location in the document containing the hyperlink and the destination resource", false, false, ElementType.a, ElementType.area)]
        [Attribute("Relationship between the document containing the hyperlink and the destination resource", false, false, ElementType.link)]
        rel,

        [Attribute("Whether the control is required for form submission", false, true, ElementType.input, ElementType.select, ElementType.textarea)]
        required,

        [Attribute("Number the list backwards", false, true, ElementType.ol)]
        reversed,

        [Attribute("Number of lines to show", false, false, ElementType.textarea)]
        rows,

        [Attribute("Number of rows that the cell is to span", false, false, ElementType.td, ElementType.th)]
        rowspan,

        [Attribute("Security rules for nested content", false, false, ElementType.iframe)]
        sandbox,

        [Attribute("Specifies which cells the header cell applies to", false, false, ElementType.th)]
        scope,

        [Attribute("Whether the option is selected by default", false, true, ElementType.option)]
        selected,

        [Attribute("The kind of shape to be created in an image map", false, false, ElementType.area)]
        shape,

        [Attribute("Size of the control", false, false, ElementType.input, ElementType.select)]
        size,

        [Attribute("Sizes of the icons (for rel=\"icon\")", false, false, ElementType.link)]
        [Attribute("Image sizes for different page layouts", false, false, ElementType.img, ElementType.source)]
        sizes,

        [Attribute("The element's desired slot", false, false)]
        slot,

        [Attribute("Number of columns spanned by the element", false, false, ElementType.col, ElementType.colgroup)]
        span,

        [Attribute("Whether the element is to have its spelling and grammar checked", true, false)]
        spellcheck,

        [Attribute("Address of the resource", false, false, ElementType.audio, ElementType.embed, ElementType.iframe, ElementType.img, ElementType.input, ElementType.script, ElementType.source, ElementType.track, ElementType.video)]
        src,

        [Attribute("A document to render in the iframe", false, false, ElementType.iframe)]
        srcdoc,

        [Attribute("Language of the text track", false, false, ElementType.track)]
        srclang,

        [Attribute("Images to use in different situations, e.g., high-resolution displays, small monitors, etc.", false, false, ElementType.img, ElementType.source)]
        srcset,

        [Attribute("Starting value of the list", false, false, ElementType.ol)]
        start,

        [Attribute("Granularity to be matched by the form control's value", false, false, ElementType.input)]
        step,

        [Attribute("Presentational and formatting instructions", true, false)]
        style,

        [Attribute("Whether the element is focusable and sequentially focusable, and the relative order of the element for the purposes of sequential focus navigation", true, false)]
        tabindex,

        [Attribute("Navigable for hyperlink navigation", false, false, ElementType.a, ElementType.area)]
        [Attribute("Default navigable for hyperlink navigation and form submission", false, false, ElementType.base_)]
        [Attribute("Navigable for form submission", false, false, ElementType.form)]
        target,

        [Attribute("Advisory information for the element", true, false)]
        [Attribute("Full term or expansion of abbreviation", true, false, ElementType.abbr, ElementType.dfn)]
        [Attribute("Description of pattern (when used with pattern attribute)", true, false, ElementType.input)]
        [Attribute("Title of the link", true, false, ElementType.link)]
        [Attribute("CSS style sheet set name", true, false, ElementType.link, ElementType.style)]
        title,

        [Attribute("Whether the element is to be translated when the page is localized", true, false)]
        translate,

        [Attribute("Hint for the type of the referenced resource", false, false, ElementType.a, ElementType.link)]
        [Attribute("Type of button", false, false, ElementType.button)]
        [Attribute("Type of embedded resource", false, false, ElementType.embed, ElementType.object_, ElementType.source)]
        [Attribute("Type of form control", false, false, ElementType.input)]
        [Attribute("Kind of list marker", false, false, ElementType.ol)]
        [Attribute("Type of script", false, false, ElementType.script)]
        type,

        [Attribute("Name of image map to use", false, false, ElementType.img)]
        usemap,

        [Attribute("Value to be used for form submission", false, false, ElementType.button, ElementType.option)]
        [Attribute("Machine-readable value", false, false, ElementType.data)]
        [Attribute("Value of the form control", false, false, ElementType.input)]
        [Attribute("Ordinal value of the list item", false, false, ElementType.li)]
        [Attribute("Current value of the element", false, false, ElementType.meter, ElementType.progress)]
        value,

        [Attribute("Horizontal dimension", false, false, ElementType.canvas, ElementType.embed, ElementType.iframe, ElementType.img, ElementType.input, ElementType.object_, ElementType.source, ElementType.video)]
        width,

        [Attribute("How the value of the form control is to be wrapped for form submission", false, false, ElementType.textarea)]
        wrap,
    }
}
