using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action<List<Tile>> OnGridInit;
    public event Action<GemBaseStats[]> OnGemsInit;
    public event Action<GemBaseStats[]> OnEconomyInit;
    public event Action<Vector3> OnGemCollect;
    public event Action<GemBase> OnGemSale;
    public event Action<int> OnUpdateWallet;
    public event Action<Dictionary<GemBaseStats, int>> OnUpdatePopup;

    public void InvokeOnGridInit(List<Tile> tiles) => OnGridInit?.Invoke(tiles);
    public void InvokeOnGemsInit(GemBaseStats[] gems) => OnGemsInit?.Invoke(gems);
    public void InvokeOnEconomyInit(GemBaseStats[] gems) => OnEconomyInit?.Invoke(gems);
    public void InvokeOnGemCollect(Vector3 pos) => OnGemCollect?.Invoke(pos);
    public void InvokeOnGemSale(GemBase gem) => OnGemSale?.Invoke(gem);
    public void InvokeOnUpdateWallet(int currentWallet) => OnUpdateWallet?.Invoke(currentWallet);
    public void InvokeOnUpdatePopup(Dictionary<GemBaseStats, int> dict) => OnUpdatePopup?.Invoke(dict);
}