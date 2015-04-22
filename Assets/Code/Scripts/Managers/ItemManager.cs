using UnityEngine;
using System.Collections.Generic;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private List<WorldItemInformation> worldItems = new List<WorldItemInformation>();

    public List<WorldItemInformation> GetWorldItemInformation()
    {
        return new List<WorldItemInformation>(worldItems);
    }
}