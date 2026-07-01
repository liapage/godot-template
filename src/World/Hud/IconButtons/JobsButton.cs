using Godot;

namespace Game.World.Hud.IconButtons;

using Jobs;

public partial class JobsButton : TextureButton
{
    [Export] private PackedScene _jobsModalScene = null!;

    public override void _Ready()
    {
        Pressed += () =>
        {
            var node = _jobsModalScene.Instantiate();
            Game.Instance.World.ModalContainer.AddChild(node);
        };
    }
}
