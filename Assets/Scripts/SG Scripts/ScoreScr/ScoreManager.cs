using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text currentScore, currentScoreEnd;
    private int coinScore = 0, highCoin;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highCoin = PlayerPrefs.GetInt("HighScore", 0);
    }
    void Update()
    {
        CheckHighScore();
    }
    public void UpdateCoin()
    {
        coinScore++;
        currentScore.text = "x " + coinScore.ToString();
        currentScoreEnd.text = "x " + coinScore.ToString();
        Debug.Log("Score is ++");
    }

    public void CheckHighScore()
    {
        if (coinScore>highCoin)
        {
            highCoin = coinScore;
            PlayerPrefs.SetInt("HighScore", highCoin);
        }
    }
}