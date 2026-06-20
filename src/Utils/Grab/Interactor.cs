namespace Game.Utils.Grab;

using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class Interactor : Area2D
{
    private readonly Stack<Interactable> _grabbables = new();

    public override void _Ready()
    {
        BodyEntered += body =>
        {
            var grabbable = body.FindChild<Interactable>();
            if (grabbable != null)
            {
                _grabbables.Push(grabbable);
            }
        };

        AreaEntered += area =>
        {
            var grabbable = area.FindChild<Interactable>();
            if (grabbable != null)
            {
                _grabbables.Push(grabbable);
            }
        };
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("grab"))
        {
            if (_grabbables.TryPop(out var grabbable))
            {
                grabbable.Interact(this);
            }
        }
    }
}
