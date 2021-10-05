using System;
using System.Linq;

namespace Markupolation
{
    /// <summary>
    /// Extension methods for HTML templating.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Wraps each item in an <see cref="Element"/>.
        /// </summary>
        /// <typeparam name="T">Type of items.</typeparam>
        /// <param name="items">Items.</param>
        /// <param name="element">Element delegate.</param>
        /// <returns>Content.</returns>
        public static string Each<T>(this T[] items, Func<string, Element> element)
        {
            return items.Select(x => element(x!.ToString())).ToArray().Join();
        }

        internal static string Join<T>(this T[] items, string separator = "") => string.Join(separator, items);

        internal static string Pad(this string content) => content.Any() ? " " + content : content;
    }
}
