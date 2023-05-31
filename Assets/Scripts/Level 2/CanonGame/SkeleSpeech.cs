using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleSpeech : SpeechEncounter
{

    //public GameObject controls;

    protected override bool SpeechConditionMet() { return (StaticLevel2Info.targetsHit < 5); }

/*
    // Update is called once per frame
    protected override void Start() { base.Start(); controls.SetActive(false); }

    protected override void OnTriggerEnter(Collider player)
    {
        base.OnTriggerEnter(player);
        if(player.gameObject.tag == "Player" && SpeechConditionMet()) { controls.SetActive(true); }
    }
*/
}