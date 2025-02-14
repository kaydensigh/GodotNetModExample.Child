using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

public partial class GodotClassInMod : VBoxContainer
{
    public string Source { get; set; }

    public override void _Ready()
    {
        AddChild(new Label { Text = $"Label <- {Name} {Source}" });

        var subscenePacked = GD.Load<PackedScene>("res://Mods/GodotNetModExample.Child/SubSceneInMod.tscn");
        var subscene = subscenePacked.Instantiate<SubSceneInMod>();
        subscene.Name = "SubSceneInMod_GodotClassInMod";
        subscene.Source = $"<- {Name} {Source}";
        AddChild(subscene);
    }
}
