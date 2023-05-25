using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;
    public bool dead = false;
    public bool die = false;
    public CameraFade cameraFade;
    public bool inCanyon = false;
    [Header("Thirst Levels")]
    public float thirst = 10;
    public float maxThirst = 100;
    [Header("Thirst Decrease Rate")]
    public float timer = 0;
    public float value = .1f;

    private float starttime = 1;

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    private void Update()
    {
        if (die) {StartCoroutine(dieofThirst()); die = false;}
        if (inCanyon)
        {
            // Decrease the variable value every 5 seconds
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                lowerThirst();
                timer = starttime; // Reset the timer
            }   
        }
    }

    void lowerThirst()
    {
        thirst -= value;
        if (thirst < 6)
        {
            playerLocomotion.movementSpeed -= value;
            playerLocomotion.sprintSpeed -= value;
        }
        if (thirst < 1 && !dead) {dead = true; StartCoroutine(dieofThirst());}
    }

    IEnumerator dieofThirst()
    {
        float deathtimer = 7f;
        cameraFade.Fade(.1f);
        Debug.Log(Time.deltaTime);
        yield return new WaitForSeconds(deathtimer);
        Debug.Log(Time.deltaTime);
        transform.position = new Vector3(1, 1.85f, 1);
        cameraFade.Fade(.8f);
        //print on UI that you died of thirst;

        //reset thirst and incanyon bool
        thirst = 10;
        inCanyon = false;
        dead = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Canyon Entrance"))
        {
            inCanyon = true;
        }
    }
}
