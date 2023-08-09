using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> onInventoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData,InventoryItem> itemDictionary = new Dictionary<ItemData,InventoryItem>();

    private void OnEnable()
    {
        //Gem.OnGemCollected += Add;
    }

    private void OnDisable()
    {
    
    }

    public void Add(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData,out InventoryItem item)) {
            
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total no. of stacks {item.stackSize}");
            onInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);    
            inventory.Add(newItem);
            itemDictionary.Add(itemData,newItem);
            Debug.Log($"Added {item.itemData.displayName} to the iventory for fist time");
            onInventoryChange?.Invoke(inventory);

        }
    }


    public void Remove(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            //item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);    
            }
            onInventoryChange?.Invoke(inventory);
        }

    }
}
