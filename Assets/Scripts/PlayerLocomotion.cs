using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
Description:
This script handles all the movements of the charecter,
processes the inputs and converts them into charecter movement.
*/

public class PlayerLocomotion : MonoBehaviour
{
    public InputManager inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;
    //public Transform other_dog;
    public Transform player;
    //public TextMeshProUGUI dogtext;
    
    [Header("Terrain Allignment")]
    public float playerAngle = 0f;
    public float angleTime;
    public float triggerAngle;
    public float terrainAngleMultiplier = 0f;

    [Header("Falling")]
    public float inAirTimer;
    public float maxinAirTime = 15;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffset = 0.5f;
    public LayerMask groundLayer;

    [Header("Movement Speeds")]
    public float movementSpeed = 7;
    public float rotationSpeed = 10;

    [Header("Movement Flags")]
    public bool isGrounded;
    public bool isJumping;

    [Header("Jumping Speeds")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        if (playerRigidbody == null){
            Debug.Log("Could not get rigidbody");
        }
        cameraObject = Camera.main.transform;
        //dogtext.enabled = false;
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        AlignWithTerrain();
        HandleMovement();
        HandleRotation();
    }
    
    private void AlignWithTerrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 targetNormal = hit.normal;
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, targetNormal) * transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, angleTime);
            }
    }

    private void HandleMovement() // Handles the movement of the player.
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerAngle = transform.eulerAngles.x;
        if (playerAngle > 180) {playerAngle -= 360;}
        playerAngle *= terrainAngleMultiplier;
        if ((playerAngle > triggerAngle || playerAngle < -triggerAngle) && (movementVelocity.x > 0 || movementVelocity.z > 0))
        {
            playerRigidbody.useGravity = false;
            movementVelocity.y = playerAngle;
            Debug.Log("player angle = " + playerAngle);
            Debug.Log("movement velocity = " + movementVelocity);
            playerRigidbody.velocity = movementVelocity;
        }
        else 
        {
            playerRigidbody.useGravity = true;
            playerRigidbody.velocity = movementVelocity;
        }
    }

    private void HandleRotation() // Handles the rotation of the player, player should correctly face the direction they are
                                 // moving towards.
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if (!isGrounded && !isJumping)
        {
            inAirTimer = inAirTimer + Time.deltaTime;
            if (inAirTimer > maxinAirTime) {inAirTimer = maxinAirTime;}
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            if (playerRigidbody.velocity.y != 0) {playerRigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);}
        }
        if (Physics.SphereCast(rayCastOrigin, 0.2f, Vector3.down, out hit, 0.3f, groundLayer))
        {
            inAirTimer = 0;
            isGrounded = true;
            isJumping = false;
        }
        else
        {
            isGrounded = false;
            isJumping = false;
        }
    }
    public void HandleJump()
    {
        if (isGrounded)
        {
            isJumping = true;
            playerRigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravityIntensity), ForceMode.Impulse);
        }
    }
/*
    void OnSubmit()
    {
        if(Vector3.Distance(player.transform.position,other_dog.transform.position)<2)
        {
            
            text();
        }




    }
*/



/*
    void text()
    {
        dogtext.text = "Im Hungry maybe if you grab some of those brown mushrooms for me I can help you get that the pickup above me";
        dogtext.enabled = true;
        int i = 0;
        while(i<1000)
        {
            
            i++;

        }
        dogtext.enabled = false;

    }
    */
}
