using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Animation : MonoBehaviour
{

    public Animator animator;
    public InputManager inputManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager =  transform.parent.GetComponent<InputManager>();
    }

    // Update is called once per frame
    public void HandleAnimation()
    {
        bool isWalking = inputManager.horizontalInput != 0 || inputManager.verticalInput != 0;

        if (isWalking)
            animator.SetBool("IsWalking", isWalking);
    }
}
