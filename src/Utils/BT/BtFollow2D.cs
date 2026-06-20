namespace Game.Utils.BT;

using Godot;

[GlobalClass]
public partial class BtFollow2D : BtNode
{
    [Export] public CharacterBody2D Source = null!;
    [Export] public NavigationAgent2D NavAgent = null!;
    [Export] public float Speed = 40f;
    [Export] public string TargetGroupId = null!;
    [Export] public float RangeRadius { get; set; } = 800.0f;
    [Export] public string TargetLastSeenPositionKey = "target_last_seen_position";
    [Export(PropertyHint.Layers2DPhysics)] public uint CollisionMask { get; set; } = 1;

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
        var targetPosition = GetTargetPosition();
        if (targetPosition == null)
        {
            Source.Velocity = Vector2.Zero;
            _timer.Stop();
            return BtState.Failure;
        }

        blackboard.Set(TargetLastSeenPositionKey, targetPosition.Value);

        if (_timer.IsStopped())
        {
            _timer.Start();
        }

        // _targetPosition = targetPosition;
        NavAgent.TargetPosition = targetPosition.Value;

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

        return BtState.Success;
    }

    private Vector2? GetTargetPosition()
    {
        foreach (var node in GetTree().GetNodesInGroup(TargetGroupId))
        {
            if (node is not Node2D target)
            {
                continue;
            }

            // Check range
            var distance = Source.GlobalPosition.DistanceSquaredTo(target.GlobalPosition);
            if (distance > RangeRadius * RangeRadius)
            {
                continue;
            }

            var query = PhysicsRayQueryParameters2D.Create(
                Source.GlobalPosition,
                target.GlobalPosition,
                CollisionMask
            );

            var spaceState = Source.GetWorld2D().DirectSpaceState;
            var result = spaceState.IntersectRay(query);

            if (result.Count > 0)
            {
                if (result["collider"].As<Node2D>() == target)
                {
                    return target.GlobalPosition;
                }
            }
        }

        return null;
    }
}
