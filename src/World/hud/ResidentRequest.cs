using Game.State;
using Godot;

namespace Game.World.hud;

public partial class ResidentRequest : PanelContainer
{
    [Export] private Label _nameLabel = null!;
    [Export] private Button _acceptButton = null!;

    private State.Resident _resident;

    public void Initialize(State.Resident resident)
    {
        _resident = resident;
    }

    public override void _Ready()
    {
        _nameLabel.Text = _resident.Name;
        _acceptButton.Pressed += () =>
        {
            Game.Instance.World.ResidentManager.AcceptResidentRequest(_resident);
        };
    }
}
