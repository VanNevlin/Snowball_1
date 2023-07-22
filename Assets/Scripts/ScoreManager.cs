using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float threshold = 0.0005f; // Adjust this value as needed for the threshold

    private float playerOneStoredScale;
    private float playerTwoStoredScale;
    private int playerOneScore;
    private int playerTwoScore;

    // Method to set the stored scale for Player 1
    public void SetPlayerOneStoredScale(float scale)
    {
        playerOneStoredScale = scale;
        //CalculateScore();
        //Debug.Log("Player 1 stored scale: " + playerOneStoredScale);
    }

    // Method to set the stored scale for Player 2
    public void SetPlayerTwoStoredScale(float scale)
    {
        playerTwoStoredScale = scale;
       CalculateScore();
       // Debug.Log("Player 2 stored scale: " + playerTwoStoredScale);
    }

    // Method to calculate the scores based on the stored scale values
    private void CalculateScore()
    {
        if (Mathf.Abs(playerOneStoredScale - playerTwoStoredScale) == 0) // <= threshhold
        {
            Debug.Log("It's a draw!");
            Debug.Log("Player 1 vs Player 2 : " + playerOneStoredScale + " vs " + playerTwoStoredScale);
        }
        else if (playerOneStoredScale > playerTwoStoredScale)
        {
            playerOneScore++;
            Debug.Log("Player 1 gets a point!");
            Debug.Log("Player 1 vs Player 2 : " + playerOneStoredScale + " vs " + playerTwoStoredScale);
        }
        else if (playerOneStoredScale < playerTwoStoredScale)
        {
            playerTwoScore++;
            Debug.Log("Player 2 gets a point!");
            Debug.Log("Player 1 vs Player 2 : " + playerOneStoredScale + " vs " + playerTwoStoredScale);
        }

        // Log the current scores for debugging
        Debug.Log("Player 1 score: " + playerOneScore);
        Debug.Log("Player 2 score: " + playerTwoScore);
    }

    // Method to check if two sizes are within the threshold
    private bool IsWithinThreshold(float size1, float size2)
    {
        return Mathf.Abs(size1 - size2) <= threshold;
    }

    // Method to get Player 1's score
    public int GetPlayerOneScore()
    {
        return playerOneScore;
    }

    // Method to get Player 2's score
    public int GetPlayerTwoScore()
    {
        return playerTwoScore;
    }
}
