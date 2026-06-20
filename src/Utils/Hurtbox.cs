namespace Game.Utils;

using System;
using Godot;

[GlobalClass]
public partial class Hurtbox : Area2D
{
    [Export] public int Health = 100;
    public Action<int>? Damaged;

    public void Damage(int amount)
    {
        // Cap amount to health
        if (amount > Health)
        {
            amount = Health;
        }

        Health -= amount;
        Damaged?.Invoke(amount);
    }
}
