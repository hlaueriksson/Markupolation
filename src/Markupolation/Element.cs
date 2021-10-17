using System;
using System.Linq;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="name">Element name.</param>
        /// <param name="isVoidElement"><c>true</c> to mark the element as self-closing; otherwise, <c>false</c>.</param>
        /// <param name="content">Attributes, elements and content.</param>
        public Element(string name, bool isVoidElement, params Content[] content) : base(ToString(name, isVoidElement, content))
        {
        }

        internal Element(ElementType type, bool isVoidElement, params Content[] content) : base(ToString(type, isVoidElement, content))
        {
            Type = type;
        }

        internal ElementType Type { get; }

        public static implicit operator string(Element value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        /// <inheritdoc/>
        public override string ToString() => base.ToString();

        private static string ToString(ElementType type, bool isVoidElement, Content[] content)
        {
            return ToString(type.ToString().TrimEnd('_'), isVoidElement, content);
        }

        private static string ToString(string name, bool isVoidElement, Content[] content)
        {
            var attributes = content.OfType<Attribute>().ToArray();

            if (isVoidElement)
            {
                return $"<{name}{attributes.Join(" ").Pad()} />";
            }

            var children = content.Where(x => x.GetType() != typeof(Attribute)).ToArray();

            return $"<{name}{attributes.Join(" ").Pad()}>{children.Join()}</{name}>";
        }
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
