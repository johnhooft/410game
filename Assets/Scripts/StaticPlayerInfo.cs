using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlayerInfo : MonoBehaviour
{
    static public bool MiniGame1Completion = false;
    
    public GameObject door;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Minigame 1  completion = " + MiniGame1Completion);   
        if(MiniGame1Completion == true)
        {
            
            door.SetActive(false);
            Debug.Log("minigamedone");

        }
    }
}
