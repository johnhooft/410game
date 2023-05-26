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
    public Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;
    GroundAngleCheck slopeCheck;
    //public Transform other_dog;
    //public Transform player;
    //public TextMeshProUGUI dogtext;
    
    [Header("Terrain Allignment")]
    public float playerAngle = 0f;
    public float playerTilt;
    public float maxSlopeAngle = 60f;
    public float angleTime;
    public float triggerAngle;
    public float terrainAngleMultiplier = 0f;

    [Header("Falling")]
    public bool showDebug = false; 
    public float inAirTimer;
    public float maxinAirTime = 15;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffset = 0.5f;
    public float rayCastJumpHeightOffset = 0.55f;
    public LayerMask groundLayer;

    [Header("Movement Speeds")]
    public float movementSpeed = 7;
    public float maxVertMoveSpeed = 5; // max speed dog can move up or down (does not affect falling speed).
    public float sprintSpeed = 10;
    public float rotationSpeed = 10;

    [Header("Movement Flags")]
    public bool isGrounded;
    public bool isJumping;
    public bool canJump;
    public bool isSprinting;

    [Header("Jumping Speeds")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;

    [Header("Animation")]
    public Animator animator;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        slopeCheck = GetComponent<GroundAngleCheck>();
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
            playerAngle = transform.eulerAngles.x;
            playerTilt = transform.eulerAngles.z;
            if (playerAngle > 180) {playerAngle -= 360;}
            if (playerTilt > 180) {playerTilt -= 360;}
            }
    }

    private void HandleMovement() // Handles the movement of the player.
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        if (isSprinting) {moveDirection = moveDirection * sprintSpeed;}
        else {moveDirection = moveDirection * movementSpeed;}

        Vector3 movementVelocity = moveDirection;
        playerAngle *= terrainAngleMultiplier;

        if ((slopeCheck.groundSlopeAngle > triggerAngle) && (movementVelocity.x > 0 || movementVelocity.z > 0))
        {
            playerRigidbody.useGravity = false;
            movementVelocity.y = playerAngle;
            //cap movement speed up slope.
            if (movementVelocity.y > maxVertMoveSpeed) {movementVelocity.y = maxVertMoveSpeed;}
            //Cap movement speed down slope, devide by 1.5 as we want to player to go down slopes slower than climb them.
            if (movementVelocity.y < -maxVertMoveSpeed) {movementVelocity.y = -maxVertMoveSpeed / 1.5f;} 
            if (slopeCheck.groundSlopeAngle < maxSlopeAngle)
            {
                playerRigidbody.velocity = movementVelocity;
            }
            else 
            {
                playerRigidbody.useGravity = true;
                playerRigidbody.velocity = Vector3.zero;
            }
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

        RaycastHit hit2;
        Vector3 rayCastOrigin2 = transform.position;
        rayCastOrigin2.y = rayCastOrigin2.y + rayCastJumpHeightOffset;

        if (!isGrounded && !isJumping)
        {
            inAirTimer = inAirTimer + Time.deltaTime;
            if (inAirTimer > maxinAirTime) {inAirTimer = maxinAirTime;}
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            if (playerRigidbody.velocity.y != 0) {playerRigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);}
        }
        if (Physics.SphereCast(rayCastOrigin2, 0.2f, Vector3.down, out hit2, 0.3f, groundLayer))
        {
            canJump = true;
            if (showDebug) { Debug.DrawLine(rayCastOrigin2, hit2.point, Color.yellow); }
            if (Physics.SphereCast(rayCastOrigin, 0.2f, Vector3.down, out hit, 0.3f, groundLayer))
            {
                // print red line of raycast.
                if (showDebug) { Debug.DrawLine(rayCastOrigin, hit.point, Color.red); }
                inAirTimer = 0;
                isGrounded = true;
                isJumping = false;
            }
        }

        else
        {
            isGrounded = false;
            isJumping = false;
            canJump = false;
        }
    }
    public void HandleJump()
    {
        if (canJump)
        {
            isJumping = true;
            playerRigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravityIntensity), ForceMode.Impulse);
        }
    }
}
