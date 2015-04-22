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
            }
        }
    }
}