using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject distDisplay, distEndDisplay;
    public int distRun,highDist;
    public bool addingDist = false;
    public float distDelay = 0.35f;

    void Start()
    {
        highDist = PlayerPrefs.GetInt("HighDistance", 0);
    }
    void Update()
    {
        if(addingDist == false)
        {
            addingDist = true;
            StartCoroutine(AddingDist());
        }
        CheckHighDistance();
    }
    IEnumerator AddingDist()
    {
        distRun += 1;
        distDisplay.GetComponent<Text>().text = "x " + distRun + "m ";
        distEndDisplay.GetComponent<Text>().text = "x " + distRun + "m ";
        yield return new WaitForSeconds(distDelay);
        addingDist = false;
    }

    public void CheckHighDistance()
    {
        if (distRun > highDist)
        {
            highDist = distRun;
            PlayerPrefs.SetInt("HighDistance", highDist);
        }
    }
}