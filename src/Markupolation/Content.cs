using System.Diagnostics;

namespace Markupolation
{
    [DebuggerDisplay("{ToString()}")]
    public record Content
    {
        internal Content()
        {
        }

        public Content(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString() => Value;

        public static implicit operator string(Content value)
        {
            return value.ToString();
        }

        public static implicit operator Content(string value)
        {
            return new Content(value);
        }
    }
}
