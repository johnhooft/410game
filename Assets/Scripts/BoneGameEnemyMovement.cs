using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneGameEnemyMovement : MonoBehaviour
{
    private float radius;
    private float speed;
    private float height;
    private int playerHealth;
    private BoneGameManager spawner;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private bool movingForward = true;

    public void Initialize(float radius, float speed, float height, int playerHealth, BoneGameManager spawner)
    {
        this.radius = radius;
        this.speed = speed;
        this.height = height;
        this.playerHealth = playerHealth;
        this.spawner = spawner;

        startPosition = transform.position;
        targetPosition = CalculateTargetPosition();
        targetRotation = CalculateTargetRotation();
    }

    private Vector3 CalculateTargetPosition()
    {
        Vector3 direction = (startPosition - spawner.transform.position).normalized;
        Vector3 offset = direction * radius * 2;
        return startPosition + offset;
    }

    private Quaternion CalculateTargetRotation()
    {
        Vector3 forwardDirection = (spawner.transform.position - startPosition).normalized;
        return Quaternion.LookRotation(forwardDirection);
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (movingForward)
        {
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                movingForward = false;
                targetPosition = startPosition;
                targetRotation *= Quaternion.Euler(0f, 180f, 0f);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                movingForward = true;
                targetPosition = CalculateTargetPosition();
                targetRotation = CalculateTargetRotation();
            }
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
    }

}
