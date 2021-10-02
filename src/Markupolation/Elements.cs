using System.Linq;

namespace Markupolation
{
    public static partial class Elements
    {
        public static string DOCTYPE() => "<!DOCTYPE html>";

        private static Element NormalElement(ElementType type, Content[] content)
        {
            var attributes = content.OfType<Attribute>().ToArray();
            var children = content.Where(x => x.GetType() != typeof(Attribute)).ToArray();

            return new($"<{type}{attributes.Join(" ").Pad()}>{children.Join()}</{type}>");
        }

        private static Element VoidElement(ElementType type, Content[] content)
        {
            var attributes = content.OfType<Attribute>().ToArray();

            return new($"<{type}{attributes.Join(" ").Pad()} />");
        }
    }
}
