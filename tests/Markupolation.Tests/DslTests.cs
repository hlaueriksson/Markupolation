using System;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

/// <summary>
/// Different ways to write a function that renders a view model (<see cref="Link"/>) as <see cref="Content"/>.
/// Each test is self-contained, so it can be copied into the README as-is.
/// </summary>
public class DslTests
{
    /// <summary>Render inline, without a separate render function.</summary>
    [Test]
    public void Rendered_inline()
    {
        Link[] links = [new("#", "Foo", true), new("#", "Bar", false)];

        links.Each((x, index) => a(href(x.Url), id($"link{index}"), x.IfMatch(x => x.Active, x => class_("active")), x.Title)).ToString()
            .Should().Be("<a href=\"#\" id=\"link0\" class=\"active\">Foo</a><a href=\"#\" id=\"link1\">Bar</a>");
    }

    /// <summary>Render with a Func stored in a variable.</summary>
    [Test]
    public void Rendered_with_a_Func()
    {
        Link[] links = [new("#", "Foo", true), new("#", "Bar", false)];

        Func<Link, Content> render = link => a(href(link.Url), link.Active.If(class_("active")), link.Title);

        links.Each(render).ToString()
            .Should().Be("<a href=\"#\" class=\"active\">Foo</a><a href=\"#\">Bar</a>");
    }

    /// <summary>Render with a local function.</summary>
    [Test]
    public void Rendered_with_a_local_function()
    {
        Link[] links = [new("#", "Foo", true), new("#", "Bar", false)];

        static Content Render(Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);

        links.Each(Render).ToString()
            .Should().Be("<a href=\"#\" class=\"active\">Foo</a><a href=\"#\">Bar</a>");
    }

    /// <summary>Render with a local function, using a switch expression for more than one condition.</summary>
    [Test]
    public void Rendered_with_a_local_function_and_switch_expression()
    {
        Link[] links = [new("#", "Foo", true), new("#", "Bar", false)];

        static Content Render(Link link) => link switch
        {
            { Active: true } => a(href(link.Url), class_("active"), link.Title),
            _ => a(href(link.Url), link.Title),
        };

        links.Each(Render).ToString()
            .Should().Be("<a href=\"#\" class=\"active\">Foo</a><a href=\"#\">Bar</a>");
    }

    /// <summary>Render via an implicit operator conversion from Link to Content.</summary>
    [Test]
    public void Rendered_with_an_implicit_operator()
    {
        Link[] links = [new("#", "Foo", true), new("#", "Bar", false)];

        links.Each(link => link).ToString()
            .Should().Be("<a href=\"#\" class=\"active\">Foo</a><a href=\"#\">Bar</a>");
    }

    /// <summary>Render via an extension method on Link.</summary>
    [Test]
    public void Rendered_with_an_extension_method()
    {
        Link[] links = [new("#", "Foo", true), new("#", "Bar", false)];

        links.Each(link => link.ToContent()).ToString()
            .Should().Be("<a href=\"#\" class=\"active\">Foo</a><a href=\"#\">Bar</a>");
    }
}

internal sealed record Link(string Url, string Title, bool Active)
{
    public static implicit operator Content(Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);
}

internal static class LinkExtensions
{
    public static Content ToContent(this Link link) => a(href(link.Url), link.Active.If(class_("active")), link.Title);
}
