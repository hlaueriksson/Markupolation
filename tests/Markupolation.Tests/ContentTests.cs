using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class ContentTests
    {
        [Test]
        public void implicit_operator_string()
        {
            var subject = new Content("Child");
            string result = subject;
            result.Should().Be(subject.ToString());
        }

        [Test]
        public void implicit_operator_Content()
        {
            var subject = "Child";
            Content result = subject;
            result.ToString().Should().Be(subject);
        }
    }
}
