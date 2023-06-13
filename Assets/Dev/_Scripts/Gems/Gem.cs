using System;
using UnityEngine;

public class Gem : GemBase
{
    private GemStats _myBaseStats = new();

    public override void Init<T>(T stats)
    {
        _myBaseStats = (GemStats)(object)stats;
        transform.localScale = Vector3.zero;
    }

    public override float GemValue()
    {
        var gemValue = _myBaseStats.BasePrice * transform.localScale.magnitude * 100;
        return gemValue;
    }
}

[Serializable]
public class GemStats : GemBaseStats
{
    public Gem Prefab;
}