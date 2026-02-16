using Godot;

namespace Guide.Tooltip.Core;
[Tool]
public partial class TooltipProperty() : EditorProperty
{

    public static string Tooltip="No tooltip";
    public Variant attr;
    

    public void SetTooltip(string tooltip, Variant variant)
    {
        Tooltip = tooltip;
        attr = variant;
    }
    
    

    public override void _Draw()
    {
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
    }

    public void Parent()
    {
        GD.Print("PARENT: "+GetParent().GetParent());
    }
}