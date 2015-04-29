using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        RoomManager.Instance.CreateRooms();
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        PlayerManager.Instance.SpawnPlayer(worldRoom, null);
    }

    /// ToDo: Handle this loose variable
    private Door door;
    public void OpenDoor(Door door)
    {
        this.door = door;
        InventoryManager.Instance.HideWindows();
        PlayerManager.Instance.LockInput();
        CameraManager.Instance.FadeInOverlay(LoadRoom);
    }
    public void LootItem(InventoryItem inventoryItem)
    {
        if (PlayerManager.Instance.GiveItemToPlayer(inventoryItem.Item))
        {
            Enemy enemy = InventoryManager.Instance.ActiveLootEnemy;
            EnemyManager.Instance.TakeItem(enemy, inventoryItem.Item);
        }
    }

    private void LoadRoom()
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        PlayerManager.Instance.SpawnPlayer(newWorldRoom, door);
        CameraManager.Instance.FadeOutOverlay(NewRoomLoaded);
    }
    private void NewRoomLoaded()
    {
        PlayerManager.Instance.UnlockInput();
    }
}