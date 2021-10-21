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
        /// Wraps each item in <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of items.</typeparam>
        /// <param name="items">Items.</param>
        /// <param name="content">Content delegate.</param>
        /// <returns>Content.</returns>
        public static Content Each<T>(this T[] items, Func<T, Content> content)
        {
            return items.Select(x => content(x)).ToArray().Join();
        }

        internal static string Join<T>(this T[] items, string separator = "") => string.Join(separator, items);

        internal static string Pad(this string content) => content.Length > 0 ? " " + content : content;
    }
}
