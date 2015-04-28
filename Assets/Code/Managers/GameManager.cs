using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Camera perspectiveCamera = null;
    [SerializeField]
    private Camera ortographicCamera = null;
    [SerializeField]
    private bool ortographic = false;


    void Awake()
    {
        ortographicCamera.gameObject.SetActive(ortographic);
        perspectiveCamera.gameObject.SetActive(!ortographic);
    }
    void Start()
    {
        RoomManager.Instance.CreateRooms();
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        PlayerManager.Instance.SpawnPlayer(worldRoom, ortographic);
    }

    public void OpenDoor(Door door)
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        PlayerManager.Instance.SpawnPlayer(newWorldRoom, ortographic);
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