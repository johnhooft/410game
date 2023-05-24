using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Animation : MonoBehaviour
{

    public Animator animator;

    
    // Start is called before the first frame update
    void Awake()
    {
        /*
        animator = GetComponent<Animator>();
        horizontal = animator.StringToHash("x");
        vertical = animator.StringToHash("y"); */
    }

    // Update is called once per frame
    public void HandleAnimation()
    {
        // float snappedHorizontal;
        // float snappedVertical;
        /* Essentially just */
        /** y = verticalInput; or y = movementInput.y; **/
        /** x = horizontalInput; or x = movementInput.x; **/
        
        // animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        // animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);

        // bool isWalking = inputManager.horizontalInput != 0 || inputManager.verticalInput != 0;

        // animator.SetBool("IsWalking", isWalking);

        /* Is the dog sprinting? (A component of InputManager */
        // animator.SetBool("IsSprinting", playerLocomotion.isSprinting); 
    }
}
