using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech : MonoBehaviour
{
    
    public GameObject text;
    public GameObject text2;
    public GameObject speechPanel;
    
    //static public bool MiniGame1Completion = false;
    
    // Update is called once per frame
    void Start()
    {
        text.SetActive(false);
        text2.SetActive(false);
        speechPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player" && !StaticPlayerInfo.MiniGame1Completion)
        {
            speechPanel.SetActive(true);
            text.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        else if (player.gameObject.tag == "Player" && StaticPlayerInfo.MiniGame1Completion)
        {
            speechPanel.SetActive(true);
            text2.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        

    }

    IEnumerator WaitForSec()
    {
        if (!StaticPlayerInfo.MiniGame1Completion)
        {
            yield return new WaitForSeconds(7);
            speechPanel.SetActive(false);
            text.SetActive(false);
        }
        else if (StaticPlayerInfo.MiniGame1Completion)
        {
            yield return new WaitForSeconds(7);
            speechPanel.SetActive(false);
            text2.SetActive(false);
        }
    }
   
}
