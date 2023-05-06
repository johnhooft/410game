using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is for resetting the scene if the player falls out of bounds.
using UnityEngine.SceneManagement;

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
        playerLocomotion.inputManager = inputManager;
    }

    private void Update() //run the function that handles inputs every frame.
    {
        inputManager.HandleAllInputs();
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
        if (other.gameObject.CompareTag("PickUp")) { other.gameObject.SetActive(false); }

	// If the player falls off the edge it resets the scene.
		// NOTE: This was included specifically for the PoC build.
		// We can remove this line of code if we don't need it later on.
        else if (other.gameObject.CompareTag("Respawn")) { SceneManager.LoadScene(0); }

    }
}
