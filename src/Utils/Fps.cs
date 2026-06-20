using Godot;

namespace inf9.Game.Utils;

[GlobalClass]
public partial class Fps : Label
{
	public override void _Process(double delta)
	{
		var fps = Engine.GetFramesPerSecond();
		Text = $"FPS: {fps}";

		LabelSettings.FontColor = Colors.Green;
		if (fps < 60)
			LabelSettings.FontColor = Colors.Red;
	}
}