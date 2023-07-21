using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
   public Transform playerTransform;
    public float followSpeed = 2.0f;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
