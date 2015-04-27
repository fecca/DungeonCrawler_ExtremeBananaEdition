using UnityEngine;
using System.Collections;

public class Troll : Enemy
{
    public Troll()
        : base(EnemyType.Troll, 4)
    {
        Item axe = ItemGenerator.GenerateItem(ItemType.Axe);
        GiveItem(axe);
        Item hammer = ItemGenerator.GenerateItem(ItemType.Hammer);
        GiveItem(hammer);
    }
}