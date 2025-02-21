using System;
using Godot;
using GodotNetModExample.ChildLib;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

/// <summary>
/// A class in the mod that can be instantiated from C#.
/// </summary>
public partial class GodotClassInMod : PanelContainer
{
    ClassInChildLib _classInChildLib = new();

    public override void _Ready()
    {
        AddThemeStyleboxOverride("panel", GD.Load<StyleBox>("res://Mods/GodotNetModExample.Child/style_box.tres"));

        var container = new VBoxContainer();
        AddChild(container);
        container.AddChild(new Label { Text = nameof(GodotClassInMod) });

        // Instantiate a class from ChildLib.
        container.AddChild(new Label { Text = $"Loaded {_classInChildLib}" });

        /// Instantiate a scene from this mod.
        var subscenePacked = GD.Load<PackedScene>("res://Mods/GodotNetModExample.Child/SubSceneInMod.tscn");
        var subscene = subscenePacked.Instantiate<SubSceneInMod>();
        subscene.Name = nameof(SubSceneInMod);
        container.AddChild(subscene);

        // Instantiate a scene from the parent.
        PackedScene parentScenePacked;
        try
        {
            parentScenePacked = GD.Load<PackedScene>("res://SceneInParent.tscn");
        }
        catch (Exception)
        {
            container.AddChild(new Label { Text = "Could not load SceneInParent" });
            throw;
        }
        Node parentScene;
        try
        {
            parentScene = parentScenePacked.Instantiate();
        }
        catch (Exception)
        {
            container.AddChild(new Label { Text = "Could not instantiate SceneInParent" });
            throw;
        }
        subscene.Name = "SceneInParent";
        container.AddChild(parentScene);
    }
}
