using System;

namespace Markupolation;

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
internal sealed class ElementAttribute(string description, params AttributeType[] attributes) : System.Attribute
{
    public string Description { get; } = description;

    // Named rather than positional, so the generated enum carries it only where it is true - see
    // AttributeAttribute for the same reasoning.
    public bool IsVoidElement { get; set; }

    public AttributeType[] Attributes { get; } = attributes;
}
