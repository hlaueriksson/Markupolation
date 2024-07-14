using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using HtmlTags;
using Markupolation.Razor;
using Microsoft.AspNetCore.Http;
using RazorSlices;
using static HyperTextExpression.HtmlExp;

namespace Markupolation.Benchmark
{
    public class AdvancedUsage
    {
        readonly Func<int, bool> _fizz = (int i) => i % 3 == 0;
        readonly Func<int, bool> _buzz = (int i) => i % 5 == 0;

        private IEnumerable<int> _numbers = null!;
        private StringBuilder _builder = null!;
        private DefaultHttpContext _httpContext = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _numbers = Enumerable.Range(1, 100);
            _builder = new StringBuilder();
            _httpContext = new DefaultHttpContext();
            _httpContext.Response.Body = new MemoryStream();
        }

        [Benchmark]
        public string StringBuilder()
        {
            _builder.Clear();
            _builder.Append("<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\" /><title>Markupolation.Extensions</title><meta name=\"description\" content=\"Sample of how to use Markupolation.Extensions\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /></head><body><ul>");
            foreach (int i in _numbers)
            {
                _builder.Append("<li>");
                if (_fizz(i) && _buzz(i))
                {
                    _builder.Append("<strong>");
                    _builder.Append("FizzBuzz");
                    _builder.Append("</strong>");
                }
                else if (_fizz(i))
                {
                    _builder.Append("<em>");
                    _builder.Append("Fizz");
                    _builder.Append("</em>");
                }
                else if (_buzz(i))
                {
                    _builder.Append("<em>");
                    _builder.Append("Buzz");
                    _builder.Append("</em>");
                }
                else
                {
                    _builder.Append(i);
                }
                _builder.Append("</li>");
            }
            _builder.Append("</ul></body></html>");
            return _builder.ToString();
        }

        [Benchmark]
        public string StringFormat()
        {
            var result = "<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\" /><title>Markupolation.Extensions</title><meta name=\"description\" content=\"Sample of how to use Markupolation.Extensions\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /></head><body><ul>";
            foreach (int i in _numbers)
            {
                result += "<li>";
                if (_fizz(i) && _buzz(i))
                {
                    result += string.Format("<strong>{0}</strong>", "FizzBuzz");
                }
                else if (_fizz(i))
                {
                    result += string.Format("<em>{0}</em>", "Fizz");
                }
                else if (_buzz(i))
                {
                    result += string.Format("<em>{0}</em>", "Buzz");
                }
                else
                {
                    result += i;
                }
                result += "</li>";
            }
            result += "</ul></body></html>";
            return result;
        }

        [Benchmark]
        public string Markupolation()
        {
            return
                DOCTYPE() +
                html(lang("en"),
                    head(
                        meta(charset("utf-8")),
                        e.title("Markupolation.Extensions"),
                        meta(name("description"), content("Sample of how to use Markupolation.Extensions")),
                        meta(name("viewport"), content("width=device-width, initial-scale=1"))
                    ),
                    body(
                        ul(
                            _numbers.Each(i => li(
                                _fizz(i) && _buzz(i) ? strong("FizzBuzz") :
                                _fizz(i) && !_buzz(i) ? em("Fizz") :
                                !_fizz(i) && _buzz(i) ? em("Buzz") :
                                i.ToString()
                            ))
                        )
                    )
                );
        }

        [Benchmark]
        public string HtmlTags()
        {
            var doc = new HtmlDocument();
            doc.RootTag.Attr("lang", "en");
            doc.Head.Add("meta").Attr("charset", "utf-8");
            doc.Title = "Markupolation";
            doc.Head.Add("meta").Attr("name", "description").Attr("content", "Sample of how to use Markupolation.Extensions");
            doc.Head.Add("meta").Attr("name", "viewport").Attr("content", "width=device-width, initial-scale=1");
            doc.Add("ul").Append(
                _numbers.Select(i =>
                    _fizz(i) && _buzz(i) ? new HtmlTag("li").Add("strong").Text("FizzBuzz").Parent :
                    _fizz(i) && !_buzz(i) ? new HtmlTag("li").Add("em").Text("Fizz").Parent :
                    !_fizz(i) && _buzz(i) ? new HtmlTag("li").Add("em").Text("Buzz").Parent :
                    new HtmlTag("li").Text(i.ToString())
                )
            );
            return doc.ToString();
        }

        [Benchmark]
        public string HyperTextExpression()
        {
            var doc = HtmlDoc(
                Attrs(("lang", "en")),
                Head(
                    ("meta", Attrs(("charset", "utf-8"))),
                    ("title", "Markupolation.Extensions"),
                    ("meta", Attrs(("name", "description"), ("content", "Sample of how to use Markupolation.Extensions"))),
                    ("meta", Attrs(("name", "viewport"), ("content", "width=device-width, initial-scale=1")))
                ),
                Body(
                    ("ul",
                        _numbers.Select(i => ("li", Children(
                            _fizz(i) && _buzz(i) ? ("strong", "FizzBuzz") :
                            _fizz(i) && !_buzz(i) ? ("em", "Fizz") :
                            !_fizz(i) && _buzz(i) ? ("em", "Buzz") :
                            ("span", i.ToString())
                        )))
                    )
                )
            );
            return doc.ToString();
        }

        [Benchmark]
        public async Task<string> RazorSlices()
        {
            _httpContext.Response.Body.SetLength(0); // Clear
            var slice = Results.Extensions.RazorSlice<Razor.AdvancedUsage, IEnumerable<int>>(_numbers);
            await slice.ExecuteAsync(_httpContext);

            _httpContext.Response.Body.Position = 0;
            using (var reader = new StreamReader(_httpContext.Response.Body))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<bool> IsValid()
        {
            var benchmark = new AdvancedUsage();
            benchmark.GlobalSetup();
            var expected = benchmark.Markupolation();
            return
                expected.IsEquivalentTo(benchmark.StringBuilder()) &&
                expected.IsEquivalentTo(benchmark.StringFormat()) &&
                //expected.IsEquivalentTo(benchmark.HtmlTags()) &&
                //expected.IsEquivalentTo(benchmark.HyperTextExpression()) &&
                expected.IsEquivalentTo(await benchmark.RazorSlices());
        }
    }
}
