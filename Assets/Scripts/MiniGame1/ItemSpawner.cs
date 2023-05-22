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

    private void Awake()
    {
        // Spawn the objects
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (objectsSpawned < numberOfObjects)
        {
            // Calculate a random point within a unit circle
            Vector2 randomPoint = Random.insideUnitCircle;

            // Scale and offset the random point based on the spawn radius and transform position
            Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * spawnRadius + transform.position;

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