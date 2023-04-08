using System.Diagnostics;

namespace Markupolation
{
    /// <summary>
    /// HTML content.
    /// </summary>
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

        /// <summary>
        /// Converts <see cref="Content"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="value">The content.</param>
        public static implicit operator string(Content value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        /// <summary>
        /// Converts <see cref="string"/> to <see cref="Content"/>.
        /// </summary>
        /// <param name="value">The string.</param>
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
