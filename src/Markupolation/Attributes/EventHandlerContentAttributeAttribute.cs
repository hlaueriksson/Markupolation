using System;

namespace Markupolation
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal sealed class EventHandlerContentAttributeAttribute(string description, params ElementType[] elements) : System.Attribute
    {
        public string Description { get; } = description;

        public ElementType[] Elements { get; } = elements;
    }
}
