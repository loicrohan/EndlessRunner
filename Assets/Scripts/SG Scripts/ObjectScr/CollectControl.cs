using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay, coinEndDisplay;
    void Update()
    {
        //coinCountDisplay.GetComponent<Text>().text = "x " + coinCount;
        //coinEndDisplay.GetComponent<Text>().text = "x " + coinCount;
    }
}