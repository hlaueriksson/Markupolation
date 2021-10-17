using System;

namespace Markupolation
{
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
    public sealed record Attribute : Content
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attribute"/> class.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        public Attribute(string name, string? value = null) : base(ToString(name, value))
        {
        }

        internal Attribute(AttributeType type, string? value = null) : base(ToString(type, value))
        {
            Type = type;
        }

        internal AttributeType Type { get; }

        public static implicit operator string(Attribute value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        /// <inheritdoc/>
        public override string ToString() => base.ToString();

        private static string ToString(AttributeType type, string? value = null)
        {
            return ToString(type.ToString().TrimEnd('_').Replace("_", "-"), value);
        }

        private static string ToString(string name, string? value = null)
        {
            return value != null ? $"{name}=\"{value}\"" : $"{name}";
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    internal sealed class AttributeAttribute : System.Attribute
    {
        public AttributeAttribute(string description, bool isGlobalAttribute, bool isBooleanAttribute, params string[] elements)
        {
            Description = description;
            IsGlobalAttribute = isGlobalAttribute;
            IsBooleanAttribute = isBooleanAttribute;
            Elements = elements;
        }

        public string Description { get; }

        public bool IsGlobalAttribute { get; }

        public bool IsBooleanAttribute { get; }

        public string[] Elements { get; }
    }
}
