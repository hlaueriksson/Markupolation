using System;

namespace Markupolation
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal sealed class ElementAttribute(string description, bool isVoidElement, params AttributeType[] attributes) : System.Attribute
    {
        public string Description { get; } = description;

        public bool IsVoidElement { get; } = isVoidElement;

        public AttributeType[] Attributes { get; } = attributes;
    }
}
