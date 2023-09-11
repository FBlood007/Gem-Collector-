using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BuyItemDetailPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI CountText;
    [SerializeField] private TextMeshProUGUI FinalAmount;
    private ItemData Currentitem;
    private int currentItemCount = 0;

    public void decreaseItemCount()
    {
        string s = currentItemCount.ToString();
        if (currentItemCount > 0 && Currentitem != null)
        {
            currentItemCount--;
            if (currentItemCount < 9)
                s = "0" + currentItemCount.ToString();
            if (Currentitem.Count <= 9)
                CountText.text = s + "/0" + Currentitem.Count;
            else if (Currentitem.Count > 9)
                CountText.text = s + "/" + Currentitem.Count;
            FinalAmount.text = calcuateFinalAmount().ToString();
        }
    }

    public void IncreaseItemCount()
    {
        string s = currentItemCount.ToString();
        if (currentItemCount < Currentitem.Count && Currentitem != null)
        {
            currentItemCount++;

            if (currentItemCount < 9)
                s = "0" + currentItemCount.ToString();

            if (Currentitem.Count <= 9)
                CountText.text = s + "/0" + Currentitem.Count;
            else if (Currentitem.Count > 9)
                CountText.text = s + "/" + Currentitem.Count;
            FinalAmount.text = calcuateFinalAmount().ToString();
        }
    }

    public void updateItemDetail(ItemData item)
    {
        if (item != null && Currentitem != item)
        {
            Currentitem = item;
            descriptionText.text = item.Description;
            iconImage.sprite = item.Icon;
            if (item.Count <= 9)
                CountText.text = "01/0" + item.Count.ToString();
            else if (item.Count > 9)
                CountText.text = "01/" + item.Count.ToString();
            currentItemCount = 1;
            FinalAmount.text = calcuateFinalAmount().ToString();
            calcuateFinalAmount();
        }
        
    }

    private int calcuateFinalAmount()
    {
        if (Currentitem != null)
        return Mathf.RoundToInt(Currentitem.Price * currentItemCount);
        else return 0;
    }

}
