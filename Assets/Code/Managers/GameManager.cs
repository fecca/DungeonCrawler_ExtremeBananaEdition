using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Camera perspectiveCamera = null;
    [SerializeField]
    private Camera orthographicCamera = null;
    [SerializeField]
    private bool orthographic = false;


    void Awake()
    {
        orthographicCamera.gameObject.SetActive(orthographic);
        perspectiveCamera.gameObject.SetActive(!orthographic);
    }
    void Start()
    {
        RoomManager.Instance.CreateRooms();
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        PlayerManager.Instance.SpawnPlayer(worldRoom, orthographic);
    }

    public void OpenDoor(Door door)
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        PlayerManager.Instance.SpawnPlayer(newWorldRoom, orthographic);
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