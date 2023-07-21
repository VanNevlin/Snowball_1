using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravityReversed = false;
    private bool isCollidingWithGround = false;
    private bool isCollidingWithRoof = false; // New flag to track roof collision.
    public float reverseGravityScale = -5.0f;
    public KeyCode keycode = KeyCode.Space;
    private const string groundTag = "Ground";
    private const string roofTag = "Roof"; // The tag of the roof objects.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keycode) && (isCollidingWithGround || isCollidingWithRoof)) // Check both ground and roof collision.
        {
            gravityReversed = !gravityReversed;
            UpdateGravity();
        }
    }

    private void UpdateGravity()
    {
        if (gravityReversed)
        {
            rb.gravityScale = reverseGravityScale;
        }
        else
        {
            rb.gravityScale = 50.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isCollidingWithGround = true;
        }
        else if (collision.gameObject.CompareTag(roofTag)) // Check for the roof tag.
        {
            isCollidingWithRoof = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isCollidingWithGround = false;
        }
        else if (collision.gameObject.CompareTag(roofTag)) // Check for the roof tag.
        {
            isCollidingWithRoof = false;
        }
    }
}
