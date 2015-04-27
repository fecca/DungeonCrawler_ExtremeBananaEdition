using System.Collections.Generic;

public class Inventory
{
    private List<Item> items;
    private int space;
    private int spaceUsed = 0;

    public Inventory(int space)
    {
        items = new List<Item>();
        this.space = space;
    }

    public bool AddItem(Item item)
    {
        if (spaceUsed < space)
        {
            items.Add(item);
            ++spaceUsed;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TakeItem(Item item)
    {
        if (spaceUsed < space)
        {
            items.Remove(item);
            --spaceUsed;
            return true;
        }
        else
        {
            return false;
        }
    }
    public List<Item> GetItems()
    {
        return items;
    }
}