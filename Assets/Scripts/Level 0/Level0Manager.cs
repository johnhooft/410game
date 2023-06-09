using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level0Manager : MonoBehaviour
{
    public Transform player;
    /*public GameObject bone;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSec());
    }*/

    // Update is called once per frame
    void Update()
    {
        if(player.position.y <= 3)
        {
            SceneManager.LoadScene(1);

        }
    }

/*
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(10);
        bone.SetActive(false);

    }
*/
}
 