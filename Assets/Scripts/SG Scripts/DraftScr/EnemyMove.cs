using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance;
    public GameObject turtle, thePlayer, charModel, mainCam, levelControl;
    public AudioSource crashThud;

    private Vector3 leftPoint, rightPoint;

    private Vector3 currentTarget;
    private int direction = 1; // 1 -> right direction,-1 -> left direction

    void Start()
    {
        leftPoint= transform.position - new Vector3(maxDistance,0,0);
        rightPoint = transform.position + new Vector3(maxDistance, 0, 0);
    }

    void Update()
    {
        if(direction== 1 /*|| this.gameObject.transform.position.y > LevelManager.rightSide*/)
        {
            currentTarget = rightPoint;
            turtle.GetComponent<Animator>().Play("WalkRight");
        }
        else if (direction== -1 /*|| this.gameObject.transform.position.y > LevelManager.leftSide*/)
        {
            currentTarget = leftPoint;
            turtle.GetComponent<Animator>().Play("WalkLeft");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position,currentTarget) <= 0.01f)
        {
            direction *= -1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().StopAllCoroutines();
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        crashThud.Play();
        mainCam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<GeneratePath>().enabled = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
        //GameStatus.instance.ResetScore();
    }
}