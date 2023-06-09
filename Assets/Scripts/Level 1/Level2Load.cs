using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Load : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StaticPlayerInfo.InLevel1 = false;
            StaticPlayerInfo.InMiniGame1 = false;
            SceneManager.LoadScene(3);
        }
    }
}
