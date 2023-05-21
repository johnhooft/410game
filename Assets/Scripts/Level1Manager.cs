using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Minigame 1  completion = " + MiniGame1Completion);   
        if(StaticPlayerInfo.MiniGame1Completion == true)
        {
            
            door.SetActive(false);
            //Debug.Log("minigamedone");

        }
    }
}
