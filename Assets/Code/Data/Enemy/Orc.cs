using UnityEngine;
using System.Collections;

public class Orc : Enemy
{
    public Orc()
        : base(EnemyType.Orc, 8)
    {
        Item axe = ItemGenerator.GenerateItem(ItemType.Axe);
        GiveItem(axe);
        Item hammer = ItemGenerator.GenerateItem(ItemType.Hammer);
        GiveItem(hammer);
        Item sword = ItemGenerator.GenerateItem(ItemType.Sword);
        GiveItem(sword);
    }
}