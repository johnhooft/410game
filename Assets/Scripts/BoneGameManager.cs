using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneGameManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public float radius = 10f;
    public float objectSpeed = 3f;
    public float objectHeight = 2f;
    public int maxObjects = 6;

    private int currentObjectCount = 0;
    private int playerHealth = 3;

    private void Start() 
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (currentObjectCount < maxObjects)
        {
            SpawnObjectOnCircleEdge();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnObjectOnCircleEdge()
    {
        Vector3 spawnPosition = GetPositionOnCircleEdge();
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        BoneGameEnemyMovement enemyMovement = FindObjectOfType<BoneGameEnemyMovement>();
        enemyMovement.Initialize(radius, objectSpeed, objectHeight, playerHealth, this);
        currentObjectCount++;
    }

    private Vector3 GetPositionOnCircleEdge()
    {
        float angle = Random.Range(0f, 360f);
        float x = transform.position.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = transform.position.y + objectHeight;
        float z = transform.position.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, z);
    }

}
