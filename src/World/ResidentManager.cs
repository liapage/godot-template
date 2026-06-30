using Godot;

namespace Game.World;

using System;
using addons.godlib.SceneGrid;
using Chickensoft.Log;
using State;

public partial class ResidentManager : Node2D
{
    private readonly ILog _log = new Log(nameof(Game), new ConsoleWriter(), new TraceWriter());

    [Export] public PackedScene ResidentScene = null!;

    public Action? ResidentRequestsModified;
    public Action<Resident>? ResidentAdded;

    public void AddResidentRequest(Resident resident)
    {
        Game.Instance.State.ResidentRequests.Add(resident);
        ResidentRequestsModified?.Invoke();
    }

    public void AcceptResidentRequest(Resident resident)
    {
        var selectedTile = Game.Instance.World.DrawGrid.SelectedTileCoords;
        if (!selectedTile.HasValue)
        {
            _log.Err("Can't accept resident request as no tile is selected");
            return;
        }

        // Set data
        Game.Instance.State.Residents.Add(selectedTile.Value.ToString(), resident);
        Game.Instance.State.ResidentRequests.Remove(resident);

        // Add scene
        var residentScene = ResidentScene.Instantiate<SceneGridNode>();
        Game.Instance.World.SceneGrid.SetCell(selectedTile.Value, residentScene);

        // Invoke events
        ResidentRequestsModified?.Invoke();
        ResidentAdded?.Invoke(resident);
    }
}
