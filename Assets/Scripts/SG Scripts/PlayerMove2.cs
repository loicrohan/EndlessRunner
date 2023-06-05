using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpForce = 5f;
    [SerializeField]
    private CharacterController myCharCtrl;
    private Vector3 moveVector;
    //private float verticalVelocity = 0.0f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private Animator anim;
    //[SerializeField]
    //private bool canJump = false;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private Transform groundCheckPoint;
    public float checkRadius;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myCharCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, checkRadius, _groundLayer);

        if (isGrounded && moveVector.y <= 0)
        {
            moveVector.y = -2f;
        }

        //moveVector = Vector3.zero;

        //if (myCharCtrl.isGrounded)
        //{
        //    verticalVelocity = -0.5f;
        //}
        //else
        //{
        //    verticalVelocity -= gravity * Time.deltaTime;
        //}

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //moveVector.y = verticalVelocity;
        moveVector.z = speed;
        myCharCtrl.Move(moveVector * Time.deltaTime);

        moveVector.y += gravity * Time.deltaTime;

        //canJump = Physics.OverlapSphere(groundCheckPoint.position, 0.5f, _groundLayer).Length > 0;

        if ( isGrounded && Input.GetKeyDown(KeyCode.Space) /*&& canJump*/)
        {
            //verticalVelocity = jumpForce;
            anim.SetTrigger("Jump");
            moveVector.y = Mathf.Sqrt(gravity * -2f * jumpForce);
        }
    }
}