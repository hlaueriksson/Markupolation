using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

public class ElementsTests
{
    [Test]
    public void NormalElement()
    {
        var result = a(href("https://html.spec.whatwg.org/multipage/"), "Read the HTML Living Standard");
        result.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");

        result = a(href("https://html.spec.whatwg.org/multipage/"), $"Read the {b($"HTML {i("Living")}")} Standard");
        result.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the <b>HTML <i>Living</i></b> Standard</a>");
    }

    [Test]
    public void VoidElement()
    {
        // crossorigin is not a boolean attribute, so a null value omits it entirely rather than
        // rendering it bare - required() below is the boolean case, unaffected by that.
        var result = img(id("main-logo"), crossorigin(null!), src("https://resources.whatwg.org/logo.svg"));
        result.ToString().Should().Be("<img id=\"main-logo\" src=\"https://resources.whatwg.org/logo.svg\" />");

        result = img(id("main-logo"), crossorigin(null!), src("https://resources.whatwg.org/logo.svg"), "Child");
        result.ToString().Should().Be("<img id=\"main-logo\" src=\"https://resources.whatwg.org/logo.svg\" />");

        result = img(id("main-logo"), ismap(), src("https://resources.whatwg.org/logo.svg"));
        result.ToString().Should().Be("<img id=\"main-logo\" ismap src=\"https://resources.whatwg.org/logo.svg\" />");
    }

    [Test]
    public void Element_()
    {
        base_().ToString().Should().Be("<base />");
        object_().ToString().Should().Be("<object></object>");
    }

    [Test]
    public void ObjectArgument()
    {
        a(1).ToString().Should().Be("<a>1</a>");
        a((int?)null!).ToString().Should().Be("<a></a>");
    }

    [Test]
    public void Duplicate_attributes_keep_only_the_first_occurrence()
    {
        // Matches how a browser resolves a duplicate attribute during HTML parsing - the first one
        // wins and later ones are dropped, rather than both rendering (which nothing would parse
        // back the same way) or the last one silently overriding the first.
        div(class_("a"), class_("b")).ToString().Should().Be("<div class=\"a\"></div>");

        // Holds across a mix of the generated, type-based attribute and the raw, name-based one.
        div(class_("a"), new Attribute("class", "b")).ToString().Should().Be("<div class=\"a\"></div>");
        div(new Attribute("class", "a"), class_("b")).ToString().Should().Be("<div class=\"a\"></div>");

        // Non-duplicates around it are unaffected.
        div(id("x"), class_("a"), class_("b"), title("t")).ToString()
            .Should().Be("<div id=\"x\" class=\"a\" title=\"t\"></div>");
    }
}
