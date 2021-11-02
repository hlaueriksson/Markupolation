using System;

namespace Markupolation
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal sealed class ElementAttribute : System.Attribute
    {
        public ElementAttribute(string description, bool isVoidElement, params string[] attributes)
        {
            Description = description;
            IsVoidElement = isVoidElement;
            Attributes = attributes;
        }

        public string Description { get; }

        public bool IsVoidElement { get; }

        public string[] Attributes { get; }
    }
}
