using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private DoorType doorType = DoorType.NONE;

    public DoorType DoorType
    {
        get { return doorType; }
    }
    public int LeadsTo { get; set; }
}