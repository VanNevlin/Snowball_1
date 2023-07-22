using UnityEngine;

public class PlayerTwoResizer : MonoBehaviour
{
    public float TrapDecrease = 0.1f;
    public float CoinIncrease = 0.2f;
    public float GroundDecrease = 0.05f;
    public float SnowIncrease = 0.15f;

    private Vector3 initialScale;
    private float storedScale;
    private ScoreManager scoreManager;

    private float maxSize = 2.0f;
    private float minSize = 0.5f;

    private void Start()
    {
        // Store the initial scale of the player object
        initialScale = transform.localScale;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            DecreaseScale(TrapDecrease);
        }
        else if (other.CompareTag("Coin"))
        {
            IncreaseScale(CoinIncrease);
            Destroy(other.gameObject); // Destroy the "Coin" object
        }
        else if (other.CompareTag("Ground"))
        {
            DecreaseScale(GroundDecrease);
        }
        else if (other.CompareTag("Snow"))
        {
            IncreaseScale(SnowIncrease);
        }
        else if (other.CompareTag("Checker"))
        {
            // Store the player's scale before returning back to its initial state
            storedScale = transform.localScale.x;
            transform.localScale = initialScale;

            // Set the stored scale value in ScoreManager for Player 2
            scoreManager.SetPlayerTwoStoredScale(storedScale);

            // Log the stored scale value for debugging
            
        }
    }

    private void DecreaseScale(float amount)
    {
        Vector3 newScale = Vector3.Max(transform.localScale - new Vector3(amount, amount, amount), initialScale * minSize);
        transform.localScale = newScale;
    }

    private void IncreaseScale(float amount)
    {
        Vector3 newScale = Vector3.Min(transform.localScale + new Vector3(amount, amount, amount), initialScale * maxSize);
        transform.localScale = newScale;
    }
}
