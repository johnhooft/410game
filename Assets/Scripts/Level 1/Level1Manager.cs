using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Manager : MonoBehaviour
{
    public GameObject door;
    public TextMeshProUGUI redBoneUIText;
    
    void Start()
    {
        StaticPlayerInfo.redBones = GameObject.FindGameObjectsWithTag("PickUp_Key");
        StaticPlayerInfo.redBoneMaxCount = StaticPlayerInfo.redBones.Length;
        SetKeyText();
    }

    void Update()
    {
        //Debug.Log("Minigame 1  completion = " + MiniGame1Completion);   
        if(StaticPlayerInfo.MiniGame1Completion == true)
        {
            if (StaticPlayerInfo.portalReturn)
            {
                transform.position = StaticPlayerInfo.portal1;
                StaticPlayerInfo.portalReturn = false;
            }
            door.SetActive(false);
            //Debug.Log("minigamedone");

        }
    }

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
