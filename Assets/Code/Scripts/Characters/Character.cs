using UnityEngine;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour
{
    private Inventory inventory;

    void Awake()
    {
        inventory = new Inventory();
    }

    public void GiveItem(Item item)
    {
        inventory.AddItem(item);
    }
    public void GiveItem(ItemType type)
    {
        Item item = ItemGenerator.GenerateItem(type);
        GiveItem(item);
    }
    public List<Item> GetItems()
    {
        return inventory.GetItems();
    }
}