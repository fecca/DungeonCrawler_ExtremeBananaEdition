using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public void HandleInput()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Collider hitCollider = hit.collider;
                WorldEnemy enemy = hitCollider.GetComponent<WorldEnemy>();
                InventoryManager.Instance.ToggleLootWindow(enemy);

                Door door = hitCollider.GetComponent<Door>();
                if (door != null)
                {
                    GameManager.Instance.OpenDoor(door);
                }
            }
        }
    }
}