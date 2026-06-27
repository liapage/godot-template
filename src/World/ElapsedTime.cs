using Godot;

namespace Game.World;

using System;
using System.Globalization;

public partial class ElapsedTime : Label
{
    public override void _Process(double delta)
    {
        var elapsedTime = DateTime.UtcNow - Game.Instance.State.RunStartTime;
        Text = elapsedTime.ToString("hh\\:mm\\:ss", DateTimeFormatInfo.InvariantInfo);
    }
}
