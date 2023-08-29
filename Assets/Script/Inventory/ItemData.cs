using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable Item", menuName = "GemCollectorScriptable/Collectable Item", order = 0)]
public class ItemData : ScriptableObject
{
    public string Name = "Default";
    public string Description = "Description";
    public Sprite Icon;
    public int Price;
    public int level;
    public GameObject Prefab;
}
