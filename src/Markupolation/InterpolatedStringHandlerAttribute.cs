#if !NET

namespace System.Runtime.CompilerServices;

/// <summary>
/// Marks a type as an interpolated string handler. Provided here because it does not exist in
/// netstandard2.1; the compiler only needs the type to be present.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
internal sealed class InterpolatedStringHandlerAttribute : Attribute
{
}

#endif
