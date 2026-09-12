using e = Markupolation.Elements;
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

        // A string branch is the same, and value types do not help here.
        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : "not fizz")).ToString()
            .Should().Be("<li>not fizz</li><li>&lt;strong&gt;Fizz&lt;/strong&gt;</li>");
    }

    [Test]
    public void If_avoids_the_conditional_problem_entirely()
    {
        // If takes Content parameters, so each argument converts on its own and there is no
        // common type to infer: the element stays markup and the string is encoded as text.
        // This is the recommended form for a conditional that mixes elements and text.
        new[] { 1, 3 }.Each(i => li((i % 3 == 0).If(strong("Fizz"), "not fizz"))).ToString()
            .Should().Be("<li>not fizz</li><li><strong>Fizz</strong></li>");

        // The text branch is still encoded.
        li(false.If(strong("x"), "<script>")).ToString()
            .Should().Be("<li>&lt;script&gt;</li>");

        // The same holds for the rest of the If* family, which all take Content.
        li(3.IfMatch(x => x > 0, x => strong("Fizz"), x => (Content)"none")).ToString()
            .Should().Be("<li><strong>Fizz</strong></li>");
    }

    [Test]
    public void Script_and_style_content_is_not_encoded()
    {
        // script and style are "raw text" elements: the HTML parser does not decode character
        // references inside them, so encoding their content would break it. Content keeps the
        // text it was created from, and these two elements render that instead.
        e.style("a > b { color: red }").ToString()
            .Should().Be("<style>a > b { color: red }</style>");

        script("if (a < b && c) x();").ToString()
            .Should().Be("<script>if (a < b && c) x();</script>");

        // Also with attributes, where the body arrives through the params overload.
        script(type("module"), "if (a < b) x();").ToString()
            .Should().Be("<script type=\"module\">if (a < b) x();</script>");

        // Attribute values on those elements are still encoded - only the body is raw.
        script(src("/a.js?x=1&y=2")).ToString()
            .Should().Be("<script src=\"/a.js?x=1&amp;y=2\"></script>");

        // Content.Raw still works, and nested markup is unaffected.
        e.style(Content.Raw("a > b {}")).ToString().Should().Be("<style>a > b {}</style>");
    }
    [Test]
    public void Title_and_textarea_content_is_encoded_correctly()
    {
        // These are "escapable raw text": character references ARE decoded, so encoding is right.
        e.title("A > B").ToString().Should().Be("<title>A &gt; B</title>");
        textarea("A > B").ToString().Should().Be("<textarea>A &gt; B</textarea>");
    }

    [Test]
    public void Encoding_leaves_non_ascii_alone()
    {
        // WebUtility.HtmlEncode would turn these into numeric references (G&#246;teborg), which
        // is bigger and unreadable in a UTF-8 document. Only & < > " are encoded.
        div("Göteborg, naïve café, 日本語").ToString()
            .Should().Be("<div>Göteborg, naïve café, 日本語</div>");

        // Apostrophes are left alone too: attribute values are always double-quoted.
        div("it's").ToString().Should().Be("<div>it's</div>");
        a(href("/x?q=it's")).ToString().Should().Be("<a href=\"/x?q=it's\"></a>");
    }

    [Test]
    public void Text_behaves_exactly_like_converting_a_string()
    {
        // Content.Text documents itself as "the same as converting a string to Content", so the
        // two must agree everywhere - including inside a raw text element, where Content keeps
        // the original to render instead of the encoded form.
        div("a > b").ToString().Should().Be(div(Content.Text("a > b")).ToString());
        e.style("a > b").ToString().Should().Be(e.style(Content.Text("a > b")).ToString());

        div(Content.Text("a > b")).ToString().Should().Be("<div>a &gt; b</div>");
        e.style(Content.Text("a > b")).ToString().Should().Be("<style>a > b</style>");
    }

    [Test]
    public void Raw_is_markup_everywhere()
    {
        // Raw sets the value directly - the string already is the markup - so there is no
        // original text to fall back to and it renders the same in both places.
        div(Content.Raw("a > b")).ToString().Should().Be("<div>a > b</div>");
        e.style(Content.Raw("a > b")).ToString().Should().Be("<style>a > b</style>");
    }
}
