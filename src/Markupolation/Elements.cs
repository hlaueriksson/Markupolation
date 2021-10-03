using System.Linq;

namespace Markupolation
{
    public static partial class Elements
    {
        public static string DOCTYPE() => "<!DOCTYPE html>";

        private static Element NormalElement(ElementType type, Content[] content)
        {
            var name = type.ToString().TrimEnd('_');
            var attributes = content.OfType<Attribute>().ToArray();
            var children = content.Where(x => x.GetType() != typeof(Attribute)).ToArray();

            return new($"<{name}{attributes.Join(" ").Pad()}>{children.Join()}</{name}>");
        }

        private static Element VoidElement(ElementType type, Content[] content)
        {
            var name = type.ToString().TrimEnd('_');
            var attributes = content.OfType<Attribute>().ToArray();

            return new($"<{name}{attributes.Join(" ").Pad()} />");
        }
    }
}
