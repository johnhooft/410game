using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlayerInfo : MonoBehaviour
{
    // Level 1 info
    static public bool InitLevel1 = true;
    static public bool InLevel1 = false;
    static public bool InitMiniGame1 = true;
    static public bool InMiniGame1 = false;
    static public bool MiniGame1Completion = false;
    static public Vector3 portal1 = new Vector3(35f, 1.85f, 73f);
    static public bool portalReturn;

    // Collectibles!
    static public int redBoneCount = 0;
    static public GameObject[] redBones;
    static public int redBoneMaxCount;
    static public bool[] activeRedBones;
    static public bool allBonesCollected = false;

    // Easter Eggs

    static public bool cowboyhat = false;

}
