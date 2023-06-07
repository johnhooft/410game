using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1IntroUIDisappear : MonoBehaviour
{

    //public GameObject text;
    public GameObject speechPanel;
    
    // Update is called once per frame
    void Start()
    {
        if (!StaticPlayerInfo.InitLevel1) { speechPanel.SetActive(false); }
    }

}
