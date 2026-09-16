using System;
using System.Text;

namespace Markupolation;

/// <summary>
/// HTML content.
/// </summary>
public static class Contents
{
    private static readonly Content Doctype = Content.Raw("<!DOCTYPE html>");

    private static readonly Content EmptyComment = Content.Raw("<!---->");

    /// <summary>
    /// DOCTYPE.
    /// </summary>
    /// <remarks>A document type declaration.</remarks>
    /// <returns><c><![CDATA[<!DOCTYPE html>]]></c></returns>
    public static Content DOCTYPE() => Doctype;

    /// <summary>
    /// Comment.
    /// </summary>
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
    /// The unqualified spelling of <see cref="Content.Raw(string?)"/>.
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
