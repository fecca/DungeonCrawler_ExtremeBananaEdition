using UnityEngine;

public class WorldManager : Singleton<WorldManager>
{
    [SerializeField]
    private GameObject roomPrefab = null;

    public WorldRoom PreviousWorldRoom { get; private set; }

    public WorldRoom SpawnRoom(int roomNumber)
    {
        Room room = RoomManager.Instance.GetRoom(roomNumber);

        if (room != null)
        {
            GameObject worldRoomObj = Instantiate(roomPrefab) as GameObject;
            WorldRoom worldRoom = worldRoomObj.GetComponent<WorldRoom>();
            worldRoom.Initialise(room);

            DespawnPreviousRoom();

            PreviousWorldRoom = worldRoom;

            return worldRoom;
        }

        return null;
    }
    public void DespawnPreviousRoom()
    {
        if (PreviousWorldRoom != null)
        {
            Destroy(PreviousWorldRoom.gameObject);
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
}