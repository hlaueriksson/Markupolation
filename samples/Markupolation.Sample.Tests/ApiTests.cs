using System.Net;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using FluentAssertions;
using VerifyTests.AngleSharp;

namespace Markupolation.Sample.Tests
{
    public class ApiTests
    {
        private DistributedApplication _app = null!;
        private HttpClient _httpClient = null!;
        private IBrowsingContext _context = null!;

        [OneTimeSetUp]
        public async Task Init()
        {
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Markupolation_Sample_Aspire_AppHost>();
            _app = await appHost.BuildAsync();
            await _app.StartAsync();

            _httpClient = _app.CreateHttpClient("api");

            var config = Configuration.Default;
            _context = BrowsingContext.New(config);
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
            var document = await _context.OpenAsync(async req => req.Content(await response.Content.ReadAsStringAsync()));
            var dates = document.QuerySelectorAll<IHtmlElement>("tbody tr td:first-child");
            dates.Select(x => x.InnerHtml).Should().BeEquivalentTo(Enumerable.Range(1, 5).Select(x => DateTime.Today.AddDays(x).ToShortDateString()));
        }
    }
}
