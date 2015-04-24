using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Door door = other.GetComponent<Door>();
        if (door != null)
        {
            GameManager.Instance.OpenDoor(door);
        }
    }
}