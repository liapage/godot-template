using Godot;

namespace Game.World.Hud.IconButtons.Jobs;

public partial class BackgroundButton : TextureButton
{
    public override void _Ready()
    {
        Pressed += () =>
        {
            GetParent().QueueFree();
        };
    }
}
