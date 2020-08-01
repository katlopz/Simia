using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingInteract : Interactable
{
    public GameObject endscreen;
    public override void Interact()
    {
        string[] lines = { "You don't have to do this!", "I figured out the cure!", "Hey Monicka!"," Thanks for the coffee, it really helped"};
        dialogue = new Dialogue("Alan", lines);
        TriggerDialogue();

        StartCoroutine(End());
    }


    IEnumerator End()
    {
        yield return new WaitForSeconds(10f);
        endscreen.SetActive(true);
            }
    }
