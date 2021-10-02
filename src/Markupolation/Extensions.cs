using System;
using System.Linq;

namespace Markupolation
{
    public static class Extensions
    {
        public static string Each<T>(this T[] items, Func<string, string> tag)
        {
            return items.Select(x => tag(x.ToString())).ToArray().Join();
        }

        internal static string Join<T>(this T[] items, string separator = "") => string.Join(separator, items);

        internal static string Pad(this string content) => content.Any() ? " " + content : content;
    }
}
