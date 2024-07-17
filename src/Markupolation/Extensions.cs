using System.Collections.Generic;

namespace Markupolation
{
    internal static class Extensions
    {
        internal static string Join<T>(this IEnumerable<T> items, string? separator = null) => string.Join(separator, items);

        internal static string Pad(this string content) => content.Length > 0 ? Constants.Space + content : content;
    }
}
