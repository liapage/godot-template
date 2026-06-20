namespace Game.Utils.BT;

using Godot;

[GlobalClass]
public partial class BtGrabbed : BtNode
{
    [Export] public float Time { get; set; } = 5f;

    private Timer _timer = null!;
    private bool _timedOut;

    public override void _Ready()
    {
        base._Ready();

        _timer = new Timer
        {
            WaitTime = Time,
            Autostart = false,
            OneShot = true
        };

        AddChild(_timer);
        _timer.Start();

        _timer.Timeout += () =>
        {
            _timedOut = true;
        };
    }

    public override BtState _PhysicsTick(double delta, BtBlackboard blackboard)
    {
        // Timer is finished
        if (_timedOut)
        {
            _timedOut = false;
            return BtState.Success;
        }

        // Timer not running, start running
        if (_timer.IsStopped())
        {
            _timer.Start();
        }

        GD.Print("BtCooldown");
        return BtState.Running;
    }
}
