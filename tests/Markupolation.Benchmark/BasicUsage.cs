using System.IO;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using HtmlTags;
using Markupolation.Razor;
using Microsoft.AspNetCore.Http;
using static HyperTextExpression.HtmlExp;

namespace Markupolation.Benchmark
{
    public class BasicUsage
    {
        private StringBuilder _builder = null!;
        private DefaultHttpContext _httpContext = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _builder = new StringBuilder();
            _httpContext = new DefaultHttpContext();
            _httpContext.Response.Body = new MemoryStream();
        }

        [Benchmark]
        public string StringBuilder()
        {
            _builder.Clear();
            _builder.Append("<!DOCTYPE html><html><head><title>");
            _builder.Append("Markupolation");
            _builder.Append("</title></head><body><h1>");
            _builder.Append("Hello, World!");
            _builder.Append("</h1></body></html>");
            return _builder.ToString();
        }

        [Benchmark]
#pragma warning disable CA1822 // Mark members as static
        public string StringFormat()
#pragma warning restore CA1822 // Mark members as static
        {
            return string.Format("<!DOCTYPE html><html><head><title>{0}</title></head><body><h1>{1}</h1></body></html>", "Markupolation", "Hello, World!");
        }

        [Benchmark]
#pragma warning disable CA1822 // Mark members as static
        public string Markupolation()
#pragma warning restore CA1822 // Mark members as static
        {
            return $"{DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")))}";
        }

        [Benchmark]
#pragma warning disable CA1822 // Mark members as static
        public string HtmlTags()
#pragma warning restore CA1822 // Mark members as static
        {
            var doc = new HtmlDocument
            {
                Title = "Markupolation"
            };
            doc.Add("h1").Text("Hello, World!");
            return doc.ToString();
        }

        [Benchmark]
#pragma warning disable CA1822 // Mark members as static
        public string HyperTextExpression()
#pragma warning restore CA1822 // Mark members as static
        {
            var doc = HtmlDoc(
                Head(
                    ("title", "Markupolation")
                ),
                Body(
                    ("h1", "Hello, World!")
                )
            );
            return doc.ToString();
        }

        [Benchmark]
        public async Task<string> RazorSlices()
        {
            _httpContext.Response.Body.SetLength(0); // Clear
            var slice = Results.Extensions.RazorSlice<Razor.BasicUsage, BasicModel>(new BasicModel { Title = "Markupolation", Body = "Hello, World!" });
            await slice.ExecuteAsync(_httpContext);

            _httpContext.Response.Body.Position = 0;
            using (var reader = new StreamReader(_httpContext.Response.Body))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<bool> IsValid()
        {
            var benchmark = new BasicUsage();
            benchmark.GlobalSetup();
            var expected = benchmark.Markupolation();
            return
                expected.IsEquivalentTo(benchmark.StringBuilder()) &&
                expected.IsEquivalentTo(benchmark.StringFormat()) &&
                expected.IsEquivalentTo(benchmark.HtmlTags()) &&
                expected.IsEquivalentTo(benchmark.HyperTextExpression()) &&
                expected.IsEquivalentTo(await benchmark.RazorSlices());
        }
    }
}
