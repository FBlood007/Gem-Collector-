using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemHolder : MonoBehaviour
{
   private ShopItem Item;
    private ItemData inventoryItem;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image currencyImage;
    [SerializeField] private TextMeshProUGUI priceText;


    public void Initialize(ShopItem item)
    {
        Item = item;

        iconImage.sprite = Item.Icon;
        titleText.text = item.Name;
        descriptionText.text = item.Description;
        //currencyImage.sprite = ShopManager.currencySprite;
        priceText.text = Item.Price.ToString();

        if(Item.level >= 0) //add level system condition
        {
            UnlockItem();
        }
    }

    public void InitializeSellItem(ItemData item)
    {
        inventoryItem = item;

        iconImage.sprite = Item.Icon;
        titleText.text = item.Name;
        descriptionText.text = item.Description;
        //currencyImage.sprite = ShopManager.currencySprite;
        priceText.text = Item.Price.ToString();

        if (Item.level >= 0) //add level system condition
        {
            UnlockItem();
        }
    }

    public void UnlockItem()
    {
        iconImage.transform.GetChild(0).gameObject.SetActive(true);
    }
}
