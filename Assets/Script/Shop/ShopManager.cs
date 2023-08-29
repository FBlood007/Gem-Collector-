using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager _instance;
    //[SerializeField] public static Sprite currencySprite;
    //Animator animator;
    public Inventory inventoryScript;
    [SerializeField] private GameObject questItemPrefab;
    [SerializeField] private GameObject sellItemPrefab;
    public Dictionary<ShopItemCategory, List<ShopItem>> shopItems = new Dictionary<ShopItemCategory, List<ShopItem>>();
    public Dictionary<ShopItemCategory, List<ItemData>> shopSellItems = new Dictionary<ShopItemCategory, List<ItemData>>();
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
        inventoryScript = GetComponent<Inventory>();
        gameObject.SetActive(false);
        Load();
        Initialize();
    }

    private void Load()
    {
        ShopItem[] items = Resources.LoadAll<ShopItem>("Shop");
        shopItems.Add(ShopItemCategory.Quests, new List<ShopItem>());
        shopItems.Add(ShopItemCategory.Buy, new List<ShopItem>());
        foreach (var item in items)
        {
            shopItems[item.Category].Add(item);
        }
        /*shopSellItems.Add(ShopItemCategory.Sell, new List<ItemData>());
        if (inventoryScript.itemDictionary != null)
        {
            inventoryItems = inventoryScript.itemDictionary.Keys;
            foreach (var inventoryitem in inventoryItems)
            {
                shopSellItems[ShopItemCategory.Sell].Add(inventoryitem);
            }

        }*/
    }

    private void Initialize()
    {
        int k = 0;
        for (int i = 0; i < shopItems.Keys.Count; i++)
        {
            foreach (var item in shopItems[(ShopItemCategory)i])
            {
                GameObject itemObject = Instantiate(questItemPrefab, shopTabs.objectsToSwap[i].transform);
                itemObject.GetComponent<ShopItemHolder>().Initialize(item);
            }
            k++;
        }

        /*for (int j = k; j < shopSellItems.Keys.Count; j++)
        {
            foreach (var sellItem in shopSellItems[(ShopItemCategory)j])
            {
                GameObject itemObject = Instantiate(sellItemPrefab, shopTabs.objectsToSwap[j].transform);
                itemObject.GetComponent<ShopItemHolder>().InitializeSellItem(sellItem);
            }
        }*/
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
