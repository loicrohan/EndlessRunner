using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CubeMove2 : MonoBehaviour
{
    public float speed = 7.0f;
    private CharacterController myCharCtrl;
    private float Ymin = -5f;
    [SerializeField]
    private int Respawn = 1;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        myCharCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        moveVector = Vector3.zero;

        if (myCharCtrl.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        Boundary();
        myCharCtrl.Move(moveVector * Time.deltaTime);

    }

    void Boundary()
    {
        if (transform.position.y < Ymin)
        {
            SceneManager.LoadScene(Respawn);
            //transform.position = new Vector3(Xmax, Ymax, Zmax);
        }
    }
}