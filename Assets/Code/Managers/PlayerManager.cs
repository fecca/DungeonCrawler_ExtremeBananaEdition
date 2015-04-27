using UnityEngine;
using System.Collections;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    private GameObject playerPrefab = null;

    public Player Player { get; private set; }

    public void SpawnPlayer(WorldRoom worldRoom)
    {
        if (worldRoom != null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj == null)
            {
                playerObj = Instantiate(playerPrefab) as GameObject;
            }

            playerObj.transform.position = worldRoom.transform.position + Vector3.up;

            if (Player == null)
            {
                Player = new Player();
            }
        }
        else
        {
            Debug.LogWarning("No room with that room number registered.");
        }
    }
    public bool GiveItemToPlayer(Item item)
    {
        if (Player.GiveItem(item))
        {
            InventoryManager.Instance.PopulatePlayerInventory(Player.GetItems());
            return true;
        }
        else
        {
            Debug.LogWarning("Could not add item to inventory due to lack of space.");
            return false;
        }
    }
}