using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

/// <summary>
/// Script attached to a scene resource in the mod.
/// The scene contains a subscene from the mod.
/// This also programmatically instantiates a non-scene class from the mod.
/// </summary>
public partial class SceneInMod : PanelContainer
{
    public override void _Ready()
    {
        var container = GetNode<Container>("Container");

        container.AddChild(new GodotClassInMod { Name = nameof(GodotClassInMod) });
    }
}
