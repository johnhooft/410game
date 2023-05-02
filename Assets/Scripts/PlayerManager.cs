using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Description:
Script used to run all functionality created for player
*/

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        cameraManager = FindAnyObjectByType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.FollowTarget();
    }
}
