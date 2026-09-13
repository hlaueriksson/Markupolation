using FluentAssertions;
using NUnit.Framework;
using static Markupolation.Htmx;

namespace Markupolation.Tests;

/// <summary>
/// Several sibling nodes without a wrapper element.
/// </summary>
/// <remarks>
/// <para>
/// <c>element + element</c> is the obvious way to write this, and it is a trap: the <c>+</c> is
/// <see cref="string"/> concatenation (via the implicit conversion on <see cref="Content"/>), so
/// the result is a <see cref="string"/>, and the moment that string flows back into a
/// <see cref="Content"/> position it is encoded as text. It only survives where it stays a string
/// all the way out to the caller.
/// </para>
/// <para>
/// These tests pin what happens today, broken cases included. <c>Content.Raw</c> is the workaround;
/// a <c>Fragment(params Content[])</c> helper would be the ergonomic version of it.
/// </para>
/// </remarks>
public class FragmentTests
{
    private static readonly Item[] Items = [new("T1", "B1"), new("T2", "B2")];

    // A component returning two siblings, written the way you reach for first.
    private static Content Card(Item x) => (Content)(h3(x.Title) + p(x.Body));

    // The same component, saying explicitly that the string is already markup.
    private static Content CardRaw(Item x) => Content.Raw(h3(x.Title) + p(x.Body));

    // ------------------------------------------------------------- where the + lands ----------

    [Test]
    public void Broken_1_nested_in_an_element()
    {
        div(h1("a") + p("b")).ToString()
            .Should().Be("<div>&lt;h1&gt;a&lt;/h1&gt;&lt;p&gt;b&lt;/p&gt;</div>");
    }

    [Test]
    public void Broken_2_a_component_used_through_Each()
    {
        Items.Each(Card).ToString()
            .Should().Be("&lt;h3&gt;T1&lt;/h3&gt;&lt;p&gt;B1&lt;/p&gt;&lt;h3&gt;T2&lt;/h3&gt;&lt;p&gt;B2&lt;/p&gt;");
    }

    [Test]
    public void Broken_3_passed_to_If()
    {
        li(true.If(h1("a") + p("b"))).ToString()
            .Should().Be("<li>&lt;h1&gt;a&lt;/h1&gt;&lt;p&gt;b&lt;/p&gt;</li>");
    }

    [Test]
    public void Works_4_at_the_top_level_where_it_stays_a_string()
    {
        (h1("a") + p("b")).Should().Be("<h1>a</h1><p>b</p>");
    }

    [Test]
    public void Works_5_with_an_explicit_content_array()
    {
        div(new Content[] { h1("a"), p("b") }).ToString()
            .Should().Be("<div><h1>a</h1><p>b</p></div>");
    }

    // ------------------------------------------------- the three examples, as they stand -------

    [Test]
    public void Cards_a_component_returning_two_siblings()
    {
        // div(class_("cards"), items.Each(Card))
        div(class_("cards"), Items.Each(Card)).ToString()
            .Should().Be("<div class=\"cards\">"
                + "&lt;h3&gt;T1&lt;/h3&gt;&lt;p&gt;B1&lt;/p&gt;"
                + "&lt;h3&gt;T2&lt;/h3&gt;&lt;p&gt;B2&lt;/p&gt;"
                + "</div>");

        // Content.Raw says the concatenation is already markup.
        div(class_("cards"), Items.Each(CardRaw)).ToString()
            .Should().Be("<div class=\"cards\">"
                + "<h3>T1</h3><p>B1</p>"
                + "<h3>T2</h3><p>B2</p>"
                + "</div>");
    }

    [Test]
    public void Two_links_behind_one_condition()
    {
        var loggedIn = true;

        // loggedIn.If(a(href("/profile"), "Profile") + a(href("/logout"), "Log out"))
        loggedIn.If(a(href("/profile"), "Profile") + a(href("/logout"), "Log out")).ToString()
            .Should().Be("&lt;a href=&quot;/profile&quot;&gt;Profile&lt;/a&gt;"
                + "&lt;a href=&quot;/logout&quot;&gt;Log out&lt;/a&gt;");

        loggedIn.If(Content.Raw(a(href("/profile"), "Profile") + a(href("/logout"), "Log out"))).ToString()
            .Should().Be("<a href=\"/profile\">Profile</a><a href=\"/logout\">Log out</a>");

        false.If(Content.Raw(a(href("/profile"), "Profile"))).ToString().Should().BeEmpty();
    }

    [Test]
    public void An_htmx_out_of_band_response()
    {
        // Results.Extensions.Html(...) takes a string, and this stays a string, so the
        // top level case is the one that already works.
        var html = div(id("result"), "one")
            + div(id("count"), hx_swap_oob("true"), "two");

        html.Should().Be("<div id=\"result\">one</div><div id=\"count\" hx-swap-oob=\"true\">two</div>");

        // ...until it is nested in anything.
        div(html).ToString().Should().Be("<div>"
            + "&lt;div id=&quot;result&quot;&gt;one&lt;/div&gt;"
            + "&lt;div id=&quot;count&quot; hx-swap-oob=&quot;true&quot;&gt;two&lt;/div&gt;"
            + "</div>");
    }

    private sealed record Item(string Title, string Body);
}
