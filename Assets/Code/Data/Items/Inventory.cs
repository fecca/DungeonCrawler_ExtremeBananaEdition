using System.Collections.Generic;

public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public List<Item> GetItems()
    {
        return items;
    }
}