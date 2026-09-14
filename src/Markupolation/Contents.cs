using System;
using System.Text;

namespace Markupolation;

/// <summary>
/// HTML content.
/// </summary>
/// <remarks>
/// The markup that is neither an element nor an attribute, and so is hand-written rather than
/// generated from the specification. Imported with a static using alongside <see cref="Elements"/>
/// and <see cref="Attributes"/>, so it reads inline with the rest of the API:
/// <c>DOCTYPE() + html(body(comment("content here"), p("Hello")))</c>.
/// </remarks>
public static class Contents
{
    private static readonly Content Doctype = Content.Raw("<!DOCTYPE html>");

    private static readonly Content EmptyComment = Content.Raw("<!---->");

    /// <summary>
    /// DOCTYPE.
    /// </summary>
    /// <remarks>
    /// Not an element - it is a document type declaration, and not in the element index the rest of
    /// <see cref="Elements"/> is generated from. <see cref="Content"/> rather than
    /// <see cref="string"/>, so that <c>DOCTYPE() + html(...)</c> composes as markup; a raw
    /// <see cref="string"/> here would be text, and encoded.
    /// </remarks>
    /// <returns><c><![CDATA[<!DOCTYPE html>]]></c></returns>
    public static Content DOCTYPE() => Doctype;

    /// <summary>
    /// Comment.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A comment looks like text but is markup, so it cannot be written as one - <c>body("&lt;!-- x
    /// --&gt;")</c> shows up on the page as literal text.
    /// </para>
    /// <para>
    /// Encoding is not the answer either: the HTML parser does not decode character references
    /// inside a comment, so <c>&amp;lt;</c> would appear as it is and <c>--&gt;</c> would still end
    /// the comment early and let the rest of the text into the document as markup. The sequences
    /// the specification forbids are broken up with a space instead, which is why this is safe for
    /// text that came from a user where <see cref="raw(string?)"/> is not.
    /// </para>
    /// </remarks>
    /// <param name="value">Comment text.</param>
    /// <returns><c><![CDATA[<!--{value}-->]]></c></returns>
    public static Content comment(string? value)
    {
        return string.IsNullOrEmpty(value)
            ? EmptyComment
            : Content.Raw(string.Concat("<!--", Commentable(value!), "-->"));
    }

    /// <summary>
    /// Wraps a string that is already markup, without encoding it.
    /// </summary>
    /// <remarks>
    /// The unqualified spelling of <see cref="Content.Raw(string?)"/>, the way <c>div</c> is the
    /// unqualified spelling of <see cref="Elements"/>.<c>div</c>.
    /// </remarks>
    /// <param name="value">Markup.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content raw(string? value) => Content.Raw(value);

    /// <summary>
    /// Makes text safe to sit inside a comment, per the authoring requirements: it must not start
    /// with <c>&gt;</c> or <c>-&gt;</c>, contain <c>&lt;!--</c>, <c>--&gt;</c> or <c>--!&gt;</c>,
    /// or end with <c>&lt;!-</c>.
    /// </summary>
    private static string Commentable(string value)
    {
        // The common case needs nothing done to it, and is returned untouched - as HtmlEncoder does.
        if (!StartsUnsafe(value) && !EndsUnsafe(value) && value.IndexOf("--", StringComparison.Ordinal) < 0)
        {
            return value;
        }

        var builder = new StringBuilder(value.Length + 2);

        if (StartsUnsafe(value))
        {
            builder.Append(' ');
        }

        // No two dashes in a row covers <!--, --> and --!> at once.
        foreach (var c in value)
        {
            if (c == '-' && builder.Length > 0 && builder[builder.Length - 1] == '-')
            {
                builder.Append(' ');
            }

            builder.Append(c);
        }

        if (EndsUnsafe(builder))
        {
            builder.Append(' ');
        }

        return builder.ToString();
    }

    private static bool StartsUnsafe(string value)
    {
        return value[0] == '>' || (value.Length > 1 && value[0] == '-' && value[1] == '>');
    }

    private static bool EndsUnsafe(string value)
    {
        return value.EndsWith("<!-", StringComparison.Ordinal);
    }

    private static bool EndsUnsafe(StringBuilder builder)
    {
        return builder.Length >= 3
            && builder[builder.Length - 3] == '<'
            && builder[builder.Length - 2] == '!'
            && builder[builder.Length - 1] == '-';
    }
}
