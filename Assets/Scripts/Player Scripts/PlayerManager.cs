using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is for resetting the scene if the player falls out of bounds.
using UnityEngine.SceneManagement;

// For UI stuff
using TMPro;

/*
Description:
Script used to run all functionality created for player.
Deals with the camera, and player movement.
*/

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager;
    CameraManager cameraManager;
    // Player_Animation player_Animation;
    PlayerLocomotion playerLocomotion;
    Rigidbody playerRigidbody;

    private void Start()
    {
        StaticPlayerInfo.redBones = GameObject.FindGameObjectsWithTag("PickUp_Key");
        StaticPlayerInfo.redBoneMaxCount = StaticPlayerInfo.redBones.Length;
    }

    private void Awake() // get various components from object that it is attached too.
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        inputManager = GetComponent<InputManager>();
        // player_Animation = transform.GetChild(0).GetComponent<Player_Animation>();
        cameraManager = FindAnyObjectByType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerLocomotion.inputManager = inputManager;
    }

    private void Update() //run the function that handles inputs every frame.
    {
        inputManager.HandleAllInputs();
        // player_Animation.HandleAnimation();
    }

    private void FixedUpdate() //take the input variables and convert them into movements of the player.
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate() //take the movement of the player and make camera follow.
    {
        cameraManager.HandleAllCameraMovement();
    }

    // Collectibles!
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hat")) 
        {
            StaticPlayerInfo.cowboyhat = true;
            other.gameObject.SetActive(false);
        }

    }
}
