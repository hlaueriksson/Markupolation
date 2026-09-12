using System.Net;
using FluentAssertions;
using VerifyTests.AngleSharp;

namespace Markupolation.Sample.Tests;

public class BlazorTests
{
    private HttpClient _httpClient = null!;

    [SetUp]
    public void Setup()
    {
        _httpClient = GlobalSetup.App.CreateHttpClient("blazor");
    }

    [Test]
    public async Task Root_should_return_HTML()
    {
        var response = await _httpClient.GetAsync("/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
    }

    [Test]
    public async Task Counter_should_return_HTML()
    {
        var response = await _httpClient.GetAsync("/counter");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
    }

    [Test]
    public async Task Weather_should_return_HTML()
    {
        var response = await _httpClient.GetAsync("/weather");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
    }
}
