using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class DoorInteract : Interactable
{
    public AudioClip FloorBreakClip;
    public AudioSource SoundSource;

    public override void Interact()
    {
        Debug.Log("teleporting");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 thePos = player.transform.localPosition;

        //teleport to lab
        if (System.Math.Abs(thePos.x - 63.8) < 1 && System.Math.Abs(thePos.y - 12.1) < 1)
        {
            thePos.x = 170.74f;
            thePos.y = 6.45f;
            player.transform.localPosition = thePos;
        }

        SoundSource.clip = FloorBreakClip;
        SoundSource.Play();

        TriggerDialogue();
    }
}
