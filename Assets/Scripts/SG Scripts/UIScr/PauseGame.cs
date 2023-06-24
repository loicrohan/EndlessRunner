using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void ClickOnPause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClickOnContinue()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
