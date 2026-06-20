namespace Game.Utils;

using System.Collections.Generic;
using Godot;

public static class GodotExtensions
{
    // Iterates over a node's children until it finds the first child of a certain type. Returns null if not found.
    public static T? FindChild<T>(this Node node) where T : Node
    {
        foreach (var child in node.GetChildren())
        {
            if (child is T type)
            {
                return type;
            }
        }

        return null;
    }

    // Iterates over a node's children, only returning children of a certain type.
    public static IEnumerable<T> FindChildren<T>(this Node node) where T : Node
    {
        foreach (var child in node.GetChildren())
        {
            if (child is T type)
            {
                yield return type;
            }
        }
    }
}
