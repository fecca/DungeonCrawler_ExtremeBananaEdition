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

        // Always close the loot window
        if (lootWindow.activeInHierarchy)
        {
            lootWindow.SetActive(false);
        }

        if (ActiveLootEnemy != enemy)
        {
            if (enemy != null && enemy.CarriesLoot())
            {
                PopulateInventoryWindow(enemy.GetItems(), lootSlots);
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
    public void PopulatePlayerInventory(List<Item> items)
    {
        ClearInventory();
        PopulateInventoryWindow(items, inventorySlots);
    }

    private void PopulateInventoryWindow(List<Item> items, GameObject[] slots)
    {
        /// ToDo: Refactor mess
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
    private void ClearInventory()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            GameObject inventorySlotObj = inventorySlots[i];

            InventoryItem inventoryItem = inventorySlotObj.GetComponent<InventoryItem>();
            inventoryItem.Item = null;

            Image image = inventorySlotObj.GetComponent<Image>();
            image.sprite = null;
        }
    }
}