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

    public void ToggleInventory(Character character)
    {
        /// ToDo: Refactor mess
        if (character is Player)
        {
            if (inventoryWindow.activeInHierarchy)
            {
                inventoryWindow.SetActive(false);
            }
            else
            {
                PopulateInventoryWindow(character.GetItems(), inventorySlots);
                inventoryWindow.SetActive(true);
            }
        }
        else if (character is Enemy)
        {
            if (lootWindow.activeInHierarchy)
            {
                lootWindow.SetActive(false);
            }
            else
            {
                PopulateInventoryWindow(character.GetItems(), lootSlots);
                lootWindow.SetActive(true);
            }
        }
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
}