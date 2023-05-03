using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Description:
This script deals with the camera that follows the character.
The camera currently maintains the the same direction all the time while the character rotates freely.
*/

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform; //object camera will follow.
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float cameraFollowSpeed = 0.2f;

    private void Awake()
    {
        targetTransform = FindAnyObjectByType<PlayerManager>().transform;
    }
    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;


    }
}
