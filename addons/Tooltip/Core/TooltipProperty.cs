using Godot;
using Godot.Collections;

namespace Tooltip;
[Tool]
public partial class TooltipProperty() : EditorProperty
{

    public static string Tooltip="No tooltip";
    public Variant attr;
    

    public void SetTooltip(string tooltip, Variant variant)
    {
        Tooltip = tooltip;
        attr = variant;
        Name="tooltip";
    }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {

        }
    }
    
    

    public override void _Draw()
    {
        if (!Engine.IsEditorHint())
        {
            return;
        }
        if (!(GetChildCount() > 2))
        {
            return;
        }

        var inspectortooltip = GetChild(2, true);
        if (inspectortooltip == null)
        {
            return;
        }
        var inspectortooltiphelper = inspectortooltip.GetChild(2, true);
        if (inspectortooltiphelper == null)
        {
            return;
        }
        RichTextLabel tooltipDescription = inspectortooltiphelper.GetChild<RichTextLabel>(1, true);
        tooltipDescription.Text = Tooltip;
        GetParent().GetChild(1, true).PrintTree();
        
        //GD.Print(EditorInterface.Singleton.GetInspector().GetChild(0).GetChild(2).GetChild(1).GetChild(0).GetChild(2,true).GetChild(2,true).GetChild<RichTextLabel>(1,true).Text);
    }

    public void Parent()
    {
        /*
        GD.Print("PARENT: "+GetParent());
        var root = GetParent().GetChild(1, true);
        if (!IsInstanceValid(root))
        {
            return;
        }

        if (!IsInstanceValid(root.GetChild(2)))
        {
            return;
        }
        root.GetChild(2).Reparent(this);
        */
        GD.Print(GetPath());
        GD.Print(EditorInterface.Singleton.GetInspector().GetChild(0).GetChild(2).Name);

    }
}