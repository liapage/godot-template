using System.Collections.Generic;
using Godot;

namespace inf9.Game.Utils.Fsm;

[GlobalClass]
public partial class Fsm : Node3D
{
    [Export] private string _initialState;
    private readonly Dictionary<string, FsmState> _states = [];
    private string _currentState;

    public override void _Ready()
    {
        foreach (var node in GetChildren())
        {
            if (node is not FsmState fsmState) continue;
            _states.Add(fsmState.Name, fsmState);
            fsmState.Fsm = this;
        }

        _currentState = _initialState;
        _states[_initialState].Enter();
    }

    public void SwitchState(string newState)
    {
        // Game.Instance.Log.Debug("Switching state: " + _currentState + " -> " + newState);
        _states[_currentState].Exit();
        _currentState = newState;
        _states[_currentState].Enter();
    }

    public void PhysicsProcess(double delta)
    {
        _states[_currentState].PhysicsProcess(delta);
    }
}