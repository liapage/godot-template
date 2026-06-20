namespace Game;

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Chickensoft.Log;
using Godot;
using Utils;
// using Steamworks;

public partial class Game : Control
{
    // API
    public static Game Instance = null!;

    [Export] public SceneManager SceneManager = null!;
    [Export] public AudioManager AudioManager = null!;
    public readonly ILog Log = new Log(nameof(Game), new ConsoleWriter(), new TraceWriter());
    public readonly Config.Config Config = new();
    public State.State State = null!;

    // Dependencies
    [Export] private PackedScene _initialScene = null!;

    public override void _EnterTree()
    {
        Instance = this;
        Input.SetMouseMode(Input.MouseModeEnum.Hidden);
    }

    public override void _ExitTree()
    {
        Input.SetMouseMode(Input.MouseModeEnum.Visible);
    }

    public override void _Ready()
    {
        State = new State.State(Config);

        SceneManager.SwitchScene(_initialScene);

        if (SteamLoader.Init())
        {
            GD.Print("Initialized steam");
        }
        else
        {
            GD.PrintErr("Not able to initialize steam");
        }

        // GD.Print($"SteamAPI.IsSteamRunning() {SteamAPI.IsSteamRunning()}");
        // GD.Print($"SteamAPI.IsSteamRunning() {SteamFriends.GetPersonaName()}");
    }



    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("exit"))
        {
            GetTree().Quit();
        }
    }
}
