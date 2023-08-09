using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI stackSizeText;


    public void ClearSlot()
    {
        Icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;

    }

    public void DrawSlot(InventoryItem item)
    {
        if(item == null) 
        {
            ClearSlot();
            return;
        }
        Icon.enabled = true;
        labelText.enabled = true;
        stackSizeText.enabled = true;

        Icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.name;
        stackSizeText.text = item.stackSize.ToString();


    }

}
