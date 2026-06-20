namespace Game.Utils;

using Godot;

[GlobalClass]
public partial class Cursor : Sprite2D
{
    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseModeEnum.Hidden);
    }

    public override void _Process(double delta)
    {
        GlobalPosition = GetGlobalMousePosition();
    }
}
