using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

public partial class SceneInMod : VBoxContainer
{
    public override void _Ready()
    {
        AddChild(new Label()
        {
            Name = "Label2",
            Text = $"Label <- {Name}",
        });

        AddChild(new GodotClassInMod
        {
            Name = "GodotClassInMod_SceneInMod",
            Source = $"<- {Name}",
        });
    }
}
