using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagInteract : Interactable
{
    public GameObject Kid;
    public Sprite notSad;
    private bool hasGift;

    public override void Interact()
    {
        if (!hasGift)
        {
            //if player has necklace
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().checkFor("keyButton"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().removeSlot("keyButton");
                hasGift = true;
                GameObject.FindGameObjectWithTag("Billy").GetComponent<SpriteRenderer>().sprite = notSad;

                // spawn Kid in future
                Vector2 kidPos = new Vector2(15.55f, 7.55f);
                Instantiate(Kid, kidPos, Quaternion.identity);
            }
            else
            {
                dialogue = new Dialogue("Monica", "Who's bag is this?");
                TriggerDialogue();
            }
        }
        else
        {
            dialogue = new Dialogue("Billy", "Thanks for dropping off my gift");
            TriggerDialogue();
        }
    }
}
