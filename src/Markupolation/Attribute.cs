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

    internal Attribute(AttributeType type, string? value = null)
        : base(ToString(type, value))
    {
        Type = type;
    }

    internal AttributeType Type { get; }

    /// <inheritdoc/>
    public override string ToString() => base.ToString();

    private static string? ToString(AttributeType type, string? value = null)
    {
        // A boolean attribute's own generated method never passes a value, so null here is the
        // intentional default and still renders bare. For every other attribute, null means the
        // caller passed one in (typically a nullable property) - that omits the attribute entirely
        // rather than rendering a bare one, which Element already does for any Attribute whose
        // Value is null.
        if (value == null && !AttributeBooleanness.Get(type))
        {
            return null;
        }

        return ToString(AttributeNames.Get(type), value);
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
