using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX,clickFX;

    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFX);
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
}