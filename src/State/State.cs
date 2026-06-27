namespace Game.State;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Chickensoft.Collections;
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
}

