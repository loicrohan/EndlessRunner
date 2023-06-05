using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CubeMove : MonoBehaviour
{
    private bool turnLeft, turnRight;
    public float speed = 7.0f;
    private CharacterController myCharCtrl;
    private float Ymin = -5f;
    [SerializeField]
    private int Respawn = 0;
    //private float Ymax = 0.48f;
    //private float Xmax = 0;
    //private float Zmax = -11.2f;

    // Start is called before the first frame update
    void Start()
    {
        myCharCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));

        myCharCtrl.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharCtrl.Move(transform.forward * speed * Time.deltaTime);

        Boundary();
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
