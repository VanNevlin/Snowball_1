using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the platform moves towards the player
    public float destroyDelay = 5f; // Time in seconds after which the platform gets destroyed if not collided with a border

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Start()
    {
        // Set a velocity to move the platform towards the player
        rb.velocity = Vector2.left * moveSpeed;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the platform collided with an object tagged "border"
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject); // Destroy the platform on collision with the border
        }
    }
}
