using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace Markupolation.Converter;

/// <summary>
/// Turns HTML into Markupolation source.
/// </summary>
/// <remarks>
/// What the HTML specification says is reused rather than restated: whether a name is an element
/// or an attribute, whether an element is void, whether an attribute is boolean, and which names
/// collide all come from the generated metadata in Markupolation itself.
/// </remarks>
public static class HtmlConverter
{
    private static readonly char[] NewLines = ['\n', '\r'];

    private static readonly HashSet<string> Elements =
        new(Enum.GetNames<ElementType>(), StringComparer.Ordinal);

    private static readonly HashSet<string> AttributeNames =
        new(Enum.GetNames<AttributeType>(), StringComparer.Ordinal);

    private static readonly HashSet<string> Ambiguous =
        new(Enum.GetNames<ElementType>().Intersect(Enum.GetNames<AttributeType>(), StringComparer.Ordinal), StringComparer.Ordinal);

    /// <summary>
    /// Converts HTML into Markupolation source.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns>Markupolation source.</returns>
    public static string Convert(string html) => Convert(html, new ConvertOptions());

    /// <summary>
    /// Converts HTML into Markupolation source.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <param name="options">How to convert.</param>
    /// <returns>Markupolation source.</returns>
    public static string Convert(string html, ConvertOptions options)
    {
        html ??= string.Empty;
        options ??= new ConvertOptions();

        var document = new HtmlParser().ParseDocument(html);
        var fragment = options.Fragment ?? !LooksLikeDocument(html);

        var builder = new StringBuilder();

        if (fragment)
        {
            var nodes = document.Body?.ChildNodes.Where(Renders).ToList() ?? [];

            if (nodes.Count == 0)
            {
                nodes = document.Head?.ChildNodes.Where(Renders).ToList() ?? [];
            }

            WriteSiblings(builder, nodes, options, 0);
        }
        else
        {
            if (document.Doctype != null)
            {
                builder.Append("DOCTYPE() +").Append(Environment.NewLine);
            }

            var root = document.DocumentElement;

            if (root == null)
            {
                return string.Empty;
            }

            Write(builder, root, options, 0);
        }

        return builder.ToString();
    }

    private static bool LooksLikeDocument(string html)
    {
        var trimmed = html.TrimStart();

        return trimmed.StartsWith("<!doctype", StringComparison.OrdinalIgnoreCase)
            || trimmed.StartsWith("<html", StringComparison.OrdinalIgnoreCase);
    }

    private static bool Renders(INode node)
    {
        // Whitespace between elements is not content; keep everything else.
        return node.NodeType != NodeType.Text || !string.IsNullOrWhiteSpace(node.TextContent);
    }

    private static void WriteSiblings(StringBuilder builder, List<INode> nodes, ConvertOptions options, int depth)
    {
        for (var i = 0; i < nodes.Count; i++)
        {
            Write(builder, nodes[i], options, depth);

            if (i < nodes.Count - 1)
            {
                builder.Append(" +").Append(Environment.NewLine);
            }
        }
    }

    private static void Write(StringBuilder builder, INode node, ConvertOptions options, int depth)
    {
        switch (node)
        {
            case IElement element:
                WriteElement(builder, element, options, depth);
                break;
            case IComment comment:
                Indent(builder, options, depth);
                builder.Append("new E(").Append(Literal("<!--" + comment.TextContent + "-->")).Append(')');
                break;
            default:
                Indent(builder, options, depth);
                builder.Append(Literal(node.TextContent));
                break;
        }
    }

    private static void WriteElement(StringBuilder builder, IElement element, ConvertOptions options, int depth)
    {
        var name = element.LocalName;
        var clean = name.CleanName();

        Indent(builder, options, depth);

        if (!Elements.Contains(clean) || !string.Equals(element.NamespaceUri, "http://www.w3.org/1999/xhtml", StringComparison.Ordinal))
        {
            // Not in the specification, or not HTML at all (svg, mathml): keep it verbatim.
            builder.Append("new E(").Append(Literal(element.OuterHtml)).Append(')');
            return;
        }

        var method = options.Aliases && Ambiguous.Contains(clean) ? "e." + clean : clean;
        var arguments = element.Attributes.Select(x => Attribute(x, options)).ToList();
        var isVoid = IsVoidElement(clean);
        var children = isVoid ? [] : element.ChildNodes.Where(Renders).ToList();

        builder.Append(method).Append('(');

        if (children.Count == 0)
        {
            builder.Append(string.Join(", ", arguments)).Append(')');
            return;
        }

        if (arguments.Count > 0)
        {
            builder.Append(string.Join(", ", arguments)).Append(',');
        }

        // Only a single piece of text: keep the element on one line.
        if (children.Count == 1 && children[0] is not IElement && children[0] is not IComment)
        {
            if (arguments.Count > 0)
            {
                builder.Append(' ');
            }

            builder.Append(Literal(children[0].TextContent)).Append(')');
            return;
        }

        builder.Append(Environment.NewLine);

        for (var i = 0; i < children.Count; i++)
        {
            Write(builder, children[i], options, depth + 1);

            if (i < children.Count - 1)
            {
                builder.Append(',');
            }

            builder.Append(Environment.NewLine);
        }

        Indent(builder, options, depth);
        builder.Append(')');
    }

    private static string Attribute(IAttr attribute, ConvertOptions options)
    {
        var name = attribute.Name;
        var value = attribute.Value;

        if (name.StartsWith("data-", StringComparison.Ordinal) && name.Length > 5)
        {
            return $"data({Literal(name.Substring(5))}, {Literal(value)})";
        }

        var clean = name.CleanName();

        if (!AttributeNames.Contains(clean))
        {
            return $"new A({Literal(name)}, {Literal(value)})";
        }

        var method = options.Aliases && Ambiguous.Contains(clean) ? "a." + clean : clean;

        // A boolean attribute carries no value; the generated method takes none, regardless of what
        // the source HTML wrote as the value text (e.g. disabled="disabled").
        return IsBooleanAttribute(clean)
            ? $"{method}()"
            : $"{method}({Literal(value)})";
    }

    private static bool IsVoidElement(string clean)
    {
        return typeof(ElementType).GetMember(clean)[0].GetCustomAttribute<ElementAttribute>()?.IsVoidElement == true;
    }

    private static bool IsBooleanAttribute(string clean)
    {
        return typeof(AttributeType).GetMember(clean)[0].GetCustomAttributes<AttributeAttribute>()
            .Any(x => x.IsBooleanAttribute);
    }

    private static void Indent(StringBuilder builder, ConvertOptions options, int depth)
    {
        builder.Append(' ', options.Indent * depth);
    }

    private static string Literal(string? value)
    {
        value ??= string.Empty;

        var quotes = 0;
        var run = 0;

        foreach (var c in value)
        {
            run = c == '"' ? run + 1 : 0;
            quotes = Math.Max(quotes, run);
        }

        var multiline = value.IndexOfAny(NewLines) >= 0;

        // A raw string literal reads better when there is a lot to escape, but its content may not
        // start or end with a quote, and a single-line one may not contain a newline - so a multiline
        // value always falls through to the escaped literal below.
        if (quotes > 0
            && !multiline
            && !value.StartsWith('"')
            && !value.EndsWith('"'))
        {
            var fence = new string('"', Math.Max(3, quotes + 1));

            return fence + value + fence;
        }

        var builder = new StringBuilder(value.Length + 2).Append('"');

        foreach (var c in value)
        {
            switch (c)
            {
                case '"': builder.Append("\\\""); break;
                case '\\': builder.Append("\\\\"); break;
                case '\r': builder.Append("\\r"); break;
                case '\n': builder.Append("\\n"); break;
                case '\t': builder.Append("\\t"); break;
                default: builder.Append(c); break;
            }
        }

        return builder.Append('"').ToString();
    }
}
