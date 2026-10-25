using FluentAssertions;
using Markupolation.AspNetCore.Htmx;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Markupolation.Tests;

public class HttpResponseExtensionsTests
{
    [Test]
    public void Htmx_response_headers()
    {
        var context = new DefaultHttpContext();

        context.Response.HxTrigger("refresh");
        context.Response.HxTrigger("{\"showMessage\":\"Here Is A Message\"}");
        context.Response.HxTriggerAfterSettle("settled");
        context.Response.HxTriggerAfterSwap("swapped");
        context.Response.HxRetarget("#result");
        context.Response.HxReswap("outerHTML");
        context.Response.HxReselect("#content");
        context.Response.HxPushUrl("/page/2");
        context.Response.HxReplaceUrl("/page/3");
        context.Response.HxRedirect("/login");
        context.Response.HxLocation("/details/1");
        context.Response.HxRefresh();

        context.Response.Headers["HX-Trigger"].ToString().Should().Be("{\"showMessage\":\"Here Is A Message\"}");
        context.Response.Headers["HX-Trigger-After-Settle"].ToString().Should().Be("settled");
        context.Response.Headers["HX-Trigger-After-Swap"].ToString().Should().Be("swapped");
        context.Response.Headers["HX-Retarget"].ToString().Should().Be("#result");
        context.Response.Headers["HX-Reswap"].ToString().Should().Be("outerHTML");
        context.Response.Headers["HX-Reselect"].ToString().Should().Be("#content");
        context.Response.Headers["HX-Push-Url"].ToString().Should().Be("/page/2");
        context.Response.Headers["HX-Replace-Url"].ToString().Should().Be("/page/3");
        context.Response.Headers["HX-Redirect"].ToString().Should().Be("/login");
        context.Response.Headers["HX-Location"].ToString().Should().Be("/details/1");
        context.Response.Headers["HX-Refresh"].ToString().Should().Be("true");
    }

    [Test]
    public void Htmx_history_update_can_be_prevented()
    {
        var context = new DefaultHttpContext();

        context.Response.HxPreventPushUrl();
        context.Response.HxPreventReplaceUrl();

        // htmx special-cases the literal string false; anything else is the url to push.
        context.Response.Headers["HX-Push-Url"].ToString().Should().Be("false");
        context.Response.Headers["HX-Replace-Url"].ToString().Should().Be("false");
    }
}
