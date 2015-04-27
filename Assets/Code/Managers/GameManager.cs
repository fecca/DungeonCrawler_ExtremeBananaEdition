using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        RoomManager.Instance.CreateRooms();
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        PlayerManager.Instance.SpawnPlayer(worldRoom);
    }

    public void OpenDoor(Door door)
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        PlayerManager.Instance.SpawnPlayer(newWorldRoom);
    }
    public void LootItem(InventoryItem inventoryItem)
    {
        if (PlayerManager.Instance.GiveItemToPlayer(inventoryItem.Item))
        {
            Enemy enemy = InventoryManager.Instance.ActiveLootEnemy;
            EnemyManager.Instance.TakeItem(enemy, inventoryItem.Item);
        }
    }
}