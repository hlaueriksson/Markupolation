using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Markupolation.Tests
{
    public class GenerateTests
    {
        [Test, Explicit]
        public async Task ElementType()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/multipage/syntax.html#void-elements");
            var elements = await page.QuerySelectorAllAsync("dl dd:first-of-type code[id^='elements'] a");
            var voidElements = elements.Select(async x => await x.InnerTextAsync()).Select(x => x.Result).ToList();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#elements-3");
            elements = await page.QuerySelectorAllAsync("body > table:nth-child(7) tbody tr");

            var result = new StringBuilder();
            result.AppendLine("internal enum ElementType");
            result.AppendLine("{");
            foreach (var element in elements)
            {
                var names = await GetNamesAsync(element);

                if (!names.Any()) continue;

                var description = await element.EvalOnSelectorAsync<string>("td", "e => e.innerText");
                var attributes = await GetAttributesAsync(element);
                var attributeArray = attributes.Any() ? ", " + string.Join(" ,", attributes.Select(x => $"\"{x}\"")) : string.Empty;

                foreach (var name in names)
                {
                    var isVoidElement = voidElements.Contains(name).ToString().ToLower();
                    var suffix = IsCsharpKeyword(name) ? "_" : string.Empty;

                    result.AppendLine($"    [Element(\"{description}\", {isVoidElement}{attributeArray})]");
                    result.AppendLine($"    {name}{suffix},");
                    result.AppendLine();
                }
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            async Task<string[]> GetNamesAsync(IElementHandle element)
            {
                var links = await element.QuerySelectorAllAsync("th code[id^='elements'] a");
                return links.Select(async x => await x.InnerTextAsync()).Select(x => x.Result).ToArray();
            }

            async Task<string[]> GetAttributesAsync(IElementHandle element)
            {
                var attributes = await element.QuerySelectorAllAsync("td code[id^='elements'] a[href*='attr']");
                return attributes.Select(async x => await x.InnerTextAsync()).Select(x => x.Result).ToArray();
            }

            bool IsCsharpKeyword(string name) => new[] { "base", "object" }.Contains(name);
        }

        [Test, Explicit]
        public async Task AttributeType()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/dom.html#global-attributes");
            var attributes = await page.QuerySelectorAllAsync("ul.brief:nth-of-type(11) li code[id^='global-attributes'] a");
            var globalAttributes = attributes.Select(async x => await x.InnerTextAsync()).Select(x => x.Result.Replace('-', '_')).ToList();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#attributes-3");
            attributes = await page.QuerySelectorAllAsync("table#attributes-1 tbody tr");

            var result = new StringBuilder();
            result.AppendLine("internal enum AttributeType");
            result.AppendLine("{");
            for (int i = 0; i < attributes.Count; i++)
            {
                var attribute = attributes[i];
                var name = await GetNameAsync(attribute);
                var suffix = IsCsharpKeyword(name) ? "_" : string.Empty;
                var nextName = await GetNameAsync(i < attributes.Count - 1 ? attributes[i + 1] : null);

                var description = (await attribute.EvalOnSelectorAsync<string>("td:nth-of-type(2)", "e => e.innerText")).Replace("\"", "\\\"");
                var isGlobalAttribute = globalAttributes.Contains(name).ToString().ToLower();
                var isBooleanAttribute = (await attribute.QuerySelectorAsync("td a[href$='boolean-attribute']") != null).ToString().ToLower();
                var elements = await GetElementsAsync(attribute);
                var elementArray = elements.Any() ? ", " + string.Join(" ,", elements.Select(x => $"\"{x}\"")) : string.Empty;

                result.AppendLine($"    [Attribute(\"{description}\", {isGlobalAttribute}, {isBooleanAttribute}{elementArray})]");
                if (name != nextName)
                {
                    result.AppendLine($"    {name}{suffix},");
                    result.AppendLine();
                }
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            async Task<string> GetNameAsync(IElementHandle attribute)
            {
                if (attribute == null) return null;
                var code = await attribute.QuerySelectorAsync("th code");
                var name = await code.InnerTextAsync();
                return name.Replace('-', '_');
            }

            async Task<string[]> GetElementsAsync(IElementHandle attribute)
            {
                var elements = await attribute.QuerySelectorAllAsync("td:first-of-type code[id^='attributes'] a[href*='attr']");
                return elements.Select(async x => await x.InnerTextAsync()).Select(x => x.Result).ToArray();
            }

            bool IsCsharpKeyword(string name) => new[] { "as", "checked", "class", "default", "for", "is", "readonly" }.Contains(name);
        }

        [Test, Explicit]
        public async Task EventHandlerContentAttributeType()
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
                var name = await attribute.InnerTextAsync();
                result.AppendLine($"    {name},");
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());
        }

        [Test, Explicit]
        public void Elements()
        {
            var values = Enum.GetValues(typeof(ElementType));

            var result = new StringBuilder();
            result.AppendLine("public static partial class Elements");
            result.AppendLine("{");
            foreach (var value in values)
            {
                var a = GetElementAttribute(value);
                var remarks = string.Join(", ", a.Attributes.Select(x => $"<see cref=\"Attributes.{x}\"/>"));
                var param = a.IsVoidElement ? "Attributes." : "Attributes, elements and content.";
                var returns = a.IsVoidElement ? $"<{value} />" : $"<{value}></{value}>";

                result.AppendLine($"    /// <summary>{a.Description}.</summary>");
                if (a.Attributes.Any())
                {
                    result.AppendLine($"    /// <remarks>Attributes: {remarks}</remarks>");
                }
                result.AppendLine($"    /// <param name=\"content\">{param}</param>");
                result.AppendLine($"    /// <returns><code><![CDATA[{returns}]]></code></returns>");
                if (a.IsVoidElement)
                {
                    result.AppendLine($"    public static Element {value}(params Content[] content) => VoidElement(ElementType.{value}, content);");
                }
                else
                {
                    result.AppendLine($"    public static Element {value}(params Content[] content) => NormalElement(ElementType.{value}, content);");
                }
                result.AppendLine();
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            ElementAttribute GetElementAttribute(object value)
            {
                var member = typeof(ElementType).GetMember(value.ToString()).First();
                return member.GetCustomAttributes(false).OfType<ElementAttribute>().Single();
            }
        }

        [Test, Explicit]
        public void Attributes()
        {
            var values = Enum.GetValues(typeof(AttributeType));

            var result = new StringBuilder();
            result.AppendLine("public static partial class Attributes");
            result.AppendLine("{");
            foreach (var value in values)
            {
                var a = GetAttributeAttributes(value);
                var remarks = string.Join(", ", a.SelectMany(x => x.Elements).Select(x => $"<see cref=\"Elements.{x}\"/>"));
                var returns = a.Any(x => x.IsBooleanAttribute) ? $"{value}" : $"{value}=\"value\"";

                result.AppendLine($"    /// <summary>");
                foreach (var x in a)
                {
                    result.AppendLine($"    /// {x.Description}.");
                }
                result.AppendLine($"    /// </summary>");
                if (a.SelectMany(x => x.Elements).Any())
                {
                    result.AppendLine($"    /// <remarks>Elements: {remarks}</remarks>");
                }
                if (a.All(x => !x.IsBooleanAttribute))
                {
                    result.AppendLine($"    /// <param name=\"value\">Attribute value.</param>");
                }
                result.AppendLine($"    /// <returns><code>{returns}</code></returns>");

                if (a.Any(x => x.IsBooleanAttribute))
                {
                    result.AppendLine($"    public static Attribute {value}() => new(AttributeType.{value});");
                }
                else
                {
                    result.AppendLine($"    public static Attribute {value}(string value) => new(AttributeType.{value}, value);");
                }
                result.AppendLine();
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            AttributeAttribute[] GetAttributeAttributes(object value)
            {
                var member = typeof(AttributeType).GetMember(value.ToString()).First();
                return member.GetCustomAttributes(false).OfType<AttributeAttribute>().ToArray();
            }
        }

        [Test]
        public void Conflicts()
        {
            var elementValues = Enum.GetValues(typeof(ElementType)).Cast<ElementType>().Select(x => x.ToString());
            var attributeValues = Enum.GetValues(typeof(AttributeType)).Cast<AttributeType>().Select(x => x.ToString());
            var result = elementValues.Intersect(attributeValues);
            result.Should().BeEquivalentTo(new[] { "abbr", "cite", "data", "form", "label", "slot", "span", "style", "title" });
        }

        [Test]
        public void Conflicts_title()
        {
            var result = $"{title("Title")}";
            result.Should().Be("title=\"Title\"");

            result = $"{Markupolation.Attributes.title("Title")}";
            result.Should().Be("title=\"Title\"");

            result = $"{Markupolation.Elements.title("Title")}";
            result.Should().Be("<title>Title</title>");
        }
    }
}
