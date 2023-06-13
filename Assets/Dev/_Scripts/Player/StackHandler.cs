using System.Collections.Generic;
using UnityEngine;

public class StackHandler : MonoBehaviour
{
    [SerializeField] private Transform baseTransform;

    private Vector3 _stackPos = Vector3.zero;
    private Stack<GemBase> _gems = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GemBase gem))
        {
            if (!gem.IsCollectable) return;

            gem.Collect();
            AddToStack(gem);
        }
    }

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

    private void AddToStack(GemBase gem)
    {
        _gems.Push(gem);
        gem.transform.SetParent(baseTransform);
        gem.transform.SetLocalPositionAndRotation(_stackPos, Quaternion.identity);
        _stackPos += gem.TopPivot;
    }
}