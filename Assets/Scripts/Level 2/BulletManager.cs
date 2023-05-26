using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BulletManager : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        // if (collision.compareTag("target") then do something)
        Destroy(gameObject, life);
    }
}