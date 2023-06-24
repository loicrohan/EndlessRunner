using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuFunction : MonoBehaviour
{
    public GameObject _mainMenu;
    public GameObject _instruction;
    public Text highScoreText;
    public Text highDistText;
    void Start()
    {
        highScoreText.text = "x " + PlayerPrefs.GetInt("HighScore", 0);
        highDistText.text = "x " + PlayerPrefs.GetInt("HighDistance") + "m";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ClickOnInstruction()
    {
        _mainMenu.SetActive(false);
        _instruction.SetActive(true);
    }

    public void ClickOnBack()
    {
        _mainMenu.SetActive(true);
        _instruction.SetActive(false);
    }
    public void ClickOnQuit()
    {
        Application.Quit();
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "x 0";
        PlayerPrefs.DeleteKey("HighDistance");
        highDistText.text = "x 0m";
    }
}