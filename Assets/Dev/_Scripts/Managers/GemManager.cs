using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemManager : MonoBehaviour
{
    [SerializeField] GemStats[] gems;

    private void OnEnable()
    {
        GameManager.Instance.OnGridInit += Init;
        GameManager.Instance.OnGemCollect += CreateGem;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGridInit -= Init;
        GameManager.Instance.OnGemCollect -= CreateGem;
    }

    private void Init(List<Tile> tiles)
    {
        foreach (var tile in tiles)
            CreateGem(tile.transform.position);
    }

    private void CreateGem(Vector3 pos)
    {
        var randomGem = gems[Random.Range(0, gems.Length)];
        var gem = Instantiate(randomGem.Prefab, pos, Quaternion.identity, transform);
        gem.Init(randomGem);
    }
}


