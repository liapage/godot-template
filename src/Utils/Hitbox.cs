namespace Game.Utils;

using System;
using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class Hitbox : Area2D
{
    [Export] public int DamageOnEnter;
    public Action<Hurtbox>? Hit;

    private readonly HashSet<Hurtbox> _hurtboxes = [];

    public override void _Ready()
    {
        AreaEntered += area =>
        {
            if (area is Hurtbox hurtbox)
            {
                _hurtboxes.Add(hurtbox);

                if (DamageOnEnter != 0)
                {
                    hurtbox.Damage(DamageOnEnter);
                    Hit?.Invoke(hurtbox);
                }
            }
        };

        AreaExited += area =>
        {
            if (area is Hurtbox hurtbox)
            {
                _hurtboxes.Remove(hurtbox);
            }
        };
    }

    public void Damage(int amount)
    {
        foreach (var hurtbox in _hurtboxes)
        {
            hurtbox.Damage(amount);
            Hit?.Invoke(hurtbox);
        }
    }
}
