using System;

namespace Markupolation
{
    public sealed record Element : Content
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="value">Element value.</param>
        public Element(string value) : base(value)
        {
        }

        public static implicit operator string(Element value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        /// <inheritdoc/>
        public override string ToString() => base.ToString();
    }

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
