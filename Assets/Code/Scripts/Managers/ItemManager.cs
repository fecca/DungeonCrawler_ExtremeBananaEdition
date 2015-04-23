using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private List<ItemInformation> itemInformation = new List<ItemInformation>();

    public List<ItemInformation> GetItemInformation()
    {
        return new List<ItemInformation>(itemInformation);
    }
    public Sprite GetItemSprite(ItemType type)
    {
        ItemInformation itemInfo = itemInformation.Find(x => x.Type == type);
        if (itemInfo != null)
        {
            return itemInfo.Sprite;
        }

        return null;
    }
}