using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Description:
This script handles the input manager, takes inputs specified in the mapping (see Input Manager in assets)
and converts those inputs into vertical input and horizontal input.
*/

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    Player_Animation playerAnimation;

    public Vector2 movementInput;
    private float moveAmount;
    public Vector2 cameraInput;
    
    public float cameraInputX;
    public float cameraInputY;

    public float verticalInput;
    public float horizontalInput;

    public bool jump_Input;
    public float shiftInput;

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerAnimation = GetComponent<Player_Animation>();
    }
    public void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerAction.Jump.performed += i => {jump_Input = true;};
            playerControls.PlayerAction.Sprint.performed += i => shiftInput = i.ReadValue<float>();
    }

        playerControls.Enable();
    }

    public void OnDisable()
    {
        movementInput.x = 0;
        movementInput.y = 0;
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleSprintInput();
    }

    private void HandleSprintInput()
    {
        if (shiftInput == 1) {playerLocomotion.isSprinting = true;}
        else {playerLocomotion.isSprinting = false;}
    }
    private void HandleJumpInput()
    {
        if (jump_Input)
        {

            playerLocomotion.HandleJump();
        }
        jump_Input = false;
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        playerAnimation.HandleAnimation(0, moveAmount);
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

    }

}
