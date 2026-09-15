namespace Markupolation;

/// <summary>
/// HTML attribute.
/// </summary>
public sealed record Attribute : Content
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Attribute"/> class.
    /// </summary>
    /// <param name="name">Attribute name.</param>
    /// <param name="value">Attribute value.</param>
    public Attribute(string name, string? value = null)
        : base(ToString(name, value))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Attribute"/> class, written bare with no value
    /// at all.
    /// </summary>
    /// <remarks>
    /// What separates <c>required()</c> and <c>hidden()</c> from <c>hidden(someNullableString)</c>:
    /// the arity says "there is no value here" outright, so a null arriving at the constructor
    /// below can keep meaning "the caller had nothing to say" and omit the attribute. Both a
    /// boolean attribute and one whose specification lists the empty string among its values are
    /// written this way - bare and <c>=""</c> are the same thing once parsed.
    /// </remarks>
    /// <param name="type">Attribute type.</param>
    internal Attribute(AttributeType type)
        : base(AttributeNames.Get(type))
    {
        Type = type;
    }

    internal Attribute(AttributeType type, string? value)
        : base(ToString(type, value))
    {
        Type = type;
    }

    internal AttributeType Type { get; }

    /// <inheritdoc/>
    public override string ToString() => base.ToString();

    private static string? ToString(AttributeType type, string? value)
    {
        // Reaching here at all means a value was passed, so a null one came from the caller -
        // typically a nullable property with nothing in it. That omits the attribute entirely
        // rather than rendering a bare one, which Element already does for any Attribute whose
        // Value is null. Anything meant to be bare uses the constructor above instead.
        return value == null ? null : ToString(AttributeNames.Get(type), value);
    }

    private static string? ToString(string name, string? value = null)
    {
        // An attribute with no name is not an attribute, so it renders nothing at all - the same
        // "no value to render" state a null value produces above, which Element skips. Without
        // this, a null name concatenates into ="value" and lands in the tag as markup.
        if (string.IsNullOrEmpty(name))
        {
            return null;
        }

        return value != null ? string.Concat(name, "=\"", HtmlEncoder.Encode(value), "\"") : name;
    }
}
