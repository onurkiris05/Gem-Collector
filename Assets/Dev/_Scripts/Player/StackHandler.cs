using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackHandler : MonoBehaviour
{
    [SerializeField] private Transform baseTransform;

    private Vector3 _stackPos = Vector3.zero;
    private Stack<GemBase> _gems = new();

    #region UNITY EVENTS

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GemBase gem))
        {
            if (!gem.IsCollectable) return;

            gem.Collect();
            AddToStack(gem);
        }
    }

    #endregion

    #region PUBLIC METHODS

    public GemBase GetFromStack()
    {
        if (_gems.Count > 0)
        {
            var gem = _gems.Pop();
            _stackPos -= gem.TopPivot;
            return gem;
        }
        return null;
    }

    #endregion

    #region PRIVATE METHODS

    private void AddToStack(GemBase gem)
    {
        var pos = _stackPos;
        _stackPos += gem.TopPivot;
        
        gem.transform.SetParent(baseTransform);
        gem.transform.DOLocalJump(pos, 2f, 1, 1f).OnComplete(() =>
        {
            _gems.Push(gem);
        });
    }

    #endregion
}