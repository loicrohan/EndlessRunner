using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCamera2 : MonoBehaviour
{
    public Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }


    void Update()
    {
        moveVector = lookAt.position + startOffset;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 0, 3);
        transform.position = moveVector;
    }
}
