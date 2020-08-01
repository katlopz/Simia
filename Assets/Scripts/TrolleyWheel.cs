using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class TrolleyWheel : Interactable
{
    private bool combineable = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Wheel"))
            combineable = true;
        else
            combineable = false;
    }

    public override void Interact()
    {
        if(GameObject.Find("Player").GetComponent<Inventory>().checkFor("Trolley Wheel Button")){
            transform.parent.GetComponent<Animator>().SetBool("fixed", true);
            GameObject.Find("Player").GetComponent<Inventory>().removeSlot("Trolley Wheel Button");
            //GameObject.FindGameObjectWithTag("Wheel").SetActive(false);   
            transform.parent.GetComponent<Trolley>().trolleyFixed();
        }
    }
}
