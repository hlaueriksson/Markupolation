using e = Markupolation.Elements;
using FluentAssertions;
using NUnit.Framework;
using static Markupolation.Htmx;

namespace Markupolation.Tests;

/// <summary>
/// Several sibling nodes without a wrapper element.
/// </summary>
/// <remarks>
/// <para>
/// <c>element + element</c> is the obvious way to write this, and it is what you should write.
/// <see cref="Content"/> declares <c>operator +</c>, which concatenates each side's rendered value,
/// so the result is <see cref="Content"/> and every operand keeps its own rule: an element is
/// already markup and stays raw, a <see cref="string"/> is text and is encoded.
/// </para>
/// <para>
/// It used to be a trap. Without a user-defined <c>+</c> the expression fell through to predefined
/// <c>string</c> concatenation, and the resulting string was encoded as text the moment it reached
/// a <see cref="Content"/> position - so the fragment only survived where it stayed a string all
/// the way out to the caller. These tests pin that it no longer does.
/// </para>
/// </remarks>
public class FragmentTests
{
    private static readonly Item[] Items = [new("T1", "B1"), new("T2", "B2")];

    // A component returning two siblings, written the way you reach for first.
    private static Content Card(Item x) => h3(x.Title) + p(x.Body);

    // ------------------------------------------------------------- where the + lands ----------

    [Test]
    public void Nested_in_an_element()
    {
        div(h1("a") + p("b")).ToString()
            .Should().Be("<div><h1>a</h1><p>b</p></div>");
    }

    [Test]
    public void A_component_used_through_Each()
    {
        Items.Each(Card).ToString()
            .Should().Be("<h3>T1</h3><p>B1</p><h3>T2</h3><p>B2</p>");
    }

    [Test]
    public void Passed_to_If()
    {
        li(true.If(h1("a") + p("b"))).ToString()
            .Should().Be("<li><h1>a</h1><p>b</p></li>");
    }

    [Test]
    public void At_the_top_level()
    {
        (h1("a") + p("b")).ToString().Should().Be("<h1>a</h1><p>b</p>");
    }

    [Test]
    public void With_an_explicit_content_array()
    {
        div(new Content[] { h1("a"), p("b") }).ToString()
            .Should().Be("<div><h1>a</h1><p>b</p></div>");
    }

    // ------------------------------------------------- the three examples, as they stand -------

    [Test]
    public void Cards_a_component_returning_two_siblings()
    {
        div(class_("cards"), Items.Each(Card)).ToString()
            .Should().Be("<div class=\"cards\">"
                + "<h3>T1</h3><p>B1</p>"
                + "<h3>T2</h3><p>B2</p>"
                + "</div>");
    }

    [Test]
    public void Two_links_behind_one_condition()
    {
        var loggedIn = true;

        loggedIn.If(a(href("/profile"), "Profile") + a(href("/logout"), "Log out")).ToString()
            .Should().Be("<a href=\"/profile\">Profile</a><a href=\"/logout\">Log out</a>");

        false.If(a(href("/profile"), "Profile")).ToString().Should().BeEmpty();
    }

    [Test]
    public void An_htmx_out_of_band_response()
    {
        var html = div(id("result"), "one")
            + div(id("count"), hx_swap_oob("true"), "two");

        html.ToString().Should().Be("<div id=\"result\">one</div><div id=\"count\" hx-swap-oob=\"true\">two</div>");

        // ...and it survives being nested in anything, which is the whole point.
        div(html).ToString().Should().Be("<div>"
            + "<div id=\"result\">one</div>"
            + "<div id=\"count\" hx-swap-oob=\"true\">two</div>"
            + "</div>");
    }

    // ------------------------------------------------------------------- what + means ---------

    [Test]
    public void A_string_operand_is_text()
    {
        // A string is text everywhere, + included. Content.Raw is the single opt-out.
        ("<b>" + p("x")).ToString().Should().Be("&lt;b&gt;<p>x</p>");
        (Content.Raw("<b>") + p("x")).ToString().Should().Be("<b><p>x</p>");
    }

    [Test]
    public void Chaining_and_null_operands()
    {
        (h1("a") + p("b") + e.span("c")).ToString().Should().Be("<h1>a</h1><p>b</p><span>c</span>");

        ((Content?)null + p("x")).ToString().Should().Be("<p>x</p>");
        (p("x") + (Content?)null).ToString().Should().Be("<p>x</p>");
        ((Content?)null + (Content?)null).ToString().Should().BeEmpty();
    }

    [Test]
    public void Content_accumulates()
    {
        // += on a Content is what replaces accumulating markup in a string.
        var list = Content.Raw(null);

        foreach (var i in new[] { 1, 2 })
        {
            list += li(i);
        }

        ul(list).ToString().Should().Be("<ul><li>1</li><li>2</li></ul>");
    }

    [Test]
    public void Concatenated_text_still_falls_back_in_a_raw_text_element()
    {
        // Both sides are still text, so script and style get the original to render.
        script(Content.Text("if (a < b") + Content.Text(" && c) x();")).ToString()
            .Should().Be("<script>if (a < b && c) x();</script>");

        div(Content.Text("if (a < b") + Content.Text(" && c) x();")).ToString()
            .Should().Be("<div>if (a &lt; b &amp;&amp; c) x();</div>");
    }

    private sealed record Item(string Title, string Body);
}
