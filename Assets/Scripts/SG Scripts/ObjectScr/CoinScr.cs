using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScr : MonoBehaviour
{
    public int rotateSpeed = 1;
    //public AudioSource coinFX;
    //private int score = 0;
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    score++;
    //    coinFX.Play();
    //    //CollectControl.coinCount += 1;
    //    ScoreManager.instance.UpdateCoin(1);
    //    ScoreManager.instance.currentScore.text = score.ToString();
    //    this.gameObject.SetActive(false);
    //}
}