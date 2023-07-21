using UnityEngine;

public class SizeController : MonoBehaviour
{
    public float sizeChangeRate = 0.1f; // Rate of size increase and decrease per second.
    public float maxSize = 2.0f; // Maximum size of the player object.
    public float minSize = 0.5f; // Minimum size of the player object.

    private Vector3 originalScale;
    private bool isCollidingWithGround = false;

    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    private void Start()
    {
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isCollidingWithGround)
        {
            // Increase the size.
            Vector3 newScale = transform.localScale + Vector3.one * sizeChangeRate * Time.deltaTime;
            newScale = Vector3.Min(newScale, originalScale * maxSize);
            transform.localScale = newScale;

            // Scale up the sprite.
            spriteRenderer.transform.localScale = transform.localScale;

            // Scale up the collider.
            playerCollider.transform.localScale = transform.localScale;
        }
        else
        {
            // Decrease the size.
            Vector3 newScale = transform.localScale - Vector3.one * sizeChangeRate * Time.deltaTime;
            newScale = Vector3.Max(newScale, originalScale * minSize);
            transform.localScale = newScale;

            // Scale down the sprite.
            spriteRenderer.transform.localScale = transform.localScale;

            // Scale down the collider.
            playerCollider.transform.localScale = transform.localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isCollidingWithGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isCollidingWithGround = false;
        }
    }
}
