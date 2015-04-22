using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class InventoryItemInformation
{
    [SerializeField]
    private ItemType type = ItemType.NONE;
    [SerializeField]
    private Sprite sprite = null;

    public ItemType Type
    {
        get { return type; }
    }
    public Sprite Sprite
    {
        get { return sprite; }
    }
}