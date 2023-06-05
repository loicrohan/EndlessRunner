using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCam : MonoBehaviour
{
    //   Note you can add a xFocus and a yFocus if you want the camera to follow x and y directions
    //   but for now it will only follow in the z axis.
    private float zFocus;         
    public float xCameraAdjust;
    public float yCameraAdjust;
    public float zCameraAdjust;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zFocus = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        this.transform.position = new Vector3(xCameraAdjust, yCameraAdjust, zFocus + zCameraAdjust);
    }
}
