using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlantGrowth : Interactable
{
    private bool combineable = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PlantGrowth"))
            combineable = true;
        else
            combineable = false; 
    }

    public override void Interact()
    {
        if (GameObject.Find("Player").GetComponent<Inventory>().checkFor("plant_growth Button"))
        {
            GameObject.Find("Player").GetComponent<Inventory>().removeSlot("plant_growth Button");
            //GameObject.FindGameObjectWithTag("PlantGrowth").SetActive(false);
            transform.parent.GetComponent<FuturePot>().grow();
        }
    }
}
