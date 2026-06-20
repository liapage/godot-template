namespace Game.Utils.BT;

using System.Collections.Generic;

public class BtBlackboard
{
    private readonly Dictionary<string, object> _data = [];

    public void Set(string key, object val)
    {
        _data[key] = val;
    }

    public bool Get<T>(string key, out T? value)
    {
        if (!_data.TryGetValue(key, out var val))
        {
            value = default;
            return false;
        }

        if (val is not T t)
        {
            value = default;
            return false;
        }

        value = t;
        return true;
    }
}
