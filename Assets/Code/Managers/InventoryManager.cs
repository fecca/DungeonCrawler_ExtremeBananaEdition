using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]
    private GameObject inventoryWindow = null;
    [SerializeField]
    private GameObject lootWindow = null;
    [SerializeField]
    private GameObject[] inventorySlots = null;
    [SerializeField]
    private GameObject[] lootSlots = null;

    public Enemy ActiveLootEnemy { get; set; }

    public void ToggleInventory()
    {
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            PopulatePlayerInventory(PlayerManager.Instance.Player.GetItems());
            inventoryWindow.SetActive(true);
        }
    }
    public void ToggleLootWindow(WorldEnemy worldEnemy)
    {
        Enemy enemy = null;
        if (worldEnemy != null)
        {
            enemy = worldEnemy.Enemy;
        }

        if (lootWindow.activeInHierarchy)
        {
            lootWindow.SetActive(false);
        }

        if (ActiveLootEnemy != enemy)
        {
            if (enemy != null && enemy.CarriesLoot())
            {
                PopulateLootWindow(enemy.GetItems());
                lootWindow.SetActive(true);
                ActiveLootEnemy = enemy;
            }
            else
            {
                ActiveLootEnemy = null;
            }
        }
        else
        {
            ActiveLootEnemy = null;
        }
    }
    public void HideWindows()
    {
        lootWindow.SetActive(false);
        inventoryWindow.SetActive(false);
    }
    public void PopulatePlayerInventory(List<Item> items)
    {
        ClearWindow(inventorySlots);
        PopulateWindow(items, inventorySlots);
    }
    public void PopulateLootWindow(List<Item> items)
    {
        ClearWindow(lootSlots);
        PopulateWindow(items, lootSlots);
    }

    private void PopulateWindow(List<Item> items, GameObject[] slots)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            GameObject inventorySlotObj = slots[i];

            InventoryItem inventoryItem = inventorySlotObj.GetComponent<InventoryItem>();
            inventoryItem.Item = item;

            Sprite itemSprite = ItemManager.Instance.GetItemSprite(item.Type);
            Image image = inventorySlotObj.GetComponent<Image>();
            image.sprite = itemSprite;

            inventorySlotObj.SetActive(true);
        }
    }
    private void ClearWindow(GameObject[] slots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject inventorySlotObj = slots[i];

            InventoryItem inventoryItem = inventorySlotObj.GetComponent<InventoryItem>();
            inventoryItem.Item = null;

            Image image = inventorySlotObj.GetComponent<Image>();
            image.sprite = null;

            inventorySlotObj.SetActive(false);
        }
    }
}