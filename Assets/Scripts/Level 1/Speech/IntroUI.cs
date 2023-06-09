using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour
{

    public GameObject text;
    public GameObject speechPanel;
    
    // Update is called once per frame
    void Start() { StartCoroutine("WaitForSec"); }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(13);
        speechPanel.SetActive(false);
        text.SetActive(false);
        if (StaticPlayerInfo.InLevel1) { StaticPlayerInfo.InitLevel1 = false; }
        else if (StaticPlayerInfo.InMiniGame1) { StaticPlayerInfo.InitMiniGame1 = false; }
    }
}
