using System.Threading.Tasks;
using AngleSharp.Diffing;
using FluentAssertions;
using Markupolation.Converter;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using NUnit.Framework;

namespace Markupolation.Tests;

public class HtmlConverterTests
{
    private const string Usings = """
        using Markupolation;
        using static Markupolation.Elements;
        using static Markupolation.Attributes;
        using static Markupolation.EventHandlerContentAttributes;
        using static Markupolation.Contents;
        using e = Markupolation.Elements;
        using a = Markupolation.Attributes;
        using E = Markupolation.Element;
        using A = Markupolation.Attribute;
        """;

    // The converter emits Environment.NewLine; normalise so the expectations below can be
    // written as plain LF regardless of platform.
    private static string Convert(string html, ConvertOptions? options = null) =>
        HtmlConverter.Convert(html, options ?? new ConvertOptions()).ReplaceLineEndings("\n");

    // A multi-line raw string literal keeps the newlines of the source file itself, which is
    // CRLF when the repository is checked out with core.autocrlf=true, so the expectations
    // need the same normalisation as the actual value.
    private static string Normalize(string source) => source.ReplaceLineEndings("\n");

    [Test]
    public void Elements_attributes_and_text()
    {
        Convert("""<div class="card"><h1 title="t">Hello</h1></div>""")
            .Should().Be(Normalize("""
                div(class_("card"),
                    h1(a.title("t"), "Hello")
                )
                """));
    }

    [Test]
    public void Void_elements_and_boolean_attributes()
    {
        // Void-ness and boolean-ness come from the generated metadata, not a list here.
        Convert("""<p><img src="/x.png" alt="X"><input type="checkbox" checked></p>""")
            .Should().Be(Normalize("""
                p(
                    img(src("/x.png"), alt("X")),
                    input(type("checkbox"), checked_())
                )
                """));
    }

    [Test]
    public void Boolean_attribute_with_an_explicit_value_text_still_converts_to_the_no_arg_call()
    {
        // disabled="disabled" (rather than disabled="") used to convert to disabled("disabled"),
        // which does not compile - the generated method takes no arguments.
        Convert("""<input type="checkbox" disabled="disabled">""")
            .Should().Be(Normalize("""input(type("checkbox"), disabled())"""));
    }

    [Test]
    public void Ambiguous_names_are_qualified()
    {
        // title is both an element and an attribute; unqualified it resolves to the attribute,
        // so the element needs e. to compile.
        Convert("<html><head><title>T</title></head><body></body></html>")
            .Should().Contain("e.title(\"T\")");

        Convert("""<p title="t">x</p>""").Should().Be("""p(a.title("t"), "x")""");
    }

    [Test]
    public void Data_attributes_use_the_data_helper()
    {
        Convert("""<p data-foo="bar">x</p>""").Should().Be("""p(data("foo", "bar"), "x")""");
    }

    [Test]
    public void Off_spec_names_fall_back_to_the_escape_hatches()
    {
        Convert("""<div hx-get="/x"></div>""").Should().Be("""div(new A("hx-get", "/x"))""");
        Convert("""<my-widget a="1"></my-widget>""").Should().Contain("new E(");
    }

    [Test]
    public void Foreign_content_is_kept_verbatim()
    {
        Convert("""<p><svg viewBox="0 0 1 1"></svg></p>""")
            .Should().Contain("""new E(""" + "\"\"\"" + """<svg viewBox="0 0 1 1"></svg>""" + "\"\"\"" + ")");
    }

    [Test]
    public void A_whole_document_keeps_the_doctype()
    {
        Convert("""<!DOCTYPE html><html lang="en"><head></head><body><p>x</p></body></html>""")
            .Should().StartWith("DOCTYPE() +");
    }

    [Test]
    public void Fragment_and_document_can_be_forced()
    {
        Convert("<p>x</p>", new ConvertOptions { Fragment = false })
            .Should().StartWith("html(");

        Convert("<!DOCTYPE html><html><body><p>x</p></body></html>", new ConvertOptions { Fragment = true })
            .Should().Be("""p("x")""");
    }

    [Test]
    public void Indent_is_configurable()
    {
        Convert("<div><p>x</p></div>", new ConvertOptions { Indent = 2 })
            .Should().Be("div(\n  p(\"x\")\n)");
    }

    [Test]
    public void Siblings_are_concatenated()
    {
        Convert("<p>a</p><p>b</p>").Should().Be("p(\"a\") +\np(\"b\")");
    }

    // The real test: compile what the converter emitted, run it, and compare the markup it
    // produces with the markup that went in.
    [TestCase("""<div class="card"><h1 title="t">Hello</h1><p>Text &amp; more</p></div>""")]
    [TestCase("""<ul><li>1</li><li>2</li><li>3</li></ul>""")]
    [TestCase("""<form method="post" action="/save"><input type="checkbox" checked disabled><button type="submit">Go</button></form>""")]
    [TestCase("""<input type="checkbox" disabled="disabled">""")]
    [TestCase("""<p><img src="/x.png" alt="A &quot;quoted&quot; alt"><br></p>""")]
    [TestCase("""<div data-foo="bar" hx-get="/x"><span>y</span></div>""")]
    [TestCase("""<!DOCTYPE html><html lang="en"><head><meta charset="utf-8"><title>T</title></head><body><h1>Hi</h1></body></html>""")]
    [TestCase("""<table><thead><tr><th>A</th></tr></thead><tbody><tr><td>1</td></tr></tbody></table>""")]
    [TestCase("""<p>Göteborg, naïve café</p>""")]
    public async Task Round_trips_through_the_compiler(string html)
    {
        var source = Convert(html);
        var options = ScriptOptions.Default.AddReferences(typeof(Content).Assembly);

        var rendered = await CSharpScript.EvaluateAsync<string>(
            $"{Usings}\n(\n{source}\n).ToString()", options);

        DiffBuilder.Compare(html).WithTest(rendered).Build().Should().BeEmpty(
            $"the emitted source should render the same markup.\n--- source ---\n{source}\n--- rendered ---\n{rendered}");
    }
}
