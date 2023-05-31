using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleSpeech : SpeechEncounter
{

    protected override bool SpeechConditionMet() { return (StaticLevel2Info.targetsHit < 5); }

}