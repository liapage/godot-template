namespace Game.Utils.BT;

using System;
using Godot;

[GlobalClass]
public partial class BtSequence : BtNode
{
    private BtNode? _runningNode;

    public override BtState _PhysicsTick(double delta, BtBlackboard blackboard)
    {
        // AND
        foreach (var btNode in this.FindChildren<BtNode>())
        {
            // Skip until at currently running node
            if (_runningNode != null && _runningNode != btNode)
            {
                continue;
            }
            _runningNode = null;

            var state = btNode.PhysicsTick(delta, blackboard);
            if (state == BtState.Running)
            {
                _runningNode = btNode;
            }
            if (state != BtState.Success)
            {
                return state;
            }
        }
        return BtState.Success;
    }
}
