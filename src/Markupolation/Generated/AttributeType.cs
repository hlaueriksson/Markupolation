namespace Markupolation;

internal enum AttributeType
{
    [Attribute("Alternative label to use for the header cell when referencing the cell in other contexts", ElementType.th)]
    abbr,

    [Attribute("Hint for expected file type in file upload controls", ElementType.input)]
    accept,

    [Attribute("Character encodings to use for form submission", ElementType.form)]
    accept_charset,

    [Attribute("Keyboard shortcut to activate or focus element", IsGlobalAttribute = true)]
    accesskey,

    [Attribute("URL to use for form submission", ElementType.form)]
    action,

    [Attribute("Permissions policy to be applied to the iframe's contents", ElementType.iframe)]
    allow,

    [Attribute("Whether to allow the iframe's contents to use requestFullscreen()", ElementType.iframe, IsBooleanAttribute = true)]
    allowfullscreen,

    [Attribute("Allow the color's alpha component to be set", ElementType.input, IsBooleanAttribute = true)]
    alpha,

    [Attribute("Replacement text for use when images are not available", ElementType.area, ElementType.img, ElementType.input)]
    alt,

    [Attribute("Destination for a preload request (for rel=\"preload\" and rel=\"modulepreload\")", ElementType.link)]
    as_,

    [Attribute("Execute script when available, without blocking while fetching", ElementType.script, IsBooleanAttribute = true)]
    async,

    [Attribute("Recommended autocapitalization behavior (for supported input methods)", IsGlobalAttribute = true)]
    autocapitalize,

    [Attribute("Default setting for autofill feature for controls in the form", ElementType.form)]
    [Attribute("Hint for form autofill feature", ElementType.input, ElementType.select, ElementType.textarea)]
    autocomplete,

    [Attribute("Recommended autocorrection behavior (for supported input methods)", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    autocorrect,

    [Attribute("Automatically focus the element when the page is loaded", IsGlobalAttribute = true, IsBooleanAttribute = true)]
    autofocus,

    [Attribute("Hint that the media resource can be started automatically when the page is loaded", ElementType.audio, ElementType.video, IsBooleanAttribute = true)]
    autoplay,

    [Attribute("Whether the element is potentially render-blocking", ElementType.link, ElementType.script, ElementType.style)]
    blocking,

    [Attribute("Character encoding declaration", ElementType.meta)]
    charset,

    [Attribute("Whether the control is checked", ElementType.input, IsBooleanAttribute = true)]
    checked_,

    [Attribute("Link to the source of the quotation or more information about the edit", ElementType.blockquote, ElementType.del, ElementType.ins, ElementType.q)]
    cite,

    [Attribute("Classes to which the element belongs")]
    class_,

    [Attribute("Which user actions will close the dialog", ElementType.dialog)]
    closedby,

    [Attribute("Color to use when customizing a site's icon (for rel=\"mask-icon\")", ElementType.link)]
    color,

    [Attribute("The color space of the serialized color", ElementType.input)]
    colorspace,

    [Attribute("Maximum number of characters per line", ElementType.textarea)]
    cols,

    [Attribute("Number of columns that the cell is to span", ElementType.td, ElementType.th)]
    colspan,

    [Attribute("Indicates to the targeted element which action to take", ElementType.button)]
    command,

    [Attribute("Targets another element to be invoked", ElementType.button)]
    commandfor,

    [Attribute("Value of the element", ElementType.meta)]
    content,

    [Attribute("Whether the element is editable", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    contenteditable,

    [Attribute("Show user agent controls", ElementType.audio, ElementType.video, ElementType.img, IsBooleanAttribute = true)]
    controls,

    [Attribute("Coordinates for the shape to be created in an image map", ElementType.area)]
    coords,

    [Attribute("How the element handles crossorigin requests", ElementType.audio, ElementType.img, ElementType.link, ElementType.script, ElementType.video, IsEmptyStringValid = true)]
    crossorigin,

    [Attribute("Address of the resource", ElementType.object_)]
    data,

    [Attribute("Date and (optionally) time of the change", ElementType.del, ElementType.ins)]
    [Attribute("Machine-readable value", ElementType.time)]
    datetime,

    [Attribute("Decoding hint to use when processing this image for presentation", ElementType.img)]
    decoding,

    [Attribute("Enable the track if no other text track is more suitable", ElementType.track, IsBooleanAttribute = true)]
    default_,

    [Attribute("Defer script execution", ElementType.script, IsBooleanAttribute = true)]
    defer,

    [Attribute("The text directionality of the element", IsGlobalAttribute = true)]
    [Attribute("The text directionality of the element", IsGlobalAttribute = true)]
    dir,

    [Attribute("Name of form control to use for sending the element's directionality in form submission", ElementType.input, ElementType.textarea)]
    dirname,

    [Attribute("Whether the form control is disabled", ElementType.button, ElementType.input, ElementType.optgroup, ElementType.option, ElementType.select, ElementType.textarea, IsBooleanAttribute = true)]
    [Attribute("Whether the descendant form controls, except any inside legend, are disabled", ElementType.fieldset, IsBooleanAttribute = true)]
    [Attribute("Whether the link is disabled", ElementType.link, IsBooleanAttribute = true)]
    disabled,

    [Attribute("Whether to download the resource instead of navigating to it, and its filename if so", ElementType.a, ElementType.area)]
    download,

    [Attribute("Whether the element is draggable", IsGlobalAttribute = true)]
    draggable,

    [Attribute("Entry list encoding type to use for form submission", ElementType.form)]
    enctype,

    [Attribute("Hint for selecting an enter key action", IsGlobalAttribute = true)]
    enterkeyhint,

    [Attribute("Sets the priority for fetches initiated by the element", ElementType.img, ElementType.link, ElementType.script)]
    fetchpriority,

    [Attribute("Associate the label with form control", ElementType.label)]
    [Attribute("Specifies controls from which the output was calculated", ElementType.output)]
    [Attribute("Updates existing content", ElementType.template)]
    for_,

    [Attribute("Associates the element with a form element", ElementType.button, ElementType.fieldset, ElementType.input, ElementType.object_, ElementType.output, ElementType.select, ElementType.textarea)]
    form,

    [Attribute("URL to use for form submission", ElementType.button, ElementType.input)]
    formaction,

    [Attribute("Entry list encoding type to use for form submission", ElementType.button, ElementType.input)]
    formenctype,

    [Attribute("Variant to use for form submission", ElementType.button, ElementType.input)]
    formmethod,

    [Attribute("Bypass form control validation for form submission", ElementType.button, ElementType.input, IsBooleanAttribute = true)]
    formnovalidate,

    [Attribute("Navigable for form submission", ElementType.button, ElementType.input)]
    formtarget,

    [Attribute("The header cells for this cell", ElementType.td, ElementType.th)]
    headers,

    [Attribute("Offsets heading levels for descendants", IsGlobalAttribute = true)]
    headingoffset,

    [Attribute("Prevents a heading offset computation from traversing beyond the element with the attribute", IsGlobalAttribute = true, IsBooleanAttribute = true)]
    headingreset,

    [Attribute("Vertical dimension", ElementType.canvas, ElementType.embed, ElementType.iframe, ElementType.img, ElementType.input, ElementType.object_, ElementType.source, ElementType.video)]
    height,

    [Attribute("Whether the element is relevant", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    hidden,

    [Attribute("Low limit of high range", ElementType.meter)]
    high,

    [Attribute("Address of the hyperlink", ElementType.a, ElementType.area)]
    [Attribute("Address of the hyperlink", ElementType.link)]
    [Attribute("Document base URL", ElementType.base_)]
    href,

    [Attribute("Language of the linked resource", ElementType.a, ElementType.link)]
    hreflang,

    [Attribute("Pragma directive", ElementType.meta)]
    http_equiv,

    [Attribute("The element's ID")]
    id,

    [Attribute("Image sizes for different page layouts (for rel=\"preload\")", ElementType.link)]
    imagesizes,

    [Attribute("Images to use in different situations, e.g., high-resolution displays, small monitors, etc. (for rel=\"preload\")", ElementType.link)]
    imagesrcset,

    [Attribute("Whether the element is inert", IsGlobalAttribute = true, IsBooleanAttribute = true)]
    inert,

    [Attribute("Hint for selecting an input modality", IsGlobalAttribute = true)]
    inputmode,

    [Attribute("Integrity metadata used in Subresource Integrity checks [SRI]", ElementType.link, ElementType.script)]
    integrity,

    [Attribute("Creates a customized built-in element", IsGlobalAttribute = true)]
    is_,

    [Attribute("Whether the image is a server-side image map", ElementType.img, IsBooleanAttribute = true)]
    ismap,

    [Attribute("Global identifier for a microdata item", IsGlobalAttribute = true)]
    itemid,

    [Attribute("Property names of a microdata item", IsGlobalAttribute = true)]
    itemprop,

    [Attribute("Referenced elements", IsGlobalAttribute = true)]
    itemref,

    [Attribute("Introduces a microdata item", IsGlobalAttribute = true, IsBooleanAttribute = true)]
    itemscope,

    [Attribute("Item types of a microdata item", IsGlobalAttribute = true)]
    itemtype,

    [Attribute("The type of text track", ElementType.track)]
    kind,

    [Attribute("User-visible label", ElementType.optgroup, ElementType.option, ElementType.track)]
    label,

    [Attribute("Language of the element", IsGlobalAttribute = true)]
    lang,

    [Attribute("List of autocomplete options", ElementType.input)]
    list,

    [Attribute("Used when determining loading deferral", ElementType.iframe, ElementType.img, ElementType.audio, ElementType.video)]
    loading,

    [Attribute("Whether to loop the media resource", ElementType.audio, ElementType.video, IsBooleanAttribute = true)]
    loop,

    [Attribute("High limit of low range", ElementType.meter)]
    low,

    [Attribute("Maximum value", ElementType.input)]
    [Attribute("Upper bound of range", ElementType.meter, ElementType.progress)]
    max,

    [Attribute("Maximum length of value", ElementType.input, ElementType.textarea)]
    maxlength,

    [Attribute("Applicable media", ElementType.link, ElementType.meta, ElementType.source, ElementType.style)]
    media,

    [Attribute("Variant to use for form submission", ElementType.form)]
    method,

    [Attribute("Minimum value", ElementType.input)]
    [Attribute("Lower bound of range", ElementType.meter)]
    min,

    [Attribute("Minimum length of value", ElementType.input, ElementType.textarea)]
    minlength,

    [Attribute("Whether to allow multiple values", ElementType.input, ElementType.select, IsBooleanAttribute = true)]
    multiple,

    [Attribute("Whether to mute the media resource by default", ElementType.audio, ElementType.video, IsBooleanAttribute = true)]
    muted,

    [Attribute("Name of the element to use for form submission and in the form.elements API", ElementType.button, ElementType.fieldset, ElementType.input, ElementType.output, ElementType.select, ElementType.textarea)]
    [Attribute("Name of group of mutually-exclusive details elements", ElementType.details)]
    [Attribute("Name of form to use in the document.forms API", ElementType.form)]
    [Attribute("Name of content navigable", ElementType.iframe, ElementType.object_)]
    [Attribute("Name of image map to reference from the usemap attribute", ElementType.map)]
    [Attribute("Metadata name", ElementType.meta)]
    [Attribute("Name of shadow tree slot", ElementType.slot)]
    name,

    [Attribute("Prevents execution in user agents that support module scripts", ElementType.script, IsBooleanAttribute = true)]
    nomodule,

    [Attribute("Cryptographic nonce used in Content Security Policy checks [CSP]", IsGlobalAttribute = true)]
    nonce,

    [Attribute("Bypass form control validation for form submission", ElementType.form, IsBooleanAttribute = true)]
    novalidate,

    [Attribute("Whether the details are visible", ElementType.details, IsBooleanAttribute = true)]
    [Attribute("Whether the dialog box is showing", ElementType.dialog, IsBooleanAttribute = true)]
    open,

    [Attribute("Optimum value in gauge", ElementType.meter)]
    optimum,

    [Attribute("Pattern to be matched by the form control's value", ElementType.input)]
    pattern,

    [Attribute("URLs to ping")]
    ping,

    [Attribute("User-visible label to be placed within the form control", ElementType.input, ElementType.textarea)]
    placeholder,

    [Attribute("Encourage the user agent to display video content within the element's playback area", ElementType.video, IsBooleanAttribute = true)]
    playsinline,

    [Attribute("Makes the element a popover element", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    popover,

    [Attribute("Targets a popover element to toggle, show, or hide", ElementType.button, ElementType.input)]
    popovertarget,

    [Attribute("Indicates whether a targeted popover element is to be toggled, shown, or hidden", ElementType.button, ElementType.input)]
    popovertargetaction,

    [Attribute("Poster frame to show prior to video playback", ElementType.video)]
    poster,

    [Attribute("Hints how much buffering the media resource will likely need", ElementType.audio, ElementType.video, IsEmptyStringValid = true)]
    preload,

    [Attribute("Whether to allow the value to be edited by the user", ElementType.input, ElementType.textarea, IsBooleanAttribute = true)]
    [Attribute("Affects willValidate, plus any behavior added by the custom element author", IsBooleanAttribute = true)]
    readonly_,

    [Attribute("Referrer policy for fetches initiated by the element", ElementType.a, ElementType.area, ElementType.iframe, ElementType.img, ElementType.link, ElementType.script)]
    referrerpolicy,

    [Attribute("Relationship between the location in the document containing the hyperlink and the destination resource", ElementType.a, ElementType.area)]
    [Attribute("Relationship between the document containing the hyperlink and the destination resource", ElementType.link)]
    rel,

    [Attribute("Whether the control is required for form submission", ElementType.input, ElementType.select, ElementType.textarea, IsBooleanAttribute = true)]
    required,

    [Attribute("Number the list backwards", ElementType.ol, IsBooleanAttribute = true)]
    reversed,

    [Attribute("Number of lines to show", ElementType.textarea)]
    rows,

    [Attribute("Number of rows that the cell is to span", ElementType.td, ElementType.th)]
    rowspan,

    [Attribute("Security rules for nested content", ElementType.iframe)]
    sandbox,

    [Attribute("Specifies which cells the header cell applies to", ElementType.th)]
    scope,

    [Attribute("Whether the option is selected by default", ElementType.option, IsBooleanAttribute = true)]
    selected,

    [Attribute("Sets clonable on a declarative shadow root", ElementType.template, IsBooleanAttribute = true)]
    shadowrootclonable,

    [Attribute("Enables declarative shadow roots to indicate they will use a custom element registry", ElementType.template, IsBooleanAttribute = true)]
    shadowrootcustomelementregistry,

    [Attribute("Sets delegates focus on a declarative shadow root", ElementType.template, IsBooleanAttribute = true)]
    shadowrootdelegatesfocus,

    [Attribute("Enables streaming declarative shadow roots", ElementType.template)]
    shadowrootmode,

    [Attribute("Sets serializable on a declarative shadow root", ElementType.template, IsBooleanAttribute = true)]
    shadowrootserializable,

    [Attribute("Sets slot assignment on a declarative shadow root", ElementType.template)]
    shadowrootslotassignment,

    [Attribute("The kind of shape to be created in an image map", ElementType.area)]
    shape,

    [Attribute("Size of the control", ElementType.input, ElementType.select)]
    size,

    [Attribute("Sizes of the icons (for rel=\"icon\")", ElementType.link)]
    [Attribute("Image sizes for different page layouts", ElementType.img, ElementType.source)]
    sizes,

    [Attribute("The element's desired slot")]
    slot,

    [Attribute("Number of columns spanned by the element", ElementType.col, ElementType.colgroup)]
    span,

    [Attribute("Whether the element is to have its spelling and grammar checked", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    spellcheck,

    [Attribute("Address of the resource", ElementType.audio, ElementType.embed, ElementType.iframe, ElementType.img, ElementType.input, ElementType.script, ElementType.source, ElementType.track, ElementType.video)]
    src,

    [Attribute("A document to render in the iframe", ElementType.iframe)]
    srcdoc,

    [Attribute("Language of the text track", ElementType.track)]
    srclang,

    [Attribute("Images to use in different situations, e.g., high-resolution displays, small monitors, etc", ElementType.img, ElementType.source)]
    srcset,

    [Attribute("Starting value of the list", ElementType.ol)]
    start,

    [Attribute("Granularity to be matched by the form control's value", ElementType.input)]
    step,

    [Attribute("Presentational and formatting instructions", IsGlobalAttribute = true)]
    style,

    [Attribute("Whether the element is focusable and sequentially focusable, and the relative order of the element for the purposes of sequential focus navigation", IsGlobalAttribute = true)]
    tabindex,

    [Attribute("Navigable for hyperlink navigation", ElementType.a, ElementType.area)]
    [Attribute("Default navigable for hyperlink navigation and form submission", ElementType.base_)]
    [Attribute("Navigable for form submission", ElementType.form)]
    target,

    [Attribute("Advisory information for the element", IsGlobalAttribute = true)]
    [Attribute("Full term or expansion of abbreviation", ElementType.abbr, ElementType.dfn, IsGlobalAttribute = true)]
    [Attribute("Description of pattern (when used with pattern attribute)", ElementType.input, IsGlobalAttribute = true)]
    [Attribute("Title of the link", ElementType.link, IsGlobalAttribute = true)]
    [Attribute("CSS style sheet set name", ElementType.link, ElementType.style, IsGlobalAttribute = true)]
    title,

    [Attribute("Whether the element is to be translated when the page is localized", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    translate,

    [Attribute("Hint for the type of the referenced resource", ElementType.a, ElementType.link)]
    [Attribute("Type of button", ElementType.button)]
    [Attribute("Type of embedded resource", ElementType.embed, ElementType.object_, ElementType.source)]
    [Attribute("Type of form control", ElementType.input)]
    [Attribute("Kind of list marker", ElementType.ol)]
    [Attribute("Type of script", ElementType.script)]
    type,

    [Attribute("Name of image map to use", ElementType.img)]
    usemap,

    [Attribute("Value to be used for form submission", ElementType.button, ElementType.option)]
    [Attribute("Machine-readable value", ElementType.data)]
    [Attribute("Value of the form control", ElementType.input)]
    [Attribute("Ordinal value of the list item", ElementType.li)]
    [Attribute("Current value of the element", ElementType.meter, ElementType.progress)]
    value,

    [Attribute("Horizontal dimension", ElementType.canvas, ElementType.embed, ElementType.iframe, ElementType.img, ElementType.input, ElementType.object_, ElementType.source, ElementType.video)]
    width,

    [Attribute("How the value of the form control is to be wrapped for form submission", ElementType.textarea)]
    wrap,

    [Attribute("Whether the element can offer writing suggestions or not", IsGlobalAttribute = true, IsEmptyStringValid = true)]
    writingsuggestions,
}
