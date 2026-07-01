namespace Game.World.hud.Panels.Vitals;

public partial class VitalsPanel : Panel
{
    public override void _Ready()
    {
        base._Ready();

        Visible = false;
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
            Visible = false;
            return;
        }

        if (!Game.Instance.State.Residents.ContainsKey(Game.Instance.World.DrawGrid.SelectedTileCoords.Value.ToString()))
        {
            Visible = false;
            return;
        }

        Visible = true;
    }
}
