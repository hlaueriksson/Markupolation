using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

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
    public void A_null_value_is_bare_for_a_boolean_type_but_omitted_for_a_value_type()
    {
        // AttributeType carries whether the attribute is boolean, so the type-based constructor can
        // tell "boolean attribute, this is the default" (bare) apart from "value attribute, the
        // caller passed null" (omitted) - unlike the name-based constructor above, which has no
        // such metadata and always treats null as bare.
        var subject = new Attribute(AttributeType.required);
        subject.ToString().Should().Be("required");
        subject.Value.Should().Be("required");

        subject = new Attribute(AttributeType.href, null);
        subject.ToString().Should().BeEmpty();
        subject.Value.Should().BeNull();
    }

    [Test]
    public void explicit_operator_string()
    {
        var subject = new Attribute("href", "https://html.spec.whatwg.org/multipage/");
        var result = (string)subject;
        result.Should().Be(subject.ToString());
    }
}
