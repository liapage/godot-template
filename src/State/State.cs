namespace Game.State;

using System;
using System.Collections.Generic;
using Config;
using Godot;

public class State
{
    public State()
    {
    }

    public State(Config config)
    {
    }

    public DateTime RunStartTime =  DateTime.UtcNow;

    public readonly Dictionary<string, Resident> Residents = [];
    public readonly List<Resident> ResidentRequests =
    [
        new() { Name = "Jane Doe", Health = 100, MaxHealth = 100 },
        new() { Name = "John Doe", Health = 15, MaxHealth = 20 },
        new() { Name = "Beep Boop", Health = 3, MaxHealth = 15 }
    ];
}

public record struct Resident
{
    public string Name;
    public int Health;
    public int MaxHealth;
}
