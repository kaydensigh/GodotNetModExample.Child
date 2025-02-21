using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

/// <summary>
/// A class in the mod that can be instantiated from C#.
/// This programmatically adds a scene loaded from the mod.
/// </summary>
public partial class GodotClassInMod : PanelContainer
{
    public override void _Ready()
    {
        AddThemeStyleboxOverride("panel", GD.Load<StyleBox>("res://Mods/GodotNetModExample.Child/style_box.tres"));

        var container = new VBoxContainer();
        AddChild(container);

        container.AddChild(new Label { Text = nameof(GodotClassInMod) });

        var subscenePacked = GD.Load<PackedScene>("res://Mods/GodotNetModExample.Child/SubSceneInMod.tscn");
        var subscene = subscenePacked.Instantiate<SubSceneInMod>();
        subscene.Name = nameof(SubSceneInMod);
        container.AddChild(subscene);
    }
}
