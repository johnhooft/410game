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
    InputManager inputManager;
    public Transform targetTransform; //object camera will follow.
    public Transform cameraPivot; //object camera uses to pivot.
    public Transform cameraTransform; // transform of the actually camera object in the scene.
    public LayerMask collisionLayers;
    private float defaultPosition = -3;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    public float cameraCollisionOffSet = 0.2f; //how much the camera will jump off objects its colliding with.
    public float minCollisionOffSet = 0.2f;
    public float cameraCollisionRadius = 0.2f;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;
    public float camLookSmoothTime = 1;
    public float maxCamPosition;
    public float minCamPosition;


    public float minPivotAngle = -35;
    public float maxPivotAngle = 35;
    public float lookAngle;
    public float pivotAngle;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisons();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;
        lookAngle = Mathf.Lerp(lookAngle, lookAngle + (inputManager.cameraInputX * cameraLookSpeed), 
            camLookSmoothTime * Time.deltaTime);
        pivotAngle = Mathf.Lerp(pivotAngle, pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed), 
            camLookSmoothTime * Time.deltaTime);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisons()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direciton = cameraTransform.position - cameraPivot.position;
        direciton.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direciton, 
        out hit, Mathf.Abs(targetPosition), collisionLayers));
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition = -(distance - cameraCollisionOffSet); 
        }

        if (Mathf.Abs(targetPosition) < minCollisionOffSet)
        {
            targetPosition = targetPosition - minCollisionOffSet;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        if (cameraVectorPosition.z > maxCamPosition) {cameraVectorPosition.z = maxCamPosition;}
        if (cameraVectorPosition.z < minCamPosition) {cameraVectorPosition.z = minCamPosition;}
        cameraTransform.localPosition = cameraVectorPosition;
    }
}