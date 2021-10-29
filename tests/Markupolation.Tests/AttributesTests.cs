using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
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
            var result = crossorigin(null!);
            result.ToString().Should().Be("crossorigin");

            result = crossorigin("");
            result.ToString().Should().Be("crossorigin=\"\"");

            result = required();
            result.ToString().Should().Be("required");
        }

        [Test]
        public void Data()
        {
            data("value").ToString().Should().Be("data=\"value\"");
            data("foo", "value").ToString().Should().Be("data-foo=\"value\"");
            data("foo-bar", "value").ToString().Should().Be("data-foo-bar=\"value\"");
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
            accept((int?)null!).ToString().Should().Be("accept");
        }
    }
}
