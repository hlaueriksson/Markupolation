using System;
#if NET
using System.Buffers;
#endif
using System.Text;

namespace Markupolation;

/// <summary>
/// HTML attributes.
/// </summary>
public static partial class Attributes
{
#if NET
    private static readonly SearchValues<char> UnsafeNameCharacters = SearchValues.Create("\t\n\f\r /=>");
#else
    private static readonly char[] UnsafeNameCharacters = ['\t', '\n', '\f', '\r', ' ', '/', '=', '>'];
#endif

    private static readonly Attribute None = new(string.Empty);

    /// <summary>
    /// Custom data attribute.
    /// </summary>
    /// <param name="name">Attribute name suffix.</param>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>data-{name}="{value}"</c></returns>
    public static Attribute data(string name, string value)
    {
        var suffix = Nameable(name);

        return string.IsNullOrEmpty(suffix) ? None : new($"data-{suffix}", value);
    }

    /// <inheritdoc cref="data(string, string)" />
    public static Attribute data(string name, object value)
    {
        var suffix = Nameable(name);

        return string.IsNullOrEmpty(suffix) ? None : new($"data-{suffix}", ValueFormatter.Format(value));
    }

    /// <summary>
    /// Makes a string safe to use as (part of) a data attribute name, by replacing any character
    /// that would end the name early with <c>-</c>.
    /// </summary>
    private static string Nameable(string name)
    {
        // The common case needs nothing done to it, and is returned untouched - as HtmlEncoder does.
        if (string.IsNullOrEmpty(name) || IndexOfUnsafeCharacter(name) < 0)
        {
            return name;
        }

        var builder = new StringBuilder(name.Length);
        var pending = false;

        foreach (var c in name)
        {
            if (IsUnsafeCharacter(c))
            {
                // Held back rather than written: a run collapses into the single separator appended
                // below, and a run at the end is simply never flushed.
                pending = true;
                continue;
            }

            if (pending && builder.Length > 0)
            {
                // The length check is what drops a leading run - there is nothing to separate yet.
                builder.Append('-');
            }

            pending = false;
            builder.Append(c);
        }

        return builder.ToString();
    }

    private static bool IsUnsafeCharacter(char c)
    {
#if NET
        return UnsafeNameCharacters.Contains(c);
#else
        return Array.IndexOf(UnsafeNameCharacters, c) >= 0;
#endif
    }

    private static int IndexOfUnsafeCharacter(string name)
    {
#if NET
        return name.AsSpan().IndexOfAny(UnsafeNameCharacters);
#else
        return name.IndexOfAny(UnsafeNameCharacters);
#endif
    }
}
