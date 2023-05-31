using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGameControlsUI : MonoBehaviour
{
    public GameObject controls;

    // Start is called before the first frame update
    void Start()
    {
        controls.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && (StaticLevel2Info.targetsHit < 5))
        {
            controls.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        if (StaticLevel2Info.targetsHit < 5)
        {
            yield return new WaitForSeconds(7);
            controls.SetActive(false);
        }
    }

}
