using System.Collections;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Settings")]
    [SerializeField] private float saleDelay = 0.1f;

    private Coroutine _saleCoroutine;
    private bool _isSelling;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || _isSelling) return;

        if (other.TryGetComponent(out StackHandler stackHandler))
        {
            _isSelling = true;
            _saleCoroutine = StartCoroutine(ProcessGemSale(stackHandler));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player") || !_isSelling) return;

        _isSelling = false;
        StopCoroutine(_saleCoroutine);
    }

    private IEnumerator ProcessGemSale(StackHandler stackHandler)
    {
        while (_isSelling)
        {
            var gem = stackHandler.GetFromStack();
            if (gem != null)
                GameManager.Instance.InvokeOnGemSale(gem);

            yield return Helpers.BetterWaitForSeconds(saleDelay);
        }
    }
}