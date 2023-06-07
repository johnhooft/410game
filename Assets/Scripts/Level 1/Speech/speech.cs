using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech : SpeechEncounter
{

    protected override bool SpeechConditionMet() { return (!StaticPlayerInfo.MiniGame1Completion); }

}
