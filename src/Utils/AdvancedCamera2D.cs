using Godot;

namespace Game.Utils;

[GlobalClass]
public partial class AdvancedCamera2D : Camera2D
{
    [Export] private Node2D _cursorAnchor = null!;

    // How much the mouse can move the camera forward. 0.5 being the most extreme with anchor on one edge and cursor on the other.
    [Export] private float _mouseInfluence = 0.2f;

    // Shake
    private float _shakeFade = 5.0f;
    private FastNoiseLite _noise = new();
    private float _shakeStrength;
    private double _noiseI;

    public override void _Ready()
    {
        _noise.Seed = (int)GD.Randi();
        _noise.Frequency = 0.5f; // Adjust for "speed" of shake
    }

    public override void _Process(double delta)
    {
        if (!Visible)
        {
            return;
        }

        var playerPosition = _cursorAnchor.GlobalPosition;
        var mousePosition = GetGlobalMousePosition();
        GlobalPosition = playerPosition.Lerp(mousePosition, _mouseInfluence);

        ProcessShake(delta);
    }

    private void ProcessShake(double delta)
    {
        if (_shakeStrength <= 0)
        {
            return;
        }

        // Fade the shake over time
        _shakeStrength = Mathf.Lerp(_shakeStrength, 0, _shakeFade * (float)delta);

        // Increment noise coordinate
        _noiseI += delta * 100;

        // Shake
        Offset = new Vector2(
            _noise.GetNoise1D((float)_noiseI) * _shakeStrength,
            _noise.GetNoise1D((float)_noiseI + 100) * _shakeStrength
        );
    }

    public void Shake(float strength, float fade)
    {
        _shakeStrength = strength;
        _shakeFade = fade;
    }
}
