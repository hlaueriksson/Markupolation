using System.Collections.Generic;

namespace Markupolation
{
    internal static class Extensions
    {
        internal static string Join<T>(this IEnumerable<T> items, string separator = "") => string.Join(separator, items);

        internal static string Pad(this string content) => content.Length > 0 ? " " + content : content;
    }
}
