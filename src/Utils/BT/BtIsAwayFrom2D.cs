namespace Game.Utils.BT;

using Godot;

[GlobalClass]
public partial class BtIsAwayFrom2D : BtNode
{
    [Export] public Node2D Source = null!;
    [Export] public string TargetGroupId = null!;
    [Export] public float Distance = 30f;

    public override BtState _PhysicsTick(double delta, BtBlackboard blackboard)
    {
        foreach (var node in GetTree().GetNodesInGroup(TargetGroupId))
        {
            if (node is not Node2D target)
            {
                continue;
            }

            var distance = Source.GlobalPosition.DistanceSquaredTo(target.GlobalPosition);
            if (distance <= Distance * Distance)
            {
                continue;
            }

            return BtState.Success;
        }

        return BtState.Failure;
    }
}
