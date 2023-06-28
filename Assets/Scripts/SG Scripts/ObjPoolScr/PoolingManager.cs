using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public GameObject[] pathPrefabs; // An array that holds different path prefabs.
    public int poolSize = 20; // Specifies the number of paths to spawn at the start of the game.
    public float zPos = 115.5f; //the initial z-position where the paths will be spawned.
    public float spawnInterval = 9f; //the time interval between spawning each path prefab.

    private List<GameObject> pathPool; // A list that holds the pooled path objects.
    private int pathIndex = 0; //An index variable to keep track of the current path
                               //prefab to be instantiated from the pathPrefabs array.
    private void Start()
    {
        //It initializes the object pool by instantiating the path objects and adding them to the pathPool list.

        pathPool = new List<GameObject>(); // create a list on hierarchy based on the number of poolSize

        //a for loop runs poolSize times to instantiate
        //and activate the path objects. Each instantiated path object is added to the pathPool list.

        // Populate the object pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject path = InstantiatePath();
            path.SetActive(true);
            pathPool.Add(path);
        }

        // Start spawning paths at regular intervals
        //line of code schedules the SpawnPath() method to be invoked repeatedly with a specified time interval 
        //starting from the beginning of the game.
        InvokeRepeating("SpawnPath", 0f, spawnInterval);
    }
    private GameObject InstantiatePath()
    {
        //This method instantiates a path object from the pathPrefabs array.
        //It selects the path prefab using the pathIndex, increments the pathIndex,
        //and wraps it around using the modulus operator (%) to ensure it stays within the array bounds.
        //The instantiated path object is positioned at (-3, 1, zPos),
        //and the zPos is incremented by 51.1f for the next path object.

        GameObject pathPrefab = pathPrefabs[pathIndex];
        GameObject path = Instantiate(pathPrefab, new Vector3(-3, 1, zPos), Quaternion.identity);
        pathIndex = (pathIndex + 1) % pathPrefabs.Length;
        zPos += 50.5f/*51.1f*/;
        return path;
    }
    private void SpawnPath()
    {
        //This method is called at regular intervals. It searches for an inactive path in the object pool.
        //If an inactive path is found, it is repositioned to (-3, 1, zPos), activated,
        //and zPos is incremented for the next path. If no inactive path is available,
        //the oldest path in the pool is deactivated, repositioned, and reactivated.
        //The oldest path is then moved to the end of the pathPool list to maintain the order.

        // Search for an inactive path in the pool
        foreach (GameObject path in pathPool)
        {
            if (!path.activeInHierarchy)
            {
                path.transform.position = new Vector3(-3, 1, zPos);
                path.SetActive(true);
                zPos += 50.5f;
                return;
            }
        }

        // If no inactive path is found, deactivate the oldest path and reuse it
        GameObject oldestPath = pathPool[0];
        oldestPath.transform.position = new Vector3(-3, 1, zPos);
        oldestPath.SetActive(true);
        zPos += 50.5f;

        // Move the oldest path to the end of the pool (to maintain order)
        pathPool.RemoveAt(0);
        pathPool.Add(oldestPath);
    }
}