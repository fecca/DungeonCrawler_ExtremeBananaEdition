using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed { get; set; }

    public void HandleMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(inputX, 0, inputZ);
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.Translate(0, 0, MovementSpeed * Time.deltaTime);
        }
    }
}