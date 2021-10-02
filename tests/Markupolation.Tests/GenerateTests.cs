using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class GenerateTests
    {
        [Test, Explicit]
        public async Task Elements()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/multipage/syntax.html#void-elements");
            var elements = await page.QuerySelectorAllAsync("dl dd:first-of-type code[id^='elements'] a");
            var voidElements = elements.Select(async x => await x.InnerTextAsync()).Select(x => x.Result).ToList();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#elements-3");
            elements = await page.QuerySelectorAllAsync("table tbody tr th code[id^='elements'] a");

            var result = new StringBuilder();
            result.AppendLine("internal enum ElementType");
            result.AppendLine("{");
            foreach (var element in elements)
            {
                var name = await element.InnerTextAsync();
                if (new[] { "base", "object" }.Contains(name))
                {
                    name += "_";
                }
                if (voidElements.Contains(name))
                {
                    result.AppendLine("    [Void]");
                }
                result.AppendLine($"    {name},");
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());
        }

        [Test, Explicit]
        public async Task Attributes()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#attributes-3");
            var attributes = await page.QuerySelectorAllAsync("table#attributes-1 tbody tr th code");
            var distinctAttributes = attributes.Select(async x => await x.InnerTextAsync()).Select(x => x.Result).Distinct().ToList();

            var result = new StringBuilder();
            result.AppendLine("internal enum AttributeType");
            result.AppendLine("{");
            foreach (var attribute in distinctAttributes)
            {
                var name = attribute.Replace('-', '_');
                if (new[] { "as", "checked", "class", "default", "for", "is", "readonly" }.Contains(name))
                {
                    name += "_";
                }
                result.AppendLine($"    {name},");
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());
        }

        [Test, Explicit]
        public async Task EventHandlerContentAttributes()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#ix-event-handlers");
            var attributes = await page.QuerySelectorAllAsync("table#ix-event-handlers tbody tr th code");

            var result = new StringBuilder();
            result.AppendLine("internal enum EventHandlerContentAttributeType");
            result.AppendLine("{");
            foreach (var attribute in attributes)
            {
                var name = (await attribute.InnerTextAsync());
                result.AppendLine($"    {name},");
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());
        }
    }
}
