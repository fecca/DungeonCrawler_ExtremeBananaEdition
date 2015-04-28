using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private Camera raycastCamera;

    void Start()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogWarning("No main camera in scene.");
        }
        raycastCamera = mainCamera;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // Enemy enemy = Raycaster.Raycast<Enemy>(layer);
            RaycastHit hit;
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Collider hitCollider = hit.collider;
                WorldEnemy enemy = hitCollider.GetComponent<WorldEnemy>();
                InventoryManager.Instance.ToggleLootWindow(enemy);
            }
        }
    }
}