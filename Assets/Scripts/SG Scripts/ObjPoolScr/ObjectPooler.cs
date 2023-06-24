using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] prefab;
    public int poolSize = 10;
    public float zPos = 115.5f;

    private List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab[poolSize], new Vector3(-3, 1, zPos), Quaternion.identity);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // Search for an inactive object in the pool
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // If no inactive object is found, create a new one and add it to the pool
        GameObject obj = Instantiate(prefab[poolSize], new Vector3(-3, 1, zPos), Quaternion.identity);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
    }
}