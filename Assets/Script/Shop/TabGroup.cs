using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons = new List<TabButton>();
    public List<GameObject> objectsToSwap = new List<GameObject>();

    [NonSerialized] public TabButton selectedTab;


    private void Start()
    {
        OnTabSelected(tabButtons[0]);
    }

    public void Subscribe(TabButton button)
    {
        tabButtons.Add(button);
    }

    private void ResetTabs()
    {
        foreach (var button in tabButtons) 
        { 
            if (selectedTab != null && button == selectedTab) 
            {
                continue;
            }
            //if background change
        }
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        //if background change

        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }

    }
}
