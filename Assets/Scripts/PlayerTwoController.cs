using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    private Rigidbody2D rb; // or Rigidbody for 3D

    private bool isGravityInverted = false;
    private float normalGravityScale = -1.0f;
    private float invertedGravityScale = 1.0f;
    private float rotationSpeed = 100f;

    private float sizeChangeRate = 0.1f;
    private float maxSize = 2.0f;
    private float minSize = 0.5f;
    private Vector3 originalScale;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    private bool isOnGround = false;
    private bool isOnIce = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // or GetComponent<Rigidbody>() for 3D
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isOnGround || isOnIce))
        {
            isGravityInverted = !isGravityInverted;
            UpdateGravity();
        }

        if (isOnGround)
        {
            Vector3 newScale = transform.localScale - Vector3.one * sizeChangeRate * Time.deltaTime;
            newScale = Vector3.Max(newScale, originalScale * minSize);
            transform.localScale = newScale;

            spriteRenderer.transform.localScale = transform.localScale;
            playerCollider.transform.localScale = transform.localScale;
        }

        if (isOnIce)
        {
            Vector3 newScale = transform.localScale + Vector3.one * sizeChangeRate * Time.deltaTime;
            newScale = Vector3.Min(newScale, originalScale * maxSize);
            transform.localScale = newScale;

            spriteRenderer.transform.localScale = transform.localScale;
            playerCollider.transform.localScale = transform.localScale;
        }
    }

    private void UpdateGravity()
    {
        if (isGravityInverted)
        {
            rb.gravityScale = invertedGravityScale;
        }
        else
        {
            rb.gravityScale = normalGravityScale;
        }
    }

    private void FixedUpdate()
    {
        if (isGravityInverted) transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Player") && !isOnGround)
        {
            //Debug.Log("Collided with Player");
            isGravityInverted = !isGravityInverted;
            UpdateGravity();
        }
        else if (collision.gameObject.CompareTag("Snow"))
        {
            isOnIce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
        else if (collision.gameObject.CompareTag("Snow"))
        {
            isOnIce = false;
        }
    }
}
