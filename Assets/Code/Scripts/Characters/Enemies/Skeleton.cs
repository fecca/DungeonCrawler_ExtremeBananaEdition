using UnityEngine;

public class Skeleton : Character
{
    void Start()
    {
        Item item = ItemGenerator.GenerateItem(ItemType.Sword);
        GiveItem(item);
    }
}