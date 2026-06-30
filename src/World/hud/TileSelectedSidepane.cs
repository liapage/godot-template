using Godot;

namespace Game.World.hud;

using Chickensoft.Log;

public partial class TileSelectedSidepane : VBoxContainer
{
    private readonly ILog _log = new Log(nameof(Game), new ConsoleWriter(), new TraceWriter());

    [Export] private Label _nameLabel;

    public override void _Ready()
    {
        if (!Game.Instance.World.ResidentGrid.SelectedTileCoords.HasValue)
        {
            _log.Err("No tile selected, can't get resident for sidepane");
            return;
        }

        if (!Game.Instance.State.Residents.TryGetValue(Game.Instance.World.ResidentGrid.SelectedTileCoords.Value.ToString(), out var resident))
        {
            _log.Err("Can't find resident in list");
            return;
        }

        _nameLabel.Text = $"{resident.Name}";
    }
}
