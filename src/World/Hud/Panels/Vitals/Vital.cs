using Godot;

namespace Game.World.hud.Panels.Vitals;

public partial class Vital : VBoxContainer
{
    [Export] public string Title = "";
    [Export] public Color FillColor = Godot.Color.FromHtml("#00885e");

    [Export] private Label _titleLabel = null!;
    [Export] private ProgressBar _progressBar = null!;

    public override void _Ready()
    {
        _titleLabel.Text = Title;
        _progressBar.AddThemeStyleboxOverride("fill", new StyleBoxFlat{ BgColor = FillColor });
    }

    public void SetValue(int value)
    {
        _progressBar.Value = value;
    }

    public void SetMaxValue(int maxValue)
    {
        _progressBar.MaxValue = maxValue;
    }
}
