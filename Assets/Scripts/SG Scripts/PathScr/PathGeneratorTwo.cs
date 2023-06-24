using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGeneratorTwo : MonoBehaviour
{
    public PoolManagerTwo poolManagerTwo;
    public float spawnInterval = 2f;

    private float timer = 0f;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnPath();
            timer = spawnInterval;
        }
    }

    private void SpawnPath()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        GameObject pathObj = poolManagerTwo.GetObjFromPool(spawnPos, spawnRotation);
        // Additional customization of the path object (if needed)
    }
}