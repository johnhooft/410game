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
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) {Destroy(other.gameObject); StaticLevel2Info.targetsHit++;}
    }
}