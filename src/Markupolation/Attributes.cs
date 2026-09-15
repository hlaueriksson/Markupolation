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
    // Tab, LF, FF, CR, space, /, > and = all end an attribute name in the HTML tokenizer's
    // "attribute name" state, so any of them in a dynamic name would end data-{name} early and
    // start a new attribute (or close the tag) instead of becoming part of the name. Unlike a
    // value, a name is never quoted, so encoding does not help here - the character has to not
    // be there at all.
#if NET
    private static readonly SearchValues<char> UnsafeNameCharacters = SearchValues.Create("\t\n\f\r /=>");
#else
    private static readonly char[] UnsafeNameCharacters = ['\t', '\n', '\f', '\r', ' ', '/', '=', '>'];
#endif

    // The attribute equivalent of Content.Empty: one shared instance that renders nothing, for the
    // null name that has no attribute to build. Sharing is safe because Attribute never changes
    // after construction.
    private static readonly Attribute None = new(string.Empty);

    /// <summary>
    /// Custom data attribute.
    /// </summary>
    /// <remarks>
    /// Null tolerant, like the rest of the library: a null name has no attribute to build, so it
    /// renders nothing rather than throwing or emitting a nameless <c>data-</c>.
    /// </remarks>
    /// <param name="name">Attribute name suffix.</param>
    /// <param name="value">Attribute value.</param>
    /// <returns><c>data-{name}="{value}"</c></returns>
    public static Attribute data(string name, string value)
    {
        return name == null ? None : new($"data-{Nameable(name)}", value);
    }

    /// <inheritdoc cref="data(string, string)" />
    /// <remarks>
    /// The <c>object</c> overload every generated attribute has, so a data attribute renders a
    /// value the same way the rest of the library does - lowercase <c>true</c>, an invariant
    /// number, an ISO 8601 date. Without it the caller has to write <c>value.ToString()</c>, and a
    /// bool would reach the markup as <c>True</c>, which <c>dataset.x === "true"</c> does not match.
    /// </remarks>
    public static Attribute data(string name, object value)
    {
        return name == null ? None : new($"data-{Nameable(name)}", ValueFormatter.Format(value));
    }

    /// <summary>
    /// Makes a string safe to use as (part of) an attribute name, by replacing any character that
    /// would end the name early with <c>_</c>.
    /// </summary>
    private static string Nameable(string name)
    {
        // The common case needs nothing done to it, and is returned untouched - as HtmlEncoder does.
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
