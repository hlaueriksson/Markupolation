using System;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using a = Markupolation.Attributes;
using e = Markupolation.Elements;

namespace Markupolation.Tests;

public class EncodingTests
{
    [Test]
    public void Comment_writes_a_comment()
    {
        comment("Add your site or application content here").ToString()
            .Should().Be("<!--Add your site or application content here-->");

        body(comment("content here"), p("Hello")).ToString()
            .Should().Be("<body><!--content here--><p>Hello</p></body>");

        // Empty is an empty comment, the way div(null) is an empty div.
        comment(null).ToString().Should().Be("<!---->");
        comment("").ToString().Should().Be("<!---->");
    }

    [Test]
    public void Comment_neutralises_what_would_end_it_early()
    {
        // Encoding cannot help here - the parser does not decode character references inside a
        // comment - so the sequences the spec forbids are broken up with a space instead. This is
        // what makes comment() safe for text that came from a user, where raw() is not.
        comment("a --> b").ToString().Should().Be("<!--a - -> b-->");
        comment("a <!-- b").ToString().Should().Be("<!--a <!- - b-->");
        comment("a --!> b").ToString().Should().Be("<!--a - -!> b-->");
        comment("---").ToString().Should().Be("<!--- - --->");

        // Must not start with > or ->, and must not end with <!-.
        comment(">x").ToString().Should().Be("<!-- >x-->");
        comment("->x").ToString().Should().Be("<!-- ->x-->");
        comment("a<!-").ToString().Should().Be("<!--a<!- -->");

        // A lone trailing dash is fine as it is; the parser gives it back.
        comment("x-").ToString().Should().Be("<!--x--->");
    }

    [TestCase("plain")]
    [TestCase("a --> b")]
    [TestCase("a <!-- b")]
    [TestCase("a --!> b")]
    [TestCase("---")]
    [TestCase(">x")]
    [TestCase("->x")]
    [TestCase("a<!-")]
    [TestCase("x-")]
    [TestCase("</script><img src=x onerror=alert(1)>")]
    public void Comment_stays_one_comment_through_a_real_parser(string text)
    {
        // The point of the neutralising: whatever the text, the document still has exactly one
        // comment node and nothing has escaped into the markup around it.
        var parser = new AngleSharp.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(body(comment(text), p("after")).ToString());

        var comments = document.Body!.ChildNodes
            .Where(x => x.NodeType == AngleSharp.Dom.NodeType.Comment).ToList();

        comments.Should().ContainSingle();
        document.Body.QuerySelectorAll("img").Should().BeEmpty();
        document.Body.QuerySelectorAll("p").Should().ContainSingle();
        document.Body.QuerySelector("p")!.TextContent.Should().Be("after");
    }

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

        // raw is the unqualified spelling, imported with a static using like the elements are.
        div(raw("<b>bold</b>")).ToString()
            .Should().Be("<div><b>bold</b></div>");

        // An HTML comment is the case that catches people out: it looks like text, but is markup.
        // comment() is the way to write one; raw is the escape hatch under it.
        body(raw("<!-- content here -->")).ToString()
            .Should().Be("<body><!-- content here --></body>");

        // The string constructors are raw too - that is how Element wraps markup verbatim.
        div(new Content("<b>bold</b>")).ToString()
            .Should().Be("<div><b>bold</b></div>");

        new Element("<svg viewBox=\"0 0 1 1\"></svg>").ToString()
            .Should().Be("<svg viewBox=\"0 0 1 1\"></svg>");
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
        // DOCTYPE() returns Content, not a string, so the doctype composes as markup instead of
        // being encoded as text by Content's + operator.
        (DOCTYPE() + html(body(h1("Hello, World!")))).ToString()
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
    public void A_ternary_mixing_elements_and_strings_keeps_the_element_raw()
    {
        // This used to collapse to string: Element converted to string implicitly and not the
        // reverse, so string was the conditional's natural type, and the rendered element was then
        // encoded as text. The conversion to string is explicit now, so the branches have no common
        // type, the conditional is target-typed to Content, and each branch converts on its own.
        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : i.ToString())).ToString()
            .Should().Be("<li>1</li><li><strong>Fizz</strong></li>");

        new[] { 1, 3 }.Each(i => li(i % 3 == 0 ? strong("Fizz") : "not fizz")).ToString()
            .Should().Be("<li>not fizz</li><li><strong>Fizz</strong></li>");

        // The text branch is still text, and is still encoded.
        li(false ? strong("Fizz") : "<script>").ToString().Should().Be("<li>&lt;script&gt;</li>");
    }

    [Test]
    public void If_reads_better_than_a_ternary()
    {
        // If takes Content parameters, so each argument converts on its own - the same outcome a
        // ternary now gives, in a shape that reads better inside a template.
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
    public void A_converted_string_keeps_its_original_for_a_raw_text_element()
    {
        // A string becomes Content as text, encoded lazily, and Content keeps the original - which
        // is what a raw text element renders instead of the encoded form.
        div((Content)"a > b").ToString().Should().Be("<div>a &gt; b</div>");
        e.style((Content)"a > b").ToString().Should().Be("<style>a > b</style>");

        // Spelling the conversion out changes nothing; it is the same conversion either way.
        div("a > b").ToString().Should().Be(div((Content)"a > b").ToString());
        e.style("a > b").ToString().Should().Be(e.style((Content)"a > b").ToString());

        // A null string is empty content, not a throw.
        string? none = null;
        div(none!).ToString().Should().Be("<div></div>");
        ((Content)"<b>").ToString().Should().Be("&lt;b&gt;");
    }

    [Test]
    public void Raw_is_markup_everywhere()
    {
        // Raw sets the value directly - the string already is the markup - so there is no
        // original text to fall back to and it renders the same in both places.
        div(Content.Raw("a > b")).ToString().Should().Be("<div>a > b</div>");
        e.style(Content.Raw("a > b")).ToString().Should().Be("<style>a > b</style>");
    }

    [Test]
    public void Concatenating_with_an_empty_seed_keeps_the_raw_text_fallback()
    {
        // Content.Raw(null) and Content.Empty are real Content instances, not a C# null, and are
        // in the "markup" state (Unencoded is null). Accumulating text onto one of them with +
        // used to fall through to the general concatenation branch - which discards Unencoded -
        // instead of being recognised as a no-op that should return the text side untouched.
        var accumulated = Content.Raw(null) + "a < b";
        e.style(accumulated).ToString().Should().Be("<style>a < b</style>");

        accumulated = Content.Empty + "a < b";
        e.style(accumulated).ToString().Should().Be("<style>a < b</style>");

        // The same has to hold building up incrementally with +=, and regardless of which side is
        // empty.
        Content acc = Content.Raw(null);
        acc += "a < b";
        e.style(acc).ToString().Should().Be("<style>a < b</style>");

        accumulated = "a < b" + Content.Raw(null);
        e.style(accumulated).ToString().Should().Be("<style>a < b</style>");

        // Outside a raw text element this was never observable - Value was already correct either
        // way - so pin that too.
        div(Content.Raw(null) + "a < b").ToString().Should().Be("<div>a &lt; b</div>");
    }

    [Test]
    public void Value_types_that_would_otherwise_widen_to_the_wrong_conversion()
    {
        // Each of these three has to be declared explicitly. Without it the value widens to
        // another conversion and renders wrong - or does not compile at all.
        div('a').ToString().Should().Be("<div>a</div>", "a char would widen to int and render 97");
        div(0.1f).ToString().Should().Be("<div>" + 0.1f.ToString(CultureInfo.InvariantCulture) + "</div>",
            "a float would widen to double and render its binary artefacts");
        div(ulong.MaxValue).ToString().Should().Be("<div>18446744073709551615</div>",
            "a ulong would be ambiguous between the double and decimal conversions");

        Content fromChar = 'a';
        Content fromFloat = 0.1f;
        Content fromULong = ulong.MaxValue;
        fromChar.ToString().Should().Be("a");
        fromFloat.ToString().Should().Be(0.1f.ToString(CultureInfo.InvariantCulture));
        fromULong.ToString().Should().Be("18446744073709551615");
    }

    [Test]
    public void Smaller_integer_types_convert()
    {
        // Each integer type is declared: once ulong exists, int and ulong are incomparable and
        // the smaller types have no unique conversion to widen through.
        Content fromShort = (short)-5;
        Content fromByte = (byte)5;
        Content fromUInt = uint.MaxValue;

        fromShort.ToString().Should().Be("-5");
        fromByte.ToString().Should().Be("5");
        fromUInt.ToString().Should().Be("4294967295");
    }

    [Test]
    public void Other_value_types_convert()
    {
        Content fromBool = true;
        Content fromGuid = Guid.Empty;
        Content fromTimeSpan = TimeSpan.FromMinutes(90);
        Content fromEnum = StringComparison.Ordinal;
        Content fromOffset = new DateTimeOffset(2026, 9, 12, 0, 0, 0, TimeSpan.Zero);

        // Lowercase, because anything that reads the value back as a string compares against
        // "true" - dataset.x === "true", htmx, Alpine. bool.ToString() would say "True".
        fromBool.ToString().Should().Be("true");
        fromGuid.ToString().Should().Be("00000000-0000-0000-0000-000000000000");
        fromTimeSpan.ToString().Should().Be("01:30:00");
        fromEnum.ToString().Should().Be("Ordinal");
        fromOffset.ToString().Should().Be("2026-09-12T00:00:00+00:00");
    }

    [Test]
    public void Dates_render_as_ISO_8601()
    {
        // HTML's date and time attributes are defined in terms of ISO 8601, so that is what a
        // DateTime renders as - an invariant ToString() would give 09/15/2026 13:45:00, which
        // <time datetime> does not accept. Nor the round-trip "O" format: its seven fractional
        // digits exceed the three HTML allows.
        Content date = new DateTime(2026, 9, 15, 13, 45, 0);
        date.ToString().Should().Be("2026-09-15T13:45:00");

        Content offset = new DateTimeOffset(2026, 9, 15, 13, 45, 0, TimeSpan.FromHours(2));
        offset.ToString().Should().Be("2026-09-15T13:45:00+02:00");

        e.time(datetime(new DateTime(2026, 9, 15)), "Sep 15").ToString()
            .Should().Be("<time datetime=\"2026-09-15T00:00:00\">Sep 15</time>");
    }

    [Test]
    public void A_bool_renders_the_same_through_every_path()
    {
        // The implicit conversion, the generated object overload and an interpolation hole are the
        // same thing to whoever writes them, so they have to agree.
        Content converted = true;
        converted.ToString().Should().Be("true");
        div(contenteditable(true)).ToString().Should().Be("<div contenteditable=\"true\"></div>");
        div($"{true}").ToString().Should().Be("<div>true</div>");

        // data is one of the nine names that are both an element and an attribute, so a non-string
        // value needs the a. alias - unqualified it is now CS0121 rather than silently binding to
        // Elements.data(params Content[]) and rendering <data>onTrue</data>.
        a.data("on", true).ToString().Should().Be("data-on=\"true\"");
    }

    [Test]
    public void Conversions_are_culture_invariant()
    {
        // A server running under a comma-decimal culture must not change what gets rendered -
        // otherwise a numeric HTML attribute or embedded JSON silently breaks depending on where
        // the process happens to be deployed.
        var original = CultureInfo.CurrentCulture;

        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");

            Content fromDouble = 3.14;
            Content fromDecimal = 3.14m;
            Content fromFloat = 3.14f;
            Content fromDate = new DateTime(2026, 9, 15);
            Content interpolated = $"{3.14}";

            fromDouble.ToString().Should().Be("3.14");
            fromDecimal.ToString().Should().Be("3.14");
            fromFloat.ToString().Should().Be("3.14");
            fromDate.ToString().Should().NotContain(",");
            interpolated.ToString().Should().Be("3.14");
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }

    [Test]
    public void Conversions_keep_elements_raw_in_a_conditional()
    {
        // The point of these conversions: the conditional has no natural type, so it is
        // target-typed to Content and the element branch stays markup.
        li(true ? strong("Fizz") : StringComparison.Ordinal).ToString()
            .Should().Be("<li><strong>Fizz</strong></li>");
        li(false ? strong("Fizz") : StringComparison.Ordinal).ToString()
            .Should().Be("<li>Ordinal</li>");

        li(true ? strong("Fizz") : 'x').ToString().Should().Be("<li><strong>Fizz</strong></li>");
        li(false ? strong("Fizz") : 'x').ToString().Should().Be("<li>x</li>");
    }

    [Test]
    public void Nullable_value_types_convert()
    {
        // The conversion lookup uses the underlying type, so int? reaches operator Content(int).
        // The compiler emits the HasValue check, so a null yields null content rather than throwing.
        int? some = 5;
        int? none = null;

        Content fromSome = some;
        Content fromNone = none!;

        fromSome.ToString().Should().Be("5");
        div(fromSome).ToString().Should().Be("<div>5</div>");
        (fromNone is null).Should().BeTrue("a null nullable converts to null content, it does not throw");
        div(none).ToString().Should().Be("<div></div>");

        // And in a conditional, which is what the conversions exist for.
        li(true ? strong("Fizz") : some).ToString().Should().Be("<li><strong>Fizz</strong></li>");
        li(false ? strong("Fizz") : some).ToString().Should().Be("<li>5</li>");
        li(false ? strong("Fizz") : none).ToString().Should().Be("<li></li>");
    }
}
