using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -6.95f;
    public static float rightSide = 6.65f;
    public float internalLeft;
    public float internalRight;
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}