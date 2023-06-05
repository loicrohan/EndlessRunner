using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10, leftRightSpeed = 6;
    public bool isJumping = false, comingDown = false;
    public GameObject playerObject;
    static public bool canMove = false;
    public AudioSource coinFX, jumpFX;
    public void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelManager.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelManager.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    jumpFX.Play();
                    playerObject.GetComponent<Animator>().Play("Jump");                 
                    StartCoroutine(JumpSequence());
                }
            }
            if (isJumping == true)
            {
                if (comingDown == false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
                }
                if (comingDown == true)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * 4.05f, Space.World);
                }
            }
        }
    }
    IEnumerator JumpSequence()
    {
        float initialHeight = transform.position.y;
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Points")
        {
            coinFX.Play();
            ScoreManager.instance.UpdateCoin();
            Destroy(other.gameObject);
        }
    }
}