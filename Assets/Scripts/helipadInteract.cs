using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class helipadInteract : Interactable
{
    public GameObject helipadDraw;

    public override void Interact()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().checkFor("spraycanButton")) return;

        if (GameObject.FindGameObjectWithTag("Helipad") == null)
        {
            Vector2 pos = new Vector2(0, 0);
            Instantiate(helipadDraw, pos, Quaternion.identity);

            //stop player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Helipad"));

            //allowing player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().removeSlot("spraycanButton");
        }
    }
}
