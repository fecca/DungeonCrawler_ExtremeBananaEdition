using UnityEngine;
using System.Collections.Generic;

public class WorldManager : Singleton<WorldManager>
{
    [SerializeField]
    private int numberOfRooms = 100;

    private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

    public void CreateWorld()
    {
        for (int i = 0; i < numberOfRooms; i++)
        {
            rooms.Add(i, new Room());
        }
    }
    public WorldItem AddItemToWorld(ItemType type, Vector3 position)
    {
        Item item = ItemGenerator.GenerateItem(type);

        return AddItemToWorld(type, position, item);
    }
    public WorldItem AddItemToWorld(ItemType type, Vector3 position, Item item)
    {
        GameObject worldItemObj = ObjectPool.Instance.GetObject(type);
        if (worldItemObj == null)
        {
            return null;
        }

        WorldItem worldItem = worldItemObj.AddComponent<WorldItem>();
        worldItem.Item = item;

        worldItemObj.name = item.Type.ToString();
        worldItemObj.transform.position = position;

        return worldItem;
    }
    public void RemoveItemFormWorld(WorldItem worldItem)
    {
        ObjectPool.Instance.ReturnObject(worldItem.gameObject, worldItem.Item.Type);
    }
    public Room GetRoom(int roomNumber)
    {
        if (rooms.ContainsKey(roomNumber))
        {
            return rooms[roomNumber];
        }

        Debug.LogWarning("No Room with that room number registered.");

        return null;
    }
}