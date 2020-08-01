using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ComputerInteract : Interactable
{
    public GameObject computerScreen;

    public override void Interact()
    { 
        if (GameObject.FindGameObjectWithTag("Computer") == null)
        {
            Vector2 pos = new Vector2(0, 0);
            Instantiate(computerScreen, pos, Quaternion.identity);

            //stop player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Computer"));

            //allowing player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
        }
    }
}

