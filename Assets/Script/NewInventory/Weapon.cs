using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Equipments
{
    public int damamge;

    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new WeaponInstance(this));
    }
}

[System.Serializable]
public class WeaponInstance : EquipmentInstance {

    public float weaponFloat1 = 0.5f;

    public WeaponInstance(Items template) :  base(template) {
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

    public override void UnEquip()
    {
        PlayerInventory.instance.UnEquipItem(this); 
    }
}
