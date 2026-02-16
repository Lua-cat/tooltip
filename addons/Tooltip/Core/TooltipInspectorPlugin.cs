
namespace Guide.Tooltip.Core;

using Godot;
using System;
using System.Reflection;
[Tool]
public partial class TooltipInspectorPlugin : EditorInspectorPlugin
{
    public override bool _CanHandle(GodotObject obj)
    {
        // Only handle valid objects
        return IsInstanceValid(obj);
    }
    
    public override bool _ParseProperty(
        GodotObject obj,
        Variant.Type type,
        string path,
        PropertyHint hint,
        string hintText,
        PropertyUsageFlags usage,
        bool wide
    )
    {
        // check if valid object
        if (obj == null || !IsInstanceValid(obj))
            return false;

        // path must not be null
        if (string.IsNullOrEmpty(path))
            return false;

        // Get the script
        var script = obj.GetScript().As<CSharpScript>();
        if (script == null || string.IsNullOrEmpty(script.ResourcePath))
            return false;

        string scriptPath = script.ResourcePath;

        // Load the C# script
        var scriptClass = GD.Load<CSharpScript>(scriptPath);
        if (scriptClass == null)
            return false;

        object o;
        try
        {
            o = scriptClass.New().Obj;
        }
        catch (Exception e)
        {
            GD.PrintErr($"Failed to instantiate script for tooltip: {e}");
            return false;
        }

        if (o == null)
            return false;
        
        var field = o.GetType().GetField(
            path,
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
        );
        if (field == null)
            return false;

        // Check for TooltipAttribute
        var attr = field.GetCustomAttribute<TooltipAttribute>();
        if (attr == null || string.IsNullOrEmpty(attr.TooltipText))
            return false;
        GD.Print("obj: ",obj);
        GD.Print("type: ",type);
        GD.Print("path: ",path);
        GD.Print("hint: ",hint);
        GD.Print("attr: ",hintText);
        GD.Print("usage: ",usage);
        GD.Print("wide: ",wide);
        
        /*
        EditorProperty editor = EditorInspector.InstantiatePropertyEditor(
            obj,
            type,
            path,
            hint,
            hintText, // use tooltip from attribute
            (uint)usage,
            wide
        );
        */;
        EditorInterface.Singleton.GetInspector().Visible = true;
        GD.Print("INTER:"+EditorInterface.Singleton.GetInspector().GetChild<VBoxContainer>(0));
        TooltipProperty property= new TooltipProperty();
        property.SetTooltip(attr.TooltipText,obj.Get(path));
        AddPropertyEditor(path, property);
        Callable.From(property.Parent).CallDeferred();;
        return false;
    }
}