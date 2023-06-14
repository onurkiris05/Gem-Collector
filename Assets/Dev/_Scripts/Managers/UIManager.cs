using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private GemInfo gemInfoPrefab;
    [SerializeField] private RectTransform gemInfoParent;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private TextMeshProUGUI walletText;

    private List<GemInfo> _gemInfos = new();

    #region UNITY EVENTS

    private void OnEnable()
    {
        GameManager.Instance.OnGemsInit += Init;
        GameManager.Instance.OnUpdateWallet += UpdateWalletUI;
        GameManager.Instance.OnUpdatePopup += UpdatePopupUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGemsInit -= Init;
        GameManager.Instance.OnUpdateWallet -= UpdateWalletUI;
        GameManager.Instance.OnUpdatePopup -= UpdatePopupUI;
    }

    #endregion

    #region PRIVATE METHODS

    private void Init(GemBaseStats[] gems)
    {
        // Initialize popup window content
        foreach (var gem in gems)
        {
            var gemInfo = Instantiate(gemInfoPrefab, gemInfoParent);
            gemInfo.Init(gem);
            _gemInfos.Add(gemInfo);
        }

        scrollbar.value = 1;
    }

    private void UpdatePopupUI(Dictionary<GemBaseStats, int> dict)
    {
        var gemInfosDict = _gemInfos.ToDictionary(info => info.Name);
        
        foreach (var gem in dict)
            if (gemInfosDict.TryGetValue(gem.Key.Name, out var info))
                info.UpdateCount(gem.Value);
    }

    private void UpdateWalletUI(int wallet)
    {
        walletText.text = wallet.ToString("000000");
    }

    #endregion
}