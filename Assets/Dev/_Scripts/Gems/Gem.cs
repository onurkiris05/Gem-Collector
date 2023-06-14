using System;
using UnityEngine;

public class Gem : GemBase
{
    public override GemBaseStats Stats() => _myStats;
    private GemStats _myStats = new();

    #region PUBLIC METHODS

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

    #endregion
}

[Serializable]
public class GemStats : GemBaseStats
{
    public Gem Prefab;
}