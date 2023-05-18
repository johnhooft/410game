using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            StaticPlayerInfo.portalTransform = transform.position;
            SceneManager.LoadScene(1);
    }
}
