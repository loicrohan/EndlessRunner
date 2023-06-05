using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3, countDown2, countDown1, countDownGO, fadeIn;
    void Start()
    {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownGO.SetActive(true);
        PlayerMove.canMove = true;
    }
}