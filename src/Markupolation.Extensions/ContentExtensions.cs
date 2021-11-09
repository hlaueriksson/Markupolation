using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Markupolation
{
    /// <summary>
    /// Extension methods for HTML content.
    /// </summary>
    public static class ContentExtensions
    {
        /// <summary>
        /// Wraps each element in <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Elements.</param>
        /// <param name="content">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content Each<T>(this IEnumerable<T> value, Func<T, Content> content)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.Select(x => content(x)).Join();
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is null.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNull<T>(this T value, Content then)
        {
            return value == null ? then : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is not null.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNotNull<T>(this T value, Func<T, Content> then)
        {
            return value != null && then != null ? then(value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is null or empty.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNullOrEmpty(this string value, Content then)
        {
            return string.IsNullOrEmpty(value) ? then : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is not null or empty.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNotNullOrEmpty(this string value, Func<string, Content> then)
        {
            return !string.IsNullOrEmpty(value) && then != null ? then(value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is empty.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfEmpty<T>(this IEnumerable<T> value, Content then)
        {
            return value?.Any() != true ? then : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is not empty.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNotEmpty<T>(this IEnumerable<T> value, Func<IEnumerable<T>, Content> then)
        {
            return value?.Any() == true && then != null ? then(value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value has value.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfHasValue<T>(this T? value, Func<T, Content> then)
            where T : struct
        {
            return value.HasValue && then != null ? then(value.Value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value not has value.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNotHasValue<T>(this T? value, Content then)
            where T : struct
        {
            return !value.HasValue ? then : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value match expression.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="predicate">Predicate.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfMatch<T>(this T value, Expression<Func<T, bool>> predicate, Func<T, Content> then)
        {
            return predicate?.Compile()(value) == true && then != null ? then(value) : string.Empty;
        }
    }
}
