using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemHolder : MonoBehaviour
{
    private QuestItem questItem;
    
    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private TextMeshProUGUI RewardText;
    [SerializeField] private TextMeshProUGUI questProgressText;
    [SerializeField] private Image questStatusButtonBGImage;

    [SerializeField] private TextMeshProUGUI questButtonStatusText;
    [SerializeField] private Image rewardImage;

    //private int currentProgress = 0;
    public void Initialize(QuestItem item, int count)
    {
        questItem = item;
        questDescriptionText.text = item.Description;
        rewardImage.sprite = questItem.RewardIcon;
        questProgressText.text = "0/" + questItem.ProgressCount.ToString();
        RewardText.text = questItem.RewardAmount.ToString();
        updateQuestButtonText(questItem.Status);
        if (questItem.Level >= 0) //add level system condition
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

    public void startQuest()
    {
        if(questItem != null)
        {
            if (questItem.Status == QuestStatus.NotStarted)
            {
                questItem.Status = QuestStatus.InProgress;
                updateQuestButtonText(questItem.Status);
            }
            else if(questItem.Status == QuestStatus.InProgress) 
            {   
                questItem.Status = QuestStatus.Completed;                
                updateQuestButtonText(questItem.Status);
            } 
            else if (questItem.Status == QuestStatus.Completed)
            {
                questItem.Status = QuestStatus.NotStarted;
                updateQuestButtonText(questItem.Status);
            }

            //add current level check and null
        }
    }

    public void updateQuestButtonText(QuestStatus qStat)
    {
        if (qStat == QuestStatus.NotStarted)
        {
            questButtonStatusText.text = "START";
            questStatusButtonBGImage.color = Color.white;
        }
        else if (qStat == QuestStatus.InProgress)
        {
            questButtonStatusText.text = "ONGOING";
            questStatusButtonBGImage.color = Color.cyan;
        }
        else if (qStat == QuestStatus.Completed)
        {
            questButtonStatusText.text = "DONE";
            questStatusButtonBGImage.color = Color.green;
        }
    }


    public void CheckQuestProgess()
    {

    }
}
