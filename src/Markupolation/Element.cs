using System.Linq;

namespace Markupolation
{
    /// <summary>
    /// HTML element.
    /// </summary>
    public sealed record Element : Content
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="value">Element value.</param>
        public Element(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="name">Element name.</param>
        /// <param name="isVoidElement"><c>true</c> to mark the element as self-closing; otherwise, <c>false</c>.</param>
        /// <param name="content">Attributes, elements and content.</param>
        public Element(string name, bool isVoidElement, params Content[] content)
            : base(ToString(name, isVoidElement, content))
        {
        }

        internal Element(ElementType type, bool isVoidElement, params Content[] content)
            : base(ToString(type, isVoidElement, content))
        {
            Type = type;
        }

        internal ElementType Type { get; }

        /// <summary>
        /// Converts <see cref="Element"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="value">The element.</param>
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
            var attributes = content.OfType<Attribute>();

            if (isVoidElement)
            {
                return $"<{name}{attributes.Join(" ").Pad()} />";
            }

            var children = content.Where(x => x.GetType() != typeof(Attribute));

            return $"<{name}{attributes.Join(" ").Pad()}>{children.Join()}</{name}>";
        }
    }
}
