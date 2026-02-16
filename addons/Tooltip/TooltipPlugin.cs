namespace Guide.Tooltip;
using Godot;
using Guide.Tooltip.Core;

[Tool]
public partial class TooltipPlugin : EditorPlugin
{
    public static EditorProperty Editor;
    private TooltipInspectorPlugin _plugin;

    public override void _EnterTree()
    {
        _plugin = new TooltipInspectorPlugin();
        AddInspectorPlugin(_plugin);
    }

    public override void _ExitTree()
    {
        RemoveInspectorPlugin(_plugin);
        _plugin.Free();
    }
}
