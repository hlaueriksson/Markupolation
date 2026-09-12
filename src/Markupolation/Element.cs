#if NET
using System;
#else
using System.Text;
#endif

namespace Markupolation;

/// <summary>
/// HTML element.
/// </summary>
public sealed record Element : Content
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> class.
    /// </summary>
    /// <param name="value">Element value.</param>
    public Element(string value)
        : base(value)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> class.
    /// </summary>
    /// <param name="name">Element name.</param>
    /// <param name="isVoidElement"><c>true</c> to mark the element as self-closing; otherwise, <c>false</c>.</param>
    /// <param name="content">Attributes, elements and content.</param>
    public Element(string name, bool isVoidElement, params Content[] content)
        : base(ToString(name, isVoidElement, content))
    {
    }

    internal Element(ElementType type, bool isVoidElement, params Content[] content)
        : base(ToString(ElementNames.Get(type), isVoidElement, content))
    {
        Type = type;
    }

    internal ElementType Type { get; }

    /// <summary>
    /// Converts <see cref="Element"/> to <see cref="string"/>.
    /// </summary>
    /// <param name="value">The element.</param>
    public static implicit operator string(Element value)
    {
        return value != null ? value.ToString() : string.Empty;
    }

    /// <inheritdoc/>
    public override string ToString() => base.ToString();

    private static string ToString(string name, bool isVoidElement, Content[] content)
    {
        var length = Length(name, isVoidElement, content);

#if NET
        return string.Create(length, (name, isVoidElement, content), static (destination, state) => Write(destination, state.name, state.isVoidElement, state.content));
#else
        var builder = new StringBuilder(length);

        builder.Append('<').Append(name);

        for (var i = 0; i < content.Length; i++)
        {
            if (content[i] is Attribute attribute && attribute.Value != null)
            {
                builder.Append(' ').Append(attribute.Value);
            }
        }

        if (isVoidElement)
        {
            return builder.Append(" />").ToString();
        }

        builder.Append('>');

        for (var i = 0; i < content.Length; i++)
        {
            if (content[i] is not Attribute)
            {
                builder.Append(content[i]?.Value);
            }
        }

        return builder.Append("</").Append(name).Append('>').ToString();
#endif
    }

#if NET
    private static void Write(Span<char> destination, string name, bool isVoidElement, Content[] content)
    {
        var position = 0;

        destination[position++] = '<';
        name.AsSpan().CopyTo(destination.Slice(position));
        position += name.Length;

        for (var i = 0; i < content.Length; i++)
        {
            if (content[i] is Attribute attribute && attribute.Value is { } attributeValue)
            {
                destination[position++] = ' ';
                attributeValue.AsSpan().CopyTo(destination.Slice(position));
                position += attributeValue.Length;
            }
        }

        if (isVoidElement)
        {
            " />".AsSpan().CopyTo(destination.Slice(position));
            return;
        }

        destination[position++] = '>';

        for (var i = 0; i < content.Length; i++)
        {
            if (content[i] is not Attribute && content[i]?.Value is { } childValue)
            {
                childValue.AsSpan().CopyTo(destination.Slice(position));
                position += childValue.Length;
            }
        }

        "</".AsSpan().CopyTo(destination.Slice(position));
        position += 2;
        name.AsSpan().CopyTo(destination.Slice(position));
        position += name.Length;
        destination[position] = '>';
    }
#endif

    /// <summary>
    /// Calculates the exact rendered length, so the buffer is allocated once and never grows.
    /// </summary>
    private static int Length(string name, bool isVoidElement, Content[] content)
    {
        // <name /> or <name></name>
        var length = isVoidElement ? name.Length + 4 : (name.Length * 2) + 5;

        for (var i = 0; i < content.Length; i++)
        {
            var value = content[i]?.Value;

            if (value == null)
            {
                continue;
            }

            if (content[i] is Attribute)
            {
                length += value.Length + 1; // separating space
            }
            else if (!isVoidElement)
            {
                length += value.Length;
            }
        }

        return length;
    }
}
