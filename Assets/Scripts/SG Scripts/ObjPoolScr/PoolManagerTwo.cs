using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerTwo : MonoBehaviour
{
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private int poolSize;
    private List<GameObject> pathPool;
    private static PoolManagerTwo instance;

    private void Awake()
    {
        MakeSingleton();
        InitPool();
    }

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void InitPool()
    {
        pathPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newPath = Instantiate(pathPrefab);
            newPath.SetActive(false);
            pathPool.Add(newPath);
        }
    }

    public GameObject GetObjFromPool(Vector3 targetPos, Quaternion rotation)
    {
        if (pathPool.Count == 0)
        {
            Debug.LogWarning("Object pool is empty. Consider increasing the pool size.");
            return null;
        }

        GameObject gObj = pathPool[pathPool.Count - 1];
        gObj.SetActive(true);
        gObj.transform.position = targetPos;
        gObj.transform.rotation = rotation;
        pathPool.Remove(gObj);

        return gObj;
    }

    public void ReturnObjToPool(GameObject g)
    {
        g.SetActive(false);
        pathPool.Add(g);
    }
}
