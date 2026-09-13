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

    private static string ToString(AttributeType type, string? value = null)
    {
        return ToString(AttributeNames.Get(type), value);
    }

    private static string ToString(string name, string? value = null)
    {
        return value != null ? string.Concat(name, "=\"", HtmlEncoder.Encode(value), "\"") : name;
    }
}
