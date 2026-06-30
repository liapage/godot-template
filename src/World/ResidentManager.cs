using Godot;

namespace Game.World;

using System;
using Chickensoft.Log;
using State;
using Utils;

public partial class ResidentManager : Node2D
{
    private readonly ILog _log = new Log(nameof(Game), new ConsoleWriter(), new TraceWriter());

    public Action? ResidentRequestsModified;
    public Action<Resident>? ResidentAdded;

    public void AddResidentRequest(Resident resident)
    {
        Game.Instance.State.ResidentRequests.Add(resident);
        ResidentRequestsModified?.Invoke();
    }

    public void AcceptResidentRequest(Resident resident)
    {
        var selectedTile = Game.Instance.World.ResidentGrid.SelectedTileCoords;
        if (!selectedTile.HasValue)
        {
            _log.Err("Can't accept resident request as no tile is selected");
            return;
        }

        Game.Instance.State.Residents.Add(selectedTile.Value.ToString(), resident);
        Game.Instance.State.ResidentRequests.Remove(resident);
        ResidentRequestsModified?.Invoke();
        ResidentAdded?.Invoke(resident);

        Game.Instance.World.ResidentGrid.SetCell(selectedTile.Value, 0, Vector2I.Zero);
    }
}
