using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

public class ContentTests
{
    [Test]
    public void explicit_operator_string()
    {
        // Explicit on purpose: markup leaving Content for a string is a deliberate step, because a
        // string that comes back is text and is encoded.
        var subject = new Content("Child");
        var result = (string)subject;
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
