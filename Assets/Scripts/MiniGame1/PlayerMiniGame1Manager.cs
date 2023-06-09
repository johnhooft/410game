using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMiniGame1Manager : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;

    private int count;
    private int health;

    private void Start() 
    {
        count = 0;
        health = 3;
        SetHealthText();
        SetCountText();
        StaticPlayerInfo.InitMiniGame1 = false;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString() + " / 3";
        if (health < 1)
        {
            ReloadScene();
        }
    }

    void SetCountText()
    {
        countText.text = "Bones: " + count.ToString() + " / 12";
        if(count >= 12)
        {
            StaticPlayerInfo.MiniGame1Completion = true;
            StaticPlayerInfo.portalReturn = true;
            SceneManager.LoadScene(1);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("tag = " + other.gameObject.tag);
        if (other.gameObject.CompareTag("PickUp")) 
        { 
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            SetHealthText();
        }
    }
}
