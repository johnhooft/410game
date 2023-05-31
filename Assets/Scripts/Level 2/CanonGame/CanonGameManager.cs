using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonGameManager : MonoBehaviour
{
    public int targetsHit = 0;
    public int numTargets;
    public GameObject door;

    private void Update() 
    {
        targetsHit = StaticLevel2Info.targetsHit;
        if (targetsHit == numTargets) {Destroy(door);} 
    }
}
