using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class ElementTests
    {
        [Test]
        public void implicit_operator_string()
        {
            var subject = new Element("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");
            string result = subject;
            result.Should().Be(subject.ToString());
        }
    }
}
