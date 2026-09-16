using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

public class AttributesTests
{
    [Test]
    public void NormalAttribute()
    {
        var result = href("https://html.spec.whatwg.org/multipage/");
        result.ToString().Should().Be("href=\"https://html.spec.whatwg.org/multipage/\"");
    }

    [Test]
    public void BooleanAttribute()
    {
        var result = crossorigin("");
        result.ToString().Should().Be("crossorigin=\"\"");

        result = required();
        result.ToString().Should().Be("required");
    }

    [Test]
    public void A_null_value_omits_a_non_boolean_attribute_entirely()
    {
        // crossorigin is not boolean - it takes real values like "anonymous" - so unlike a boolean
        // attribute's own null default, a null passed in here (typically from a nullable property)
        // omits the attribute rather than rendering it bare.
        crossorigin(null!).ToString().Should().BeEmpty();
        a(crossorigin(null!), href("#")).ToString().Should().Be("<a href=\"#\"></a>");
    }

    [Test]
    public void Attributes_whose_specification_allows_the_empty_string_are_written_bare()
    {
        // These are not boolean attributes - they are enumerated, and the specification lists the
        // empty string among their values, which is the same as writing them bare once parsed.
        p(hidden(), "This paragraph should be hidden.").ToString()
            .Should().Be("<p hidden>This paragraph should be hidden.</p>");

        div(contenteditable()).ToString().Should().Be("<div contenteditable></div>");
        div(spellcheck()).ToString().Should().Be("<div spellcheck></div>");
        div(translate()).ToString().Should().Be("<div translate></div>");
        div(popover()).ToString().Should().Be("<div popover></div>");
        img(crossorigin(), src("/x.png")).ToString().Should().Be("<img crossorigin src=\"/x.png\" />");
    }

    [Test]
    public void The_bare_spelling_does_not_replace_the_other_states()
    {
        // The whole reason these are not marked as boolean attributes: a boolean attribute is true
        // whatever its value, while these have real values that mean something else.
        div(hidden("until-found")).ToString().Should().Be("<div hidden=\"until-found\"></div>");
        div(contenteditable("false")).ToString().Should().Be("<div contenteditable=\"false\"></div>");
        div(contenteditable(false)).ToString().Should().Be("<div contenteditable=\"false\"></div>");

        // And null still means "I have nothing to say", so it omits rather than turning into the
        // bare form - otherwise a nullable property could hide content by accident.
        div(hidden(null!), id("x")).ToString().Should().Be("<div id=\"x\"></div>");
    }

    [Test]
    public void Data()
    {
        data("value").ToString().Should().Be("data=\"value\"");
        data("foo", "value").ToString().Should().Be("data-foo=\"value\"");
        data("foo-bar", "value").ToString().Should().Be("data-foo-bar=\"value\"");
    }

    [Test]
    public void Data_neutralises_a_dynamic_name_that_would_otherwise_break_out_of_the_tag()
    {
        // The name is never quoted, so encoding & < > " (as HtmlEncoder does for a value) would not
        // help here - a space, /, > or = in the name has to not be there at all. What it becomes is
        // -, the separator a data-* name is spelled with, so what renders is the name the caller
        // meant: data("foo bar", "value") and data("foo-bar", "value") are the same attribute, and
        // JavaScript reads it as dataset.fooBar rather than dataset.foo_bar.
        data("foo bar", "value").ToString().Should().Be("data-foo-bar=\"value\"");
        data("foo=bar", "value").ToString().Should().Be("data-foo-bar=\"value\"");
        data("foo/bar", "value").ToString().Should().Be("data-foo-bar=\"value\"");
        data("foo>bar", "value").ToString().Should().Be("data-foo-bar=\"value\"");
        data("foo\fbar", "value").ToString().Should().Be("data-foo-bar=\"value\"");

        // A run collapses into one separator and a run at either end is dropped, so sloppy input
        // still spells the name a dataset reader expects instead of data-foo-bar-- .
        data("foo\tbar\r\n", "value").ToString().Should().Be("data-foo-bar=\"value\"");
        data("foo  bar ", "value").ToString().Should().Be("data-foo-bar=\"value\"");
        data(" foo", "value").ToString().Should().Be("data-foo=\"value\"");

        // Only the replacements are normalised - a - the caller wrote is left exactly where it is,
        // so this keeps both rather than quietly merging them.
        data("foo- bar", "value").ToString().Should().Be("data-foo--bar=\"value\"");

        // And the point of all of it, in the place it matters: inside the tag, where the space
        // would have started a second attribute and the > would have closed the tag early.
        div(data("foo bar", "x")).ToString().Should().Be("<div data-foo-bar=\"x\"></div>");
        div(data("foo>bar", "x")).ToString().Should().Be("<div data-foo-bar=\"x\"></div>");
    }

    [Test]
    public void Data_is_null_tolerant_about_its_name()
    {
        // Null tolerant rather than throwing, like the rest of the library: there is no attribute
        // to build without a name, so nothing renders - not a nameless data- in the tag.
        data(null!, "value").ToString().Should().BeEmpty();
        div(data(null!, "value"), id("x")).ToString().Should().Be("<div id=\"x\"></div>");

        // An empty name is the same "no name" case. data-="value" is not a custom data attribute
        // (the specification wants at least one character after the dash) and dataset would not
        // expose it, so it does not render either.
        div(data("", "value"), id("x")).ToString().Should().Be("<div id=\"x\"></div>");

        // And so is a name that sanitising empties out, which is why the name is tested after the
        // replacement and not before - otherwise this would reach the tag as data-="value".
        div(data("   ", "value"), id("x")).ToString().Should().Be("<div id=\"x\"></div>");
        div(Attributes.data(" > ", true), id("x")).ToString().Should().Be("<div id=\"x\"></div>");

        // And it does not fall back to the data attribute, which is a different thing entirely -
        // object's resource URL. That one is spelled data("value").
        data("value").ToString().Should().Be("data=\"value\"");

        // Same for the raw constructor, which used to concatenate a null name into ="value".
        div(new Attribute(null!, "value"), id("x")).ToString().Should().Be("<div id=\"x\"></div>");
    }

    [Test]
    public void Attribute_()
    {
        as_("value").ToString().Should().Be("as=\"value\"");
        checked_().ToString().Should().Be("checked");
        class_("value").ToString().Should().Be("class=\"value\"");
        default_().ToString().Should().Be("default");
        for_("value").ToString().Should().Be("for=\"value\"");
        is_("value").ToString().Should().Be("is=\"value\"");
        readonly_().ToString().Should().Be("readonly");

        accept_charset("value").ToString().Should().Be("accept-charset=\"value\"");
        http_equiv("value").ToString().Should().Be("http-equiv=\"value\"");
    }

    [Test]
    public void ObjectArgument()
    {
        accept(1).ToString().Should().Be("accept=\"1\"");
        accept((int?)null!).ToString().Should().BeEmpty();
    }
}
