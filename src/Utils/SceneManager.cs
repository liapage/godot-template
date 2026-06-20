namespace Game.Utils;

using Godot;

[GlobalClass]
public partial class SceneManager : Node
{
    [Export] private Node _sceneContainer = null!;
    [Export] private float _duration = 0.3f;

    private ColorRect _colorRect = null!;
    private PackedScene? _previousScene;
    private PackedScene? _currentScene;
    private PackedScene? _switchingTo;

    public override void _EnterTree()
    {
        var canvasLayer = new CanvasLayer { Layer = 100 };
        AddChild(canvasLayer);

        _colorRect = new ColorRect
        {
            Color = new Color(0, 0, 0, 0),
            Visible = false,
        };
        _colorRect.SetAnchorsPreset(Control.LayoutPreset.FullRect);
        canvasLayer.AddChild(_colorRect);
    }

    public void SwitchScene(PackedScene? scene)
    {
        if (scene == null)
        {
            Game.Instance.Log.Err("Got null scene");
            return;
        }

        _switchingTo = scene;

        _switchingTo = null;
        _previousScene = _currentScene;
        _currentScene = scene;

        // Remove current scene
        foreach (var child in _sceneContainer.GetChildren())
        {
            _sceneContainer.RemoveChild(child);
        }

        // Add new scene
        _sceneContainer.AddChild(scene.Instantiate());
        Game.Instance.Log.Print("Switched scene");
    }

    public void SwitchSceneFade(PackedScene scene)
    {
        if (_switchingTo != null)
        {
            // Fail quietly if already switching
            return;
        }

        _switchingTo = scene;

        _colorRect.Visible = true;
        _colorRect.Color = new Color(0, 0, 0, 0);

        var tween = GetTree().CreateTween();
        tween.TweenProperty(_colorRect, "color", Colors.Black, _duration);

        tween.Finished += () =>
        {
            var fadeOutTween = GetTree().CreateTween();
            fadeOutTween.TweenProperty(_colorRect, "color", new Color(0, 0, 0, 0), _duration);
            fadeOutTween.Finished += () =>
            {
                _colorRect.Visible = false;
            };

            SwitchScene(_switchingTo);
        };
    }

    public void SwitchToPreviousScene()
    {
        SwitchScene(_previousScene);
    }

    public bool IsSwitching()
    {
        return _switchingTo != null;
    }

    public override void _UnhandledKeyInput(InputEvent @event)
     {
         if (@event.IsActionPressed("reload_scene"))
         {
             SwitchScene(_currentScene);
         }
     }
}
