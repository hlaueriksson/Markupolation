namespace Markupolation;

/// <summary>HTML attributes.</summary>
public static partial class Attributes
{
    /// <summary>
    /// Alternative label to use for the header cell when referencing the cell in other contexts.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.th(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>abbr="{value}"</c></returns>
    public static Attribute abbr(string value) => new(AttributeType.abbr, value);

    /// <inheritdoc cref="abbr(string)" />
    public static Attribute abbr(object value) => new(AttributeType.abbr, ValueFormatter.Format(value));

    /// <summary>
    /// Hint for expected file type in file upload controls.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>accept="{value}"</c></returns>
    public static Attribute accept(string value) => new(AttributeType.accept, value);

    /// <inheritdoc cref="accept(string)" />
    public static Attribute accept(object value) => new(AttributeType.accept, ValueFormatter.Format(value));

    /// <summary>
    /// Character encodings to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.form(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>accept_charset="{value}"</c></returns>
    public static Attribute accept_charset(string value) => new(AttributeType.accept_charset, value);

    /// <inheritdoc cref="accept_charset(string)" />
    public static Attribute accept_charset(object value) => new(AttributeType.accept_charset, ValueFormatter.Format(value));

    /// <summary>
    /// Keyboard shortcut to activate or focus element.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>accesskey="{value}"</c></returns>
    public static Attribute accesskey(string value) => new(AttributeType.accesskey, value);

    /// <inheritdoc cref="accesskey(string)" />
    public static Attribute accesskey(object value) => new(AttributeType.accesskey, ValueFormatter.Format(value));

    /// <summary>
    /// URL to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.form(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>action="{value}"</c></returns>
    public static Attribute action(string value) => new(AttributeType.action, value);

    /// <inheritdoc cref="action(string)" />
    public static Attribute action(object value) => new(AttributeType.action, ValueFormatter.Format(value));

    /// <summary>
    /// Permissions policy to be applied to the iframe's contents.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.iframe(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>allow="{value}"</c></returns>
    public static Attribute allow(string value) => new(AttributeType.allow, value);

    /// <inheritdoc cref="allow(string)" />
    public static Attribute allow(object value) => new(AttributeType.allow, ValueFormatter.Format(value));

    /// <summary>
    /// Whether to allow the iframe's contents to use requestFullscreen().
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.iframe(Content[])"/>.</remarks>
    /// <returns><c>allowfullscreen</c></returns>
    public static Attribute allowfullscreen() => new(AttributeType.allowfullscreen);

    /// <summary>
    /// Allow the color's alpha component to be set.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <returns><c>alpha</c></returns>
    public static Attribute alpha() => new(AttributeType.alpha);

    /// <summary>
    /// Replacement text for use when images are not available.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.area(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>alt="{value}"</c></returns>
    public static Attribute alt(string value) => new(AttributeType.alt, value);

    /// <inheritdoc cref="alt(string)" />
    public static Attribute alt(object value) => new(AttributeType.alt, ValueFormatter.Format(value));

    /// <summary>
    /// Destination for a preload request (for rel="preload" and rel="modulepreload").
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>as_="{value}"</c></returns>
    public static Attribute as_(string value) => new(AttributeType.as_, value);

    /// <inheritdoc cref="as_(string)" />
    public static Attribute as_(object value) => new(AttributeType.as_, ValueFormatter.Format(value));

    /// <summary>
    /// Execute script when available, without blocking while fetching.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.script(Content[])"/>.</remarks>
    /// <returns><c>async</c></returns>
    public static Attribute async() => new(AttributeType.async);

    /// <summary>
    /// Recommended autocapitalization behavior (for supported input methods).
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>autocapitalize="{value}"</c></returns>
    public static Attribute autocapitalize(string value) => new(AttributeType.autocapitalize, value);

    /// <inheritdoc cref="autocapitalize(string)" />
    public static Attribute autocapitalize(object value) => new(AttributeType.autocapitalize, ValueFormatter.Format(value));

    /// <summary>
    /// Default setting for autofill feature for controls in the form.
    /// Hint for form autofill feature.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.form(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.select(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>autocomplete="{value}"</c></returns>
    public static Attribute autocomplete(string value) => new(AttributeType.autocomplete, value);

    /// <inheritdoc cref="autocomplete(string)" />
    public static Attribute autocomplete(object value) => new(AttributeType.autocomplete, ValueFormatter.Format(value));

    /// <summary>
    /// Recommended autocorrection behavior (for supported input methods).
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>autocorrect="{value}"</c></returns>
    public static Attribute autocorrect(string value) => new(AttributeType.autocorrect, value);

    /// <inheritdoc cref="autocorrect(string)" />
    public static Attribute autocorrect(object value) => new(AttributeType.autocorrect, ValueFormatter.Format(value));

    /// <summary>
    /// Recommended autocorrection behavior (for supported input methods).
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>autocorrect</c></returns>
    public static Attribute autocorrect() => new(AttributeType.autocorrect);

    /// <summary>
    /// Automatically focus the element when the page is loaded.
    /// </summary>
    /// <returns><c>autofocus</c></returns>
    public static Attribute autofocus() => new(AttributeType.autofocus);

    /// <summary>
    /// Hint that the media resource can be started automatically when the page is loaded.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <returns><c>autoplay</c></returns>
    public static Attribute autoplay() => new(AttributeType.autoplay);

    /// <summary>
    /// Whether the element is potentially render-blocking.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>, <see cref="Elements.script(Content[])"/>, <see cref="Elements.style(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>blocking="{value}"</c></returns>
    public static Attribute blocking(string value) => new(AttributeType.blocking, value);

    /// <inheritdoc cref="blocking(string)" />
    public static Attribute blocking(object value) => new(AttributeType.blocking, ValueFormatter.Format(value));

    /// <summary>
    /// Character encoding declaration.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.meta(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>charset="{value}"</c></returns>
    public static Attribute charset(string value) => new(AttributeType.charset, value);

    /// <inheritdoc cref="charset(string)" />
    public static Attribute charset(object value) => new(AttributeType.charset, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the control is checked.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <returns><c>checked_</c></returns>
    public static Attribute checked_() => new(AttributeType.checked_);

    /// <summary>
    /// Link to the source of the quotation or more information about the edit.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.blockquote(Content[])"/>, <see cref="Elements.del(Content[])"/>, <see cref="Elements.ins(Content[])"/>, <see cref="Elements.q(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>cite="{value}"</c></returns>
    public static Attribute cite(string value) => new(AttributeType.cite, value);

    /// <inheritdoc cref="cite(string)" />
    public static Attribute cite(object value) => new(AttributeType.cite, ValueFormatter.Format(value));

    /// <summary>
    /// Classes to which the element belongs.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>class_="{value}"</c></returns>
    public static Attribute class_(string value) => new(AttributeType.class_, value);

    /// <inheritdoc cref="class_(string)" />
    public static Attribute class_(object value) => new(AttributeType.class_, ValueFormatter.Format(value));

    /// <summary>
    /// Which user actions will close the dialog.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.dialog(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>closedby="{value}"</c></returns>
    public static Attribute closedby(string value) => new(AttributeType.closedby, value);

    /// <inheritdoc cref="closedby(string)" />
    public static Attribute closedby(object value) => new(AttributeType.closedby, ValueFormatter.Format(value));

    /// <summary>
    /// Color to use when customizing a site's icon (for rel="mask-icon").
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>color="{value}"</c></returns>
    public static Attribute color(string value) => new(AttributeType.color, value);

    /// <inheritdoc cref="color(string)" />
    public static Attribute color(object value) => new(AttributeType.color, ValueFormatter.Format(value));

    /// <summary>
    /// The color space of the serialized color.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>colorspace="{value}"</c></returns>
    public static Attribute colorspace(string value) => new(AttributeType.colorspace, value);

    /// <inheritdoc cref="colorspace(string)" />
    public static Attribute colorspace(object value) => new(AttributeType.colorspace, ValueFormatter.Format(value));

    /// <summary>
    /// Maximum number of characters per line.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>cols="{value}"</c></returns>
    public static Attribute cols(string value) => new(AttributeType.cols, value);

    /// <inheritdoc cref="cols(string)" />
    public static Attribute cols(object value) => new(AttributeType.cols, ValueFormatter.Format(value));

    /// <summary>
    /// Number of columns that the cell is to span.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.td(Content[])"/>, <see cref="Elements.th(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>colspan="{value}"</c></returns>
    public static Attribute colspan(string value) => new(AttributeType.colspan, value);

    /// <inheritdoc cref="colspan(string)" />
    public static Attribute colspan(object value) => new(AttributeType.colspan, ValueFormatter.Format(value));

    /// <summary>
    /// Indicates to the targeted element which action to take.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>command="{value}"</c></returns>
    public static Attribute command(string value) => new(AttributeType.command, value);

    /// <inheritdoc cref="command(string)" />
    public static Attribute command(object value) => new(AttributeType.command, ValueFormatter.Format(value));

    /// <summary>
    /// Targets another element to be invoked.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>commandfor="{value}"</c></returns>
    public static Attribute commandfor(string value) => new(AttributeType.commandfor, value);

    /// <inheritdoc cref="commandfor(string)" />
    public static Attribute commandfor(object value) => new(AttributeType.commandfor, ValueFormatter.Format(value));

    /// <summary>
    /// Value of the element.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.meta(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>content="{value}"</c></returns>
    public static Attribute content(string value) => new(AttributeType.content, value);

    /// <inheritdoc cref="content(string)" />
    public static Attribute content(object value) => new(AttributeType.content, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is editable.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>contenteditable="{value}"</c></returns>
    public static Attribute contenteditable(string value) => new(AttributeType.contenteditable, value);

    /// <inheritdoc cref="contenteditable(string)" />
    public static Attribute contenteditable(object value) => new(AttributeType.contenteditable, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is editable.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>contenteditable</c></returns>
    public static Attribute contenteditable() => new(AttributeType.contenteditable);

    /// <summary>
    /// Show user agent controls.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.video(Content[])"/>, <see cref="Elements.img(Content[])"/>.</remarks>
    /// <returns><c>controls</c></returns>
    public static Attribute controls() => new(AttributeType.controls);

    /// <summary>
    /// Coordinates for the shape to be created in an image map.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.area(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>coords="{value}"</c></returns>
    public static Attribute coords(string value) => new(AttributeType.coords, value);

    /// <inheritdoc cref="coords(string)" />
    public static Attribute coords(object value) => new(AttributeType.coords, ValueFormatter.Format(value));

    /// <summary>
    /// How the element handles crossorigin requests.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.script(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>crossorigin="{value}"</c></returns>
    public static Attribute crossorigin(string value) => new(AttributeType.crossorigin, value);

    /// <inheritdoc cref="crossorigin(string)" />
    public static Attribute crossorigin(object value) => new(AttributeType.crossorigin, ValueFormatter.Format(value));

    /// <summary>
    /// How the element handles crossorigin requests.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>crossorigin</c></returns>
    public static Attribute crossorigin() => new(AttributeType.crossorigin);

    /// <summary>
    /// Address of the resource.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.object_(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>data="{value}"</c></returns>
    public static Attribute data(string value) => new(AttributeType.data, value);

    /// <inheritdoc cref="data(string)" />
    public static Attribute data(object value) => new(AttributeType.data, ValueFormatter.Format(value));

    /// <summary>
    /// Date and (optionally) time of the change.
    /// Machine-readable value.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.del(Content[])"/>, <see cref="Elements.ins(Content[])"/>, <see cref="Elements.time(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>datetime="{value}"</c></returns>
    public static Attribute datetime(string value) => new(AttributeType.datetime, value);

    /// <inheritdoc cref="datetime(string)" />
    public static Attribute datetime(object value) => new(AttributeType.datetime, ValueFormatter.Format(value));

    /// <summary>
    /// Decoding hint to use when processing this image for presentation.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.img(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>decoding="{value}"</c></returns>
    public static Attribute decoding(string value) => new(AttributeType.decoding, value);

    /// <inheritdoc cref="decoding(string)" />
    public static Attribute decoding(object value) => new(AttributeType.decoding, ValueFormatter.Format(value));

    /// <summary>
    /// Enable the track if no other text track is more suitable.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.track(Content[])"/>.</remarks>
    /// <returns><c>default_</c></returns>
    public static Attribute default_() => new(AttributeType.default_);

    /// <summary>
    /// Defer script execution.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.script(Content[])"/>.</remarks>
    /// <returns><c>defer</c></returns>
    public static Attribute defer() => new(AttributeType.defer);

    /// <summary>
    /// The text directionality of the element.
    /// The text directionality of the element.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>dir="{value}"</c></returns>
    public static Attribute dir(string value) => new(AttributeType.dir, value);

    /// <inheritdoc cref="dir(string)" />
    public static Attribute dir(object value) => new(AttributeType.dir, ValueFormatter.Format(value));

    /// <summary>
    /// Name of form control to use for sending the element's directionality in form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>dirname="{value}"</c></returns>
    public static Attribute dirname(string value) => new(AttributeType.dirname, value);

    /// <inheritdoc cref="dirname(string)" />
    public static Attribute dirname(object value) => new(AttributeType.dirname, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the form control is disabled.
    /// Whether the descendant form controls, except any inside legend, are disabled.
    /// Whether the link is disabled.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.optgroup(Content[])"/>, <see cref="Elements.option(Content[])"/>, <see cref="Elements.select(Content[])"/>, <see cref="Elements.textarea(Content[])"/>, <see cref="Elements.fieldset(Content[])"/>, <see cref="Elements.link(Content[])"/>.</remarks>
    /// <returns><c>disabled</c></returns>
    public static Attribute disabled() => new(AttributeType.disabled);

    /// <summary>
    /// Whether to download the resource instead of navigating to it, and its filename if so.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.area(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>download="{value}"</c></returns>
    public static Attribute download(string value) => new(AttributeType.download, value);

    /// <inheritdoc cref="download(string)" />
    public static Attribute download(object value) => new(AttributeType.download, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is draggable.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>draggable="{value}"</c></returns>
    public static Attribute draggable(string value) => new(AttributeType.draggable, value);

    /// <inheritdoc cref="draggable(string)" />
    public static Attribute draggable(object value) => new(AttributeType.draggable, ValueFormatter.Format(value));

    /// <summary>
    /// Entry list encoding type to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.form(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>enctype="{value}"</c></returns>
    public static Attribute enctype(string value) => new(AttributeType.enctype, value);

    /// <inheritdoc cref="enctype(string)" />
    public static Attribute enctype(object value) => new(AttributeType.enctype, ValueFormatter.Format(value));

    /// <summary>
    /// Hint for selecting an enter key action.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>enterkeyhint="{value}"</c></returns>
    public static Attribute enterkeyhint(string value) => new(AttributeType.enterkeyhint, value);

    /// <inheritdoc cref="enterkeyhint(string)" />
    public static Attribute enterkeyhint(object value) => new(AttributeType.enterkeyhint, ValueFormatter.Format(value));

    /// <summary>
    /// Sets the priority for fetches initiated by the element.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.img(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.script(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>fetchpriority="{value}"</c></returns>
    public static Attribute fetchpriority(string value) => new(AttributeType.fetchpriority, value);

    /// <inheritdoc cref="fetchpriority(string)" />
    public static Attribute fetchpriority(object value) => new(AttributeType.fetchpriority, ValueFormatter.Format(value));

    /// <summary>
    /// Associate the label with form control.
    /// Specifies controls from which the output was calculated.
    /// Updates existing content.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.label(Content[])"/>, <see cref="Elements.output(Content[])"/>, <see cref="Elements.template(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>for_="{value}"</c></returns>
    public static Attribute for_(string value) => new(AttributeType.for_, value);

    /// <inheritdoc cref="for_(string)" />
    public static Attribute for_(object value) => new(AttributeType.for_, ValueFormatter.Format(value));

    /// <summary>
    /// Associates the element with a form element.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.fieldset(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.object_(Content[])"/>, <see cref="Elements.output(Content[])"/>, <see cref="Elements.select(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>form="{value}"</c></returns>
    public static Attribute form(string value) => new(AttributeType.form, value);

    /// <inheritdoc cref="form(string)" />
    public static Attribute form(object value) => new(AttributeType.form, ValueFormatter.Format(value));

    /// <summary>
    /// URL to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>formaction="{value}"</c></returns>
    public static Attribute formaction(string value) => new(AttributeType.formaction, value);

    /// <inheritdoc cref="formaction(string)" />
    public static Attribute formaction(object value) => new(AttributeType.formaction, ValueFormatter.Format(value));

    /// <summary>
    /// Entry list encoding type to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>formenctype="{value}"</c></returns>
    public static Attribute formenctype(string value) => new(AttributeType.formenctype, value);

    /// <inheritdoc cref="formenctype(string)" />
    public static Attribute formenctype(object value) => new(AttributeType.formenctype, ValueFormatter.Format(value));

    /// <summary>
    /// Variant to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>formmethod="{value}"</c></returns>
    public static Attribute formmethod(string value) => new(AttributeType.formmethod, value);

    /// <inheritdoc cref="formmethod(string)" />
    public static Attribute formmethod(object value) => new(AttributeType.formmethod, ValueFormatter.Format(value));

    /// <summary>
    /// Bypass form control validation for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <returns><c>formnovalidate</c></returns>
    public static Attribute formnovalidate() => new(AttributeType.formnovalidate);

    /// <summary>
    /// Navigable for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>formtarget="{value}"</c></returns>
    public static Attribute formtarget(string value) => new(AttributeType.formtarget, value);

    /// <inheritdoc cref="formtarget(string)" />
    public static Attribute formtarget(object value) => new(AttributeType.formtarget, ValueFormatter.Format(value));

    /// <summary>
    /// The header cells for this cell.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.td(Content[])"/>, <see cref="Elements.th(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>headers="{value}"</c></returns>
    public static Attribute headers(string value) => new(AttributeType.headers, value);

    /// <inheritdoc cref="headers(string)" />
    public static Attribute headers(object value) => new(AttributeType.headers, ValueFormatter.Format(value));

    /// <summary>
    /// Offsets heading levels for descendants.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>headingoffset="{value}"</c></returns>
    public static Attribute headingoffset(string value) => new(AttributeType.headingoffset, value);

    /// <inheritdoc cref="headingoffset(string)" />
    public static Attribute headingoffset(object value) => new(AttributeType.headingoffset, ValueFormatter.Format(value));

    /// <summary>
    /// Prevents a heading offset computation from traversing beyond the element with the attribute.
    /// </summary>
    /// <returns><c>headingreset</c></returns>
    public static Attribute headingreset() => new(AttributeType.headingreset);

    /// <summary>
    /// Vertical dimension.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.canvas(Content[])"/>, <see cref="Elements.embed(Content[])"/>, <see cref="Elements.iframe(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.object_(Content[])"/>, <see cref="Elements.source(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>height="{value}"</c></returns>
    public static Attribute height(string value) => new(AttributeType.height, value);

    /// <inheritdoc cref="height(string)" />
    public static Attribute height(object value) => new(AttributeType.height, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is relevant.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hidden="{value}"</c></returns>
    public static Attribute hidden(string value) => new(AttributeType.hidden, value);

    /// <inheritdoc cref="hidden(string)" />
    public static Attribute hidden(object value) => new(AttributeType.hidden, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is relevant.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>hidden</c></returns>
    public static Attribute hidden() => new(AttributeType.hidden);

    /// <summary>
    /// Low limit of high range.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.meter(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>high="{value}"</c></returns>
    public static Attribute high(string value) => new(AttributeType.high, value);

    /// <inheritdoc cref="high(string)" />
    public static Attribute high(object value) => new(AttributeType.high, ValueFormatter.Format(value));

    /// <summary>
    /// Address of the hyperlink.
    /// Address of the hyperlink.
    /// Document base URL.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.area(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.base_(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>href="{value}"</c></returns>
    public static Attribute href(string value) => new(AttributeType.href, value);

    /// <inheritdoc cref="href(string)" />
    public static Attribute href(object value) => new(AttributeType.href, ValueFormatter.Format(value));

    /// <summary>
    /// Language of the linked resource.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.link(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>hreflang="{value}"</c></returns>
    public static Attribute hreflang(string value) => new(AttributeType.hreflang, value);

    /// <inheritdoc cref="hreflang(string)" />
    public static Attribute hreflang(object value) => new(AttributeType.hreflang, ValueFormatter.Format(value));

    /// <summary>
    /// Pragma directive.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.meta(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>http_equiv="{value}"</c></returns>
    public static Attribute http_equiv(string value) => new(AttributeType.http_equiv, value);

    /// <inheritdoc cref="http_equiv(string)" />
    public static Attribute http_equiv(object value) => new(AttributeType.http_equiv, ValueFormatter.Format(value));

    /// <summary>
    /// The element's ID.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>id="{value}"</c></returns>
    public static Attribute id(string value) => new(AttributeType.id, value);

    /// <inheritdoc cref="id(string)" />
    public static Attribute id(object value) => new(AttributeType.id, ValueFormatter.Format(value));

    /// <summary>
    /// Image sizes for different page layouts (for rel="preload").
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>imagesizes="{value}"</c></returns>
    public static Attribute imagesizes(string value) => new(AttributeType.imagesizes, value);

    /// <inheritdoc cref="imagesizes(string)" />
    public static Attribute imagesizes(object value) => new(AttributeType.imagesizes, ValueFormatter.Format(value));

    /// <summary>
    /// Images to use in different situations, e.g., high-resolution displays, small monitors, etc. (for rel="preload").
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>imagesrcset="{value}"</c></returns>
    public static Attribute imagesrcset(string value) => new(AttributeType.imagesrcset, value);

    /// <inheritdoc cref="imagesrcset(string)" />
    public static Attribute imagesrcset(object value) => new(AttributeType.imagesrcset, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is inert.
    /// </summary>
    /// <returns><c>inert</c></returns>
    public static Attribute inert() => new(AttributeType.inert);

    /// <summary>
    /// Hint for selecting an input modality.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>inputmode="{value}"</c></returns>
    public static Attribute inputmode(string value) => new(AttributeType.inputmode, value);

    /// <inheritdoc cref="inputmode(string)" />
    public static Attribute inputmode(object value) => new(AttributeType.inputmode, ValueFormatter.Format(value));

    /// <summary>
    /// Integrity metadata used in Subresource Integrity checks [SRI].
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>, <see cref="Elements.script(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>integrity="{value}"</c></returns>
    public static Attribute integrity(string value) => new(AttributeType.integrity, value);

    /// <inheritdoc cref="integrity(string)" />
    public static Attribute integrity(object value) => new(AttributeType.integrity, ValueFormatter.Format(value));

    /// <summary>
    /// Creates a customized built-in element.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>is_="{value}"</c></returns>
    public static Attribute is_(string value) => new(AttributeType.is_, value);

    /// <inheritdoc cref="is_(string)" />
    public static Attribute is_(object value) => new(AttributeType.is_, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the image is a server-side image map.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.img(Content[])"/>.</remarks>
    /// <returns><c>ismap</c></returns>
    public static Attribute ismap() => new(AttributeType.ismap);

    /// <summary>
    /// Global identifier for a microdata item.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>itemid="{value}"</c></returns>
    public static Attribute itemid(string value) => new(AttributeType.itemid, value);

    /// <inheritdoc cref="itemid(string)" />
    public static Attribute itemid(object value) => new(AttributeType.itemid, ValueFormatter.Format(value));

    /// <summary>
    /// Property names of a microdata item.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>itemprop="{value}"</c></returns>
    public static Attribute itemprop(string value) => new(AttributeType.itemprop, value);

    /// <inheritdoc cref="itemprop(string)" />
    public static Attribute itemprop(object value) => new(AttributeType.itemprop, ValueFormatter.Format(value));

    /// <summary>
    /// Referenced elements.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>itemref="{value}"</c></returns>
    public static Attribute itemref(string value) => new(AttributeType.itemref, value);

    /// <inheritdoc cref="itemref(string)" />
    public static Attribute itemref(object value) => new(AttributeType.itemref, ValueFormatter.Format(value));

    /// <summary>
    /// Introduces a microdata item.
    /// </summary>
    /// <returns><c>itemscope</c></returns>
    public static Attribute itemscope() => new(AttributeType.itemscope);

    /// <summary>
    /// Item types of a microdata item.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>itemtype="{value}"</c></returns>
    public static Attribute itemtype(string value) => new(AttributeType.itemtype, value);

    /// <inheritdoc cref="itemtype(string)" />
    public static Attribute itemtype(object value) => new(AttributeType.itemtype, ValueFormatter.Format(value));

    /// <summary>
    /// The type of text track.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.track(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>kind="{value}"</c></returns>
    public static Attribute kind(string value) => new(AttributeType.kind, value);

    /// <inheritdoc cref="kind(string)" />
    public static Attribute kind(object value) => new(AttributeType.kind, ValueFormatter.Format(value));

    /// <summary>
    /// User-visible label.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.optgroup(Content[])"/>, <see cref="Elements.option(Content[])"/>, <see cref="Elements.track(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>label="{value}"</c></returns>
    public static Attribute label(string value) => new(AttributeType.label, value);

    /// <inheritdoc cref="label(string)" />
    public static Attribute label(object value) => new(AttributeType.label, ValueFormatter.Format(value));

    /// <summary>
    /// Language of the element.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>lang="{value}"</c></returns>
    public static Attribute lang(string value) => new(AttributeType.lang, value);

    /// <inheritdoc cref="lang(string)" />
    public static Attribute lang(object value) => new(AttributeType.lang, ValueFormatter.Format(value));

    /// <summary>
    /// List of autocomplete options.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>list="{value}"</c></returns>
    public static Attribute list(string value) => new(AttributeType.list, value);

    /// <inheritdoc cref="list(string)" />
    public static Attribute list(object value) => new(AttributeType.list, ValueFormatter.Format(value));

    /// <summary>
    /// Used when determining loading deferral.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.iframe(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.audio(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>loading="{value}"</c></returns>
    public static Attribute loading(string value) => new(AttributeType.loading, value);

    /// <inheritdoc cref="loading(string)" />
    public static Attribute loading(object value) => new(AttributeType.loading, ValueFormatter.Format(value));

    /// <summary>
    /// Whether to loop the media resource.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <returns><c>loop</c></returns>
    public static Attribute loop() => new(AttributeType.loop);

    /// <summary>
    /// High limit of low range.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.meter(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>low="{value}"</c></returns>
    public static Attribute low(string value) => new(AttributeType.low, value);

    /// <inheritdoc cref="low(string)" />
    public static Attribute low(object value) => new(AttributeType.low, ValueFormatter.Format(value));

    /// <summary>
    /// Maximum value.
    /// Upper bound of range.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.meter(Content[])"/>, <see cref="Elements.progress(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>max="{value}"</c></returns>
    public static Attribute max(string value) => new(AttributeType.max, value);

    /// <inheritdoc cref="max(string)" />
    public static Attribute max(object value) => new(AttributeType.max, ValueFormatter.Format(value));

    /// <summary>
    /// Maximum length of value.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>maxlength="{value}"</c></returns>
    public static Attribute maxlength(string value) => new(AttributeType.maxlength, value);

    /// <inheritdoc cref="maxlength(string)" />
    public static Attribute maxlength(object value) => new(AttributeType.maxlength, ValueFormatter.Format(value));

    /// <summary>
    /// Applicable media.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>, <see cref="Elements.meta(Content[])"/>, <see cref="Elements.source(Content[])"/>, <see cref="Elements.style(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>media="{value}"</c></returns>
    public static Attribute media(string value) => new(AttributeType.media, value);

    /// <inheritdoc cref="media(string)" />
    public static Attribute media(object value) => new(AttributeType.media, ValueFormatter.Format(value));

    /// <summary>
    /// Variant to use for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.form(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>method="{value}"</c></returns>
    public static Attribute method(string value) => new(AttributeType.method, value);

    /// <inheritdoc cref="method(string)" />
    public static Attribute method(object value) => new(AttributeType.method, ValueFormatter.Format(value));

    /// <summary>
    /// Minimum value.
    /// Lower bound of range.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.meter(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>min="{value}"</c></returns>
    public static Attribute min(string value) => new(AttributeType.min, value);

    /// <inheritdoc cref="min(string)" />
    public static Attribute min(object value) => new(AttributeType.min, ValueFormatter.Format(value));

    /// <summary>
    /// Minimum length of value.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>minlength="{value}"</c></returns>
    public static Attribute minlength(string value) => new(AttributeType.minlength, value);

    /// <inheritdoc cref="minlength(string)" />
    public static Attribute minlength(object value) => new(AttributeType.minlength, ValueFormatter.Format(value));

    /// <summary>
    /// Whether to allow multiple values.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.select(Content[])"/>.</remarks>
    /// <returns><c>multiple</c></returns>
    public static Attribute multiple() => new(AttributeType.multiple);

    /// <summary>
    /// Whether to mute the media resource by default.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <returns><c>muted</c></returns>
    public static Attribute muted() => new(AttributeType.muted);

    /// <summary>
    /// Name of the element to use for form submission and in the form.elements API.
    /// Name of group of mutually-exclusive details elements.
    /// Name of form to use in the document.forms API.
    /// Name of content navigable.
    /// Name of image map to reference from the usemap attribute.
    /// Metadata name.
    /// Name of shadow tree slot.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.fieldset(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.output(Content[])"/>, <see cref="Elements.select(Content[])"/>, <see cref="Elements.textarea(Content[])"/>, <see cref="Elements.details(Content[])"/>, <see cref="Elements.form(Content[])"/>, <see cref="Elements.iframe(Content[])"/>, <see cref="Elements.object_(Content[])"/>, <see cref="Elements.map(Content[])"/>, <see cref="Elements.meta(Content[])"/>, <see cref="Elements.slot(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>name="{value}"</c></returns>
    public static Attribute name(string value) => new(AttributeType.name, value);

    /// <inheritdoc cref="name(string)" />
    public static Attribute name(object value) => new(AttributeType.name, ValueFormatter.Format(value));

    /// <summary>
    /// Prevents execution in user agents that support module scripts.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.script(Content[])"/>.</remarks>
    /// <returns><c>nomodule</c></returns>
    public static Attribute nomodule() => new(AttributeType.nomodule);

    /// <summary>
    /// Cryptographic nonce used in Content Security Policy checks [CSP].
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>nonce="{value}"</c></returns>
    public static Attribute nonce(string value) => new(AttributeType.nonce, value);

    /// <inheritdoc cref="nonce(string)" />
    public static Attribute nonce(object value) => new(AttributeType.nonce, ValueFormatter.Format(value));

    /// <summary>
    /// Bypass form control validation for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.form(Content[])"/>.</remarks>
    /// <returns><c>novalidate</c></returns>
    public static Attribute novalidate() => new(AttributeType.novalidate);

    /// <summary>
    /// Whether the details are visible.
    /// Whether the dialog box is showing.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.details(Content[])"/>, <see cref="Elements.dialog(Content[])"/>.</remarks>
    /// <returns><c>open</c></returns>
    public static Attribute open() => new(AttributeType.open);

    /// <summary>
    /// Optimum value in gauge.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.meter(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>optimum="{value}"</c></returns>
    public static Attribute optimum(string value) => new(AttributeType.optimum, value);

    /// <inheritdoc cref="optimum(string)" />
    public static Attribute optimum(object value) => new(AttributeType.optimum, ValueFormatter.Format(value));

    /// <summary>
    /// Pattern to be matched by the form control's value.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>pattern="{value}"</c></returns>
    public static Attribute pattern(string value) => new(AttributeType.pattern, value);

    /// <inheritdoc cref="pattern(string)" />
    public static Attribute pattern(object value) => new(AttributeType.pattern, ValueFormatter.Format(value));

    /// <summary>
    /// URLs to ping.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ping="{value}"</c></returns>
    public static Attribute ping(string value) => new(AttributeType.ping, value);

    /// <inheritdoc cref="ping(string)" />
    public static Attribute ping(object value) => new(AttributeType.ping, ValueFormatter.Format(value));

    /// <summary>
    /// User-visible label to be placed within the form control.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>placeholder="{value}"</c></returns>
    public static Attribute placeholder(string value) => new(AttributeType.placeholder, value);

    /// <inheritdoc cref="placeholder(string)" />
    public static Attribute placeholder(object value) => new(AttributeType.placeholder, ValueFormatter.Format(value));

    /// <summary>
    /// Encourage the user agent to display video content within the element's playback area.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.video(Content[])"/>.</remarks>
    /// <returns><c>playsinline</c></returns>
    public static Attribute playsinline() => new(AttributeType.playsinline);

    /// <summary>
    /// Makes the element a popover element.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>popover="{value}"</c></returns>
    public static Attribute popover(string value) => new(AttributeType.popover, value);

    /// <inheritdoc cref="popover(string)" />
    public static Attribute popover(object value) => new(AttributeType.popover, ValueFormatter.Format(value));

    /// <summary>
    /// Makes the element a popover element.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>popover</c></returns>
    public static Attribute popover() => new(AttributeType.popover);

    /// <summary>
    /// Targets a popover element to toggle, show, or hide.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>popovertarget="{value}"</c></returns>
    public static Attribute popovertarget(string value) => new(AttributeType.popovertarget, value);

    /// <inheritdoc cref="popovertarget(string)" />
    public static Attribute popovertarget(object value) => new(AttributeType.popovertarget, ValueFormatter.Format(value));

    /// <summary>
    /// Indicates whether a targeted popover element is to be toggled, shown, or hidden.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>popovertargetaction="{value}"</c></returns>
    public static Attribute popovertargetaction(string value) => new(AttributeType.popovertargetaction, value);

    /// <inheritdoc cref="popovertargetaction(string)" />
    public static Attribute popovertargetaction(object value) => new(AttributeType.popovertargetaction, ValueFormatter.Format(value));

    /// <summary>
    /// Poster frame to show prior to video playback.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>poster="{value}"</c></returns>
    public static Attribute poster(string value) => new(AttributeType.poster, value);

    /// <inheritdoc cref="poster(string)" />
    public static Attribute poster(object value) => new(AttributeType.poster, ValueFormatter.Format(value));

    /// <summary>
    /// Hints how much buffering the media resource will likely need.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>preload="{value}"</c></returns>
    public static Attribute preload(string value) => new(AttributeType.preload, value);

    /// <inheritdoc cref="preload(string)" />
    public static Attribute preload(object value) => new(AttributeType.preload, ValueFormatter.Format(value));

    /// <summary>
    /// Hints how much buffering the media resource will likely need.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>preload</c></returns>
    public static Attribute preload() => new(AttributeType.preload);

    /// <summary>
    /// Whether to allow the value to be edited by the user.
    /// Affects willValidate, plus any behavior added by the custom element author.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <returns><c>readonly_</c></returns>
    public static Attribute readonly_() => new(AttributeType.readonly_);

    /// <summary>
    /// Referrer policy for fetches initiated by the element.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.area(Content[])"/>, <see cref="Elements.iframe(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.script(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>referrerpolicy="{value}"</c></returns>
    public static Attribute referrerpolicy(string value) => new(AttributeType.referrerpolicy, value);

    /// <inheritdoc cref="referrerpolicy(string)" />
    public static Attribute referrerpolicy(object value) => new(AttributeType.referrerpolicy, ValueFormatter.Format(value));

    /// <summary>
    /// Relationship between the location in the document containing the hyperlink and the destination resource.
    /// Relationship between the document containing the hyperlink and the destination resource.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.area(Content[])"/>, <see cref="Elements.link(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>rel="{value}"</c></returns>
    public static Attribute rel(string value) => new(AttributeType.rel, value);

    /// <inheritdoc cref="rel(string)" />
    public static Attribute rel(object value) => new(AttributeType.rel, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the control is required for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.select(Content[])"/>, <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <returns><c>required</c></returns>
    public static Attribute required() => new(AttributeType.required);

    /// <summary>
    /// Number the list backwards.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.ol(Content[])"/>.</remarks>
    /// <returns><c>reversed</c></returns>
    public static Attribute reversed() => new(AttributeType.reversed);

    /// <summary>
    /// Number of lines to show.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>rows="{value}"</c></returns>
    public static Attribute rows(string value) => new(AttributeType.rows, value);

    /// <inheritdoc cref="rows(string)" />
    public static Attribute rows(object value) => new(AttributeType.rows, ValueFormatter.Format(value));

    /// <summary>
    /// Number of rows that the cell is to span.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.td(Content[])"/>, <see cref="Elements.th(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>rowspan="{value}"</c></returns>
    public static Attribute rowspan(string value) => new(AttributeType.rowspan, value);

    /// <inheritdoc cref="rowspan(string)" />
    public static Attribute rowspan(object value) => new(AttributeType.rowspan, ValueFormatter.Format(value));

    /// <summary>
    /// Security rules for nested content.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.iframe(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>sandbox="{value}"</c></returns>
    public static Attribute sandbox(string value) => new(AttributeType.sandbox, value);

    /// <inheritdoc cref="sandbox(string)" />
    public static Attribute sandbox(object value) => new(AttributeType.sandbox, ValueFormatter.Format(value));

    /// <summary>
    /// Specifies which cells the header cell applies to.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.th(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>scope="{value}"</c></returns>
    public static Attribute scope(string value) => new(AttributeType.scope, value);

    /// <inheritdoc cref="scope(string)" />
    public static Attribute scope(object value) => new(AttributeType.scope, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the option is selected by default.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.option(Content[])"/>.</remarks>
    /// <returns><c>selected</c></returns>
    public static Attribute selected() => new(AttributeType.selected);

    /// <summary>
    /// Sets clonable on a declarative shadow root.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.template(Content[])"/>.</remarks>
    /// <returns><c>shadowrootclonable</c></returns>
    public static Attribute shadowrootclonable() => new(AttributeType.shadowrootclonable);

    /// <summary>
    /// Enables declarative shadow roots to indicate they will use a custom element registry.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.template(Content[])"/>.</remarks>
    /// <returns><c>shadowrootcustomelementregistry</c></returns>
    public static Attribute shadowrootcustomelementregistry() => new(AttributeType.shadowrootcustomelementregistry);

    /// <summary>
    /// Sets delegates focus on a declarative shadow root.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.template(Content[])"/>.</remarks>
    /// <returns><c>shadowrootdelegatesfocus</c></returns>
    public static Attribute shadowrootdelegatesfocus() => new(AttributeType.shadowrootdelegatesfocus);

    /// <summary>
    /// Enables streaming declarative shadow roots.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.template(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>shadowrootmode="{value}"</c></returns>
    public static Attribute shadowrootmode(string value) => new(AttributeType.shadowrootmode, value);

    /// <inheritdoc cref="shadowrootmode(string)" />
    public static Attribute shadowrootmode(object value) => new(AttributeType.shadowrootmode, ValueFormatter.Format(value));

    /// <summary>
    /// Sets serializable on a declarative shadow root.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.template(Content[])"/>.</remarks>
    /// <returns><c>shadowrootserializable</c></returns>
    public static Attribute shadowrootserializable() => new(AttributeType.shadowrootserializable);

    /// <summary>
    /// Sets slot assignment on a declarative shadow root.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.template(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>shadowrootslotassignment="{value}"</c></returns>
    public static Attribute shadowrootslotassignment(string value) => new(AttributeType.shadowrootslotassignment, value);

    /// <inheritdoc cref="shadowrootslotassignment(string)" />
    public static Attribute shadowrootslotassignment(object value) => new(AttributeType.shadowrootslotassignment, ValueFormatter.Format(value));

    /// <summary>
    /// The kind of shape to be created in an image map.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.area(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>shape="{value}"</c></returns>
    public static Attribute shape(string value) => new(AttributeType.shape, value);

    /// <inheritdoc cref="shape(string)" />
    public static Attribute shape(object value) => new(AttributeType.shape, ValueFormatter.Format(value));

    /// <summary>
    /// Size of the control.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>, <see cref="Elements.select(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>size="{value}"</c></returns>
    public static Attribute size(string value) => new(AttributeType.size, value);

    /// <inheritdoc cref="size(string)" />
    public static Attribute size(object value) => new(AttributeType.size, ValueFormatter.Format(value));

    /// <summary>
    /// Sizes of the icons (for rel="icon").
    /// Image sizes for different page layouts.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.link(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.source(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>sizes="{value}"</c></returns>
    public static Attribute sizes(string value) => new(AttributeType.sizes, value);

    /// <inheritdoc cref="sizes(string)" />
    public static Attribute sizes(object value) => new(AttributeType.sizes, ValueFormatter.Format(value));

    /// <summary>
    /// The element's desired slot.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>slot="{value}"</c></returns>
    public static Attribute slot(string value) => new(AttributeType.slot, value);

    /// <inheritdoc cref="slot(string)" />
    public static Attribute slot(object value) => new(AttributeType.slot, ValueFormatter.Format(value));

    /// <summary>
    /// Number of columns spanned by the element.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.col(Content[])"/>, <see cref="Elements.colgroup(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>span="{value}"</c></returns>
    public static Attribute span(string value) => new(AttributeType.span, value);

    /// <inheritdoc cref="span(string)" />
    public static Attribute span(object value) => new(AttributeType.span, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is to have its spelling and grammar checked.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>spellcheck="{value}"</c></returns>
    public static Attribute spellcheck(string value) => new(AttributeType.spellcheck, value);

    /// <inheritdoc cref="spellcheck(string)" />
    public static Attribute spellcheck(object value) => new(AttributeType.spellcheck, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is to have its spelling and grammar checked.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>spellcheck</c></returns>
    public static Attribute spellcheck() => new(AttributeType.spellcheck);

    /// <summary>
    /// Address of the resource.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.audio(Content[])"/>, <see cref="Elements.embed(Content[])"/>, <see cref="Elements.iframe(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.script(Content[])"/>, <see cref="Elements.source(Content[])"/>, <see cref="Elements.track(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>src="{value}"</c></returns>
    public static Attribute src(string value) => new(AttributeType.src, value);

    /// <inheritdoc cref="src(string)" />
    public static Attribute src(object value) => new(AttributeType.src, ValueFormatter.Format(value));

    /// <summary>
    /// A document to render in the iframe.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.iframe(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>srcdoc="{value}"</c></returns>
    public static Attribute srcdoc(string value) => new(AttributeType.srcdoc, value);

    /// <inheritdoc cref="srcdoc(string)" />
    public static Attribute srcdoc(object value) => new(AttributeType.srcdoc, ValueFormatter.Format(value));

    /// <summary>
    /// Language of the text track.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.track(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>srclang="{value}"</c></returns>
    public static Attribute srclang(string value) => new(AttributeType.srclang, value);

    /// <inheritdoc cref="srclang(string)" />
    public static Attribute srclang(object value) => new(AttributeType.srclang, ValueFormatter.Format(value));

    /// <summary>
    /// Images to use in different situations, e.g., high-resolution displays, small monitors, etc.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.img(Content[])"/>, <see cref="Elements.source(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>srcset="{value}"</c></returns>
    public static Attribute srcset(string value) => new(AttributeType.srcset, value);

    /// <inheritdoc cref="srcset(string)" />
    public static Attribute srcset(object value) => new(AttributeType.srcset, ValueFormatter.Format(value));

    /// <summary>
    /// Starting value of the list.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.ol(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>start="{value}"</c></returns>
    public static Attribute start(string value) => new(AttributeType.start, value);

    /// <inheritdoc cref="start(string)" />
    public static Attribute start(object value) => new(AttributeType.start, ValueFormatter.Format(value));

    /// <summary>
    /// Granularity to be matched by the form control's value.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.input(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>step="{value}"</c></returns>
    public static Attribute step(string value) => new(AttributeType.step, value);

    /// <inheritdoc cref="step(string)" />
    public static Attribute step(object value) => new(AttributeType.step, ValueFormatter.Format(value));

    /// <summary>
    /// Presentational and formatting instructions.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>style="{value}"</c></returns>
    public static Attribute style(string value) => new(AttributeType.style, value);

    /// <inheritdoc cref="style(string)" />
    public static Attribute style(object value) => new(AttributeType.style, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is focusable and sequentially focusable, and the relative order of the element for the purposes of sequential focus navigation.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>tabindex="{value}"</c></returns>
    public static Attribute tabindex(string value) => new(AttributeType.tabindex, value);

    /// <inheritdoc cref="tabindex(string)" />
    public static Attribute tabindex(object value) => new(AttributeType.tabindex, ValueFormatter.Format(value));

    /// <summary>
    /// Navigable for hyperlink navigation.
    /// Default navigable for hyperlink navigation and form submission.
    /// Navigable for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.area(Content[])"/>, <see cref="Elements.base_(Content[])"/>, <see cref="Elements.form(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>target="{value}"</c></returns>
    public static Attribute target(string value) => new(AttributeType.target, value);

    /// <inheritdoc cref="target(string)" />
    public static Attribute target(object value) => new(AttributeType.target, ValueFormatter.Format(value));

    /// <summary>
    /// Advisory information for the element.
    /// Full term or expansion of abbreviation.
    /// Description of pattern (when used with pattern attribute).
    /// Title of the link.
    /// CSS style sheet set name.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.abbr(Content[])"/>, <see cref="Elements.dfn(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.style(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>title="{value}"</c></returns>
    public static Attribute title(string value) => new(AttributeType.title, value);

    /// <inheritdoc cref="title(string)" />
    public static Attribute title(object value) => new(AttributeType.title, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is to be translated when the page is localized.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>translate="{value}"</c></returns>
    public static Attribute translate(string value) => new(AttributeType.translate, value);

    /// <inheritdoc cref="translate(string)" />
    public static Attribute translate(object value) => new(AttributeType.translate, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element is to be translated when the page is localized.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>translate</c></returns>
    public static Attribute translate() => new(AttributeType.translate);

    /// <summary>
    /// Hint for the type of the referenced resource.
    /// Type of button.
    /// Type of embedded resource.
    /// Type of form control.
    /// Kind of list marker.
    /// Type of script.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.a(Content[])"/>, <see cref="Elements.link(Content[])"/>, <see cref="Elements.button(Content[])"/>, <see cref="Elements.embed(Content[])"/>, <see cref="Elements.object_(Content[])"/>, <see cref="Elements.source(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.ol(Content[])"/>, <see cref="Elements.script(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>type="{value}"</c></returns>
    public static Attribute type(string value) => new(AttributeType.type, value);

    /// <inheritdoc cref="type(string)" />
    public static Attribute type(object value) => new(AttributeType.type, ValueFormatter.Format(value));

    /// <summary>
    /// Name of image map to use.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.img(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>usemap="{value}"</c></returns>
    public static Attribute usemap(string value) => new(AttributeType.usemap, value);

    /// <inheritdoc cref="usemap(string)" />
    public static Attribute usemap(object value) => new(AttributeType.usemap, ValueFormatter.Format(value));

    /// <summary>
    /// Value to be used for form submission.
    /// Machine-readable value.
    /// Value of the form control.
    /// Ordinal value of the list item.
    /// Current value of the element.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.button(Content[])"/>, <see cref="Elements.option(Content[])"/>, <see cref="Elements.data(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.li(Content[])"/>, <see cref="Elements.meter(Content[])"/>, <see cref="Elements.progress(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>value="{value}"</c></returns>
    public static Attribute value(string value) => new(AttributeType.value, value);

    /// <inheritdoc cref="value(string)" />
    public static Attribute value(object value) => new(AttributeType.value, ValueFormatter.Format(value));

    /// <summary>
    /// Horizontal dimension.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.canvas(Content[])"/>, <see cref="Elements.embed(Content[])"/>, <see cref="Elements.iframe(Content[])"/>, <see cref="Elements.img(Content[])"/>, <see cref="Elements.input(Content[])"/>, <see cref="Elements.object_(Content[])"/>, <see cref="Elements.source(Content[])"/>, <see cref="Elements.video(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>width="{value}"</c></returns>
    public static Attribute width(string value) => new(AttributeType.width, value);

    /// <inheritdoc cref="width(string)" />
    public static Attribute width(object value) => new(AttributeType.width, ValueFormatter.Format(value));

    /// <summary>
    /// How the value of the form control is to be wrapped for form submission.
    /// </summary>
    /// <remarks>Elements: <see cref="Elements.textarea(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>wrap="{value}"</c></returns>
    public static Attribute wrap(string value) => new(AttributeType.wrap, value);

    /// <inheritdoc cref="wrap(string)" />
    public static Attribute wrap(object value) => new(AttributeType.wrap, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element can offer writing suggestions or not.
    /// </summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>writingsuggestions="{value}"</c></returns>
    public static Attribute writingsuggestions(string value) => new(AttributeType.writingsuggestions, value);

    /// <inheritdoc cref="writingsuggestions(string)" />
    public static Attribute writingsuggestions(object value) => new(AttributeType.writingsuggestions, ValueFormatter.Format(value));

    /// <summary>
    /// Whether the element can offer writing suggestions or not.
    /// </summary>
    /// <remarks>Written bare, which the specification allows by listing the empty string among the values. Pass a value for the other states.</remarks>
    /// <returns><c>writingsuggestions</c></returns>
    public static Attribute writingsuggestions() => new(AttributeType.writingsuggestions);
}
