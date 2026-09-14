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
    public void Empty_is_one_shared_instance()
    {
        Content.Empty.ToString().Should().BeEmpty();
        div(Content.Empty).ToString().Should().Be("<div></div>");

        // The If* family hands this back for the branch it does not take, rather than allocating a
        // new piece of empty content on every call.
        false.If(p("x")).Should().BeSameAs(Content.Empty);
        true.If(p("x"), p("y")).Should().NotBeSameAs(Content.Empty);

        // Null tolerance goes through the same instance.
        "x".IfNull((Content)null!).Should().BeSameAs(Content.Empty);
    }

    [Test]
    public void implicit_operator_Content()
    {
        var subject = "Child";
        Content result = subject;
        result.ToString().Should().Be(subject);
    }
}
