using System;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    [SerializeField] GemStats[] gems;
    
}

[Serializable]
public class GemStats {
    public string Name;
    public int BasePrice;
    public GameObject Prefab;
    public Sprite MenuSprite;
}


