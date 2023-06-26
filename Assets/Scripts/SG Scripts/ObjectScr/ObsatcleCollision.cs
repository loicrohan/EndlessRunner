using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsatcleCollision : MonoBehaviour
{
    public GameObject thePlayer, charModel, mainCam, levelControl;
    public AudioSource crashThud;
    void Start()
    {
        levelControl.GetComponent<PoolingManager>().enabled = true;
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
        levelControl.GetComponent<PoolingManager>().CancelInvoke();
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}