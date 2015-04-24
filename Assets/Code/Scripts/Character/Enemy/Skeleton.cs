using UnityEngine;

public class Skeleton : Enemy
{
    void Start()
    {
        Item item = ItemGenerator.GenerateItem(ItemType.Sword);
        GiveItem(item);
    }
}