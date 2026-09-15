using FluentAssertions;
using NUnit.Framework;
using static Markupolation.Htmx;

namespace Markupolation.Tests;

public class HtmxAttributeTests
{
    [Test]
    public void Valued_attributes_render_the_dashed_name()
    {
        hx_get("/counter/1").ToString().Should().Be("hx-get=\"/counter/1\"");
        hx_post("/save").ToString().Should().Be("hx-post=\"/save\"");
        hx_target("#result").ToString().Should().Be("hx-target=\"#result\"");
        hx_swap("outerHTML").ToString().Should().Be("hx-swap=\"outerHTML\"");
        hx_swap_oob("true").ToString().Should().Be("hx-swap-oob=\"true\"");
        hx_push_url("/page/2").ToString().Should().Be("hx-push-url=\"/page/2\"");
        hx_disabled_elt("this").ToString().Should().Be("hx-disabled-elt=\"this\"");
        hx_vars("{\"a\":1}").ToString().Should().Be("hx-vars=\"{&quot;a&quot;:1}\"");
    }

    [Test]
    public void Boolean_attributes_render_bare()
    {
        hx_disable().ToString().Should().Be("hx-disable");
        hx_history_elt().ToString().Should().Be("hx-history-elt");
        hx_preserve().ToString().Should().Be("hx-preserve");
    }

    [Test]
    public void Boolean_valued_overloads_render_lowercase_true_or_false()
    {
        // htmx's protocol only recognises lowercase "false" - bool.ToString() would send "False",
        // which htmx treats as truthy, so the push/boost/etc. would silently happen anyway.
        hx_push_url(false).ToString().Should().Be("hx-push-url=\"false\"");
        hx_push_url(true).ToString().Should().Be("hx-push-url=\"true\"");
        hx_history(false).ToString().Should().Be("hx-history=\"false\"");
        hx_boost(false).ToString().Should().Be("hx-boost=\"false\"");
        hx_validate(false).ToString().Should().Be("hx-validate=\"false\"");
    }

    [Test]
    public void Hx_on_names_the_event()
    {
        hx_on("click", "alert(1)").ToString().Should().Be("hx-on:click=\"alert(1)\"");

        // An htmx event takes a leading colon, giving hx-on:: in the output.
        hx_on(":after-request", "this.reset()").ToString().Should().Be("hx-on::after-request=\"this.reset()\"");
    }

    [Test]
    public void Values_are_encoded_like_any_other_attribute()
    {
        // hx-vals takes JSON, whose quotes have to survive being put in an attribute.
        hx_vals("{\"a\":1}").ToString().Should().Be("hx-vals=\"{&quot;a&quot;:1}\"");
        hx_get("/search?a=1&b=2").ToString().Should().Be("hx-get=\"/search?a=1&amp;b=2\"");
    }

    [Test]
    public void Composes_with_elements()
    {
        button(class_("btn"), hx_get("/counter/2"), hx_target("#result"), hx_swap("outerHTML"), "Click me")
            .ToString()
            .Should().Be("<button class=\"btn\" hx-get=\"/counter/2\" hx-target=\"#result\" hx-swap=\"outerHTML\">Click me</button>");
    }

}
