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
        return string.IsNullOrEmpty(name) ? None : new($"data-{Nameable(name)}", value);
    }

    /// <inheritdoc cref="data(string, string)" />
    public static Attribute data(string name, object value)
    {
        return string.IsNullOrEmpty(name) ? None : new($"data-{Nameable(name)}", ValueFormatter.Format(value));
    }

    /// <summary>
    /// Makes a string safe to use as (part of) an attribute name, by replacing any character that
    /// would end the name early with <c>_</c>.
    /// </summary>
    private static string Nameable(string name)
    {
        if (IndexOfUnsafeCharacter(name) < 0)
        {
            return name;
        }

        var builder = new StringBuilder(name.Length);

        foreach (var c in name)
        {
            builder.Append(IsUnsafeCharacter(c) ? '_' : c);
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
