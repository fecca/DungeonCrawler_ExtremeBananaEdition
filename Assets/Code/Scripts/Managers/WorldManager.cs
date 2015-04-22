using UnityEngine;

public class WorldManager : Singleton<WorldManager>
{
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