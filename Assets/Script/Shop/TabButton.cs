using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
   public TabGroup TabGroup;
    //[NonSerialized] public Image background;


    private void Awake()
    {
        TabGroup.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TabGroup.OnTabSelected(this);
    }
}
