using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleManager : MonoBehaviour
{
    Rigidbody rigidBody;

    public float moveSpeed = 2f;
    public Vector3 moveDirection = Vector3.forward;
    public float lifespan;

    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody>();
         Destroy(gameObject, lifespan);
    }
    private void Update() 
    {
        moveObsticle();
    }

    public void moveObsticle()
    {
        //moveSpeed += Random.Range(.5f, 2);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("lvl3Border")) {Destroy(gameObject);}
    }
}
