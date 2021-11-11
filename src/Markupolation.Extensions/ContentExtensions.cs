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
        /// Returns <see cref="Content"/> if value is null; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNull<T>(this T value, Content then, Func<T, Content> otherwise)
        {
            return value == null ? then : otherwise != null ? otherwise(value) : string.Empty;
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
        /// Returns <see cref="Content"/> if value is not null; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <param name="otherwise">Fallback attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNotNull<T>(this T value, Func<T, Content> then, Content otherwise)
        {
            return value != null && then != null ? then(value) : value == null ? otherwise : string.Empty;
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
        /// Returns <see cref="Content"/> if value is null or empty; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfNullOrEmpty(this string value, Content then, Func<string, Content> otherwise)
        {
            return string.IsNullOrEmpty(value) ? then : otherwise != null ? otherwise(value) : string.Empty;
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
        /// Returns <see cref="Content"/> if value is not null or empty; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <param name="otherwise">Fallback attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNotNullOrEmpty(this string value, Func<string, Content> then, Content otherwise)
        {
            return !string.IsNullOrEmpty(value) && then != null ? then(value) : string.IsNullOrEmpty(value) ? otherwise : string.Empty;
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
        /// Returns <see cref="Content"/> if value is empty; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content.</param>
        /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfEmpty<T>(this IEnumerable<T> value, Content then, Func<IEnumerable<T>, Content> otherwise)
        {
            return value?.Any() != true ? then : otherwise != null ? otherwise(value) : string.Empty;
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
        /// Returns <see cref="Content"/> if value is not empty; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <param name="otherwise">Fallback attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfNotEmpty<T>(this IEnumerable<T> value, Func<IEnumerable<T>, Content> then, Content otherwise)
        {
            return value?.Any() == true && then != null ? then(value) : value?.Any() != true ? otherwise : string.Empty;
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
        /// Returns <see cref="Content"/> if value has value; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <param name="otherwise">Fallback attribute, element or content.</param>
        /// <returns>Content.</returns>
        public static Content IfHasValue<T>(this T? value, Func<T, Content> then, Content otherwise)
            where T : struct
        {
            return value.HasValue && then != null ? then(value.Value) : !value.HasValue ? otherwise : string.Empty;
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

        /// <summary>
        /// Returns <see cref="Content"/> if value match expression; otherwise the fallback <see cref="Content"/>.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="predicate">Predicate.</param>
        /// <param name="then">Attribute, element or content delegate.</param>
        /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
        /// <returns>Content.</returns>
        public static Content IfMatch<T>(this T value, Expression<Func<T, bool>> predicate, Func<T, Content> then, Func<T, Content> otherwise)
        {
            if (predicate == null)
            {
                return string.Empty;
            }

            return predicate.Compile()(value) && then != null ? then(value) : !predicate.Compile()(value) && otherwise != null ? otherwise(value) : string.Empty;
        }
    }
}
