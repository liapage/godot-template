namespace Game.Utils.BT;

using System;
using Godot;

public enum BtState
{
    Success,
    Failure,
    Running
}

public abstract partial class BtNode : Node
{
    private string _name = "empty";
    private bool _setName;

    public override void _Ready()
    {
        _name = Name;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!_setName)
        {
            Name = $"{_name}";
        }

        _setName = false;
    }

    public BtState PhysicsTick(double delta, BtBlackboard blackboard)
    {
        var state = _PhysicsTick(delta, blackboard);
        Name = $"{_name}: {state}";
        _setName = true;
        return state;
    }

    public abstract BtState _PhysicsTick(double delta, BtBlackboard blackboard);
}
