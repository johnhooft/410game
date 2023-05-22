using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech2 : MonoBehaviour
{
    
    public GameObject text;
    //public GameObject bone;
    public GameObject bridge;
    public GameObject text2;
    static public bool MiniGame1Completion = false;
    
    // Update is called once per frame
    void Start()
    {
        text.SetActive(false);
        text2.SetActive(false);
    }
    void OnTriggerEnter(Collider player)
    {
        //if(player.gameObject.tag == "Player" && bone.activeSelf == true)
        if(player.gameObject.tag == "Player" && !StaticPlayerInfo.allBonesCollected)
        {
            text.SetActive(true);
            StartCoroutine("WaitForSec");

        }
        //else if(player.gameObject.tag == "Player" && bone.activeSelf == false)
        else if(player.gameObject.tag == "Player" && StaticPlayerInfo.allBonesCollected)
        {
            text2.SetActive(true);
            StartCoroutine("WaitForSec");
        }

    }
    IEnumerator WaitForSec()
    {
        //if( bone.activeSelf == true)
        if(!StaticPlayerInfo.allBonesCollected)
        {
        yield return new WaitForSeconds(7);
        text.SetActive(false);
        }
        //else if( bone.activeSelf == false)
        else if(StaticPlayerInfo.allBonesCollected)
        {
        bridge.SetActive(false);
        yield return new WaitForSeconds(7);
        text.SetActive(false);
        

        }


    }
   
}

