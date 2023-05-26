using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject target;
    public float respawnTime = 5f;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start() 
    {
        SpawnAll();
    }

    public void SpawnAll()
    {
        SpawnObject(spawn1);
        SpawnObject(spawn2);
        SpawnObject(spawn3);
        SpawnObject(spawn4);
        SpawnObject(spawn5);
    }

    private void SpawnObject(GameObject spawnPoint)
    {
        GameObject t = Instantiate(target, spawnPoint.transform.position, spawnPoint.transform.rotation);
        spawnedObjects.Add(t);
    }

    public void DestroyAllObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
    }

    public void RespawnObject(GameObject destroyedObject)
    {
        StartCoroutine(RespawnCoroutine(destroyedObject));
    }

    private IEnumerator RespawnCoroutine(GameObject destroyedObject)
    {
        yield return new WaitForSeconds(respawnTime);
        if (!spawnedObjects.Contains(destroyedObject))
        {
            spawnedObjects.Remove(destroyedObject);
            SpawnObject(destroyedObject);
        }
    }
}
