using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Markupolation.Tests
{
    [Explicit]
    public class GenerateTests
    {
        [Test]
        public async Task ElementType()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/multipage/syntax.html#void-elements");
            var elements = await page.QuerySelectorAllAsync("dl dd:first-of-type code[id^='elements'] a");
            var voidElements = elements.Select(async x => await x.InnerTextAsync()).Select(x => x.Result.CleanName()).ToList();

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
                var attributeTypes = attributes.Any() ? ", " + string.Join(", ", attributes.Select(x => $"AttributeType.{x.CleanName()}")) : string.Empty;

                foreach (var name in names)
                {
                    var isVoidElement = voidElements.Contains(name).ToString().ToLower();

                    result.AppendLine($"    [Element(\"{description}\", {isVoidElement}{attributeTypes})]");
                    result.AppendLine($"    {name},");
                    result.AppendLine();
                }
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            async Task<string[]> GetNamesAsync(IElementHandle element)
            {
                var links = await element.QuerySelectorAllAsync("th code[id^='elements'] a");
                return links.Select(async x => await x.InnerTextAsync()).Select(x => x.Result.CleanName()).ToArray();
            }

            async Task<string[]> GetAttributesAsync(IElementHandle element)
            {
                var obsolete = new[] { "manifest" };
                var attributes = await element.QuerySelectorAllAsync("td code[id^='elements'] a[href*='attr']");
                return attributes
                    .Select(async x => await x.InnerTextAsync())
                    .Select(x => x.Result.CleanName())
                    .Where(x => !obsolete.Contains(x))
                    .ToArray();
            }
        }

        [Test]
        public async Task AttributeType()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/dom.html#global-attributes");
            var attributes = await page.QuerySelectorAllAsync("ul.brief:nth-of-type(11) li code[id^='global-attributes'] a");
            var globalAttributes = attributes.Select(async x => await x.InnerTextAsync()).Select(x => x.Result.CleanName()).ToList();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#attributes-3");
            attributes = await page.QuerySelectorAllAsync("table#attributes-1 tbody tr");

            var result = new StringBuilder();
            result.AppendLine("internal enum AttributeType");
            result.AppendLine("{");
            for (int i = 0; i < attributes.Count; i++)
            {
                var attribute = attributes[i];
                var name = await GetNameAsync(attribute);
                var nextName = await GetNameAsync(i < attributes.Count - 1 ? attributes[i + 1] : null);

                var description = (await attribute.EvalOnSelectorAsync<string>("td:nth-of-type(2)", "e => e.innerText")).Replace("\"", "\\\"");
                var isGlobalAttribute = globalAttributes.Contains(name!).ToString().ToLower();
                var isBooleanAttribute = (await attribute.QuerySelectorAsync("td a[href$='boolean-attribute']") != null).ToString().ToLower();
                var elements = await GetElementsAsync(attribute);
                var elementTypes = elements.Any() ? ", " + string.Join(", ", elements.Select(x => $"ElementType.{x.CleanName()}")) : string.Empty;

                result.AppendLine($"    [Attribute(\"{description}\", {isGlobalAttribute}, {isBooleanAttribute}{elementTypes})]");
                if (name != nextName)
                {
                    result.AppendLine($"    {name},");
                    result.AppendLine();
                }
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            async Task<string?> GetNameAsync(IElementHandle? attribute)
            {
                if (attribute == null) return null;
                var code = await attribute.QuerySelectorAsync("th code");
                var name = await code!.InnerTextAsync();
                return name.CleanName();
            }

            async Task<string[]> GetElementsAsync(IElementHandle attribute)
            {
                var elements = await attribute.QuerySelectorAllAsync("td:first-of-type code[id^='attributes'] a[href*='attr']");
                return elements.Select(async x => await x.InnerTextAsync()).Select(x => x.Result.CleanName()).ToArray();
            }
        }

        [Test]
        public async Task EventHandlerContentAttributeType()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://html.spec.whatwg.org/dev/indices.html#ix-event-handlers");
            var attributes = await page.QuerySelectorAllAsync("table#ix-event-handlers tbody tr");

            var result = new StringBuilder();
            result.AppendLine("internal enum EventHandlerContentAttributeType");
            result.AppendLine("{");
            foreach (var attribute in attributes)
            {
                var name = await GetNameAsync(attribute);
                var description = (await attribute.EvalOnSelectorAsync<string>("td:nth-of-type(2)", "e => e.innerText")).Replace("\"", "\\\"");
                var elements = await GetElementsAsync(attribute);
                var elementTypes = elements.Any() ? ", " + string.Join(", ", elements.Select(x => $"ElementType.{x}")) : string.Empty;

                result.AppendLine($"    [EventHandlerContentAttribute(\"{description}\"{elementTypes})]");
                result.AppendLine($"    {name},");
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            async Task<string?> GetNameAsync(IElementHandle? attribute)
            {
                if (attribute == null) return null;
                var code = await attribute.QuerySelectorAsync("th code");
                var name = await code!.InnerTextAsync();
                return name.CleanName();
            }

            async Task<string[]> GetElementsAsync(IElementHandle attribute)
            {
                var elements = await attribute.QuerySelectorAllAsync("td:first-of-type code[id^='attributes'] a:not([id])");
                return elements.Select(async x => await x.InnerTextAsync()).Select(x => x.Result.CleanName()).ToArray();
            }
        }

        [Test]
        public void Elements()
        {
            var values = Enum.GetValues(typeof(ElementType));

            var result = new StringBuilder();
            result.AppendLine("/// <summary>HTML elements.</summary>");
            result.AppendLine("public static partial class Elements");
            result.AppendLine("{");
            foreach (var value in values)
            {
                var a = GetElementAttribute(value);
                var remarks = string.Join(", ", a.Attributes.Select(x => $"<see cref=\"Attributes.{x}{(GetAttributeAttribute(x).IsBooleanAttribute ? "()" : "(string)")}\"/>"));
                var param = a.IsVoidElement ? "Attributes." : "Attributes, elements and content.";
                var returns = a.IsVoidElement ? $"<{value} />" : $"<{value}></{value}>";

                result.AppendLine($"    /// <summary>{a.Description}.</summary>");
                if (a.Attributes.Any())
                {
                    result.AppendLine($"    /// <remarks>Attributes: {remarks}.</remarks>");
                }
                result.AppendLine($"    /// <param name=\"content\">{param}</param>");
                result.AppendLine($"    /// <returns><code><![CDATA[{returns}]]></code></returns>");
                result.AppendLine($"    public static Element {value}(params Content[] content) => new(ElementType.{value}, {a.IsVoidElement.ToString().ToLower()}, content);");
                result.AppendLine();

                if (!a.IsVoidElement)
                {
                    result.AppendLine($"    /// <inheritdoc cref=\"{value}(Content[])\" />");
                    result.AppendLine($"    public static Element {value}(object content) => new(ElementType.{value}, false, content?.ToString()!);");
                    result.AppendLine();
                }
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            static ElementAttribute GetElementAttribute(object value)
            {
                var member = typeof(ElementType).GetMember(value.ToString()!).First();
                return member.GetCustomAttributes(false).OfType<ElementAttribute>().Single();
            }

            static AttributeAttribute GetAttributeAttribute(object value)
            {
                var member = typeof(AttributeType).GetMember(value.ToString()!).First();
                return member.GetCustomAttributes(false).OfType<AttributeAttribute>().First();
            }
        }

        [Test]
        public void Attributes()
        {
            var values = Enum.GetValues(typeof(AttributeType));

            var result = new StringBuilder();
            result.AppendLine("/// <summary>HTML attributes.</summary>");
            result.AppendLine("public static partial class Attributes");
            result.AppendLine("{");
            foreach (var value in values)
            {
                var a = GetAttributeAttributes(value);
                var remarks = string.Join(", ", a.SelectMany(x => x.Elements).Select(x => $"<see cref=\"Elements.{x}(Content[])\"/>"));
                var returns = a.Any(x => x.IsBooleanAttribute) ? $"{value}" : $"{value}=\"{{value}}\"";

                result.AppendLine($"    /// <summary>");
                foreach (var x in a)
                {
                    result.AppendLine($"    /// {x.Description}.");
                }
                result.AppendLine($"    /// </summary>");
                if (a.SelectMany(x => x.Elements).Any())
                {
                    result.AppendLine($"    /// <remarks>Elements: {remarks}.</remarks>");
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

                if (!a.Any(x => x.IsBooleanAttribute))
                {
                    result.AppendLine($"    /// <inheritdoc cref=\"{value}(string)\" />");
                    result.AppendLine($"    public static Attribute {value}(object value) => new(AttributeType.{value}, value?.ToString());");
                    result.AppendLine();
                }
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            static AttributeAttribute[] GetAttributeAttributes(object value)
            {
                var member = typeof(AttributeType).GetMember(value.ToString()!).First();
                return member.GetCustomAttributes(false).OfType<AttributeAttribute>().ToArray();
            }
        }

        [Test]
        public void EventHandlerContentAttributes()
        {
            var values = Enum.GetValues(typeof(EventHandlerContentAttributeType));

            var result = new StringBuilder();
            result.AppendLine("/// <summary>HTML event handler content attributes.</summary>");
            result.AppendLine("public static class EventHandlerContentAttributes");
            result.AppendLine("{");
            foreach (var value in values)
            {
                var a = GetEventHandlerContentAttributeAttribute(value);
                var remarks = string.Join(", ", a.Elements.Select(x => $"<see cref=\"Elements.{x}(Content[])\"/>"));

                result.AppendLine($"    /// <summary>{a.Description}.</summary>");
                if (a.Elements.Any())
                {
                    result.AppendLine($"    /// <remarks>Elements: {remarks}.</remarks>");
                }
                result.AppendLine($"    /// <param name=\"value\">Attribute value.</param>");
                result.AppendLine($"    /// <returns><code>{value}=\"{{value}}\"</code></returns>");
                result.AppendLine($"    public static Attribute {value}(string value) => new(\"{value}\", value);");
                result.AppendLine();
            }
            result.AppendLine("}");

            Console.WriteLine(result.ToString());

            static EventHandlerContentAttributeAttribute GetEventHandlerContentAttributeAttribute(object value)
            {
                var member = typeof(EventHandlerContentAttributeType).GetMember(value.ToString()!).First();
                return member.GetCustomAttributes(false).OfType<EventHandlerContentAttributeAttribute>().Single();
            }
        }
    }

    public static class NameExtensions
    {
        public static string CleanName(this string name)
        {
            var suffix = IsCsharpKeyword(name) ? "_" : string.Empty;
            return name.Replace('-', '_') + suffix;
        }

        private static readonly string[] _keywords = new[] { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };

        private static bool IsCsharpKeyword(this string name) => _keywords.Contains(name);
    }
}
