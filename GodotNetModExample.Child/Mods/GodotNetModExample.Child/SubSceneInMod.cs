using Godot;

namespace GodotNetModExample.Parent.Mods.GodotNetModExample.Child;

public partial class SubSceneInMod : VBoxContainer
{
    public string Source { get; set; }

    public override void _Ready()
    {
        var label = new Label()
        {
            Name = "Label2",
            Text = $"Label <- {Name} {Source}",
        };
        AddChild(label);
    }
}
