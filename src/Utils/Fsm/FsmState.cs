using Godot;

namespace inf9.Game.Utils.Fsm;

[GlobalClass]
public partial class FsmState : Node3D
{
    public Fsm Fsm;
    
    public virtual void Enter()
    {
    }
    
    public virtual void Exit()
    {
    }

    public virtual void PhysicsProcess(double delta)
    {
    }
}