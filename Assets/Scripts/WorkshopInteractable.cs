using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class WorkshopInteractable : Interactable {

    public static bool isWorkshopOn = false;
    public GameObject workshopMenu;

    public override void Interact () {
        //open the ui 
        if (!isWorkshopOn) {
            isWorkshopOn = true;
            GameObject.Find("Player").GetComponent<PlatformerCharacter2D>().GroundPlayer();
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
            BringUpWorkshop();
            
        } else {
            isWorkshopOn = false;
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
            PutDownWorkshop();
        }
    }

    public void BringUpWorkshop() {
        workshopMenu.SetActive(true);
    }

    public void PutDownWorkshop() {
        workshopMenu.SetActive(false);
    }

    public bool getStatus() {
        return isWorkshopOn;
    }
}