using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton()
        : base(EnemyType.Skeleton, 6)
    {
        Item item = ItemGenerator.GenerateItem(ItemType.Sword);
        GiveItem(item);
    }
}