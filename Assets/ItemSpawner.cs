using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject objectPrefab;    // Prefab of the object to be spawned
    public float spawnHeight = 50f;     // Height at which the objects will be spawned
    public float spawnRadius = 10f;     // Radius around the center to spawn objects

    public int numberOfObjects = 10;    // Number of objects to be spawned
    public float spawnInterval = 1f;    // Time interval between spawns

    private int objectsSpawned = 0;     // Counter for the number of objects spawned

    private void Start()
    {
        // Spawn the objects
        SpawnObjects();
    }

    private IEnumerator SpawnObjects()
    {
        while (objectsSpawned < numberOfObjects)
        {
            // Calculate random position within the spawn radius
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;

            // Offset spawn position to center around the game object
            spawnPosition += transform.position;

            // Set the spawn height
            spawnPosition.y = spawnHeight;

            // Instantiate the object at the calculated position
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // Optional: Parent the spawned object to the game object this script is attached to
            spawnedObject.transform.SetParent(transform);

            objectsSpawned++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}