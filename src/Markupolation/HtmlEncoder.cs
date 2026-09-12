#if NET
using System;
using System.Buffers;
#endif
using System.Text;

namespace Markupolation;

/// <summary>
/// Encodes the characters that would otherwise let text break out of markup.
/// </summary>
internal static class HtmlEncoder
{
    // & < > must be encoded in text; & " must be encoded inside a double-quoted attribute value.
    // One set covers both. ' is not encoded because attribute values are always double-quoted.
    private const string CharactersToEncode = "&<>\"";

#if NET
    private static readonly SearchValues<char> Search = SearchValues.Create(CharactersToEncode);
#else
    private static readonly char[] Search = CharactersToEncode.ToCharArray();
#endif

    /// <summary>
    /// Encodes <c>&amp;</c>, <c>&lt;</c>, <c>&gt;</c> and <c>"</c>.
    /// </summary>
    /// <param name="value">The text to encode.</param>
    /// <returns>The encoded text, or the same instance when there is nothing to encode.</returns>
    internal static string? Encode(string? value)
    {
        if (value == null)
        {
            return null;
        }

        var index = IndexOfCharacterToEncode(value);

        if (index < 0)
        {
            // The overwhelming majority of content encodes to itself; do not allocate for it.
            return value;
        }

        var builder = new StringBuilder(value.Length + 16);
        builder.Append(value, 0, index);

        for (var i = index; i < value.Length; i++)
        {
            switch (value[i])
            {
                case '&': builder.Append("&amp;"); break;
                case '<': builder.Append("&lt;"); break;
                case '>': builder.Append("&gt;"); break;
                case '"': builder.Append("&quot;"); break;
                default: builder.Append(value[i]); break;
            }
        }

        return builder.ToString();
    }

    private static int IndexOfCharacterToEncode(string value)
    {
#if NET
        return value.AsSpan().IndexOfAny(Search);
#else
        return value.IndexOfAny(Search);
#endif
    }
}
