using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

/// <summary>
/// Script attached to a scene resource in the mod.
/// The scene contains a subscene from the mod.
/// </summary>
public partial class SceneInMod : PanelContainer
{
    public override void _Ready()
    {
        var container = GetNode<Container>("Container");

        // Instantiate a non-scene class from this mod.
        container.AddChild(new GodotClassInMod { Name = nameof(GodotClassInMod) });
    }
}
