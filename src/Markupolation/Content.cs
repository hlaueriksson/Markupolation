using System.Diagnostics;

namespace Markupolation
{
    [DebuggerDisplay("{ToString()}")]
    public record Content
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> class.
        /// </summary>
        /// <param name="value">Content value.</param>
        public Content(string? value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets content value.
        /// </summary>
        public string? Value { get; }

        public static implicit operator string(Content value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

#pragma warning disable CA2225 // Operator overloads have named alternates
        public static implicit operator Content(string value)
#pragma warning restore CA2225 // Operator overloads have named alternates
        {
            return new Content(value);
        }

        /// <inheritdoc/>
        public override string ToString() => Value ?? string.Empty;
    }
}
