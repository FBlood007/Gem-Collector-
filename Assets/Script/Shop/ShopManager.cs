using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public static ShopManager _instance;
    //[SerializeField] public static Sprite currencySprite;
    //Animator animator;
    public Inventory inventoryScript;
    [SerializeField] private GameObject questItemPrefab;
    [SerializeField] private GameObject sellItemPrefab;
    public Dictionary<ShopItemCategory, List<QuestItem>> shopQuestItems = new Dictionary<ShopItemCategory, List<QuestItem>>();
    public Dictionary<ShopItemCategory, List<ItemData>> shopBuyItems = new Dictionary<ShopItemCategory, List<ItemData>>();
    [SerializeField] public TabGroup shopTabs;
    //public ShopItemCategory ObjectType;
    private bool opened;
    private Dictionary<ItemData, InventoryItem>.KeyCollection inventoryItems;

    private void Awake()
    {
        _instance = this;
    }

    public void Start()
    {
        //animator = GetComponent<Animator>();
        //inventoryScript = GetComponent<Inventory>();
        gameObject.SetActive(false);
        Load();
        Initialize();
    }

    private void Load()
    {
        QuestItem[] questitems = Resources.LoadAll<QuestItem>("Quest");
        ItemData[] buyitems = Resources.LoadAll<ItemData>("Sell");
        shopQuestItems.Add(ShopItemCategory.Quests, new List<QuestItem>());
        shopBuyItems.Add(ShopItemCategory.Buy, new List<ItemData>());
        foreach (var qitem in questitems)
        {
            shopQuestItems[qitem.Category].Add(qitem);
        }
        foreach (var bitem in buyitems)
        {
            shopBuyItems[ShopItemCategory.Buy].Add(bitem);
        }
        shopBuyItems.Add(ShopItemCategory.Sell, new List<ItemData>());
        if (inventoryScript.itemDictionary != null)
        {
            inventoryItems ??= inventoryScript.itemDictionary.Keys;
            if (inventoryScript != null)
            {
                foreach (var inventoryitem in inventoryItems)
                {
                    shopBuyItems[ShopItemCategory.Sell].Add(inventoryitem);
                }
            }
        }
    }

    private void Initialize()
    {
        int k = 0;
        for (int i = 0; i < shopQuestItems.Keys.Count; i++)
        {
            int index = 0;
            foreach (var item in shopQuestItems[(ShopItemCategory)i])
            {
                GameObject itemObject = Instantiate(questItemPrefab, shopTabs.objectsToSwap[i].transform);
                itemObject.GetComponent<QuestItemHolder>().Initialize(item,index);
                index++;
            }
            k++;
        }

        for (int j = 1; j < shopBuyItems.Keys.Count; j++)
        {
            int index = 0;
            foreach (var sellItem in shopBuyItems[(ShopItemCategory)j])
            {
                GameObject itemObject = Instantiate(sellItemPrefab, shopTabs.objectsToSwap[k].transform.GetChild(0).transform);
                itemObject.GetComponent<BuyItemHolder>().Initialize(sellItem, index);
                if (index == 0)
                    shopTabs.objectsToSwap[k].transform.GetChild(1).transform.GetComponent<BuyItemDetailPanel>().updateItemDetail(sellItem);
                index++;
            }
            k++;
        }
    }



    //for item/quest to be unlocked on different levels
    /*private void OnLevelChanged(LevelChangedGameEvent info)
    {
        for (int i = 0; i < shopItems.Keys.Count; i++)
        {
           ObjectType key  = shopItems.Keys.ToArray()[i];
            for (int j = 0; j < shopItems[key].Count; j++)
            {
                ShopItem item = shopItems[key[j]];

                if (item.level == info.newLvl)
                {
                    shopTabs.transform.GetChild(i).GetChild(i).GetComponent<ShopItemHolder>().UnlockItem();
                }
            } 
        }
    }*/

    /*private void OnEnable()
    {
        Inventory.onInventoryChange += DrawInventory;
    }
    private void OnDisable()
    {
        Inventory.onInventoryChange -= DrawInventory;
    }*/

    /*void ResetInventory()
    {
        foreach (Transform clidTransform in transform)
        {
            Destroy(clidTransform.gameObject);
        }
        inventorySlot = new List<InventorySlot>(12);
    }*/

    /*void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        for (int i = 0; i < inventorySlot.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlot[i].DrawSlot(inventory[i]);
        }
    }*/

    /*void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlot.Add(newSlotComponent);
    }*/

    public void OnOpen()
    {
        gameObject.SetActive(true);
        // animator.SetTrigger("OnOpen");
    }
}
