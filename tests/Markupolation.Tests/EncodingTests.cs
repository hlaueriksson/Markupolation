using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

public class EncodingTests
{
    [Test]
    public void Text_is_encoded()
    {
        var name = "<script>alert('xss')</script>";

        div(name).ToString()
            .Should().Be("<div>&lt;script&gt;alert('xss')&lt;/script&gt;</div>");
    }

    [Test]
    public void Attribute_values_are_encoded()
    {
        // A quote in an attribute value used to break out of the attribute entirely.
        a(href("/search?q=\" onmouseover=\"alert(1)")).ToString()
            .Should().Be("<a href=\"/search?q=&quot; onmouseover=&quot;alert(1)\"></a>");

        // An unencoded & in a URL is also invalid HTML.
        a(href("/x?a=1&b=2")).ToString()
            .Should().Be("<a href=\"/x?a=1&amp;b=2\"></a>");
    }

    [Test]
    public void Boolean_attributes_are_unaffected()
    {
        input(type("checkbox"), checked_(), disabled()).ToString()
            .Should().Be("<input type=\"checkbox\" checked disabled />");
    }

    [Test]
    public void Raw_opts_out_of_encoding()
    {
        div(Content.Raw("<b>bold</b>")).ToString()
            .Should().Be("<div><b>bold</b></div>");

        // The string constructors are raw too - that is how Element wraps markup verbatim.
        div(new Content("<b>bold</b>")).ToString()
            .Should().Be("<div><b>bold</b></div>");

        new Element("<svg viewBox=\"0 0 1 1\"></svg>").ToString()
            .Should().Be("<svg viewBox=\"0 0 1 1\"></svg>");
    }

    [Test]
    public void Text_encodes_explicitly()
    {
        Content.Text("<b>").ToString().Should().Be("&lt;b&gt;");
        Content.Text(null).ToString().Should().BeEmpty();
    }

    [Test]
    public void Encoding_leaves_ordinary_text_untouched()
    {
        // The common case must not allocate a new string; it also must not change.
        const string Ordinary = "Hello, World! It's 100% fine (really).";

        div(Ordinary).ToString().Should().Be("<div>" + Ordinary + "</div>");
    }

    [Test]
    public void Interpolation_keeps_literals_raw_and_encodes_holes()
    {
        var name = "<script>";

        // The literal <i> is written by the author and stays markup; the hole is encoded.
        div($"<i>{name}</i>").ToString()
            .Should().Be("<div><i>&lt;script&gt;</i></div>");
    }

    [Test]
    public void Interpolation_keeps_elements_and_attributes_raw()
    {
        div($"see {b("bold")} here").ToString()
            .Should().Be("<div>see <b>bold</b> here</div>");

        // The README's nested interpolation still works.
        p($"Read the {b($"HTML {i("Living")}")} Standard").ToString()
            .Should().Be("<p>Read the <b>HTML <i>Living</i></b> Standard</p>");
    }

    [Test]
    public void Interpolation_works_alongside_other_content()
    {
        var name = "<script>";

        div(class_("x"), $"hi {name}").ToString()
            .Should().Be("<div class=\"x\">hi &lt;script&gt;</div>");
    }

    [Test]
    public void Interpolation_supports_format_specifiers()
    {
        div($"{42:D4}").ToString().Should().Be("<div>0042</div>");
    }

    [Test]
    public void A_string_built_first_is_encoded_whole()
    {
        // The one breaking case: build the markup into a string and the library can no longer
        // tell which parts are author-written. Content.Raw is the opt-out.
        var name = "<script>";
        var markup = $"<i>{name}</i>";

        div(markup).ToString()
            .Should().Be("<div>&lt;i&gt;&lt;script&gt;&lt;/i&gt;</div>");

        div(Content.Raw(markup)).ToString()
            .Should().Be("<div><i><script></i></div>");
    }

    [Test]
    public void Document_composition_stays_raw()
    {
        // DOCTYPE() + element uses built-in string concatenation, which must not be encoded.
        (DOCTYPE() + html(body(h1("Hello, World!"))))
            .Should().Be("<!DOCTYPE html><html><body><h1>Hello, World!</h1></body></html>");
    }

    [Test]
    public void Each_output_is_not_double_encoded()
    {
        var items = new[] { "<a>", "<b>" };

        items.Each(x => li(x)).ToString()
            .Should().Be("<li>&lt;a&gt;</li><li>&lt;b&gt;</li>");
    }

    [Test]
    public void Value_types_convert_to_content_directly()
    {
        div(42).ToString().Should().Be("<div>42</div>");
        div(42L).ToString().Should().Be("<div>42</div>");

        Content fromInt = 7;
        fromInt.ToString().Should().Be("7");
    }

    [Test]
    public void A_ternary_mixing_elements_and_values_keeps_the_elements_raw()
    {
        // int converts to Content directly, so this conditional has no natural type and is
        // target-typed to Content: the element branch stays markup. Without that conversion the
        // conditional would fall back to object, the element would be rendered to a string and
        // then encoded as text.
        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : i)).ToString()
            .Should().Be("<li>1</li><li><strong>Fizz</strong></li>");
    }

    [Test]
    public void A_ternary_mixing_elements_and_strings_collapses_to_string()
    {
        // The remaining sharp edge. When a branch is a string, the conditional takes string as
        // its natural type - because Element converts to string and not the reverse - so the
        // element is rendered and then encoded as text. Nothing warns about it.
        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : i.ToString())).ToString()
            .Should().Be("<li>1</li><li>&lt;strong&gt;Fizz&lt;/strong&gt;</li>");

        // Fix: drop the ToString(), or make the other branch Content.
        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : i)).ToString()
            .Should().Be("<li>1</li><li><strong>Fizz</strong></li>");
        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : (Content)i.ToString())).ToString()
            .Should().Be("<li>1</li><li><strong>Fizz</strong></li>");
    }
}
