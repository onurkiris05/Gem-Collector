using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI walletText;

    private void OnEnable()
    {
        GameManager.Instance.OnUpdateWallet += UpdateWalletUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnUpdateWallet -= UpdateWalletUI;
    }

    private void UpdateWalletUI(int wallet)
    {
        walletText.text = wallet.ToString("000000");
    }
}