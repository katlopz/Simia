using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class BackUpFromCamera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerRemote player = other.transform.gameObject.GetComponentInParent<PlayerRemote>();
            player.cameraCutsceneStartNow = true;
        }
    }
}
