using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemHolder : MonoBehaviour
{
    private QuestItem questItem;
    
    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private TextMeshProUGUI RewardText;
    [SerializeField] private TextMeshProUGUI questProgressText;
    [SerializeField] private Image rewardImage;
    //private int currentProgress = 0;
    public void Initialize(QuestItem item, int count)
    {
        questItem = item;
        questDescriptionText.text = item.Description;
        rewardImage.sprite = questItem.RewardIcon;
        questProgressText.text = "0/" + questItem.ProgressCount.ToString();
        RewardText.text = questItem.RewardAmount.ToString();

        if(questItem.Level >= 0) //add level system condition
        {
            UnlockItem();
            HandleSizeChange(count);
        }
    }

    public void UnlockItem()
    {
       gameObject.SetActive(true);
    }

    private void HandleSizeChange(int newCount)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(380, 50);
        rectTransform.anchoredPosition = new Vector2(10, -10 + -60 * newCount);
    }
}
