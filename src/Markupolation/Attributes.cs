namespace Markupolation
{
    public static partial class Attributes
    {
        public static Attribute data(string name, string value) => new($"data-{name}", value);
    }
}
