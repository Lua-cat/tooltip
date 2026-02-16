using Godot;
using System;
namespace Tooltip;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
[Tool]
public class TooltipAttribute : Attribute
{
    public string TooltipText { get; }
    public PropertyHint Hint { get; }

    public TooltipAttribute(string text,PropertyHint hint=PropertyHint.None)
    {
        TooltipText = text;
        Hint = hint;
    }
}
