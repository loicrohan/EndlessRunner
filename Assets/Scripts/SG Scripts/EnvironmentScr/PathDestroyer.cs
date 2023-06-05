using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDestroyer : MonoBehaviour
{
    public static PathDestroyer instance;
    private string parentName;
    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }
    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(30);
        if (parentName == "Path(Clone)")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        else if (parentName == "Path1(Clone)")
        {
            gameObject.SetActive(false);
        }
        else if (parentName == "Path2(Clone)")
        {
            gameObject.SetActive(false);
        }
        else if (parentName == "Path3(Clone)")
        {
            gameObject.SetActive(false);
        }
        else if (parentName == "Path4(Clone)")
        {
            gameObject.SetActive(false);
        }
    }
}