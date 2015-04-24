using UnityEngine;
using System;

[Serializable]
public class ItemInformation
{
    [SerializeField]
    private ItemType type = ItemType.NONE;
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField]
    private int maxAmountInWorld = 0;
    [SerializeField]
    private Sprite sprite = null;

    public ItemType Type
    {
        get { return type; }
    }
    public GameObject Prefab
    {
        get { return prefab; }
    }
    public int MaxAmountInWorld
    {
        get { return maxAmountInWorld; }
    }
    public Sprite Sprite
    {
        get { return sprite; }
    }
}