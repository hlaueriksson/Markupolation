using System;

namespace Markupolation
{
    public sealed record Element : Content
    {
        public Element(string value) : base(value)
        {
        }

        public override string ToString() => base.ToString();

        public static implicit operator string(Element value)
        {
            return value.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal class ElementAttribute : System.Attribute
    {
        public ElementAttribute(string description, bool isVoidElement, params string[] attributes)
        {
            Description = description;
            IsVoidElement = isVoidElement;
            Attributes = attributes;
        }

        public string Description { get; set; }
        public bool IsVoidElement { get; set; }
        public string[] Attributes { get; set; }
    }
}
