using System;

namespace Markupolation
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    internal sealed class AttributeAttribute(string description, bool isGlobalAttribute, bool isBooleanAttribute, params ElementType[] elements) : System.Attribute
    {
        public string Description { get; } = description;

        public bool IsGlobalAttribute { get; } = isGlobalAttribute;

        public bool IsBooleanAttribute { get; } = isBooleanAttribute;

        public ElementType[] Elements { get; } = elements;
    }
}
