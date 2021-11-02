using System;

namespace Markupolation
{
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
