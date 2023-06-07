using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech2 : SpeechEncounter
{

    public GameObject bridge;
    protected override bool SpeechConditionMet() { return (!StaticPlayerInfo.allBonesCollected); }

    protected override void OnTriggerEnter(Collider player)
    {
        base.OnTriggerEnter(player);
        if (player.gameObject.tag == "Player" && !SpeechConditionMet()) { bridge.SetActive(false); }
    }

}

