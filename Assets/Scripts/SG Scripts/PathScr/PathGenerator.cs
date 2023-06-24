using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs;
    public int poolSize = 20;
    public float zPos = 115.5f;
    public float spawnInterval = 2f;

    private List<GameObject> pathPool;
    private int pathIndex = 0;

    private void Start()
    {
        pathPool = new List<GameObject>();

        // Populate the object pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject path = InstantiatePath();
            path.SetActive(true);
            pathPool.Add(path);
        }

        // Start spawning paths at regular intervals
        InvokeRepeating("SpawnPath", 0f, spawnInterval);
    }

    private GameObject InstantiatePath()
    {
        GameObject pathPrefab = pathPrefabs[pathIndex];
        GameObject path = Instantiate(pathPrefab, new Vector3(-3, 1, zPos), Quaternion.identity);
        pathIndex = (pathIndex + 1) % pathPrefabs.Length;
        zPos += 51.1f;
        return path;
    }

    private void SpawnPath()
    {
        // Search for an inactive path in the pool
        foreach (GameObject path in pathPool)
        {
            if (!path.activeInHierarchy)
            {
                path.transform.position = new Vector3(-3, 1, zPos);
                path.SetActive(true);
                zPos += 51.1f;
                return;
            }
        }

        // If no inactive path is found, instantiate a new one
        GameObject newPath = InstantiatePath();
        newPath.SetActive(true);
        pathPool.Add(newPath);
    }
}