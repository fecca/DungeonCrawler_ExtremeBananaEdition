using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera raycastCamera = null;
    [SerializeField]
    private LayerMask layer = 0;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Enemy enemy = Raycaster.Raycast<Enemy>(layer);
            RaycastHit hit;
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);
                Collider hitCollider = hit.collider;

                WorldEnemy enemy = hitCollider.GetComponent<WorldEnemy>();
                InventoryManager.Instance.ToggleLootWindow(enemy);
            }
        }
    }
}