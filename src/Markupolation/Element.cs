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
    internal class VoidAttribute : System.Attribute
    {
    }
}
