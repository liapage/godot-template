namespace Game.Utils.Grab;

using System;
using Godot;

[GlobalClass]
public partial class Interactable : Node2D
{
    public Action<Interactor>? Interacted;

    public void Interact(Interactor interactor)
    {
        Interacted?.Invoke(interactor);
    }
}
