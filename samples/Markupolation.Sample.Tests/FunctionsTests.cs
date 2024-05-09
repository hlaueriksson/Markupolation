using System.Net;
using FluentAssertions;
using VerifyTests.AngleSharp;

namespace Markupolation.Sample.Tests
{
    [Ignore("Fails")]
    public class FunctionsTests
    {
        private DistributedApplication _app = null!;
        private HttpClient _httpClient = null!;

        [OneTimeSetUp]
        public async Task Init()
        {
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Markupolation_Sample_Aspire_AppHost>();
            _app = await appHost.BuildAsync();
            await _app.StartAsync();

            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7074") };
            //_httpClient = _app.CreateHttpClient("functions");
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            await _app.DisposeAsync();
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
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }
    }
}
