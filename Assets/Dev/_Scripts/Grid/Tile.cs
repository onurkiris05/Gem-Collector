using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    [Header("Tile Settings")]
    [SerializeField] private Sprite[] sprites;

    SpriteRenderer _spriteRenderer;

    private void Awake() => _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    private void OnEnable() => _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
}