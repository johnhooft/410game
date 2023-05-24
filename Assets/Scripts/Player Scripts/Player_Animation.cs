using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Animation : MonoBehaviour
{

    public Animator animator;
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager =  transform.parent.GetComponent<InputManager>();
        playerLocomotion = transform.parent.GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    public void HandleAnimation()
    {
        /* Essentially just */
        /** y = verticalInput; or y = movementInput.y; **/
        /** x = horizontalInput; or x = movementInput.x; **/
        
        animator.SetFloat("x", verticalInput);
        animator.SetFloat("y", horizontalInput);

        bool isWalking = inputManager.horizontalInput != 0 || inputManager.verticalInput != 0;

        animator.SetBool("IsWalking", isWalking);

        /* Is the dog sprinting? (A component of InputManager */
        animator.SetBool("IsSprinting", playerLocomotion.isSprinting); 
    }
}
