using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        WorldItem worldItem = other.GetComponent<WorldItem>();
        if (worldItem != null)
        {
            if (InventoryManager.Instance.AddItemToInventory(worldItem.Item))
            {
                WorldManager.Instance.RemoveItemFormWorld(worldItem);

                return;
            }
        }

        Door door = other.GetComponent<Door>();
        if (door != null)
        {
            GameManager.Instance.OpenDoor(door);
        }
    }
}