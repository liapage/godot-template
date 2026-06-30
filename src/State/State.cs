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
        new() { Name = "Jane Doe" }
    ];
}

public record struct Resident
{
    public string Name;
}
