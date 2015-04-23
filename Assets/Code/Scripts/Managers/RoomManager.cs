using UnityEngine;
using UnityEngine.UI;

public class RoomManager : Singleton<RoomManager>
{
    [SerializeField]
    private GameObject roomPrefab = null;
    [SerializeField]
    private Text roomNumberText = null;

    public void SpawnRoom(int roomNumber)
    {
        Room room = WorldManager.Instance.GetRoom(roomNumber);

        if (room != null)
        {
            GameObject roomObj = Instantiate(roomPrefab) as GameObject;
            WorldRoom worldRoom = roomObj.GetComponent<WorldRoom>();
        }
    }
}