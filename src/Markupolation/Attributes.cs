namespace Markupolation
{
    /// <summary>
    /// HTML attributes.
    /// </summary>
    public static partial class Attributes
    {
        /// <summary>
        /// Custom data attribute.
        /// </summary>
        /// <param name="name">Attribute name suffix.</param>
        /// <param name="value">Attribute value.</param>
        /// <returns><c>data-{name}="{value}"</c></returns>
        public static Attribute data(string name, string value) => new($"data-{name}", value);
    }
}
