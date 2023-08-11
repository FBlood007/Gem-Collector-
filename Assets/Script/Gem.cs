using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour,ICollectables
{
    public static event HandleGemCollected onGemCollected;
    public delegate void HandleGemCollected(ItemData itemData);
    public ItemData gemData;
    public void Collect()
    {
        Debug.Log("you collected a gem");
        Destroy(gameObject);
        onGemCollected?.Invoke(gemData);
    }
}
