namespace Markupolation;

internal static class AttributeBooleanness
{
    internal static bool Get(AttributeType type) => type is AttributeType.allowfullscreen or AttributeType.alpha or AttributeType.async or AttributeType.autofocus or AttributeType.autoplay or AttributeType.checked_ or AttributeType.controls or AttributeType.default_ or AttributeType.defer or AttributeType.disabled or AttributeType.formnovalidate or AttributeType.headingreset or AttributeType.inert or AttributeType.ismap or AttributeType.itemscope or AttributeType.loop or AttributeType.multiple or AttributeType.muted or AttributeType.nomodule or AttributeType.novalidate or AttributeType.open or AttributeType.playsinline or AttributeType.readonly_ or AttributeType.required or AttributeType.reversed or AttributeType.selected or AttributeType.shadowrootclonable or AttributeType.shadowrootcustomelementregistry or AttributeType.shadowrootdelegatesfocus or AttributeType.shadowrootserializable;
}
