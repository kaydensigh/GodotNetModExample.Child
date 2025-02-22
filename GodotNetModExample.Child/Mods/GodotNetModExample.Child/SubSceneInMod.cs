using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

public partial class SubSceneInMod : PanelContainer
{
    public override void _Ready()
    {
        var container = GetNode<Container>("Container");

        /// Instantiate a scene from Shared.
        var subscenePacked = GD.Load<PackedScene>("res://Shared/SceneInShared.tscn");
        var subscene = subscenePacked.Instantiate<SceneInShared>();
        subscene.Name = nameof(SceneInShared);
        container.AddChild(subscene);
    }
}
