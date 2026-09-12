using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

public class ElementTests
{
    [Test]
    public void ToString_()
    {
        var subject = new Element(ElementType.a, false, href("https://html.spec.whatwg.org/multipage/"), "Read the HTML Living Standard");
        subject.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");

        subject = new Element("a", false, href("https://html.spec.whatwg.org/multipage/"), "Read the HTML Living Standard");
        subject.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");

        subject = new Element("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");
        subject.ToString().Should().Be("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");
    }

    [Test]
    public void implicit_operator_string()
    {
        var subject = new Element("<a href=\"https://html.spec.whatwg.org/multipage/\">Read the HTML Living Standard</a>");
        string result = subject;
        result.Should().Be(subject.ToString());
    }

    [Test]
    public void WriteTo_TextWriter()
    {
        var subject = html(body(div(class_("a"), p("one"), img(src("/x.png"))), footer("two")));

        var writer = new StringWriter();
        subject.WriteTo(writer);

        writer.ToString().Should().Be(subject.ToString());
        writer.ToString().Should().Be("<html><body><div class=\"a\"><p>one</p><img src=\"/x.png\" /></div><footer>two</footer></body></html>");
    }

    [Test]
    public void WriteTo_StringBuilder()
    {
        var subject = html(body(div(class_("a"), p("one"), img(src("/x.png"))), footer("two")));

        var builder = new StringBuilder();
        subject.WriteTo(builder);

        builder.ToString().Should().Be(subject.ToString());
    }

    [Test]
    public void WriteTo_raw_element()
    {
        var subject = new Element("<svg viewBox=\"0 0 1 1\"></svg>");

        var writer = new StringWriter();
        subject.WriteTo(writer);
        writer.ToString().Should().Be(subject.ToString());

        var builder = new StringBuilder();
        subject.WriteTo(builder);
        builder.ToString().Should().Be(subject.ToString());
    }

    [Test]
    public void WriteTo_null_is_ignored()
    {
        var subject = div("x");

        subject.Invoking(x => x.WriteTo((StringWriter)null)).Should().NotThrow();
        subject.Invoking(x => x.WriteTo((StringBuilder)null)).Should().NotThrow();
    }
}
