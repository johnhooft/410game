using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsLevel3 : MonoBehaviour
{
    //[Header("Spawn Points")]
    public GameObject[] SpawnPoints;
    [Header("Obsticles")]
    public GameObject obsticle1;
    public GameObject obsticle2;
    [Header("Spawn Perameters")]
    public float range = 12f;
    public float spawnHeight = 3f;
    public float spawnInterval = 3f;

    [Header("Flags")]
    public bool inGame = false;
    public bool spawnTest = false;

    private void Start() 
    {
        // still unsure when obsticles should start spawning, right now I have it so they start when scene loads.
        if (inGame) {StartCoroutine(spawnRoutine());}
    }

    private void Update() 
    {
        // just for testing purposes.
        if (spawnTest) {spawnTest = false; spawnObsticles(SpawnPoints[0], obsticle1);}
    }

    private IEnumerator spawnRoutine()
    {
        while (inGame)
        {
            for (int i = 0; i < 3; i++) {spawnObsticles(SpawnPoints[i], obsticle2);}
            yield return new WaitForSeconds(spawnInterval);
            for (int i = 0; i < 3; i++){spawnObsticles(SpawnPoints[i], obsticle1);}
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //this is support for it we want to do hitbox based spawn starts.
        if (other.gameObject.CompareTag("Player") && inGame == false && !inGame) 
        {
            inGame = true; 
            StartCoroutine(spawnRoutine());
        }
    }

    public void spawnObsticles(GameObject spawn, GameObject obsticle)
    {
        //random spawn
        Vector3 spawnposition = spawn.transform.position;
        float spawnoffset = Random.Range(1, range);
        spawnposition.z += spawnoffset;
        spawnposition.y += spawnHeight;
        Quaternion spawnRotation = spawn.transform.rotation;
        GameObject spawnedObject = Instantiate(obsticle, spawnposition, spawnRotation);
        spawnedObject.transform.SetParent(transform);

        // do again but for other side of spawn point
        spawnposition = spawn.transform.position;
        spawnoffset = Random.Range(-range, -1);
        spawnposition.z += spawnoffset;
        spawnposition.y += spawnHeight;
        spawnRotation = spawn.transform.rotation;
        spawnedObject = Instantiate(obsticle, spawnposition, spawnRotation);
        spawnedObject.transform.SetParent(transform);
    }
}
