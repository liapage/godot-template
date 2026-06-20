namespace Game.Utils;

using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class AudioManager : Node2D
{
    private readonly Dictionary<Config.AudioEffect, AudioStreamPlayer> _effectPlayers = [];

    public override void _Ready()
    {
        foreach (var (audioEffectId, audioEffectPath) in Game.Instance.Config.AudioEffects)
        {
            var stream = ResourceLoader.Load<AudioStream>(audioEffectPath);
            var player = new AudioStreamPlayer { Stream = stream };
            AddChild(player);
            _effectPlayers.Add(audioEffectId, player);
        }
    }

    public void PlayEffect(Config.AudioEffect effect)
    {
        if (!_effectPlayers.TryGetValue(effect, out var player))
        {
            Game.Instance.Log.Err($"Player not found for audio effect {effect.ToString()}");
            return;
        }

        player.Play();
    }
}
