using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidInteract : Interactable
{
    private bool knowsSubject;
    GameObject GUI;

    private void Awake()
    {
        GUI = GameObject.FindGameObjectWithTag("GUI");

    }

    public override void Interact()
    {
        if (!knowsSubject)
        {   
            dialogue = new Dialogue("Kid", "Dr Fischer says the password is 2526. Go find out who the subject is.");
            TriggerDialogue();
        }
        else
        {   
            //dialogue = new Dialogue("Kid", "So the subject was Monty Key?");
            //TriggerDialogue();
            // cue monty grabbing Kid 
            // activate elevator
            GameObject.Find("elevator").GetComponent<ElevatorInteract>().letLeave();

            // kidnapped by monty
            GUI.transform.GetChild(5).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void knowsSubjectIdentity()
    {
        knowsSubject = true;
    }
}
