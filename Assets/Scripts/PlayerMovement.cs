using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The constant speed at which the player moves.
    public float originalMoveSpeed = 5.0f;
    private Rigidbody2D rb;
    //public Transform playerTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveSpeed, 0f); // Constant movement to the right (x-axis).

        // Move the player at a constant speed.
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}

