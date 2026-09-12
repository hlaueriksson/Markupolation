namespace Markupolation;

internal static class ElementRawText
{
    internal static bool Get(ElementType type) => type is ElementType.script or ElementType.style;
}
