using Godot;
namespace Tooltip;

[Tool]
public partial class TooltipPlugin : EditorPlugin
{
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
