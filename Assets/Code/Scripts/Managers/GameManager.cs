using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject playerPrefab = null;

    void Start()
    {
        SpawnPlayer(Vector3.up);

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
        //InventoryManager.Instance.AddItemToInventory(axe.Item);
        //InventoryManager.Instance.AddItemToInventory(hammer.Item);
        //InventoryManager.Instance.AddItemToInventory(sword.Item);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Axe);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Sword);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Axe);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
        //InventoryManager.Instance.AddItemToInventory(ItemType.Hammer);
    }

    public void SpawnPlayer(Vector3 position)
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject playerObj = Instantiate(playerPrefab) as GameObject;
            playerObj.transform.position = position;
        }
        else
        {
            Debug.LogWarning("A player already exists in the scene. No new player was spawned.");
        }
    }
}