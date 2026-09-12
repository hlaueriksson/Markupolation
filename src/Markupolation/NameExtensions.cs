using System;
using System.Linq;

namespace Markupolation;

/// <summary>
/// The naming convention that maps HTML names to C# names.
/// </summary>
/// <remarks>
/// The single definition of the convention, shared by three callers: the generator that writes
/// <c>Generated/</c>, the converter that turns HTML back into Markupolation source, and the
/// runtime, which needs the inverse to render names.
/// </remarks>
internal static class NameExtensions
{
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/
    private static readonly string[] Keywords = ["abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"];

    /// <summary>
    /// Converts an HTML name to its C# name: <c>-</c> becomes <c>_</c>, and a C# keyword gets a
    /// trailing <c>_</c>.
    /// </summary>
    /// <param name="name">HTML name, such as <c>http-equiv</c> or <c>class</c>.</param>
    /// <returns>C# name, such as <c>http_equiv</c> or <c>class_</c>.</returns>
    internal static string CleanName(this string name)
    {
        var suffix = IsCsharpKeyword(name) ? "_" : string.Empty;
        return name.Replace('-', '_') + suffix;
    }

    private static bool IsCsharpKeyword(this string name) => Keywords.Contains(name, StringComparer.Ordinal);
}
