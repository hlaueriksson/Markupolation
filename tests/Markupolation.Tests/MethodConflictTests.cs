using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class MethodConflictTests
    {
        [Test]
        public void Conflicts()
        {
            var elementValues = Enum.GetValues(typeof(ElementType)).Cast<ElementType>().Select(x => x.ToString());
            var attributeValues = Enum.GetValues(typeof(AttributeType)).Cast<AttributeType>().Select(x => x.ToString());
            var result = elementValues.Intersect(attributeValues);
            result.Should().BeEquivalentTo(new[] { "abbr", "cite", "data", "form", "label", "slot", "span", "style", "title" });
        }

        [Test]
        public void Conflicts_title()
        {
            var result = $"{title("Title")}";
            result.Should().Be("title=\"Title\"");

            result = $"{Markupolation.Attributes.title("Title")}";
            result.Should().Be("title=\"Title\"");

            result = $"{Markupolation.Elements.title("Title")}";
            result.Should().Be("<title>Title</title>");
        }
    }
}
