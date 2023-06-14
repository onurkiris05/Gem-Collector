using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    private Dictionary<GemBaseStats, int> _gems = new();
    private int _currentWallet;

    #region UNITY EVENTS

    private void OnEnable()
    {
        GameManager.Instance.OnEconomyInit += Init;
        GameManager.Instance.OnGemSale += UpdateWallet;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnEconomyInit -= Init;
        GameManager.Instance.OnGemSale -= UpdateWallet;
    }

    #endregion

    #region PRIVATE METHODS

    private void Init(GemBaseStats[] gems)
    {
        // Initialize wallet
        _currentWallet = DataManager.Instance.Load("Wallet", 0);
        GameManager.Instance.InvokeOnUpdateWallet(_currentWallet);

        // Initialize popup window info
        foreach (var gem in gems)
        {
            var collectedCount = DataManager.Instance.Load(gem.Name, 0);
            _gems.Add(gem, collectedCount);
        }
        GameManager.Instance.InvokeOnUpdatePopup(_gems);
    }

    private void UpdateWallet(GemBase gem)
    {
        _currentWallet += gem.Value();
        DataManager.Instance.Save("Wallet", _currentWallet);
        GameManager.Instance.InvokeOnUpdateWallet(_currentWallet);

        UpdateCollectedCount(gem);
    }

    private void UpdateCollectedCount(GemBase gem)
    {
        if (_gems.ContainsKey(gem.Stats()))
        {
            _gems[gem.Stats()]++;
            DataManager.Instance.Save(gem.Stats().Name, _gems[gem.Stats()]);
            GameManager.Instance.InvokeOnUpdatePopup(_gems);
        }
    }

    #endregion
}