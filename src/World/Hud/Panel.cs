using Godot;

namespace Game.World.hud;

public partial class Panel : PanelContainer
{
    [Export] private string _title = null!;
    [Export] private PackedScene _content = null!;
    [Export] private VBoxContainer _vboxContainer = null!;
    [Export] private Label _titleLabel = null!;

    public override void _Ready()
    {
        var node = _content.Instantiate();
        _vboxContainer.AddChild(node);
        _titleLabel.Text = _title;
    }
}
