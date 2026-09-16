using System;
using System.Diagnostics;

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
    /// <param name="isVoidElement"><see langword="true"/> to mark the element as self-closing; otherwise, <see langword="false"/>.</param>
    /// <param name="content">Attributes, elements and content.</param>
    public Element(string name, bool isVoidElement, params Content[] content)
        : base(ToString(name, isVoidElement, false, content))
    {
    }

    internal Element(ElementType type, bool isVoidElement, params Content[] content)
        : base(ToString(ElementNames.Get(type), isVoidElement, ElementRawText.Get(type), content))
    {
        Type = type;
    }

    internal ElementType Type { get; }

    /// <inheritdoc/>
    public override string ToString() => base.ToString();

    private static string ToString(string name, bool isVoidElement, bool isRawTextElement, Content[] content)
    {
        return string.Create(
            Length(name, isVoidElement, isRawTextElement, content),
            (name, isVoidElement, isRawTextElement, content),
            static (destination, state) => Write(destination, state.name, state.isVoidElement, state.isRawTextElement, state.content));
    }

    /// <summary>
    /// The text a child renders as. Inside a raw text element (<c>script</c>, <c>style</c>) that is
    /// the unencoded original, because the HTML parser does not decode character references there.
    /// </summary>
    private static string? ChildValue(Content? child, bool isRawTextElement)
    {
        return isRawTextElement ? child?.Unencoded ?? child?.Value : child?.Value;
    }

    private static void Write(Span<char> destination, string name, bool isVoidElement, bool isRawTextElement, Content[] content)
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
            Debug.Assert(position + 3 == destination.Length, "Length must match what Write emits.");
            return;
        }

        destination[position++] = '>';

        for (var i = 0; i < content.Length; i++)
        {
            if (content[i] is not Attribute && ChildValue(content[i], isRawTextElement) is { } childValue)
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
        Debug.Assert(position == destination.Length - 1, "Length must match what Write emits.");
    }

    /// <summary>
    /// Calculates the exact rendered length, so the buffer is allocated once and never grows.
    /// <see cref="Write"/> must skip exactly what this skips.
    /// </summary>
    private static int Length(string name, bool isVoidElement, bool isRawTextElement, Content[] content)
    {
        // <name /> or <name></name>
        var length = isVoidElement ? name.Length + 4 : (name.Length * 2) + 5;

        for (var i = 0; i < content.Length; i++)
        {
            var value = content[i] is Attribute ? content[i].Value : ChildValue(content[i], isRawTextElement);

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
