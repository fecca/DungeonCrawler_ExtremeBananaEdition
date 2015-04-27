using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    public EnemyType Type { get; protected set; }

    public Enemy(EnemyType type, int inventorySpace)
        : base(inventorySpace)
    {
        Type = type;
    }
}