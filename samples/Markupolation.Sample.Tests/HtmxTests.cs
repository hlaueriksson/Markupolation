using System.Net;
using FluentAssertions;
using VerifyTests.AngleSharp;

namespace Markupolation.Sample.Tests
{
    public class HtmxTests
    {
        private DistributedApplication _app = null!;
        private HttpClient _httpClient = null!;

        [OneTimeSetUp]
        public async Task Init()
        {
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Markupolation_Sample_Aspire_AppHost>();
            _app = await appHost.BuildAsync();
            await _app.StartAsync();

            _httpClient = _app.CreateHttpClient("htmx");
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            await _app.DisposeAsync();
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
            var response = await _httpClient.GetAsync("/counter.html");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }

        [Test]
        public async Task Weather_should_return_HTML()
        {
            var response = await _httpClient.GetAsync("/weather.html");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Verify(await response.Content.ReadAsStringAsync(), "html").PrettyPrintHtml();
        }
    }
}
