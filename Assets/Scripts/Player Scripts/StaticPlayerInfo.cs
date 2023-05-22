using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlayerInfo : MonoBehaviour
{
    static public bool MiniGame1Completion = false;
    static public Vector3 portal1 = new Vector3(35f, 1.85f, 73f);
    static public bool portalReturn;

    // Collectibles!
    static public int redBoneCount = 0;
    static public GameObject[] redBones;
    static public int redBoneMaxCount = 3;
    static public bool allBonesCollected = false;

}
