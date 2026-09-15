using System;

namespace Markupolation;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
internal sealed class AttributeAttribute(string description, params ElementType[] elements) : System.Attribute
{
    public string Description { get; } = description;

    // The flags are named properties rather than positional constructor arguments, so the generated
    // enum carries one only where it is true. Positionally, every one of the ~470 rows had to spell
    // out the falses it does not care about, with nothing at the call site to say which bool was which.
    public bool IsGlobalAttribute { get; set; }

    public bool IsBooleanAttribute { get; set; }

    // Whether the specification lists "the empty string" among the attribute's values. Not the same
    // as a boolean attribute - these are enumerated, so hidden="until-found" and
    // contenteditable="false" are real values that a boolean attribute could not express - but the
    // empty string is indistinguishable from writing the attribute bare once parsed, so it is what
    // says <p hidden> is allowed.
    public bool IsEmptyStringValid { get; set; }

    public ElementType[] Elements { get; } = elements;
}
