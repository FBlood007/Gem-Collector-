using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BuyItemDetailPanel : MonoBehaviour
{
    private ItemData Currentitem;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI CountText;
    [SerializeField] private TextMeshProUGUI FinalAmount;
    private int currentItemCount = 0;

    void Start()
    {
        
    }

    public void updateItemDetail(ItemData item)
    {
        Currentitem = item;
        descriptionText.text = item.Description;
        iconImage.sprite = item.Icon;
        if (item.Count <= 9)
            CountText.text = "01/0" + item.Count;
        else if (item.Count > 9)
            CountText.text = "01/" + item.Count;
        currentItemCount = 1;
        FinalAmount.text = calcuateFinalAmount().ToString();
    }

    private int calcuateFinalAmount()
    {
        if (Currentitem != null)
        return Mathf.RoundToInt(Currentitem.Price * currentItemCount);
        else return 0;
    }

}
