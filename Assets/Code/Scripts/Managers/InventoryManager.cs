using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]
    private GameObject[] inventorySlots = null;

    public bool AddItemToInventory(Item item)
    {
        Sprite itemSprite = ItemManager.Instance.GetItemSprite(item.Type);
        if (itemSprite == null)
        {
            Debug.LogWarning("No information on inventory item with type " + item.Type + " found. No item added to inventory.");

            return false;
        }

        if (inventorySlots.Length <= 0)
        {
            Debug.LogWarning("No inventory slots registered.");

            return false;
        }

        foreach (GameObject obj in inventorySlots)
        {
            if (!obj.activeInHierarchy)
            {
                InventoryItem inventoryItem = obj.AddComponent<InventoryItem>();
                inventoryItem.Item = item;


                Image image = obj.GetComponent<Image>();
                image.sprite = itemSprite;

                obj.SetActive(true);

                return true;
            }
        }

        Debug.LogWarning("No room in inventory for that item.");

        return false;
    }
}