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

            Player = playerObj.GetComponent<Player>();
            if (Player == null)
            {
                Debug.LogWarning("No Player script attached to Player object.");
            }
        }
        else
        {
            Debug.LogWarning("No room with that room number registered.");
        }
    }
    public void GiveItemToPlayer(Item item)
    {
        if (InventoryManager.Instance.AddItemToInventory(item))
        {
            Player.GiveItem(item);
        }
    }
}