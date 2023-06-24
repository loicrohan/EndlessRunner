using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    private ObjectPooler objectPooler;

    private void Start()
    {
        // Find the ObjectPooler script
        objectPooler = FindObjectOfType<ObjectPooler>();

        // Spawn obstacles at regular intervals
        InvokeRepeating("SpawnObstacle", 0f, 2f);
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = objectPooler.GetPooledObject();
        // Position and activate the obstacle
        obstacle.transform.position = transform.position;
        obstacle.SetActive(true);
    }
}