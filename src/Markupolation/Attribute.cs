using System;

namespace Markupolation
{
    public sealed record Attribute : Content
    {
        public Attribute(string name, string value) : base(value)
        {
            Name = name;
        }

        internal Attribute(AttributeType type) : base()
        {
            Name = type.ToString();
            Type = type;
        }

        internal Attribute(AttributeType type, string value) : base(value)
        {
            Name = type.ToString();
            Type = type;
        }

        public string Name { get; }

        internal AttributeType Type { get; }

        public override string ToString() => Value is null ? $"{Name}" : $"{Name}=\"{Value}\"";

        public static implicit operator string(Attribute value)
        {
            return value.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal class GlobalAttribute : System.Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal class BooleanAttribute : System.Attribute
    {
    }
}
