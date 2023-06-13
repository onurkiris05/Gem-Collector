using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A static class for general helpful methods
/// </summary>
public static class Helpers 
{
    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new();
    public static WaitForSeconds BetterWaitForSeconds(float seconds)
    {
        // Check if WaitForSeconds instance for the specified seconds exists in the dictionary
        if (!WaitDictionary.TryGetValue(seconds, out var wait))
        {
            wait = new WaitForSeconds(seconds);
            WaitDictionary.Add(seconds, wait);
        }

        return wait;
    }
    
    public static int LayerToInt(this LayerMask mask)
    {
        return Mathf.RoundToInt(Mathf.Log(mask.value, 2));
    }
    
    public static void DestroyChildren(this Transform t) {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }
    
    public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
    {
        // Convert the screen position of the canvas element to local position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(element, element.position,
            Camera.main, out var localPoint);
        
        return localPoint;
    }
}
