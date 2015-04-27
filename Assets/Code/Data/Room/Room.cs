using System.Collections.Generic;

public class Room
{
    public int RoomNumber { get; private set; }
    public List<Enemy> Enemies { get; private set; }
    public List<Item> Items { get; private set; }

    public Room(int roomNumber)
    {
        RoomNumber = roomNumber;
        Enemies = new List<Enemy>();
        Items = new List<Item>();

        if (RoomNumber % 2 == 0)
        {
            Enemies.Add(new Orc());
        }
        if (RoomNumber % 3 == 0)
        {
            Enemies.Add(new Skeleton());
        }
        if (RoomNumber % 4 == 0)
        {
            Enemies.Add(new Troll());
        }
    }
}