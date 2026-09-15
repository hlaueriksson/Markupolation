using System;

namespace Markupolation;

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
internal sealed class ElementAttribute(string description, params AttributeType[] attributes) : System.Attribute
{
    public string Description { get; } = description;

    public bool IsVoidElement { get; set; }

    public AttributeType[] Attributes { get; } = attributes;
}
