using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class KeydoorInteract : Interactable
{
    public GameObject Keypad;

    public override void Interact()
    {
        if (GameObject.FindGameObjectWithTag("Keypad") == null)
        {
            Vector2 pos = new Vector2(0, 0);
            Instantiate(Keypad, pos, Quaternion.identity);
            // Show TextBox to display keycode
            FindObjectOfType<DialogueManager>().animator.SetBool("active", true);
            //stop player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Keypad"));
            // Hide TextBox
            FindObjectOfType<DialogueManager>().animator.SetBool("active", false);
            //allowing player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
        }
    }
}
