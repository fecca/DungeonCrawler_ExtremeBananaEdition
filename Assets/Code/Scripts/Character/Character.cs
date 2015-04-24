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
    public List<Item> GetItems()
    {
        return inventory.GetItems();
    }
}