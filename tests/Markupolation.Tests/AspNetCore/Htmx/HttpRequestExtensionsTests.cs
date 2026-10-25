using FluentAssertions;
using Markupolation.AspNetCore.Htmx;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Markupolation.Tests;

public class HttpRequestExtensionsTests
{
    [Test]
    public void Htmx_request_headers()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers["HX-Request"] = "true";
        context.Request.Headers["HX-Boosted"] = "true";
        context.Request.Headers["HX-Target"] = "#result";
        context.Request.Headers["HX-Trigger-Name"] = "save";
        context.Request.Headers["HX-Current-URL"] = "https://example.com/page";
        context.Request.Headers["HX-Prompt"] = "yes";
        context.Request.Headers["HX-History-Restore-Request"] = "true";

        context.Request.IsHtmx().Should().BeTrue();
        context.Request.IsHtmxBoosted().Should().BeTrue();
        context.Request.IsHtmxHistoryRestore().Should().BeTrue();
        context.Request.HtmxTarget().Should().Be("#result");
        context.Request.HtmxTrigger().Should().BeNull();
        context.Request.HtmxTriggerName().Should().Be("save");
        context.Request.HtmxCurrentUrl().Should().Be("https://example.com/page");
        context.Request.HtmxPrompt().Should().Be("yes");

        var plain = new DefaultHttpContext();
        plain.Request.IsHtmx().Should().BeFalse();
        plain.Request.IsHtmxBoosted().Should().BeFalse();
        plain.Request.IsHtmxHistoryRestore().Should().BeFalse();
    }
}
