using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinText : MonoBehaviour
{
    public GameObject winText;
    public GameObject winText2;
    public GameObject winPanel;
    public GameObject endWall;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        winText2.SetActive(false);
        winPanel.SetActive(false);
        endWall.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            winPanel.SetActive(true);
            winText.SetActive(true);
            winText2.SetActive(true);
            endWall.SetActive(true);
            StartCoroutine(WaitForSec());
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(0);
    }
}
