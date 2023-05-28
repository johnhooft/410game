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
        if (!StaticPlayerInfo.MiniGame1Completion) {
            StaticPlayerInfo.activeRedBones = new bool[StaticPlayerInfo.redBoneMaxCount];
            CheckActive();
        }
        RemoveInactiveKeys();
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
            other.gameObject.SetActive(false); CheckActive();
            if (other.gameObject.CompareTag("PickUp_Key"))
            {
                StaticPlayerInfo.redBoneCount++;
                SetKeyText();
            }
        }
    }

    void RemoveInactiveKeys()
    {
        for (int i = 0; i < StaticPlayerInfo.redBoneMaxCount; i++)
        {
            if (!StaticPlayerInfo.activeRedBones[i]) { StaticPlayerInfo.redBones[i].SetActive(false); }
        }
    }

    void CheckActive()
    {
        for (int i = 0; i < StaticPlayerInfo.redBoneMaxCount; i++)
        {
            StaticPlayerInfo.activeRedBones[i] = StaticPlayerInfo.redBones[i].activeSelf;
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
