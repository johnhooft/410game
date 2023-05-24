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

    // Red Bone Counter
    public TextMeshProUGUI redBoneUIText;

    private void Start()
    {
        StaticPlayerInfo.redBones = GameObject.FindGameObjectsWithTag("PickUp_Key");
        StaticPlayerInfo.redBoneMaxCount = StaticPlayerInfo.redBones.Length;
        SetKeyText();
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
        if (other.gameObject.CompareTag("PickUp") || other.gameObject.CompareTag("PickUp_Key"))
        {
            other.gameObject.SetActive(false);
            if (other.gameObject.CompareTag("PickUp_Key"))
            {
                StaticPlayerInfo.redBoneCount++;
                SetKeyText();
            }
        }

        /* 
	// If the player falls off the edge it resets the scene.
		// NOTE: This was included specifically for the PoC build.
		// We can remove this line of code if we don't need it later on.
        else if (other.gameObject.CompareTag("Respawn")) { SceneManager.LoadScene(0); }
        */
    }

    void SetKeyText() // Updating UI Text
    {
        redBoneUIText.text = "Red Bones: " + StaticPlayerInfo.redBoneCount.ToString() + " / " + StaticPlayerInfo.redBoneMaxCount.ToString();
        if (StaticPlayerInfo.redBoneCount >= StaticPlayerInfo.redBoneMaxCount)
        {
            StaticPlayerInfo.allBonesCollected = true;
            //Debug.Log("Hooray! Collected All Bones!");
        }
    }
}
