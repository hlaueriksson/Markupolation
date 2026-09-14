using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markupolation;

/// <summary>
/// Extension methods for HTML content.
/// </summary>
public static class ContentExtensions
{
    /// <summary>
    /// Wraps each element in <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="content">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content Each<T>(this IEnumerable<T> values, Func<T, Content> content)
    {
        if (values == null || content == null)
        {
            return Content.Empty;
        }

        return Join(values, content);
    }

    /// <summary>
    /// Wraps each element in <see cref="Content"/> by incorporating the element's index.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="content">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content Each<T>(this IEnumerable<T> values, Func<T, int, Content> content)
    {
        if (values == null || content == null)
        {
            return Content.Empty;
        }

        return Join(values, content);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if the condition is met.
    /// </summary>
    /// <param name="condition">Condition.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content If(this bool condition, Content then)
    {
        return condition ? then : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if the condition is met; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <param name="condition">Condition.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <param name="otherwise">Fallback attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content If(this bool condition, Content then, Content otherwise)
    {
        return condition ? then : otherwise;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if the condition is met. The delegate is only invoked when it is.
    /// </summary>
    /// <param name="condition">Condition.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content If(this bool condition, Func<Content> then)
    {
        return condition ? Invoke(then) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if the condition is met; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <param name="condition">Condition.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content If(this bool condition, Func<Content> then, Func<Content> otherwise)
    {
        return condition ? Invoke(then) : Invoke(otherwise);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNull<T>(this T value, Content then)
    {
        return value == null ? then : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null. The delegate is only invoked when it is.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNull<T>(this T value, Func<Content> then)
    {
        return value == null ? Invoke(then) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNull<T>(this T value, Content then, Func<T, Content> otherwise)
    {
        return value == null ? then : Invoke(otherwise, value);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNull<T>(this T value, Func<Content> then, Func<T, Content> otherwise)
    {
        return value == null ? Invoke(then) : Invoke(otherwise, value);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is not null.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotNull<T>(this T value, Func<T, Content> then)
    {
        return value != null ? Invoke(then, value) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is not null; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotNull<T>(this T value, Func<T, Content> then, Content otherwise)
    {
        return value != null ? Invoke(then, value) : otherwise;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is not null; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotNull<T>(this T value, Func<T, Content> then, Func<Content> otherwise)
    {
        return value != null ? Invoke(then, value) : Invoke(otherwise);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null or empty.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNullOrEmpty(this string value, Content then)
    {
        return string.IsNullOrEmpty(value) ? then : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null or empty. The delegate is only invoked when it is.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNullOrEmpty(this string value, Func<Content> then)
    {
        return string.IsNullOrEmpty(value) ? Invoke(then) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null or empty; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNullOrEmpty(this string value, Content then, Func<string, Content> otherwise)
    {
        return string.IsNullOrEmpty(value) ? then : Invoke(otherwise, value);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is null or empty; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNullOrEmpty(this string value, Func<Content> then, Func<string, Content> otherwise)
    {
        return string.IsNullOrEmpty(value) ? Invoke(then) : Invoke(otherwise, value);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is not null or empty.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotNullOrEmpty(this string value, Func<string, Content> then)
    {
        return !string.IsNullOrEmpty(value) ? Invoke(then, value) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is not null or empty; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotNullOrEmpty(this string value, Func<string, Content> then, Content otherwise)
    {
        return !string.IsNullOrEmpty(value) ? Invoke(then, value) : otherwise;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value is not null or empty; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotNullOrEmpty(this string value, Func<string, Content> then, Func<Content> otherwise)
    {
        return !string.IsNullOrEmpty(value) ? Invoke(then, value) : Invoke(otherwise);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is empty.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfEmpty<T>(this IEnumerable<T> values, Content then)
    {
        return values?.Any() != true ? then : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is empty. The delegate is only invoked when it is.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfEmpty<T>(this IEnumerable<T> values, Func<Content> then)
    {
        return values?.Any() != true ? Invoke(then) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is empty; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfEmpty<T>(this IEnumerable<T> values, Content then, Func<IEnumerable<T>, Content> otherwise)
    {
        return values?.Any() != true ? then : Invoke(otherwise, values);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is empty; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfEmpty<T>(this IEnumerable<T> values, Func<Content> then, Func<IEnumerable<T>, Content> otherwise)
    {
        return values?.Any() != true ? Invoke(then) : Invoke(otherwise, values);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is not empty.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotEmpty<T>(this IEnumerable<T> values, Func<IEnumerable<T>, Content> then)
    {
        return values?.Any() == true ? Invoke(then, values) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is not empty; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotEmpty<T>(this IEnumerable<T> values, Func<IEnumerable<T>, Content> then, Content otherwise)
    {
        return values?.Any() == true ? Invoke(then, values) : otherwise;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if values is not empty; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <param name="values">Elements.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfNotEmpty<T>(this IEnumerable<T> values, Func<IEnumerable<T>, Content> then, Func<Content> otherwise)
    {
        return values?.Any() == true ? Invoke(then, values) : Invoke(otherwise);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value has value.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfHasValue<T>(this T? value, Func<T, Content> then)
        where T : struct
    {
        return value.HasValue ? Invoke(then, value.Value) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value has value; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfHasValue<T>(this T? value, Func<T, Content> then, Content otherwise)
        where T : struct
    {
        return value.HasValue ? Invoke(then, value.Value) : otherwise;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value has value; otherwise the fallback <see cref="Content"/>.
    /// Only the delegate for the branch that is taken is invoked.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfHasValue<T>(this T? value, Func<T, Content> then, Func<Content> otherwise)
        where T : struct
    {
        return value.HasValue ? Invoke(then, value.Value) : Invoke(otherwise);
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value match the condition.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfMatch<T>(this T value, Func<T, bool> predicate, Func<T, Content> then)
    {
        return predicate != null && predicate(value) ? Invoke(then, value) : Content.Empty;
    }

    /// <summary>
    /// Returns <see cref="Content"/> if value match the condition; otherwise the fallback <see cref="Content"/>.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="value">Value.</param>
    /// <param name="predicate">A function to test the value for a condition.</param>
    /// <param name="then">Attribute, element or content delegate.</param>
    /// <param name="otherwise">Fallback attribute, element or content delegate.</param>
    /// <returns><see cref="Content"/></returns>
    public static Content IfMatch<T>(this T value, Func<T, bool> predicate, Func<T, Content> then, Func<T, Content> otherwise)
    {
        if (predicate == null)
        {
            return Content.Empty;
        }

        return predicate(value) ? Invoke(then, value) : Invoke(otherwise, value);
    }

    /// <summary>
    /// Calls a branch delegate, or renders nothing when there is none. Every <c>If*</c> overload is
    /// null tolerant, and this is where that tolerance lives, so each body is left saying only which
    /// branch it takes.
    /// </summary>
    private static Content Invoke(Func<Content>? content) => content != null ? content() : Content.Empty;

    /// <inheritdoc cref="Invoke(Func{Content})"/>
    private static Content Invoke<T>(Func<T, Content>? content, T value) => content != null ? content(value) : Content.Empty;

    private static Content Join<T>(IEnumerable<T> values, Func<T, Content> content)
    {
        var builder = new StringBuilder();

        foreach (var value in values)
        {
            builder.Append(content(value)?.Value);
        }

        return Content.Raw(builder.ToString());
    }

    private static Content Join<T>(IEnumerable<T> values, Func<T, int, Content> content)
    {
        var builder = new StringBuilder();
        var index = 0;

        foreach (var value in values)
        {
            builder.Append(content(value, index++)?.Value);
        }

        return Content.Raw(builder.ToString());
    }
}
