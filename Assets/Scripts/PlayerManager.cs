using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Description:
Script used to run all functionality created for player.
Deals with the camera, and player movement.
*/

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    private void Awake() // get various components from object that it is attached too.
    {
        inputManager = GetComponent<InputManager>();
        cameraManager = FindAnyObjectByType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update() //run the function that handels inputs every frame.
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate() //take the input variables and convert them into movements of the player.
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate() //take the movement of the player and make camera follow.
    {
        cameraManager.FollowTarget();
    }
}
