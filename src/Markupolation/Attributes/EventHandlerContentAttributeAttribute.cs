using System;

namespace Markupolation
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal sealed class EventHandlerContentAttributeAttribute : System.Attribute
    {
        public EventHandlerContentAttributeAttribute(string description, params ElementType[] elements)
        {
            Description = description;
            Elements = elements;
        }

        public string Description { get; }

        public ElementType[] Elements { get; }
    }
}
