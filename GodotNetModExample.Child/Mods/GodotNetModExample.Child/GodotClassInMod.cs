using System;
using Godot;
using GodotNetModExample.Shared;
using GodotNetModExample.ChildLib;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

/// <summary>
/// A class in the mod that can be instantiated from C#.
/// </summary>
public partial class GodotClassInMod : GodotClassInShared
{
    protected override StyleBox StyleBox { get; } = GD.Load<StyleBox>("res://Mods/GodotNetModExample.Child/style_box.tres");

    ClassInChildLib _classInChildLib = new();

    public override void _Ready()
    {
        base._Ready();

        // Instantiate a class from ChildLib.
        Container.AddChild(new Label { Text = $"Loaded {_classInChildLib}" });

        /// Instantiate a scene from this mod.
        var subscenePacked = GD.Load<PackedScene>("res://Mods/GodotNetModExample.Child/SubSceneInMod.tscn");
        var subscene = subscenePacked.Instantiate<SubSceneInMod>();
        subscene.Name = nameof(SubSceneInMod);
        Container.AddChild(subscene);

        // Instantiate a scene from the parent.
        PackedScene parentScenePacked;
        try
        {
            parentScenePacked = GD.Load<PackedScene>("res://SceneInParent.tscn");
        }
        catch (Exception)
        {
            Container.AddChild(new Label { Text = "Could not load SceneInParent" });
            throw;
        }
        Node parentScene;
        try
        {
            parentScene = parentScenePacked.Instantiate();
        }
        catch (Exception)
        {
            Container.AddChild(new Label { Text = "Could not instantiate SceneInParent" });
            throw;
        }
        subscene.Name = "SceneInParent";
        Container.AddChild(parentScene);
    }
}
