namespace Game.Utils.BT;

using Godot;

[GlobalClass]
public partial class BtFollowPosition2D : BtNode
{
    [Export] public CharacterBody2D Source = null!;
    [Export] public NavigationAgent2D NavAgent = null!;
    [Export] public float Speed = 40f;
    [Export] public string TargetLastSeenPositionKey = "target_last_seen_position";

    private Vector2 _targetPosition = Vector2.Zero;
    private Timer _timer = null!;

    public override void _Ready()
    {
        base._Ready();

        _timer = new Timer
        {
            WaitTime = 1f,
            OneShot = false,
            Autostart = true,
        };
        _timer.Timeout += () =>
        {
            // GD.Print($"Set NavAgent.TargetPosition {_targetPosition}");
            // NavAgent.TargetPosition = _targetPosition;
        };

        AddChild(_timer);
        _timer.Start();
    }

    public override BtState _PhysicsTick(double delta, BtBlackboard blackboard)
    {
        if (!blackboard.Get<Vector2>(TargetLastSeenPositionKey, out var targetPosition))
        {
            Source.Velocity = Vector2.Zero;
            _timer.Stop();
            return BtState.Failure;
        }

        if (_timer.IsStopped())
        {
            _timer.Start();
        }

        // _targetPosition = targetPosition;
        NavAgent.TargetPosition = targetPosition;

        // if (Source.GlobalPosition.DistanceSquaredTo(targetPosition) <=
        //     NavAgent.TargetDesiredDistance * NavAgent.TargetDesiredDistance)
        // {
        //     Source.Velocity = Vector2.Zero;
        //     return BtState.Success;
        // }

        if (NavAgent.IsNavigationFinished())
        {
            Source.Velocity = Vector2.Zero;
            return BtState.Success;
        }

        var nextPathPos = NavAgent.GetNextPathPosition();
        // var direction = (nextPathPos - Source.GlobalPosition).Normalized();
        // var direction = Source.ToLocal(nextPathPos).Normalized();
        var direction = Source.GlobalPosition.DirectionTo(nextPathPos);

        Source.Velocity = direction * Speed;
        Source.Rotation = direction.Angle();
        Source.MoveAndSlide();

        // if (NavAgent.IsTargetReached())
        // {
        //     Source.Velocity = Vector2.Zero;
        //     return BtState.Success;
        // }

        return BtState.Running;
    }
}
