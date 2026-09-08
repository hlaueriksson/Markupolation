using System.Net;
using AngleSharp.Dom;
using FluentAssertions;
using VerifyTests.AngleSharp;

namespace Markupolation.Sample.Tests
{
    public class ApiTests
    {
        private HttpClient _httpClient = null!;

        [SetUp]
        public void Setup()
        {
            _httpClient = GlobalSetup.App.CreateHttpClient("api");
        }

        [Test]
        public async Task Root_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Hello_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("/hello");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Counter_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("/counter/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Weather_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("/weather");
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
