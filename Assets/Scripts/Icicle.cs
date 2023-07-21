using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Icicle : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public float penalty = 2.0f; // Speed to apply when hit by the icicle.
    public float duration = 0; // Duration of the reduced speed in seconds.
    public float regainSpeedDuration = 0; // Duration to gradually regain speed in seconds.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(AdjustSpeed());
           // playerMovement.moveSpeed = 0;
            Debug.Log("Icicle collided");
        }

    }

    private System.Collections.IEnumerator AdjustSpeed()
    {
        playerMovement.moveSpeed = playerMovement.moveSpeed-penalty;

        yield return new WaitForSeconds(duration);

        // Gradually increase the speed back to the original value.
        float timeElapsed = 0.0f;
        float startTime = Time.time;
        float initialSpeed = playerMovement.moveSpeed - penalty;
        float targetSpeed = playerMovement.originalMoveSpeed;

        while (timeElapsed < regainSpeedDuration)
        {
            timeElapsed = Time.time - startTime;
            float t = timeElapsed / regainSpeedDuration;
            playerMovement.moveSpeed = Mathf.Lerp(initialSpeed, targetSpeed, t);
            yield return null;
        }

        // Make sure to set the speed back to the original value precisely.
        playerMovement.moveSpeed = playerMovement.originalMoveSpeed;
    }
}