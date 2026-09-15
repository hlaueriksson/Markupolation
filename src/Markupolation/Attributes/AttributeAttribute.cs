using System;

namespace Markupolation;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
internal sealed class AttributeAttribute(string description, params ElementType[] elements) : System.Attribute
{
    public string Description { get; } = description;

    public bool IsGlobalAttribute { get; set; }

    public bool IsBooleanAttribute { get; set; }

    public bool IsEmptyStringValid { get; set; }

    public ElementType[] Elements { get; } = elements;
}
