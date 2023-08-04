using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour,ICollectables
{
    public static event Action onGemCollected;

    public void Collect()
    {
        Debug.Log("you collected a gem");
        Destroy(gameObject);
        onGemCollected?.Invoke();
    }
}
