using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemHolder : MonoBehaviour
{
    private ItemData inventoryItem;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private BuyItemDetailPanel detailPanel;

    public void Initialize(ItemData item, int count)
    {
        inventoryItem = item;

        iconImage.sprite = inventoryItem.Icon;
        titleText.text = item.Name;
        priceText.text = item.Price.ToString();
        
        if (inventoryItem.Level >= 0) //add level system condition
        {
            UnlockItem();
            HandleSizeChange(count);
        }
    }

    public void UnlockItem()
    {
        iconImage.transform.gameObject.SetActive(true);
    }

    private void HandleSizeChange(int newCount)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchoredPosition = new Vector2(10 + 60 * GetPosition(newCount, true), -10 + -60 * GetPosition(newCount, false));
    }

    public int GetPosition(int positionIndex, bool isWidth)
    {
        int a;
        if (isWidth)
        {
            a = (positionIndex % 3) != 0 ? (positionIndex % 3) : 0;
            //Debug.Log("positionIndex" + positionIndex + "width" + a);
            return a;
        }
        else
            a = (positionIndex % 3) == 0 ? positionIndex / 3 : (int)(positionIndex / 3);
        // Debug.Log("positionIndex" + positionIndex  + "height" +a);
        return a;
    }
}
