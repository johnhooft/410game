using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Description:
This script deals with the camera that follows the character.
The camera currently maintains the the same direction all the time while the character rotates freely.
*/
  //public Transform targetTransform; //object camera will follow.
    //private Vector3 cameraFollowVelocity = Vector3.zero;
    //public float cameraFollowSpeed = 0.2f;

    /*private void Awake()
    {
        targetTransform = FindAnyObjectByType<PlayerManager>().transform;
    }
    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;


    }

    */
public class CameraManager : MonoBehaviour
{
    
        


    

    
    public Transform camTarget;
    
    public float pLerp = .02f;
    public float rLerp = .01f;
    // Start is called before the first frame update
   
    

    // Update is called once per frame
    
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,camTarget.position,pLerp);
        transform.rotation  = Quaternion.Lerp(transform.rotation,camTarget.rotation,rLerp);


    }


}