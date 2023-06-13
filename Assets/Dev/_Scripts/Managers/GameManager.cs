using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action<List<Tile>> OnGridInit;
    public event Action<Vector3> OnGemCollect;
    public event Action<GemBase> OnGemSale;
    public event Action<int> OnUpdateWallet; 

    public void InvokeOnGridInit(List<Tile> tiles)
    {
        OnGridInit?.Invoke(tiles);
    }

    public void InvokeOnGemCollect(Vector3 pos)
    {
        OnGemCollect?.Invoke(pos);
    }

    public void InvokeOnGemSale(GemBase gem)
    {
        OnGemSale?.Invoke(gem);
        Destroy(gem.gameObject);
    }

    public void InvokeOnUpdateWallet(int currentWallet)
    {
        OnUpdateWallet?.Invoke(currentWallet);
    }
}
