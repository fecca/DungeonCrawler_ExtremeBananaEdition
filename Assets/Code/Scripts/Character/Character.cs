using UnityEngine;
using System.Collections.Generic;

public abstract class Character
{
    protected Inventory inventory;

    public Character(int inventorySpace)
    {
        inventory = new Inventory(inventorySpace);
    }
    public bool GiveItem(Item item)
    {
        return inventory.AddItem(item);
    }
    public bool TakeItem(Item item)
    {
        return inventory.TakeItem(item);
    }
    public List<Item> GetItems()
    {
        return inventory.GetItems();
    }
    public bool CarriesLoot()
    {
        return GetItems().Count > 0;
    }
}