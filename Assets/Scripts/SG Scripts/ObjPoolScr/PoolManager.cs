using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private int poolSize;
    private List<GameObject> pathPool;
    private static PoolManager instance;
    private void Awake()
    {
        makeSingleton();
        initPool();
    }
    void makeSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void initPool()
    {
        pathPool= new List<GameObject>();
        for (var i=0; i<poolSize; i++)
        {
            GameObject newPath = Instantiate(pathPrefab);
            pathPool.Add(newPath);
            newPath.SetActive(false);
        }
    }
    public GameObject getObjFromPool(Vector3 targetPos,Quaternion rotation)
    {
        GameObject gObj = pathPool[pathPool.Count-1];
        gObj.SetActive(true);
        gObj.transform.position = targetPos;
        gObj.transform.rotation = rotation;
        pathPool.Remove(gObj);
        return gObj;
    }
    public void returnObjToPool(GameObject g)
    {
        pathPool.Add(g);
        g.SetActive(false);
    }
}