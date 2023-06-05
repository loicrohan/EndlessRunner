using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePath : MonoBehaviour
{
    public GameObject[] path;
    public float zPos = 115.5f;
    public bool creatingSection = false;
    public int pathNum;
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        pathNum = Random.Range(0, 5);
        Instantiate(path[pathNum], new Vector3(-3, 1, zPos), Quaternion.identity);
        zPos += 51.1f;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}