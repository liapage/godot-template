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

    public static Vector2I Vector2IFromString(string str)
    {
        if (str.Length < 5)
        {
            GD.PrintErr("Expected string value of valid length to parse Vector2I");
            return Vector2I.Zero;
        }

        if (str[0] != '(' && str[^1] != ')')
        {
            GD.PrintErr("Expected string value of valid structure to parse Vector2I");
            return Vector2I.Zero;
        }

        str =  str.Substring(1, str.Length - 2);

        var numStrs = str.Split(',');
        if (numStrs.Length != 2)
        {
            GD.PrintErr("Expected 2 numbers to parse Vector2I");
            return Vector2I.Zero;
        }

        if (!int.TryParse(numStrs[0].Trim(), out int x) || !int.TryParse(numStrs[1].Trim(), out int y))
        {
            GD.PrintErr("Expected 2 valid numbers to parse Vector2I");
            return Vector2I.Zero;
        }

        return new Vector2I(x, y);
    }
}
