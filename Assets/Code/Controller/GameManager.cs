using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        CreateRooms();
        StartGame();
        MockData();
    }

    public void OpenDoor(Door door)
    {
        WorldRoom newWorldRoom = WorldManager.Instance.SpawnRoom(door.LeadsTo);
        PlayerManager.Instance.SpawnPlayer(newWorldRoom);
    }

    private void CreateRooms()
    {
        RoomManager.Instance.CreateRooms();
    }
    private void StartGame()
    {
        WorldRoom worldRoom = WorldManager.Instance.SpawnRoom(1);
        PlayerManager.Instance.SpawnPlayer(worldRoom);
    }
    private void MockData()
    {
        Item axe = ItemGenerator.GenerateItem(ItemType.Axe);
        PlayerManager.Instance.GiveItemToPlayer(axe);
        Item hammer = ItemGenerator.GenerateItem(ItemType.Hammer);
        PlayerManager.Instance.GiveItemToPlayer(hammer);
        //Item sword = ItemGenerator.GenerateItem(ItemType.Sword);
        //PlayerManager.Instance.GiveItemToPlayer(sword);

        EnemyManager.Instance.SpawnEnemy(EnemyType.Skeleton);
    }
}