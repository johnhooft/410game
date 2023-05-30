using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3Manager : MonoBehaviour
{
    public GameObject resetPos;
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = resetPos.transform.position;
        }
    }
}
