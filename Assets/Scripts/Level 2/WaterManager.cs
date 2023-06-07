using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterManager : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;
    public InputManager inputManager;
    public input riddleinput;
    public bool dead = false;
    public bool die = false;
    public CameraFade cameraFade;
    public bool inCanyon = false;
    [Header("Thirst Levels")]
    public float thirst = 10;
    public float maxThirst = 100;
    [Header("Thirst Decrease Rate")]
    public float timer = 0;
    public float value = .05f;
    public TextMeshProUGUI thirstMeterUIText;
    public TextMeshProUGUI youDiedOfThirst;
    public GameObject deathPanel;

    private float starttime = 1;

    private void Start()
    {
        SetThirstText();
        youDiedOfThirst.alpha = 0f;
        deathPanel.SetActive(false);
    }

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
        SetThirstText();
        if (thirst < 6)
        {
            playerLocomotion.movementSpeed -= value;
            playerLocomotion.sprintSpeed -= value;
        }
        if (thirst < 1 && !dead) { dead = true; StartCoroutine(dieofThirst()); }
    }

    void SetThirstText()
    {
        thirstMeterUIText.text = "Thirst Level: " + Mathf.Round(thirst).ToString() + " / 100";
    }

    IEnumerator dieofThirst()
    {
        thirstMeterUIText.text = "Thirst Level: 0 / 100";
        float deathtimer = 7f;
        riddleinput.exitRiddle();
        deathPanel.SetActive(true);
        youDiedOfThirst.alpha = 100;
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
        deathPanel.SetActive(false);
        youDiedOfThirst.alpha = 0;
        SetThirstText();

        //Must reset movement speed as well or else Player will continue to walk slowly backwards!
        playerLocomotion.movementSpeed = 5;
        playerLocomotion.sprintSpeed = 7;
        inputManager.OnEnable();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Canyon Entrance")) { inCanyon = true; }
        else if (other.gameObject.CompareTag("Canyon Exit")) { inCanyon = false; }
        if (other.gameObject.CompareTag("Water")) {
            thirst = 100; 
            SetThirstText();
        }
    }
}
