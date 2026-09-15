using System;

namespace Markupolation;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
internal sealed class AttributeAttribute(string description, bool isGlobalAttribute, bool isBooleanAttribute, params ElementType[] elements) : System.Attribute
{
    public string Description { get; } = description;

    public bool IsGlobalAttribute { get; } = isGlobalAttribute;

    public bool IsBooleanAttribute { get; } = isBooleanAttribute;

    // Whether the specification lists "the empty string" among the attribute's values. Not the same
    // as a boolean attribute - these are enumerated, so hidden="until-found" and
    // contenteditable="false" are real values that a boolean attribute could not express - but the
    // empty string is indistinguishable from writing the attribute bare once parsed, so it is what
    // says <p hidden> is allowed. A named property rather than a fourth positional bool, so the
    // generated enum only carries it where it is true.
    public bool IsEmptyStringValid { get; set; }

    public ElementType[] Elements { get; } = elements;
}
