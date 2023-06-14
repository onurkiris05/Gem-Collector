using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemManager : MonoBehaviour
{
    [Header("Gems")]
    [SerializeField] GemStats[] gems;

    #region UNITY EVENTS

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

    #endregion

    #region PRIVATE METHODS

    private void Init(List<Tile> tiles)
    {
        foreach (var tile in tiles)
            CreateGem(tile.transform.position);
        
        GameManager.Instance.InvokeOnGemsInit(gems);
        GameManager.Instance.InvokeOnEconomyInit(gems);
    }

    private void CreateGem(Vector3 pos)
    {
        var randomGem = gems[Random.Range(0, gems.Length)];
        var gem = Instantiate(randomGem.Prefab, pos, Quaternion.identity, transform);
        gem.Init(randomGem);
    }

    #endregion
}


