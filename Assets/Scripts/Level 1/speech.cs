using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech : MonoBehaviour
{
    
    public GameObject text;
    public GameObject text2;
    
    //static public bool MiniGame1Completion = false;
    
    // Update is called once per frame
    void Start()
    {
        text.SetActive(false);
        text2.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player" && !StaticPlayerInfo.MiniGame1Completion)
        {
            text.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        else if (player.gameObject.tag == "Player" && StaticPlayerInfo.MiniGame1Completion)
        {
            text2.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        

    }

    IEnumerator WaitForSec()
    {
        if (!StaticPlayerInfo.MiniGame1Completion)
        {
            yield return new WaitForSeconds(7);
            text.SetActive(false);
        }
        else if (StaticPlayerInfo.MiniGame1Completion)
        {
            yield return new WaitForSeconds(7);
            text2.SetActive(false);
        }
    }
   
}
