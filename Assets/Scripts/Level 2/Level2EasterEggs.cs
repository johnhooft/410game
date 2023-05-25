using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EasterEggs : MonoBehaviour
{
    public GameObject hat;
    public GameObject earLeft;
    public GameObject earRight;
    private void Update() 
    {
        level2EasterEggs();   
    }
    public void level2EasterEggs()
    {
        if (!StaticPlayerInfo.cowboyhat) {hat.SetActive(false);}
        else 
        {
            hat.SetActive(true);
            earLeft.SetActive(false);
            earRight.SetActive(false);
        }
    }
}
