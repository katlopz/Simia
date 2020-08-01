using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanInteract : Interactable
{
    public GameObject gift;

    private bool awake;

    public override void Interact()
    {
        if(!awake)
        {
            //if player has coffee, intiate dialogue and get key 
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().checkFor("coffeeButton"))
            {
                //displayText("Do you want this key?");
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().removeSlot("coffeeButton");
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
                Instantiate(gift, playerPos, Quaternion.identity);
                awake = true;
                GetComponent<Animator>().SetTrigger("wakeUp");
            }
            else
            {   
                dialogue = new Dialogue("Alan", "ZZZZZzzzzz...");
                TriggerDialogue();
            }
        }
        else
        {
            dialogue = new Dialogue("Alan", "Thanks for the coffee! I think I've finally reached a breakthrough!");
            TriggerDialogue();
        }
    }
}
