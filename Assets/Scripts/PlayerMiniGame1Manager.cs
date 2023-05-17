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
    }

    void SetHealthText ()
    {
        healthText.text = "Health: " + health.ToString();
        if (health < 1)
        {
            ReloadScene();
        }
    }

    void SetCountText()
    {
        countText.text = "Bones Collected: " + count.ToString();
        if(count >= 12)
        {
            //do something
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            SetHealthText();
        }
    }
}
