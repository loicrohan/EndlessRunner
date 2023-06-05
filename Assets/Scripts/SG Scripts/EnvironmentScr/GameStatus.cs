using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instance;
    //public static int score;
    protected int score = 0, HighScore;
    public static GameStatus GetInstance()
    {
        return instance;
    }

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        //HighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (instance != null)
        {
            // Someone ELSE is the singleton already.
            // So let's just destroy ourselves before we cause trouble.
            Destroy(this.gameObject);
            return;
        }

        // If we get here, the we are "the one". Let's act like it.
        instance = this;    // We are a Highlander
        GameObject.DontDestroyOnLoad(this.gameObject);	// Become immortal
    }
    void Update()
    {

    }
    void OnDestroy()
    {
        Debug.Log("GameStatus Destroyed");
        PlayerPrefs.SetInt("score", score);
        //PlayerPrefs.SetInt("HighScore", HighScore);
    }
    public void AddScore()
    {
        score += 1;
        //updateHighScore();
    }
    //public void updateHighScore()
    //{
    //    if (score > PlayerPrefs.GetInt("HighScore", 0))
    //    {
    //        HighScore = score;
    //        PlayerPrefs.SetInt("HighScore", HighScore);
    //    }
    //}
    public void ResetScore()
    {
        //PlayerPrefs.GetInt("score", 0);
        score = 0;
    }
    public int GetScore()
    {
        return score;
    }
}