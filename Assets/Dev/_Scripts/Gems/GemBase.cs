using UnityEngine;

public abstract class GemBase : MonoBehaviour
{
    [Header("Gem Settings")]
    [SerializeField] protected float growTime = 5f;
    [SerializeField] protected float minCollectableSize = 0.25f;
    [SerializeField] protected Transform topPivot;
    public bool IsCollectable { get; protected set; }
    public Vector3 TopPivot => Vector3.Scale(topPivot.localPosition, transform.localScale);
    
    protected bool _isGrowing = true;
    protected float _timer;
    
    protected virtual void Update()
    {
        GrowInTime();
    }

    public abstract void Init<T>(T type);
    public abstract int Value();
    
    public virtual void Collect()
    {
        _isGrowing = false;
        IsCollectable = false;
        GameManager.Instance.InvokeOnGemCollect(transform.position);
    }
    
    protected virtual void GrowInTime()
    {
        if (!_isGrowing) return;
        
        _timer += Time.deltaTime;

        if (_timer <= growTime)
        {
            var scaleFactor = _timer / growTime;
            transform.localScale = Vector3.one * scaleFactor;

            if (transform.localScale.x > minCollectableSize)
                IsCollectable = true;
        }
        else
        {
            transform.localScale = Vector3.one;
            _isGrowing = false;
        }
    }
}

// Inherit from this class for future different kind of gem stats
public abstract class GemBaseStats
{
    public string Name;
    public int BasePrice;
    public Sprite MenuSprite;
}
