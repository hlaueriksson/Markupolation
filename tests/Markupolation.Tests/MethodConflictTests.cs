using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

public class MethodConflictTests
{
    [Test]
    public void Conflicts()
    {
        var elementValues = Enum.GetValues(typeof(ElementType)).Cast<ElementType>().Select(x => x.ToString());
        var attributeValues = Enum.GetValues(typeof(AttributeType)).Cast<AttributeType>().Select(x => x.ToString());
        var result = elementValues.Intersect(attributeValues);
        result.Should().BeEquivalentTo(["abbr", "cite", "data", "form", "label", "slot", "span", "style", "title"]);
    }

    [Test]
    public void Contents_does_not_collide_with_the_specification()
    {
        // Contents is hand-written, but it arrives unqualified through a static using just like the
        // generated elements and attributes do - so a shared name merges into one candidate set and
        // changes what an unqualified call binds to. Ordinal, because that is what C# overload
        // resolution uses. If the specification ever adds <comment> or a raw attribute, this is
        // where it has to surface: fail here, then decide, rather than find out from a consumer.
        var contents = typeof(Contents)
            .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(x => x.Name)
            .ToList();

        // Pinned, so that adding a member brings you through this test - and this question.
        contents.Should().BeEquivalentTo(["DOCTYPE", "comment", "raw"]);

        foreach (var type in new[] { typeof(ElementType), typeof(AttributeType), typeof(EventHandlerContentAttributeType) })
        {
            contents.Intersect(Enum.GetNames(type), StringComparer.Ordinal)
                .Should().BeEmpty($"a Contents member may not share a name with a {type.Name}");
        }
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
