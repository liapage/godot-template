using Godot;

namespace Game.World;

public partial class World : Node2D
{
    [Export] public ResidentManager ResidentManager = null!;
    [Export] public ResidentGrid ResidentGrid = null!;

    public override void _EnterTree()
    {
        Game.Instance.World = this;
    }
}
