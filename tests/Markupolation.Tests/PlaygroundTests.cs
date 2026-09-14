using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

[Explicit]
public class PlaygroundTests
{
    [Test]
    public async Task html5_boilerplate()
    {
        var actual =
            DOCTYPE() +
            html(lang(""),
                head(
                    meta(charset("utf-8")),
                    meta(name("viewport"), content("width=device-width, initial-scale=1")),
                    Elements.title(""),
                    link(rel("stylesheet"), href("css/style.css")),
                    meta(name("description"), content("")),

                    meta(new Attribute("property", "og:title"), content("")),
                    meta(new Attribute("property", "og:type"), content("")),
                    meta(new Attribute("property", "og:url"), content("")),
                    meta(new Attribute("property", "og:image"), content("")),
                    meta(new Attribute("property", "og:image:alt"), content("")),

                    link(rel("icon"), href("/favicon.ico"), sizes("any")),
                    link(rel("icon"), href("/icon.svg"), type("image/svg+xml")),
                    link(rel("apple-touch-icon"), href("icon.png")),

                    link(rel("manifest"), href("site.webmanifest")),
                    meta(name("theme-color"), content("#fafafa"))
                ),
                body(

                    // A comment is markup, not text, so it has to say so under escape-by-default.
                    comment(" Add your site or application content here "),
                    p("Hello world! This is HTML5 Boilerplate."),
                    script(src("js/app.js"))
                )
            );

        using var client = new HttpClient();
        var expected = await client.GetStringAsync("https://raw.githubusercontent.com/h5bp/html5-boilerplate/main/src/index.html");

        var diffs = DiffBuilder.Compare(expected).WithTest(actual.ToString()).Build().ToList();
        diffs.Should().BeEmpty();
    }

    // ---------------------------------------------------------------- from the README ----------

    [Test]
    public void Each_and_IfMatch_from_the_readme()
    {
        var links = new[] { new { Url = "#", Title = "Foo", Active = true }, new { Url = "#", Title = "Bar", Active = false } };

        links.Each((x, index) => a(href(x.Url), id($"link{index}"), x.IfMatch(x => x.Active, x => class_("active")), x.Title)).ToString()
            .Should().Be("<a href=\"#\" id=\"link0\" class=\"active\">Foo</a><a href=\"#\" id=\"link1\">Bar</a>");
    }

    // ------------------------------------------ a DSL for rendering a view model: Link -> Content
    //
    // Every technique below renders the same two links to the same markup, so they can be compared
    // directly. Each<T> only needs a Func<Link, Content> - these are different ways to produce one.

    private static readonly Link[] Links = [new("#", "Foo", true), new("#", "Bar", false)];

    private const string ExpectedLinks = "<a href=\"#\" class=\"active\">Foo</a><a href=\"#\">Bar</a>";

    private delegate Content LinkRenderer(Link link);

    private static Content RenderLink(Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);

    [Test]
    public void Rendered_with_a_Func()
    {
        Func<Link, Content> render = link => a(href(link.Url), link.Active.If(class_("active")), link.Title);

        Links.Each(render).ToString().Should().Be(ExpectedLinks);
    }

    [Test]
    public void Rendered_with_a_named_delegate()
    {
        LinkRenderer render = link => a(href(link.Url), link.Active.If(class_("active")), link.Title);

        // LinkRenderer is a distinct type from Func<Link, Content>, even though the signature
        // matches - Each<T> needs the latter, so converting to one is one extra step.
        Links.Each(new Func<Link, Content>(render)).ToString().Should().Be(ExpectedLinks);
    }

    [Test]
    public void Rendered_with_a_static_method()
    {
        // A method group converts to Func<Link, Content> on its own - no lambda needed.
        Links.Each(RenderLink).ToString().Should().Be(ExpectedLinks);
    }

    [Test]
    public void Rendered_with_a_local_function()
    {
        Content Render(Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);

        Links.Each(Render).ToString().Should().Be(ExpectedLinks);
    }

    [Test]
    public void Rendered_with_an_implicit_operator()
    {
        // Content itself does this for string, int, DateTime, etc. (Content.Conversions.cs) - the
        // same trick applied to a domain type. The lambda is just "return the link"; the operator
        // does the conversion at the return statement, because Each<T> target-types it to Content.
        Links.Each(link => link).ToString().Should().Be(ExpectedLinks);

        Content direct = Links[0];
        direct.ToString().Should().Be("<a href=\"#\" class=\"active\">Foo</a>");
    }

    [Test]
    public void Rendered_with_an_extension_method()
    {
        // Reads like a method on Link, which is convenient when many view models need one.
        Links.Each(link => link.ToContent()).ToString().Should().Be(ExpectedLinks);
    }

    [Test]
    public void Rendered_through_an_interface()
    {
        // Polymorphism: any IRenderable renders itself, so a heterogeneous list of view models can
        // go through the same Each(x => x.Render()) without a switch over their concrete types.
        Links.Each(link => link.Render()).ToString().Should().Be(ExpectedLinks);
    }

    [Test]
    public void Rendered_with_a_switch_expression()
    {
        // If/IfMatch are for a binary condition. Once a view model has more than two shapes, a
        // switch expression - itself target-typed to Content - generalizes it, with no base type
        // or interface needed.
        Content Render(Link link) => link switch
        {
            { Active: true } => a(href(link.Url), class_("active"), link.Title),
            _ => a(href(link.Url), link.Title),
        };

        Links.Each(Render).ToString().Should().Be(ExpectedLinks);
    }
}

internal interface IRenderable
{
    Content Render();
}

internal sealed record Link(string Url, string Title, bool Active) : IRenderable
{
    public static implicit operator Content(Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);

    public Content Render() => a(href(Url), Active.If(class_("active")), Title);
}

internal static class LinkExtensions
{
    public static Content ToContent(this Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);
}
