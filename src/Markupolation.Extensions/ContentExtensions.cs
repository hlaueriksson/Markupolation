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
        /// <param name="content">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNull<T>(this T value, Content content)
        {
            return value == null ? content : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is not null.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNotNull<T>(this T value, Func<T, Content> content)
        {
            return value != null && content != null ? content(value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is null or empty.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNullOrEmpty(this string value, Content content)
        {
            return string.IsNullOrEmpty(value) ? content : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is not null or empty.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNotNullOrEmpty(this string value, Func<string, Content> content)
        {
            return !string.IsNullOrEmpty(value) && content != null ? content(value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is empty.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfEmpty<T>(this IEnumerable<T> value, Content content)
        {
            return value?.Any() != true ? content : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value is not empty.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNotEmpty<T>(this IEnumerable<T> value, Func<IEnumerable<T>, Content> content)
        {
            return value?.Any() == true && content != null ? content(value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value has value.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfHasValue<T>(this T? value, Func<T, Content> content)
            where T : struct
        {
            return value.HasValue && content != null ? content(value.Value) : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value not has value.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="content">Attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNotHasValue<T>(this T? value, Content content)
            where T : struct
        {
            return !value.HasValue ? content : string.Empty;
        }

        /// <summary>
        /// Returns <see cref="Content"/> if value match expression.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="predicate">Predicate.</param>
        /// <param name="content">Attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfMatch<T>(this T value, Expression<Func<T, bool>> predicate, Func<T, Content> content)
        {
            return predicate?.Compile()(value) == true && content != null ? content(value) : string.Empty;
        }
    }
}
