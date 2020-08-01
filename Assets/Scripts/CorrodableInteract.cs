using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CorrodableInteract : Interactable
{
    public GameObject CorrodableTrigger; //the object in past, acid or whatever dropped
    public GameObject CorrodableFloorFuture; //the floor that will corrode in future

    public Sprite untouched;
    public Sprite touched;
    private SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender = CorrodableTrigger.GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        if (CorrodableTrigger == null)
        {

            //stop player moving

        }
        else
        {
            if (GameObject.Find("Player").GetComponent<Inventory>().checkFor("chemGreenButton"))
            {
                //do everything
                GameObject.Find("Player").GetComponent<Inventory>().removeSlot("chemGreenButton");
                // if () {
                //do animation

                Destroy(CorrodableFloorFuture);
                // };
                spriteRender.sprite = touched;
            }
        }
    }
}