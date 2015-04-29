using UnityEngine;
using System.Collections;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    private GameObject playerPrefab = null;
    [SerializeField]
    private float movementSpeed = 5.0f;

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private bool inputLocked = true;

    public Player Player { get; private set; }

    void Update()
    {
        if (!inputLocked)
        {
            playerInput.HandleInput();
            playerMovement.HandleMovement();
        }
    }

    public void SpawnPlayer(WorldRoom worldRoom, Door doorEntered)
    {
        if (worldRoom != null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj == null)
            {
                playerObj = Instantiate(playerPrefab) as GameObject;
            }

            Transform spawnPoint = worldRoom.GetSpawnPoint(doorEntered);
            playerObj.transform.position = spawnPoint.position + Vector3.up;
            playerObj.transform.rotation = spawnPoint.rotation;

            if (Player == null)
            {
                Player = new Player();
                playerInput = playerObj.GetComponent<PlayerInput>();
                if (playerInput == null)
                {
                    Debug.LogWarning("No Player Input found on Player object.");
                }
                playerMovement = playerObj.GetComponent<PlayerMovement>();
                if (playerMovement == null)
                {
                    Debug.LogWarning("No Player Movement found on Player object.");
                }
                playerMovement.MovementSpeed = movementSpeed;
                inputLocked = false;
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
    public void LockInput()
    {
        inputLocked = true;
    }
    public void UnlockInput()
    {
        inputLocked = false;
    }
}