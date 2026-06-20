namespace Game.Utils.BT;

using Godot;

[GlobalClass]
public partial class BtNot : BtNode
{
    public override BtState _PhysicsTick(double delta, BtBlackboard blackboard)
    {
        var child = this.FindChild<BtNode>();
        if (child == null)
        {
            return BtState.Failure;
        }

        var state = child.PhysicsTick(delta, blackboard);
        return state switch
        {
            BtState.Success => BtState.Failure,
            BtState.Failure => BtState.Success,
            _ => state
        };
    }
}
