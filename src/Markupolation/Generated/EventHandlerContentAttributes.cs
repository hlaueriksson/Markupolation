namespace Markupolation;

/// <summary>HTML event handler content attributes.</summary>
public static class EventHandlerContentAttributes
{
    /// <summary>auxclick event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onauxclick="{value}"</c></returns>
    public static Attribute onauxclick(string value) => new("onauxclick", value);

    /// <summary>afterprint event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onafterprint="{value}"</c></returns>
    public static Attribute onafterprint(string value) => new("onafterprint", value);

    /// <summary>beforematch event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onbeforematch="{value}"</c></returns>
    public static Attribute onbeforematch(string value) => new("onbeforematch", value);

    /// <summary>beforeprint event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onbeforeprint="{value}"</c></returns>
    public static Attribute onbeforeprint(string value) => new("onbeforeprint", value);

    /// <summary>beforeunload event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onbeforeunload="{value}"</c></returns>
    public static Attribute onbeforeunload(string value) => new("onbeforeunload", value);

    /// <summary>beforetoggle event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onbeforetoggle="{value}"</c></returns>
    public static Attribute onbeforetoggle(string value) => new("onbeforetoggle", value);

    /// <summary>blur event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onblur="{value}"</c></returns>
    public static Attribute onblur(string value) => new("onblur", value);

    /// <summary>cancel event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncancel="{value}"</c></returns>
    public static Attribute oncancel(string value) => new("oncancel", value);

    /// <summary>canplay event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncanplay="{value}"</c></returns>
    public static Attribute oncanplay(string value) => new("oncanplay", value);

    /// <summary>canplaythrough event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncanplaythrough="{value}"</c></returns>
    public static Attribute oncanplaythrough(string value) => new("oncanplaythrough", value);

    /// <summary>change event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onchange="{value}"</c></returns>
    public static Attribute onchange(string value) => new("onchange", value);

    /// <summary>click event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onclick="{value}"</c></returns>
    public static Attribute onclick(string value) => new("onclick", value);

    /// <summary>close event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onclose="{value}"</c></returns>
    public static Attribute onclose(string value) => new("onclose", value);

    /// <summary>contextlost event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncontextlost="{value}"</c></returns>
    public static Attribute oncontextlost(string value) => new("oncontextlost", value);

    /// <summary>contextmenu event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncontextmenu="{value}"</c></returns>
    public static Attribute oncontextmenu(string value) => new("oncontextmenu", value);

    /// <summary>contextrestored event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncontextrestored="{value}"</c></returns>
    public static Attribute oncontextrestored(string value) => new("oncontextrestored", value);

    /// <summary>copy event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncopy="{value}"</c></returns>
    public static Attribute oncopy(string value) => new("oncopy", value);

    /// <summary>cuechange event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncuechange="{value}"</c></returns>
    public static Attribute oncuechange(string value) => new("oncuechange", value);

    /// <summary>cut event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oncut="{value}"</c></returns>
    public static Attribute oncut(string value) => new("oncut", value);

    /// <summary>dblclick event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondblclick="{value}"</c></returns>
    public static Attribute ondblclick(string value) => new("ondblclick", value);

    /// <summary>drag event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondrag="{value}"</c></returns>
    public static Attribute ondrag(string value) => new("ondrag", value);

    /// <summary>dragend event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondragend="{value}"</c></returns>
    public static Attribute ondragend(string value) => new("ondragend", value);

    /// <summary>dragenter event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondragenter="{value}"</c></returns>
    public static Attribute ondragenter(string value) => new("ondragenter", value);

    /// <summary>dragleave event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondragleave="{value}"</c></returns>
    public static Attribute ondragleave(string value) => new("ondragleave", value);

    /// <summary>dragover event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondragover="{value}"</c></returns>
    public static Attribute ondragover(string value) => new("ondragover", value);

    /// <summary>dragstart event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondragstart="{value}"</c></returns>
    public static Attribute ondragstart(string value) => new("ondragstart", value);

    /// <summary>drop event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondrop="{value}"</c></returns>
    public static Attribute ondrop(string value) => new("ondrop", value);

    /// <summary>durationchange event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ondurationchange="{value}"</c></returns>
    public static Attribute ondurationchange(string value) => new("ondurationchange", value);

    /// <summary>emptied event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onemptied="{value}"</c></returns>
    public static Attribute onemptied(string value) => new("onemptied", value);

    /// <summary>ended event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onended="{value}"</c></returns>
    public static Attribute onended(string value) => new("onended", value);

    /// <summary>error event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onerror="{value}"</c></returns>
    public static Attribute onerror(string value) => new("onerror", value);

    /// <summary>focus event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onfocus="{value}"</c></returns>
    public static Attribute onfocus(string value) => new("onfocus", value);

    /// <summary>formdata event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onformdata="{value}"</c></returns>
    public static Attribute onformdata(string value) => new("onformdata", value);

    /// <summary>hashchange event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onhashchange="{value}"</c></returns>
    public static Attribute onhashchange(string value) => new("onhashchange", value);

    /// <summary>input event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oninput="{value}"</c></returns>
    public static Attribute oninput(string value) => new("oninput", value);

    /// <summary>invalid event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>oninvalid="{value}"</c></returns>
    public static Attribute oninvalid(string value) => new("oninvalid", value);

    /// <summary>keydown event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onkeydown="{value}"</c></returns>
    public static Attribute onkeydown(string value) => new("onkeydown", value);

    /// <summary>keypress event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onkeypress="{value}"</c></returns>
    public static Attribute onkeypress(string value) => new("onkeypress", value);

    /// <summary>keyup event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onkeyup="{value}"</c></returns>
    public static Attribute onkeyup(string value) => new("onkeyup", value);

    /// <summary>languagechange event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onlanguagechange="{value}"</c></returns>
    public static Attribute onlanguagechange(string value) => new("onlanguagechange", value);

    /// <summary>load event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onload="{value}"</c></returns>
    public static Attribute onload(string value) => new("onload", value);

    /// <summary>loadeddata event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onloadeddata="{value}"</c></returns>
    public static Attribute onloadeddata(string value) => new("onloadeddata", value);

    /// <summary>loadedmetadata event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onloadedmetadata="{value}"</c></returns>
    public static Attribute onloadedmetadata(string value) => new("onloadedmetadata", value);

    /// <summary>loadstart event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onloadstart="{value}"</c></returns>
    public static Attribute onloadstart(string value) => new("onloadstart", value);

    /// <summary>message event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmessage="{value}"</c></returns>
    public static Attribute onmessage(string value) => new("onmessage", value);

    /// <summary>messageerror event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmessageerror="{value}"</c></returns>
    public static Attribute onmessageerror(string value) => new("onmessageerror", value);

    /// <summary>mousedown event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmousedown="{value}"</c></returns>
    public static Attribute onmousedown(string value) => new("onmousedown", value);

    /// <summary>mouseenter event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmouseenter="{value}"</c></returns>
    public static Attribute onmouseenter(string value) => new("onmouseenter", value);

    /// <summary>mouseleave event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmouseleave="{value}"</c></returns>
    public static Attribute onmouseleave(string value) => new("onmouseleave", value);

    /// <summary>mousemove event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmousemove="{value}"</c></returns>
    public static Attribute onmousemove(string value) => new("onmousemove", value);

    /// <summary>mouseout event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmouseout="{value}"</c></returns>
    public static Attribute onmouseout(string value) => new("onmouseout", value);

    /// <summary>mouseover event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmouseover="{value}"</c></returns>
    public static Attribute onmouseover(string value) => new("onmouseover", value);

    /// <summary>mouseup event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onmouseup="{value}"</c></returns>
    public static Attribute onmouseup(string value) => new("onmouseup", value);

    /// <summary>offline event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onoffline="{value}"</c></returns>
    public static Attribute onoffline(string value) => new("onoffline", value);

    /// <summary>online event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ononline="{value}"</c></returns>
    public static Attribute ononline(string value) => new("ononline", value);

    /// <summary>pagehide event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onpagehide="{value}"</c></returns>
    public static Attribute onpagehide(string value) => new("onpagehide", value);

    /// <summary>pageshow event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onpageshow="{value}"</c></returns>
    public static Attribute onpageshow(string value) => new("onpageshow", value);

    /// <summary>paste event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onpaste="{value}"</c></returns>
    public static Attribute onpaste(string value) => new("onpaste", value);

    /// <summary>pause event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onpause="{value}"</c></returns>
    public static Attribute onpause(string value) => new("onpause", value);

    /// <summary>play event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onplay="{value}"</c></returns>
    public static Attribute onplay(string value) => new("onplay", value);

    /// <summary>playing event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onplaying="{value}"</c></returns>
    public static Attribute onplaying(string value) => new("onplaying", value);

    /// <summary>popstate event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onpopstate="{value}"</c></returns>
    public static Attribute onpopstate(string value) => new("onpopstate", value);

    /// <summary>progress event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onprogress="{value}"</c></returns>
    public static Attribute onprogress(string value) => new("onprogress", value);

    /// <summary>ratechange event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onratechange="{value}"</c></returns>
    public static Attribute onratechange(string value) => new("onratechange", value);

    /// <summary>reset event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onreset="{value}"</c></returns>
    public static Attribute onreset(string value) => new("onreset", value);

    /// <summary>resize event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onresize="{value}"</c></returns>
    public static Attribute onresize(string value) => new("onresize", value);

    /// <summary>rejectionhandled event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onrejectionhandled="{value}"</c></returns>
    public static Attribute onrejectionhandled(string value) => new("onrejectionhandled", value);

    /// <summary>scroll event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onscroll="{value}"</c></returns>
    public static Attribute onscroll(string value) => new("onscroll", value);

    /// <summary>scrollend event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onscrollend="{value}"</c></returns>
    public static Attribute onscrollend(string value) => new("onscrollend", value);

    /// <summary>securitypolicyviolation event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onsecuritypolicyviolation="{value}"</c></returns>
    public static Attribute onsecuritypolicyviolation(string value) => new("onsecuritypolicyviolation", value);

    /// <summary>seeked event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onseeked="{value}"</c></returns>
    public static Attribute onseeked(string value) => new("onseeked", value);

    /// <summary>seeking event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onseeking="{value}"</c></returns>
    public static Attribute onseeking(string value) => new("onseeking", value);

    /// <summary>select event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onselect="{value}"</c></returns>
    public static Attribute onselect(string value) => new("onselect", value);

    /// <summary>slotchange event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onslotchange="{value}"</c></returns>
    public static Attribute onslotchange(string value) => new("onslotchange", value);

    /// <summary>stalled event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onstalled="{value}"</c></returns>
    public static Attribute onstalled(string value) => new("onstalled", value);

    /// <summary>storage event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onstorage="{value}"</c></returns>
    public static Attribute onstorage(string value) => new("onstorage", value);

    /// <summary>submit event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onsubmit="{value}"</c></returns>
    public static Attribute onsubmit(string value) => new("onsubmit", value);

    /// <summary>suspend event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onsuspend="{value}"</c></returns>
    public static Attribute onsuspend(string value) => new("onsuspend", value);

    /// <summary>timeupdate event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ontimeupdate="{value}"</c></returns>
    public static Attribute ontimeupdate(string value) => new("ontimeupdate", value);

    /// <summary>toggle event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>ontoggle="{value}"</c></returns>
    public static Attribute ontoggle(string value) => new("ontoggle", value);

    /// <summary>unhandledrejection event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onunhandledrejection="{value}"</c></returns>
    public static Attribute onunhandledrejection(string value) => new("onunhandledrejection", value);

    /// <summary>unload event handler for Window object.</summary>
    /// <remarks>Elements: <see cref="Elements.body(Content[])"/>.</remarks>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onunload="{value}"</c></returns>
    public static Attribute onunload(string value) => new("onunload", value);

    /// <summary>volumechange event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onvolumechange="{value}"</c></returns>
    public static Attribute onvolumechange(string value) => new("onvolumechange", value);

    /// <summary>waiting event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onwaiting="{value}"</c></returns>
    public static Attribute onwaiting(string value) => new("onwaiting", value);

    /// <summary>wheel event handler.</summary>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>onwheel="{value}"</c></returns>
    public static Attribute onwheel(string value) => new("onwheel", value);
}
