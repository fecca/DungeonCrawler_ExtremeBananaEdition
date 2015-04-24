using UnityEngine;
using System.Collections.Generic;

public class RoomManager : Singleton<RoomManager>
{
    [SerializeField]
    private int numberOfRooms = 100;

    private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

    public void CreateRooms()
    {
        for (int i = 1; i <= numberOfRooms; i++)
        {
            rooms.Add(i, new Room(i));
        }
    }
    public Room GetRoom(int roomNumber)
    {
        if (rooms.ContainsKey(roomNumber))
        {
            return rooms[roomNumber];
        }

        return null;
    }
    public bool RoomExists(int roomNumber)
    {
        return rooms.ContainsKey(roomNumber);
    }
}