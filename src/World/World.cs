using Godot;

namespace Game.World;

using addons.godlib.SceneGrid;

public partial class World : Node2D
{
    [Export] public ResidentManager ResidentManager = null!;
    [Export] public SceneGrid SceneGrid = null!;
    [Export] public DrawGrid DrawGrid = null!;
    [Export] public Control ModalContainer = null!;

    public override void _EnterTree()
    {
        Game.Instance.World = this;
    }
}
