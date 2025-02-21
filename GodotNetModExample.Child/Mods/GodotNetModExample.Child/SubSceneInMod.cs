using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

public partial class SubSceneInMod : PanelContainer
{
    public override void _Ready()
    {
        GetNode<Label>("Label").AddThemeColorOverride("font_color", Colors.Pink);
    }
}
