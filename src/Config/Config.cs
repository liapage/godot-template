namespace Game.Config;

using System.Collections.Generic;


public enum AudioEffect
{
    Unknown = 0,

    EnemyHit,
}

public class Config
{
    /* === Audio === */
    public readonly Dictionary<AudioEffect, string> AudioEffects = new()
    {
        // {
        //     AudioEffect.EnemyHit,
        //     "res://assets/audio/enemy_damaged.wav"
        // },
    };
}
