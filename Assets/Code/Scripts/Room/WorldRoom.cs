using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WorldRoom : MonoBehaviour
{
    [SerializeField]
    private WorldRoomInformation forwardInfo = new WorldRoomInformation();
    [SerializeField]
    private WorldRoomInformation backInfo = new WorldRoomInformation();
    [SerializeField]
    private WorldRoomInformation leftInfo = new WorldRoomInformation();
    [SerializeField]
    private WorldRoomInformation rightInfo = new WorldRoomInformation();

    public Room Room { get; private set; }

    public void Initialise(Room room)
    {
        Room = room;

        SetupEnemies();
        SetupItems();
        SetupDoors();
    }
    public Transform GetSpawnPoint(Door door)
    {
        if (door == null)
        {
            return transform;
        }

        switch (door.DoorType)
        {
            case DoorType.Forward:
                return backInfo.SpawnPoint;
            case DoorType.Back:
                return forwardInfo.SpawnPoint;
            case DoorType.Left:
                return rightInfo.SpawnPoint;
            case DoorType.Right:
                return leftInfo.SpawnPoint;
            default:
                return transform;
        }
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
        int potentialForwardRoomNumber = Room.RoomNumber + 5;
        if (RoomManager.Instance.RoomExists(potentialForwardRoomNumber))
        {
            forwardInfo.Door.LeadsTo = potentialForwardRoomNumber;
            forwardInfo.Door.gameObject.SetActive(true);
            forwardInfo.Text.text = potentialForwardRoomNumber.ToString();
        }
        else
        {
            forwardInfo.Text.text = "";
        }

        int potentialBackRoomNumber = Room.RoomNumber - 7;
        if (RoomManager.Instance.RoomExists(potentialBackRoomNumber))
        {
            backInfo.Door.LeadsTo = potentialBackRoomNumber;
            backInfo.Door.gameObject.SetActive(true);
            backInfo.Text.text = potentialBackRoomNumber.ToString();
        }
        else
        {
            backInfo.Text.text = "";
        }

        int potentialLeftRoomNumber = Room.RoomNumber - 2;
        if (RoomManager.Instance.RoomExists(potentialLeftRoomNumber))
        {
            leftInfo.Door.LeadsTo = potentialLeftRoomNumber;
            leftInfo.Door.gameObject.SetActive(true);
            leftInfo.Text.text = potentialLeftRoomNumber.ToString();
        }
        else
        {
            leftInfo.Text.text = "";
        }

        int potentialRightRoomNumber = Room.RoomNumber + 3;
        if (RoomManager.Instance.RoomExists(potentialRightRoomNumber))
        {
            rightInfo.Door.LeadsTo = potentialRightRoomNumber;
            rightInfo.Door.gameObject.SetActive(true);
            rightInfo.Text.text = potentialRightRoomNumber.ToString();
        }
        else
        {
            rightInfo.Text.text = "";
        }
    }
}