using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform cachedTransform;
    private float movementSpeed = 5.0f;

    void Awake()
    {
        cachedTransform = transform;
    }

    void FixedUpdate()
    {
        float xVelocity = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float zVelocity = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        cachedTransform.Translate(xVelocity, 0, zVelocity);
    }
}