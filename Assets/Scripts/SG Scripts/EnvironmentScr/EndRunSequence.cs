using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins, liveDist, endScreen, fadeOut,pauseIcon;
    void Start()
    {
        StartCoroutine(EndSequence());
    }
    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(5);
        pauseIcon.SetActive(false);
        liveCoins.SetActive(false);
        liveDist.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}