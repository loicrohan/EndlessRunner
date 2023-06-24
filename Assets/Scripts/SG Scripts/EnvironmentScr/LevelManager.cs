using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static float leftSide = -6.95f, rightSide = 6.65f;
    public float internalLeft, internalRight;
    public GameObject countDown3, countDown2, countDown1, countDownGO, fadeIn,currentScoreText;
    public AudioSource readyFX, goFX;
    public LevelDistance levelDist;
    //public PoolingManager PoolM;
    void Start()
    {
        currentScoreText.GetComponent<Text>().enabled = false;
        PlayerMove.canMove = false;
        levelDist.GetComponent<LevelDistance>().enabled = false;
        //PoolM.GetComponent<PoolingManager>().enabled = false;
        StartCoroutine(CountSequence());
    }
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDownGO.SetActive(true);
        goFX.Play();
        PlayerMove.canMove = true;
        Invoke("activateScore", 0.5f);
    }
    public void activateScore()
    {
        levelDist.GetComponent<LevelDistance>().enabled = true;
        currentScoreText.GetComponent<Text>().enabled = true;
        //PoolM.GetComponent<PoolingManager>().enabled = true;
    }
}