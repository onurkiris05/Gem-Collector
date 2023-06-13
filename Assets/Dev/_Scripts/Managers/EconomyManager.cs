using System;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    private int _currentWallet;

    private void OnEnable()
    {
        GameManager.Instance.OnGemSale += UpdateWallet;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGemSale -= UpdateWallet;
    }

    private void UpdateWallet(GemBase gem)
    {
        _currentWallet += gem.Value();
        GameManager.Instance.InvokeOnUpdateWallet(_currentWallet);
        print($"Gem Value: {gem.Value()}");
        print($"Current Wallet: {_currentWallet}");
    }
}
