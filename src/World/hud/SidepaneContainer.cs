using Godot;

namespace Game.World.hud;

public partial class SidepaneContainer : Control
{
    [Export] private PackedScene _noSelectionScene = null!;
    [Export] private PackedScene _selectedScene = null!;

    public override void _Ready()
    {
        Game.Instance.World.DrawGrid.OnTileSelect += e =>
        {
            foreach (var child in GetChildren())
            {
                RemoveChild(child);
            }

            if (e.OutOfBounds)
            {
                var scene = _noSelectionScene.Instantiate();
                AddChild(scene);
            }
            else
            {
                var scene = _selectedScene.Instantiate();
                AddChild(scene);
            }
        };
    }
}
