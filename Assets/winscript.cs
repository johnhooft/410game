using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winscript : MonoBehaviour
{
    public GameObject wintext;

    // Start is called before the first frame update
    void Start()
    {
        wintext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            StartCoroutine(WaitForSec());

        }


    }
    IEnumerator WaitForSec()
    {
        wintext.SetActive(true);
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(0);



    }
}
