using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemInfo : MonoBehaviour
{
    [Header("Info Settings")]
    [SerializeField] private TextMeshProUGUI gemTypeText;
    [SerializeField] private TextMeshProUGUI gemCollectedCountText;
    [SerializeField] private Image gemSprite;

    public string Name => _name;
    private string _name;

    #region PUBLIC METHODS

    public void Init(GemBaseStats stats)
    {
        _name = stats.Name;
        gemTypeText.text = $"Gem Type: {_name}";
        gemCollectedCountText.text = $"Collected Count: {0}";
        gemSprite.sprite = stats.MenuSprite;
    }

    public void UpdateCount(int value)
    {
        gemCollectedCountText.text = $"Collected Count: {value}";
    }

    #endregion
}