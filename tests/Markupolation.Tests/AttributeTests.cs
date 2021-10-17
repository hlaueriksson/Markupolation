using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class AttributeTests
    {
        [Test]
        public void ToString_()
        {
            var subject = new Attribute(AttributeType.href, "https://html.spec.whatwg.org/multipage/");
            subject.ToString().Should().Be("href=\"https://html.spec.whatwg.org/multipage/\"");

            subject = new Attribute(AttributeType.required);
            subject.ToString().Should().Be("required");

            subject = new Attribute("foo", "bar");
            subject.ToString().Should().Be("foo=\"bar\"");

            subject = new Attribute("foo");
            subject.ToString().Should().Be("foo");
        }

        [Test]
        public void implicit_operator_string()
        {
            var subject = new Attribute("href", "https://html.spec.whatwg.org/multipage/");
            string result = subject;
            result.Should().Be(subject.ToString());
        }
    }
}
