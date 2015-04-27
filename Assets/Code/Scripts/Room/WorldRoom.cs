using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WorldRoom : MonoBehaviour
{
    [SerializeField]
    private Text roomNumberText = null;
    [SerializeField]
    private Door leftDoor = null;
    [SerializeField]
    private Door rightDoor = null;
    [SerializeField]
    private Door forwardDoor = null;
    [SerializeField]
    private Door backDoor = null;

    public Room Room { get; private set; }

    public void Initialise(Room room)
    {
        Room = room;
        roomNumberText.text = Room.RoomNumber.ToString();

        SetupEnemies();
        SetupItems();
        SetupDoors();
    }

    private void SetupEnemies()
    {
        List<Enemy> roomEnemies = Room.Enemies;
        for (int i = 0; i < roomEnemies.Count; i++)
        {
            Enemy enemy = roomEnemies[i];
            EnemyManager.Instance.SpawnEnemy(enemy, this, Vector3.right * i);
        }
    }
    private void SetupItems()
    {

    }
    private void SetupDoors()
    {
        int potentialLeftRoomNumber = Room.RoomNumber - 2;
        if (RoomManager.Instance.RoomExists(potentialLeftRoomNumber))
        {
            leftDoor.LeadsTo = potentialLeftRoomNumber;
            leftDoor.gameObject.SetActive(true);
        }

        int potentialRightRoomNumber = Room.RoomNumber + 3;
        if (RoomManager.Instance.RoomExists(potentialRightRoomNumber))
        {
            rightDoor.LeadsTo = potentialRightRoomNumber;
            rightDoor.gameObject.SetActive(true);
        }

        int potentialForwardRoomNumber = Room.RoomNumber + 5;
        if (RoomManager.Instance.RoomExists(potentialForwardRoomNumber))
        {
            forwardDoor.LeadsTo = potentialForwardRoomNumber;
            forwardDoor.gameObject.SetActive(true);
        }

        int potentialBackRoomNumber = Room.RoomNumber - 7;
        if (RoomManager.Instance.RoomExists(potentialBackRoomNumber))
        {
            backDoor.LeadsTo = potentialBackRoomNumber;
            backDoor.gameObject.SetActive(true);
        }
    }
}