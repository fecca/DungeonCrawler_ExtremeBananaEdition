using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject playerPrefab = null;

    void Start()
    {
        CreateRooms();
        StartGame();
        //MockItems();
    }

    public void OpenDoor(Door door)
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        SpawnPlayer(newWorldRoom);
    }

    private void CreateRooms()
    {
        RoomManager.Instance.CreateRooms();
    }
    private void StartGame()
    {
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        SpawnPlayer(worldRoom);
    }
    private void SpawnPlayer(WorldRoom worldRoom)
    {
        if (worldRoom != null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj == null)
            {
                playerObj = Instantiate(playerPrefab) as GameObject;
            }
            playerObj.transform.position = worldRoom.transform.position + Vector3.up;
        }
        else
        {
            Debug.LogWarning("No room with that room number registered.");
        }
    }
    private void MockItems()
    {
        // Mock world items //
        WorldItem axe = WorldManager.Instance.AddItemToWorld(ItemType.Axe, new Vector3(-4, 0, 0));
        WorldItem hammer = WorldManager.Instance.AddItemToWorld(ItemType.Hammer, new Vector3(-2, 0, 0));
        WorldItem sword = WorldManager.Instance.AddItemToWorld(ItemType.Sword, new Vector3(0, 0, 0));
        WorldManager.Instance.AddItemToWorld(ItemType.Axe, new Vector3(2, 0, 2));
        WorldManager.Instance.AddItemToWorld(ItemType.Hammer, new Vector3(4, 0, 2));
        WorldManager.Instance.AddItemToWorld(ItemType.Sword, new Vector3(-4, 0, 2));
        WorldManager.Instance.AddItemToWorld(ItemType.Axe, new Vector3(-2, 0, 4));
        WorldManager.Instance.AddItemToWorld(ItemType.Hammer, new Vector3(0, 0, 4));
        WorldManager.Instance.AddItemToWorld(ItemType.Sword, new Vector3(2, 0, 4));
        WorldManager.Instance.AddItemToWorld(ItemType.Axe, new Vector3(4, 0, -2));
        WorldManager.Instance.AddItemToWorld(ItemType.Hammer, new Vector3(-4, 0, -2));
        WorldManager.Instance.AddItemToWorld(ItemType.Sword, new Vector3(-2, 0, -2));

        // Mock inventory items //
        InventoryManager.Instance.AddItemToInventory(axe.Item);
        InventoryManager.Instance.AddItemToInventory(hammer.Item);
        InventoryManager.Instance.AddItemToInventory(sword.Item);
        InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
        InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
        InventoryManager.Instance.AddItemToInventory(ItemType.Axe);
        InventoryManager.Instance.AddItemToInventory(ItemType.Sword);
        InventoryManager.Instance.AddItemToInventory(ItemType.Axe);
        InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
        InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
    }
}