using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : Interactable
{
    public GameObject FutureAirVent;
    private bool dissolved = false;

    public override void Interact()
    {
        //if acid in inventory, dissolved = true; remove from inventory;

        //if already dissolved, put acid back in inventory; dissolved = false;

        if(dissolved) 
        {
            Destroy(FutureAirVent);
        }
        else 
        {
            Instantiate(FutureAirVent);
        }
    }
}
