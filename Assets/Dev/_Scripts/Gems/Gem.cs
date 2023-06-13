using System;
using UnityEngine;

public class Gem : GemBase
{
    private GemStats _myStats = new();

    public override void Init<T>(T stats)
    {
        _myStats = (GemStats)(object)stats;
        transform.localScale = Vector3.zero;
    }

    public override int Value()
    {
        var gemValue = Mathf.RoundToInt(_myStats.BasePrice + transform.localScale.x * 100);
        return gemValue;
    }
}

[Serializable]
public class GemStats : GemBaseStats
{
    public Gem Prefab;
}