using UnityEngine;
using System;

[Serializable]
public class EnemyInformation
{
    [SerializeField]
    private EnemyType type = EnemyType.NONE;
    [SerializeField]
    private GameObject prefab = null;

    public EnemyType Type
    {
        get { return type; }
    }
    public GameObject Prefab
    {
        get { return prefab; }
    }
}