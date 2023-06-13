using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private int column;
    [SerializeField] private int row;
    [SerializeField] private float betweenSpace;

    public List<Tile> Tiles => _tiles;
    private List<Tile> _tiles = new();

    private void Awake() => _tiles = FindObjectsOfType<Tile>().ToList();

    private void Start()
    {
        GameManager.Instance.InvokeOnGridInit(_tiles);
    }


#if UNITY_EDITOR
    [ContextMenu("Grid/Generate Tiles")]
    private void GenerateTiles()
    {
        var xOffset = tilePrefab.transform.localScale.x + betweenSpace;
        var zOffset = tilePrefab.transform.localScale.z + betweenSpace;
        var startX = transform.position.x - (xOffset * (column / 2f) - xOffset / 2f);
        var startZ = transform.position.z - (zOffset * (row / 2f) - zOffset / 2f);

        var spawnPos = new Vector3(startX, transform.position.y, startZ);

        _tiles.Clear();

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                var tile = (Tile)PrefabUtility.InstantiatePrefab(tilePrefab, transform);
                tile.transform.position = spawnPos;
                _tiles.Add(tile);
                spawnPos = new Vector3(spawnPos.x + xOffset, spawnPos.y, spawnPos.z);
            }

            spawnPos = new Vector3(startX, spawnPos.y, spawnPos.z + zOffset);
        }
    }

    [ContextMenu("Grid/Clear Tiles")]
    private void ClearTiles()
    {
        _tiles = FindObjectsOfType<Tile>().ToList();

        if (_tiles.Count > 0)
            foreach (var tile in _tiles)
                DestroyImmediate(tile.gameObject);

        _tiles.Clear();
    }
#endif
}