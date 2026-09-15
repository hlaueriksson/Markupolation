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
        // help here - a space, /, > or = in the name has to not be there at all.
        data("foo bar", "value").ToString().Should().Be("data-foo_bar=\"value\"");
        data("foo=bar", "value").ToString().Should().Be("data-foo_bar=\"value\"");
        data("foo/bar", "value").ToString().Should().Be("data-foo_bar=\"value\"");
        data("foo>bar", "value").ToString().Should().Be("data-foo_bar=\"value\"");
        data("foo\tbar\r\n", "value").ToString().Should().Be("data-foo_bar__=\"value\"");
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
