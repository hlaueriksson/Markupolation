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
    public override string ToString() =>
        base.ToString();

    private static string? ToString(AttributeType type, string? value) =>
        value == null ? null : ToString(AttributeNames.Get(type), value);

    private static string? ToString(string name, string? value = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            return null;
        }

        return value != null ? string.Concat(name, "=\"", HtmlEncoder.Encode(value), "\"") : name;
    }
}
