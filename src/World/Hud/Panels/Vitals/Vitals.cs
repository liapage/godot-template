namespace Game.World.hud.Panels.Vitals;

using Chickensoft.Log;
using Godot;

public partial class Vitals : PanelContainer
{
    private readonly ILog _log = new Log(nameof(Game), new ConsoleWriter(), new TraceWriter());

    [Export] public Vital HealthVital = null!;
    [Export] public Vital HungerVital = null!;

    public override void _Ready()
    {
        Game.Instance.World.DrawGrid.OnTileSelect += @event =>
        {
            Populate();
        };

        Game.Instance.World.ResidentManager.ResidentAdded += resident =>
        {
            Populate();
        };
    }

    private void Populate()
    {
        if (!Game.Instance.World.DrawGrid.SelectedTileCoords.HasValue)
        {
            return;
        }

        if (!Game.Instance.State.Residents.TryGetValue(Game.Instance.World.DrawGrid.SelectedTileCoords.Value.ToString(), out var resident))
        {
            return;
        }

        HealthVital.SetValue(resident.Health);
        HealthVital.SetMaxValue(resident.MaxHealth);
    }
}
