using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "GemCollectorScriptable/Shop Item")]
public class ShopItem : ScriptableObject
{
    public string Name =  "Default";
    public string Description =  "Description";
    public Sprite Icon;
    public int Price;
    public ShopItemCategory Category;
    public int level;
    //public GameObject Prefab;

   /* public InventoryItem(ItemData item)
    {
        itemData = item;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }*/
}

public enum ShopItemCategory
{
    Buy,
    Quests,
    Sell
}
