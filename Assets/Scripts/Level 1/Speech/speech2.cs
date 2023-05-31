using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech2 : MonoBehaviour
{
    
    public GameObject text;
    //public GameObject bone;
    public GameObject bridge;
    public GameObject text2;
    public GameObject speechPanel;
    static public bool MiniGame1Completion = false;
    
    // Update is called once per frame
    void Start()
    {
        text.SetActive(false);
        text2.SetActive(false);
        speechPanel.SetActive(false);
    }
    void OnTriggerEnter(Collider player)
    {
        //if(player.gameObject.tag == "Player" && bone.activeSelf == true)
        if(player.gameObject.tag == "Player" && !StaticPlayerInfo.allBonesCollected)
        {
            speechPanel.SetActive(true);
            text.SetActive(true);
            StartCoroutine("WaitForSec");

        }
        //else if(player.gameObject.tag == "Player" && bone.activeSelf == false)
        else if(player.gameObject.tag == "Player" && StaticPlayerInfo.allBonesCollected)
        {
            speechPanel.SetActive(true);
            text2.SetActive(true);
            bridge.SetActive(false);
            StartCoroutine("WaitForSec");
        }

    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(7);
        speechPanel.SetActive(false);
        //if( bone.activeSelf == true)
        if (!StaticPlayerInfo.allBonesCollected)
        {
        text.SetActive(false);
        }
        //else if( bone.activeSelf == false)
        else if(StaticPlayerInfo.allBonesCollected)
        {
        text2.SetActive(false);
        }

    }

}

