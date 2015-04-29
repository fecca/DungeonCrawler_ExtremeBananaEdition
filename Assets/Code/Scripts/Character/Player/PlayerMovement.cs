using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5.0f;

    private Transform cachedTransform;

    void Awake()
    {
        cachedTransform = transform;
    }

    void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(inputX, 0, inputZ);
        if (direction != Vector3.zero)
        {
            cachedTransform.forward = direction;
            cachedTransform.Translate(0, 0, movementSpeed * Time.deltaTime);
        }
    }
}