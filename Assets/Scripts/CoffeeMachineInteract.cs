using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineInteract : Interactable
{
    public Sprite fixedMachine;
    public GameObject coffee;

    bool broken = true;
    bool coffeeTaken = false;

    public override void Interact()
    {
        Debug.Log("INTERACTING");
        if(broken)
        {
            this.GetComponent<SpriteRenderer>().sprite = fixedMachine;
            broken = false;
        }
        else if(!broken && !coffeeTaken)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
            Instantiate(coffee, playerPos, Quaternion.identity);
            coffeeTaken = true;
        }
    }
}
