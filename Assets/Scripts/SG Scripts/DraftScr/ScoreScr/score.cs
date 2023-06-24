using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public void Update()
    {
        GameObject go = GameObject.Find("GameStatus");

        if (go == null)
        {
            Debug.LogError("Failed to detect object named 'GameStatus' ");
            this.enabled = false;
            return;
        }

        GameStatus gs = go.GetComponent<GameStatus>();

        GetComponent<Text>().text = "x " + gs.GetScore();


        GetComponent<Text>().text = "x " + GameStatus.GetInstance().GetScore();

        GameStatus.instance.ResetScore();

    }
}