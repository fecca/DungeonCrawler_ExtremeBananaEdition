using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : Singleton<ObjectPool>
{
    private Dictionary<ItemType, List<GameObject>> objects;

    void Start()
    {
        objects = new Dictionary<ItemType, List<GameObject>>();

        InitialiseItems();
    }

    public GameObject GetObject(ItemType type)
    {
        if (objects.ContainsKey(type))
        {
            if (objects[type].Count > 0)
            {
                GameObject obj = objects[type][0];
                obj.SetActive(true);
                objects[type].Remove(obj);

                return obj;
            }

            Debug.LogWarning("No objects of type " + type + " where found to instantiate.");
        }

        Debug.LogWarning("No objects of type " + type + " has been added to the configuration.");

        return null;
    }
    public void ReturnObject(GameObject obj, ItemType type)
    {
        if (objects.ContainsKey(type))
        {
            obj.SetActive(false);
            objects[type].Add(obj);
        }
    }

    private void InitialiseItems()
    {
        ItemManager mapper = GameObject.FindObjectOfType<ItemManager>();

        List<WorldItemInformation> worldItemInformation = mapper.GetWorldItemInformation();
        foreach (WorldItemInformation worldItem in worldItemInformation)
        {
            if (objects.ContainsKey(worldItem.Type))
            {
                Debug.LogWarning("An item with that type has already been registered. Skipping.");
                continue;
            }
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < worldItem.MaxAmountInWorld; i++)
            {
                GameObject obj = Instantiate(worldItem.Prefab) as GameObject;
                obj.SetActive(false);
                list.Add(obj);
            }
            objects.Add(worldItem.Type, list);
        }
    }
}