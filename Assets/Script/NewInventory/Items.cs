using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : ScriptableObject
{
    public Sprite sprite;
    public abstract void AddToInventory();
}

public abstract class ItemInstance {

    [NonSerialized]
    public Items items;
    public string templateName;
    public string itemType;

    public ItemInstance(Items temp)
    {
        if(temp != null)
        {
            items = temp;
            templateName = temp.name;
        }
    }

    public abstract void Clicked();


}
