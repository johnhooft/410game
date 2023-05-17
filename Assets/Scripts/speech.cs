using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech : MonoBehaviour
{
    
    public GameObject text;
    
    static public bool MiniGame1Completion = false;
    
    // Update is called once per frame
    void Start()
    {
        text.SetActive(false);
    }
    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player" && MiniGame1Completion == false)
        {
            text.SetActive(true);
            StartCoroutine("WaitForSec");

        }
        

    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(7);
        text.SetActive(false);


    }
   
}
