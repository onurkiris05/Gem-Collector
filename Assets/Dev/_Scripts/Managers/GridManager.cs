using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private List<Tile> _tiles = new();
    private void Awake() => _tiles = FindObjectsOfType<Tile>().ToList();
    private void Start() => GameManager.Instance.InvokeOnGridInit(_tiles);
}
