using System;

namespace Markupolation
{
    public sealed record Attribute : Content
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attribute"/> class.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        public Attribute(string name, string value) : base(value)
        {
            Name = name;
        }

        internal Attribute(AttributeType type) : this(type, null)
        {
        }

        internal Attribute(AttributeType type, string? value) : base(value)
        {
            Name = type.ToString().TrimEnd('_').Replace("_", "-");
            Type = type;
        }

        /// <summary>
        /// Attribute name.
        /// </summary>
        public string Name { get; }

        internal AttributeType Type { get; }

        public static implicit operator string(Attribute value)
        {
            return value.ToString();
        }

        /// <inheritdoc/>
        public override string ToString() => Value is null ? $"{Name}" : $"{Name}=\"{Value}\"";
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    internal class AttributeAttribute : System.Attribute
    {
        public AttributeAttribute(string description, bool isGlobalAttribute, bool isBooleanAttribute, params string[] elements)
        {
            Description = description;
            IsGlobalAttribute = isGlobalAttribute;
            IsBooleanAttribute = isBooleanAttribute;
            Elements = elements;
        }

        public string Description { get; set; }

        public bool IsGlobalAttribute { get; set; }

        public bool IsBooleanAttribute { get; set; }

        public string[] Elements { get; set; }
    }
}
