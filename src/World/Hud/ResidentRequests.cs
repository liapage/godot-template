using Godot;

namespace Game.World.hud;

public partial class ResidentRequests : VBoxContainer
{
    [Export] private PackedScene _residentRequestScene = null!;

    public override void _Ready()
    {
        Populate();
    }

    private void Populate()
    {
        foreach (var child in GetChildren())
        {
            RemoveChild(child);
        }

        foreach (var resident in Game.Instance.State.ResidentRequests)
        {
            var scene = _residentRequestScene.Instantiate<ResidentRequest>();
            scene.Initialize(resident);
            AddChild(scene);
        }
    }
}
