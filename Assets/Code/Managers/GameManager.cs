using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        CreateRooms();
        StartGame();
        MockData();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            InventoryManager.Instance.ToggleInventory(PlayerManager.Instance.Player);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            InventoryManager.Instance.ToggleInventory(GameObject.FindObjectOfType<Skeleton>());
        }
    }

    public void OpenDoor(Door door)
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        PlayerManager.Instance.SpawnPlayer(newWorldRoom);
    }

    private void CreateRooms()
    {
        RoomManager.Instance.CreateRooms();
    }
    private void StartGame()
    {
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        PlayerManager.Instance.SpawnPlayer(worldRoom);
    }
    private void MockData()
    {
        Item axe = ItemGenerator.GenerateItem(ItemType.Axe);
        PlayerManager.Instance.GiveItemToPlayer(axe);
        Item hammer = ItemGenerator.GenerateItem(ItemType.Hammer);
        PlayerManager.Instance.GiveItemToPlayer(hammer);

        EnemyManager.Instance.SpawnEnemy(EnemyType.Skeleton);
    }
}