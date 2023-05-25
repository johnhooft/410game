using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Animation : MonoBehaviour
{

    public Animator animator;
    PlayerLocomotion playerLocomotion;
    int horizontal, vertical;

    
    // Start is called before the first frame update
    void Awake()
    {
     
        animator = transform.GetChild(0).GetComponent<Animator>();
        horizontal = Animator.StringToHash("x");
        vertical = Animator.StringToHash("y");

        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    public void HandleAnimation(float horizontalMovement, float verticalMovement)
    {
        float snappedHorizontal;
        float snappedVertical;
        /* Essentially just */
        /** y = verticalInput; or y = movementInput.y; **/
        /** x = horizontalInput; or x = movementInput.x; **/
        print("Horizontal Movement = " + horizontalMovement);
        print("Vertical Movement = " + verticalMovement);

        /* Is the dog sprinting? (A component of InputManager */
        animator.SetBool("IsGrounded", playerLocomotion.isGrounded);
        print(playerLocomotion.isGrounded);

        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            snappedHorizontal = 1;
        }
        else if(horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if(horizontalMovement < -0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion

        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snappedVertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }

        #endregion

        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);

        // bool isWalking = inputManager.horizontalInput != 0 || inputManager.verticalInput != 0;

        // animator.SetBool("IsWalking", isWalking);

    }
}
