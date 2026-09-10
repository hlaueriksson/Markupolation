using System.Net;
using AngleSharp.Dom;
using FluentAssertions;
using VerifyTests.AngleSharp;

namespace Markupolation.Sample.Tests
{
    public class FunctionsTests
    {
        private HttpClient _httpClient = null!;

        [SetUp]
        public void Setup()
        {
            _httpClient = GlobalSetup.App.CreateHttpClient("functions");
        }

        [Test]
        public async Task Html_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("api/Html");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Hello_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("api/Hello");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Counter_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("api/Counter/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Weather_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("api/Weather");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml(
                nodes =>
                {
                    foreach (var node in nodes.QuerySelectorAll("td"))
                    {
                        node.Remove();
                    }
                });
        }
    }
}
