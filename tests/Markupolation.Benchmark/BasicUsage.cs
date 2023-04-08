using System.Text;
using BenchmarkDotNet.Attributes;
using HtmlTags;

namespace Markupolation.Benchmark
{
    public class BasicUsage
    {
        private StringBuilder _builder = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _builder = new StringBuilder();
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

        public static bool IsValid()
        {
            var benchmark = new BasicUsage();
            benchmark.GlobalSetup();
            return
                benchmark.Markupolation() == benchmark.StringBuilder() &&
                benchmark.Markupolation() == benchmark.StringFormat() &&
                benchmark.Markupolation() == benchmark.HtmlTags().ReplaceLineEndings(string.Empty);
        }
    }
}
