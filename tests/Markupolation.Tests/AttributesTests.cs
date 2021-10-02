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
        public void BooleanElement()
        {
            var result = crossorigin(null);
            result.ToString().Should().Be("crossorigin");

            result = crossorigin("");
            result.ToString().Should().Be("crossorigin=\"\"");

            result = required();
            result.ToString().Should().Be("required");
        }
    }
}
