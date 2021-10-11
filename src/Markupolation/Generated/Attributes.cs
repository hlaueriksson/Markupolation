namespace Markupolation
{
    /// <summary>HTML attributes.</summary>
    public static partial class Attributes
    {
        /// <summary>
        /// Alternative label to use for the header cell when referencing the cell in other contexts.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.th"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>abbr="{value}"</code></returns>
        public static Attribute abbr(string value) => new(AttributeType.abbr, value);

        /// <summary>
        /// Hint for expected file type in file upload controls.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>accept="{value}"</code></returns>
        public static Attribute accept(string value) => new(AttributeType.accept, value);

        /// <summary>
        /// Character encodings to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.form"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>accept_charset="{value}"</code></returns>
        public static Attribute accept_charset(string value) => new(AttributeType.accept_charset, value);

        /// <summary>
        /// Keyboard shortcut to activate or focus element.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>accesskey="{value}"</code></returns>
        public static Attribute accesskey(string value) => new(AttributeType.accesskey, value);

        /// <summary>
        /// URL to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.form"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>action="{value}"</code></returns>
        public static Attribute action(string value) => new(AttributeType.action, value);

        /// <summary>
        /// Permissions policy to be applied to the iframe's contents.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.iframe"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>allow="{value}"</code></returns>
        public static Attribute allow(string value) => new(AttributeType.allow, value);

        /// <summary>
        /// Whether to allow the iframe's contents to use requestFullscreen().
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.iframe"/>.</remarks>
        /// <returns><code>allowfullscreen</code></returns>
        public static Attribute allowfullscreen() => new(AttributeType.allowfullscreen);

        /// <summary>
        /// Replacement text for use when images are not available.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.area"/>, <see cref="Elements.img"/>, <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>alt="{value}"</code></returns>
        public static Attribute alt(string value) => new(AttributeType.alt, value);

        /// <summary>
        /// Potential destination for a preload request (for rel="preload" and rel="modulepreload").
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>as_="{value}"</code></returns>
        public static Attribute as_(string value) => new(AttributeType.as_, value);

        /// <summary>
        /// Execute script when available, without blocking while fetching.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.script"/>.</remarks>
        /// <returns><code>async</code></returns>
        public static Attribute async() => new(AttributeType.async);

        /// <summary>
        /// Recommended autocapitalization behavior (for supported input methods).
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>autocapitalize="{value}"</code></returns>
        public static Attribute autocapitalize(string value) => new(AttributeType.autocapitalize, value);

        /// <summary>
        /// Default setting for autofill feature for controls in the form.
        /// Hint for form autofill feature.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.form"/>, <see cref="Elements.input"/>, <see cref="Elements.select"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>autocomplete="{value}"</code></returns>
        public static Attribute autocomplete(string value) => new(AttributeType.autocomplete, value);

        /// <summary>
        /// Automatically focus the element when the page is loaded.
        /// </summary>
        /// <returns><code>autofocus</code></returns>
        public static Attribute autofocus() => new(AttributeType.autofocus);

        /// <summary>
        /// Hint that the media resource can be started automatically when the page is loaded.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.video"/>.</remarks>
        /// <returns><code>autoplay</code></returns>
        public static Attribute autoplay() => new(AttributeType.autoplay);

        /// <summary>
        /// Character encoding declaration.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.meta"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>charset="{value}"</code></returns>
        public static Attribute charset(string value) => new(AttributeType.charset, value);

        /// <summary>
        /// Whether the control is checked.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>.</remarks>
        /// <returns><code>checked_</code></returns>
        public static Attribute checked_() => new(AttributeType.checked_);

        /// <summary>
        /// Link to the source of the quotation or more information about the edit.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.blockquote"/>, <see cref="Elements.del"/>, <see cref="Elements.ins"/>, <see cref="Elements.q"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>cite="{value}"</code></returns>
        public static Attribute cite(string value) => new(AttributeType.cite, value);

        /// <summary>
        /// Classes to which the element belongs.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>class_="{value}"</code></returns>
        public static Attribute class_(string value) => new(AttributeType.class_, value);

        /// <summary>
        /// Color to use when customizing a site's icon (for rel="mask-icon").
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>color="{value}"</code></returns>
        public static Attribute color(string value) => new(AttributeType.color, value);

        /// <summary>
        /// Maximum number of characters per line.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>cols="{value}"</code></returns>
        public static Attribute cols(string value) => new(AttributeType.cols, value);

        /// <summary>
        /// Number of columns that the cell is to span.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.td"/>, <see cref="Elements.th"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>colspan="{value}"</code></returns>
        public static Attribute colspan(string value) => new(AttributeType.colspan, value);

        /// <summary>
        /// Value of the element.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.meta"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>content="{value}"</code></returns>
        public static Attribute content(string value) => new(AttributeType.content, value);

        /// <summary>
        /// Whether the element is editable.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>contenteditable="{value}"</code></returns>
        public static Attribute contenteditable(string value) => new(AttributeType.contenteditable, value);

        /// <summary>
        /// Show user agent controls.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.video"/>.</remarks>
        /// <returns><code>controls</code></returns>
        public static Attribute controls() => new(AttributeType.controls);

        /// <summary>
        /// Coordinates for the shape to be created in an image map.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.area"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>coords="{value}"</code></returns>
        public static Attribute coords(string value) => new(AttributeType.coords, value);

        /// <summary>
        /// How the element handles crossorigin requests.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.img"/>, <see cref="Elements.link"/>, <see cref="Elements.script"/>, <see cref="Elements.video"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>crossorigin="{value}"</code></returns>
        public static Attribute crossorigin(string value) => new(AttributeType.crossorigin, value);

        /// <summary>
        /// Address of the resource.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.object_"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>data="{value}"</code></returns>
        public static Attribute data(string value) => new(AttributeType.data, value);

        /// <summary>
        /// Date and (optionally) time of the change.
        /// Machine-readable value.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.del"/>, <see cref="Elements.ins"/>, <see cref="Elements.time"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>datetime="{value}"</code></returns>
        public static Attribute datetime(string value) => new(AttributeType.datetime, value);

        /// <summary>
        /// Decoding hint to use when processing this image for presentation.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.img"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>decoding="{value}"</code></returns>
        public static Attribute decoding(string value) => new(AttributeType.decoding, value);

        /// <summary>
        /// Enable the track if no other text track is more suitable.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.track"/>.</remarks>
        /// <returns><code>default_</code></returns>
        public static Attribute default_() => new(AttributeType.default_);

        /// <summary>
        /// Defer script execution.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.script"/>.</remarks>
        /// <returns><code>defer</code></returns>
        public static Attribute defer() => new(AttributeType.defer);

        /// <summary>
        /// The text directionality of the element.
        /// The text directionality of the element.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>dir="{value}"</code></returns>
        public static Attribute dir(string value) => new(AttributeType.dir, value);

        /// <summary>
        /// Name of form control to use for sending the element's directionality in form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>dirname="{value}"</code></returns>
        public static Attribute dirname(string value) => new(AttributeType.dirname, value);

        /// <summary>
        /// Whether the form control is disabled.
        /// Whether the descendant form controls, except any inside legend, are disabled.
        /// Whether the link is disabled.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.input"/>, <see cref="Elements.optgroup"/>, <see cref="Elements.option"/>, <see cref="Elements.select"/>, <see cref="Elements.textarea"/>, <see cref="Elements.fieldset"/>, <see cref="Elements.link"/>.</remarks>
        /// <returns><code>disabled</code></returns>
        public static Attribute disabled() => new(AttributeType.disabled);

        /// <summary>
        /// Whether to download the resource instead of navigating to it, and its filename if so.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.area"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>download="{value}"</code></returns>
        public static Attribute download(string value) => new(AttributeType.download, value);

        /// <summary>
        /// Whether the element is draggable.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>draggable="{value}"</code></returns>
        public static Attribute draggable(string value) => new(AttributeType.draggable, value);

        /// <summary>
        /// Entry list encoding type to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.form"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>enctype="{value}"</code></returns>
        public static Attribute enctype(string value) => new(AttributeType.enctype, value);

        /// <summary>
        /// Hint for selecting an enter key action.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>enterkeyhint="{value}"</code></returns>
        public static Attribute enterkeyhint(string value) => new(AttributeType.enterkeyhint, value);

        /// <summary>
        /// Associate the label with form control.
        /// Specifies controls from which the output was calculated.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.label"/>, <see cref="Elements.output"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>for_="{value}"</code></returns>
        public static Attribute for_(string value) => new(AttributeType.for_, value);

        /// <summary>
        /// Associates the element with a form element.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.fieldset"/>, <see cref="Elements.input"/>, <see cref="Elements.object_"/>, <see cref="Elements.output"/>, <see cref="Elements.select"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>form="{value}"</code></returns>
        public static Attribute form(string value) => new(AttributeType.form, value);

        /// <summary>
        /// URL to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>formaction="{value}"</code></returns>
        public static Attribute formaction(string value) => new(AttributeType.formaction, value);

        /// <summary>
        /// Entry list encoding type to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>formenctype="{value}"</code></returns>
        public static Attribute formenctype(string value) => new(AttributeType.formenctype, value);

        /// <summary>
        /// Variant to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>formmethod="{value}"</code></returns>
        public static Attribute formmethod(string value) => new(AttributeType.formmethod, value);

        /// <summary>
        /// Bypass form control validation for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.input"/>.</remarks>
        /// <returns><code>formnovalidate</code></returns>
        public static Attribute formnovalidate() => new(AttributeType.formnovalidate);

        /// <summary>
        /// Browsing context for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>formtarget="{value}"</code></returns>
        public static Attribute formtarget(string value) => new(AttributeType.formtarget, value);

        /// <summary>
        /// The header cells for this cell.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.td"/>, <see cref="Elements.th"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>headers="{value}"</code></returns>
        public static Attribute headers(string value) => new(AttributeType.headers, value);

        /// <summary>
        /// Vertical dimension.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.canvas"/>, <see cref="Elements.embed"/>, <see cref="Elements.iframe"/>, <see cref="Elements.img"/>, <see cref="Elements.input"/>, <see cref="Elements.object_"/>, <see cref="Elements.source"/>, <see cref="Elements.video"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>height="{value}"</code></returns>
        public static Attribute height(string value) => new(AttributeType.height, value);

        /// <summary>
        /// Whether the element is relevant.
        /// </summary>
        /// <returns><code>hidden</code></returns>
        public static Attribute hidden() => new(AttributeType.hidden);

        /// <summary>
        /// Low limit of high range.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.meter"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>high="{value}"</code></returns>
        public static Attribute high(string value) => new(AttributeType.high, value);

        /// <summary>
        /// Address of the hyperlink.
        /// Address of the hyperlink.
        /// Document base URL.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.area"/>, <see cref="Elements.link"/>, <see cref="Elements.base_"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>href="{value}"</code></returns>
        public static Attribute href(string value) => new(AttributeType.href, value);

        /// <summary>
        /// Language of the linked resource.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.link"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>hreflang="{value}"</code></returns>
        public static Attribute hreflang(string value) => new(AttributeType.hreflang, value);

        /// <summary>
        /// Pragma directive.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.meta"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>http_equiv="{value}"</code></returns>
        public static Attribute http_equiv(string value) => new(AttributeType.http_equiv, value);

        /// <summary>
        /// The element's ID.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>id="{value}"</code></returns>
        public static Attribute id(string value) => new(AttributeType.id, value);

        /// <summary>
        /// Image sizes for different page layouts (for rel="preload").
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>imagesizes="{value}"</code></returns>
        public static Attribute imagesizes(string value) => new(AttributeType.imagesizes, value);

        /// <summary>
        /// Images to use in different situations, e.g., high-resolution displays, small monitors, etc. (for rel="preload").
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>imagesrcset="{value}"</code></returns>
        public static Attribute imagesrcset(string value) => new(AttributeType.imagesrcset, value);

        /// <summary>
        /// Hint for selecting an input modality.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>inputmode="{value}"</code></returns>
        public static Attribute inputmode(string value) => new(AttributeType.inputmode, value);

        /// <summary>
        /// Integrity metadata used in Subresource Integrity checks [SRI].
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>, <see cref="Elements.script"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>integrity="{value}"</code></returns>
        public static Attribute integrity(string value) => new(AttributeType.integrity, value);

        /// <summary>
        /// Creates a customized built-in element.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>is_="{value}"</code></returns>
        public static Attribute is_(string value) => new(AttributeType.is_, value);

        /// <summary>
        /// Whether the image is a server-side image map.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.img"/>.</remarks>
        /// <returns><code>ismap</code></returns>
        public static Attribute ismap() => new(AttributeType.ismap);

        /// <summary>
        /// Global identifier for a microdata item.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>itemid="{value}"</code></returns>
        public static Attribute itemid(string value) => new(AttributeType.itemid, value);

        /// <summary>
        /// Property names of a microdata item.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>itemprop="{value}"</code></returns>
        public static Attribute itemprop(string value) => new(AttributeType.itemprop, value);

        /// <summary>
        /// Referenced elements.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>itemref="{value}"</code></returns>
        public static Attribute itemref(string value) => new(AttributeType.itemref, value);

        /// <summary>
        /// Introduces a microdata item.
        /// </summary>
        /// <returns><code>itemscope</code></returns>
        public static Attribute itemscope() => new(AttributeType.itemscope);

        /// <summary>
        /// Item types of a microdata item.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>itemtype="{value}"</code></returns>
        public static Attribute itemtype(string value) => new(AttributeType.itemtype, value);

        /// <summary>
        /// The type of text track.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.track"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>kind="{value}"</code></returns>
        public static Attribute kind(string value) => new(AttributeType.kind, value);

        /// <summary>
        /// User-visible label.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.optgroup"/>, <see cref="Elements.option"/>, <see cref="Elements.track"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>label="{value}"</code></returns>
        public static Attribute label(string value) => new(AttributeType.label, value);

        /// <summary>
        /// Language of the element.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>lang="{value}"</code></returns>
        public static Attribute lang(string value) => new(AttributeType.lang, value);

        /// <summary>
        /// List of autocomplete options.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>list="{value}"</code></returns>
        public static Attribute list(string value) => new(AttributeType.list, value);

        /// <summary>
        /// Used when determining loading deferral.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.img"/>, <see cref="Elements.iframe"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>loading="{value}"</code></returns>
        public static Attribute loading(string value) => new(AttributeType.loading, value);

        /// <summary>
        /// Whether to loop the media resource.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.video"/>.</remarks>
        /// <returns><code>loop</code></returns>
        public static Attribute loop() => new(AttributeType.loop);

        /// <summary>
        /// High limit of low range.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.meter"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>low="{value}"</code></returns>
        public static Attribute low(string value) => new(AttributeType.low, value);

        /// <summary>
        /// Maximum value.
        /// Upper bound of range.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.meter"/>, <see cref="Elements.progress"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>max="{value}"</code></returns>
        public static Attribute max(string value) => new(AttributeType.max, value);

        /// <summary>
        /// Maximum length of value.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>maxlength="{value}"</code></returns>
        public static Attribute maxlength(string value) => new(AttributeType.maxlength, value);

        /// <summary>
        /// Applicable media.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>, <see cref="Elements.meta"/>, <see cref="Elements.source"/>, <see cref="Elements.style"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>media="{value}"</code></returns>
        public static Attribute media(string value) => new(AttributeType.media, value);

        /// <summary>
        /// Variant to use for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.form"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>method="{value}"</code></returns>
        public static Attribute method(string value) => new(AttributeType.method, value);

        /// <summary>
        /// Minimum value.
        /// Lower bound of range.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.meter"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>min="{value}"</code></returns>
        public static Attribute min(string value) => new(AttributeType.min, value);

        /// <summary>
        /// Minimum length of value.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>minlength="{value}"</code></returns>
        public static Attribute minlength(string value) => new(AttributeType.minlength, value);

        /// <summary>
        /// Whether to allow multiple values.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.select"/>.</remarks>
        /// <returns><code>multiple</code></returns>
        public static Attribute multiple() => new(AttributeType.multiple);

        /// <summary>
        /// Whether to mute the media resource by default.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.video"/>.</remarks>
        /// <returns><code>muted</code></returns>
        public static Attribute muted() => new(AttributeType.muted);

        /// <summary>
        /// Name of the element to use for form submission and in the form.elements API.
        /// Name of form to use in the document.forms API.
        /// Name of nested browsing context.
        /// Name of image map to reference from the usemap attribute.
        /// Metadata name.
        /// Name of parameter.
        /// Name of shadow tree slot.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.fieldset"/>, <see cref="Elements.input"/>, <see cref="Elements.output"/>, <see cref="Elements.select"/>, <see cref="Elements.textarea"/>, <see cref="Elements.form"/>, <see cref="Elements.iframe"/>, <see cref="Elements.object_"/>, <see cref="Elements.map"/>, <see cref="Elements.meta"/>, <see cref="Elements.param"/>, <see cref="Elements.slot"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>name="{value}"</code></returns>
        public static Attribute name(string value) => new(AttributeType.name, value);

        /// <summary>
        /// Prevents execution in user agents that support module scripts.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.script"/>.</remarks>
        /// <returns><code>nomodule</code></returns>
        public static Attribute nomodule() => new(AttributeType.nomodule);

        /// <summary>
        /// Cryptographic nonce used in Content Security Policy checks [CSP].
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>nonce="{value}"</code></returns>
        public static Attribute nonce(string value) => new(AttributeType.nonce, value);

        /// <summary>
        /// Bypass form control validation for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.form"/>.</remarks>
        /// <returns><code>novalidate</code></returns>
        public static Attribute novalidate() => new(AttributeType.novalidate);

        /// <summary>
        /// Whether the details are visible.
        /// Whether the dialog box is showing.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.details"/>, <see cref="Elements.dialog"/>.</remarks>
        /// <returns><code>open</code></returns>
        public static Attribute open() => new(AttributeType.open);

        /// <summary>
        /// Optimum value in gauge.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.meter"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>optimum="{value}"</code></returns>
        public static Attribute optimum(string value) => new(AttributeType.optimum, value);

        /// <summary>
        /// Pattern to be matched by the form control's value.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>pattern="{value}"</code></returns>
        public static Attribute pattern(string value) => new(AttributeType.pattern, value);

        /// <summary>
        /// URLs to ping.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>ping="{value}"</code></returns>
        public static Attribute ping(string value) => new(AttributeType.ping, value);

        /// <summary>
        /// User-visible label to be placed within the form control.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>placeholder="{value}"</code></returns>
        public static Attribute placeholder(string value) => new(AttributeType.placeholder, value);

        /// <summary>
        /// Encourage the user agent to display video content within the element's playback area.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.video"/>.</remarks>
        /// <returns><code>playsinline</code></returns>
        public static Attribute playsinline() => new(AttributeType.playsinline);

        /// <summary>
        /// Poster frame to show prior to video playback.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.video"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>poster="{value}"</code></returns>
        public static Attribute poster(string value) => new(AttributeType.poster, value);

        /// <summary>
        /// Hints how much buffering the media resource will likely need.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.video"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>preload="{value}"</code></returns>
        public static Attribute preload(string value) => new(AttributeType.preload, value);

        /// <summary>
        /// Whether to allow the value to be edited by the user.
        /// Affects willValidate, plus any behavior added by the custom element author.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <returns><code>readonly_</code></returns>
        public static Attribute readonly_() => new(AttributeType.readonly_);

        /// <summary>
        /// Referrer policy for fetches initiated by the element.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.area"/>, <see cref="Elements.iframe"/>, <see cref="Elements.img"/>, <see cref="Elements.link"/>, <see cref="Elements.script"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>referrerpolicy="{value}"</code></returns>
        public static Attribute referrerpolicy(string value) => new(AttributeType.referrerpolicy, value);

        /// <summary>
        /// Relationship between the location in the document containing the hyperlink and the destination resource.
        /// Relationship between the document containing the hyperlink and the destination resource.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.area"/>, <see cref="Elements.link"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>rel="{value}"</code></returns>
        public static Attribute rel(string value) => new(AttributeType.rel, value);

        /// <summary>
        /// Whether the control is required for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.select"/>, <see cref="Elements.textarea"/>.</remarks>
        /// <returns><code>required</code></returns>
        public static Attribute required() => new(AttributeType.required);

        /// <summary>
        /// Number the list backwards.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.ol"/>.</remarks>
        /// <returns><code>reversed</code></returns>
        public static Attribute reversed() => new(AttributeType.reversed);

        /// <summary>
        /// Number of lines to show.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>rows="{value}"</code></returns>
        public static Attribute rows(string value) => new(AttributeType.rows, value);

        /// <summary>
        /// Number of rows that the cell is to span.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.td"/>, <see cref="Elements.th"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>rowspan="{value}"</code></returns>
        public static Attribute rowspan(string value) => new(AttributeType.rowspan, value);

        /// <summary>
        /// Security rules for nested content.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.iframe"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>sandbox="{value}"</code></returns>
        public static Attribute sandbox(string value) => new(AttributeType.sandbox, value);

        /// <summary>
        /// Specifies which cells the header cell applies to.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.th"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>scope="{value}"</code></returns>
        public static Attribute scope(string value) => new(AttributeType.scope, value);

        /// <summary>
        /// Whether the option is selected by default.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.option"/>.</remarks>
        /// <returns><code>selected</code></returns>
        public static Attribute selected() => new(AttributeType.selected);

        /// <summary>
        /// The kind of shape to be created in an image map.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.area"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>shape="{value}"</code></returns>
        public static Attribute shape(string value) => new(AttributeType.shape, value);

        /// <summary>
        /// Size of the control.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>, <see cref="Elements.select"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>size="{value}"</code></returns>
        public static Attribute size(string value) => new(AttributeType.size, value);

        /// <summary>
        /// Sizes of the icons (for rel="icon").
        /// Image sizes for different page layouts.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.link"/>, <see cref="Elements.img"/>, <see cref="Elements.source"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>sizes="{value}"</code></returns>
        public static Attribute sizes(string value) => new(AttributeType.sizes, value);

        /// <summary>
        /// The element's desired slot.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>slot="{value}"</code></returns>
        public static Attribute slot(string value) => new(AttributeType.slot, value);

        /// <summary>
        /// Number of columns spanned by the element.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.col"/>, <see cref="Elements.colgroup"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>span="{value}"</code></returns>
        public static Attribute span(string value) => new(AttributeType.span, value);

        /// <summary>
        /// Whether the element is to have its spelling and grammar checked.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>spellcheck="{value}"</code></returns>
        public static Attribute spellcheck(string value) => new(AttributeType.spellcheck, value);

        /// <summary>
        /// Address of the resource.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.audio"/>, <see cref="Elements.embed"/>, <see cref="Elements.iframe"/>, <see cref="Elements.img"/>, <see cref="Elements.input"/>, <see cref="Elements.script"/>, <see cref="Elements.source"/>, <see cref="Elements.track"/>, <see cref="Elements.video"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>src="{value}"</code></returns>
        public static Attribute src(string value) => new(AttributeType.src, value);

        /// <summary>
        /// A document to render in the iframe.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.iframe"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>srcdoc="{value}"</code></returns>
        public static Attribute srcdoc(string value) => new(AttributeType.srcdoc, value);

        /// <summary>
        /// Language of the text track.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.track"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>srclang="{value}"</code></returns>
        public static Attribute srclang(string value) => new(AttributeType.srclang, value);

        /// <summary>
        /// Images to use in different situations, e.g., high-resolution displays, small monitors, etc..
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.img"/>, <see cref="Elements.source"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>srcset="{value}"</code></returns>
        public static Attribute srcset(string value) => new(AttributeType.srcset, value);

        /// <summary>
        /// Starting value of the list.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.ol"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>start="{value}"</code></returns>
        public static Attribute start(string value) => new(AttributeType.start, value);

        /// <summary>
        /// Granularity to be matched by the form control's value.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.input"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>step="{value}"</code></returns>
        public static Attribute step(string value) => new(AttributeType.step, value);

        /// <summary>
        /// Presentational and formatting instructions.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>style="{value}"</code></returns>
        public static Attribute style(string value) => new(AttributeType.style, value);

        /// <summary>
        /// Whether the element is focusable and sequentially focusable, and the relative order of the element for the purposes of sequential focus navigation.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>tabindex="{value}"</code></returns>
        public static Attribute tabindex(string value) => new(AttributeType.tabindex, value);

        /// <summary>
        /// Browsing context for hyperlink navigation.
        /// Default browsing context for hyperlink navigation and form submission.
        /// Browsing context for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.area"/>, <see cref="Elements.base_"/>, <see cref="Elements.form"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>target="{value}"</code></returns>
        public static Attribute target(string value) => new(AttributeType.target, value);

        /// <summary>
        /// Advisory information for the element.
        /// Full term or expansion of abbreviation.
        /// Description of pattern (when used with pattern attribute).
        /// Title of the link.
        /// CSS style sheet set name.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.abbr"/>, <see cref="Elements.dfn"/>, <see cref="Elements.input"/>, <see cref="Elements.link"/>, <see cref="Elements.link"/>, <see cref="Elements.style"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>title="{value}"</code></returns>
        public static Attribute title(string value) => new(AttributeType.title, value);

        /// <summary>
        /// Whether the element is to be translated when the page is localized.
        /// </summary>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>translate="{value}"</code></returns>
        public static Attribute translate(string value) => new(AttributeType.translate, value);

        /// <summary>
        /// Hint for the type of the referenced resource.
        /// Type of button.
        /// Type of embedded resource.
        /// Type of form control.
        /// Kind of list marker.
        /// Type of script.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.a"/>, <see cref="Elements.link"/>, <see cref="Elements.button"/>, <see cref="Elements.embed"/>, <see cref="Elements.object_"/>, <see cref="Elements.source"/>, <see cref="Elements.input"/>, <see cref="Elements.ol"/>, <see cref="Elements.script"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>type="{value}"</code></returns>
        public static Attribute type(string value) => new(AttributeType.type, value);

        /// <summary>
        /// Name of image map to use.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.img"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>usemap="{value}"</code></returns>
        public static Attribute usemap(string value) => new(AttributeType.usemap, value);

        /// <summary>
        /// Value to be used for form submission.
        /// Machine-readable value.
        /// Value of the form control.
        /// Ordinal value of the list item.
        /// Current value of the element.
        /// Value of parameter.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.button"/>, <see cref="Elements.option"/>, <see cref="Elements.data"/>, <see cref="Elements.input"/>, <see cref="Elements.li"/>, <see cref="Elements.meter"/>, <see cref="Elements.progress"/>, <see cref="Elements.param"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>value="{value}"</code></returns>
        public static Attribute value(string value) => new(AttributeType.value, value);

        /// <summary>
        /// Horizontal dimension.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.canvas"/>, <see cref="Elements.embed"/>, <see cref="Elements.iframe"/>, <see cref="Elements.img"/>, <see cref="Elements.input"/>, <see cref="Elements.object_"/>, <see cref="Elements.source"/>, <see cref="Elements.video"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>width="{value}"</code></returns>
        public static Attribute width(string value) => new(AttributeType.width, value);

        /// <summary>
        /// How the value of the form control is to be wrapped for form submission.
        /// </summary>
        /// <remarks>Elements: <see cref="Elements.textarea"/>.</remarks>
        /// <param name="value">Attribute value.</param>
        /// <returns><code>wrap="{value}"</code></returns>
        public static Attribute wrap(string value) => new(AttributeType.wrap, value);
    }
}
