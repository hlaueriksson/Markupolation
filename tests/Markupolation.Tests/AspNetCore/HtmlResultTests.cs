using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Markupolation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;

namespace Markupolation.Tests;

public class HtmlResultTests
{
    private static DefaultHttpContext Context() =>
        new() { Response = { Body = new MemoryStream() } };

    private static string Body(HttpContext context)
    {
        var stream = (MemoryStream)context.Response.Body;
        return Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
    }

    [Test]
    public async Task Writes_the_markup_with_an_html_content_type()
    {
        var context = Context();

        await new HtmlResult(html(body(h1("Hello, World!")))).ExecuteAsync(context);

        Body(context).Should().Be("<html><body><h1>Hello, World!</h1></body></html>");
        context.Response.ContentType.Should().Be("text/html; charset=utf-8");
        context.Response.StatusCode.Should().Be(200);
    }

    [Test]
    public async Task Sets_content_length_so_the_response_is_not_chunked()
    {
        var context = Context();
        var content = p("Göteborg");

        await new HtmlResult(content).ExecuteAsync(context);

        // Byte count, not character count - the content type says UTF-8.
        context.Response.ContentLength.Should().Be(Encoding.UTF8.GetByteCount(content.ToString()));
        context.Response.ContentLength.Should().BeGreaterThan(content.ToString().Length);
    }

    [Test]
    public async Task Honours_the_status_code()
    {
        var context = Context();

        await new HtmlResult(p("gone"), 404).ExecuteAsync(context);

        context.Response.StatusCode.Should().Be(404);
        Body(context).Should().Be("<p>gone</p>");
    }

    [Test]
    public async Task Writes_nothing_for_empty_content()
    {
        var context = Context();

        await new HtmlResult(string.Empty).ExecuteAsync(context);

        Body(context).Should().BeEmpty();
        context.Response.ContentLength.Should().Be(0);
    }

    [Test]
    public async Task Works_as_an_mvc_action_result()
    {
        var context = Context();
        var actionContext = new ActionContext(context, new RouteData(), new ActionDescriptor());

        await new HtmlResult(p("mvc")).ExecuteResultAsync(actionContext);

        Body(context).Should().Be("<p>mvc</p>");
        context.Response.ContentType.Should().Be("text/html; charset=utf-8");
    }

    [Test]
    public async Task Results_Extensions_Html()
    {
        var context = Context();

        await Results.Extensions.Html(p("minimal")).ExecuteAsync(context);

        Body(context).Should().Be("<p>minimal</p>");
    }

    [Test]
    public async Task HtmlResults_are_typed()
    {
        var context = Context();

        HtmlResult result = HtmlResults.NotFound(p("nope"));
        await result.ExecuteAsync(context);

        result.StatusCode.Should().Be(404);
        result.ContentType.Should().Be("text/html; charset=utf-8");
        Body(context).Should().Be("<p>nope</p>");
    }

    [Test]
    public async Task Encoding_still_applies()
    {
        var context = Context();

        await new HtmlResult(div("<script>")).ExecuteAsync(context);

        Body(context).Should().Be("<div>&lt;script&gt;</div>");
    }

    [Test]
    public void Htmx_request_headers()
    {
        var context = Context();
        context.Request.Headers["HX-Request"] = "true";
        context.Request.Headers["HX-Target"] = "#result";

        context.Request.IsHtmx().Should().BeTrue();
        context.Request.HtmxTarget().Should().Be("#result");
        context.Request.HtmxTrigger().Should().BeNull();
        Context().Request.IsHtmx().Should().BeFalse();
    }

    [Test]
    public void Htmx_response_headers()
    {
        var context = Context();

        context.Response.HxTrigger("refresh");
        context.Response.HxRetarget("#result");
        context.Response.HxReswap("outerHTML");
        context.Response.HxRefresh();

        context.Response.Headers["HX-Trigger"].ToString().Should().Be("refresh");
        context.Response.Headers["HX-Retarget"].ToString().Should().Be("#result");
        context.Response.Headers["HX-Reswap"].ToString().Should().Be("outerHTML");
        context.Response.Headers["HX-Refresh"].ToString().Should().Be("true");
    }

    [Test]
    public void ToHtmlContent_writes_markup_without_re_encoding()
    {
        var writer = new StringWriter();

        div("<script>").ToHtmlContent().WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

        // Razor's encoder must not run over content that is already encoded.
        writer.ToString().Should().Be("<div>&lt;script&gt;</div>");
    }

    [Test]
    public async Task A_whole_document_is_not_encoded()
    {
        // DOCTYPE() returns Content and + keeps it markup, so the document arrives as markup
        // rather than as a string that would be encoded on the way back in.
        var context = Context();

        await Results.Extensions.Html(DOCTYPE() + html(body(h1("Hi")))).ExecuteAsync(context);

        Body(context).Should().Be("<!DOCTYPE html><html><body><h1>Hi</h1></body></html>");
    }

    [Test]
    public async Task Text_inside_a_document_is_still_encoded()
    {
        // The API takes Content, so encoding has already happened inside the elements - and the
        // response writes what they produced, without a second pass.
        var context = Context();

        await Results.Extensions.Html(div("<script>")).ExecuteAsync(context);

        Body(context).Should().Be("<div>&lt;script&gt;</div>");
    }
}
