using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Item", menuName = "GemCollectorScriptable/Quest Item")]
public class QuestItem : ScriptableObject
{
    public string Name =  "Default";
    public string Description =  "Description";
    public Sprite RewardIcon;
    public int RewardAmount;
    public int ProgressCount;
    public ShopItemCategory Category;
    public QuestStatus Status;
    public int Level;
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
    Quests,
    Buy,
    Sell
}

public enum QuestStatus
{
    NotStarted,
    InProgress,
    Completed
}
