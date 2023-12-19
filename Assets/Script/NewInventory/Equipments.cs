using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments : Items
{
    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new EquipmentInstance(this));
    }

}

[Serializable]
public class EquipmentInstance : ItemInstance
{
    public int equipmentNum1 = 1;

    public EquipmentInstance(Items template) : base(template)
    {
        if(template != null)
        {
            items = template;
            templateName = template.name;
        }
    }

    public override void Clicked()
    {
        PlayerInventory.instance.EquipItem(this);
    }

    public virtual void UnEquip() {

        PlayerInventory.instance.UnEquipItem(this);
    
    }

}
