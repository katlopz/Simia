using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTower : Interactable
{
    private bool combineable = false;
    public GameObject fallenTower;

    //public GameObject unconciousMonty;


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Wrench"))
            combineable = true;
        else
            combineable = false;
    }

    public override void Interact()
    {
        /*
        if (combineable)
        {
            Debug.Log("Pag");
            GameObject.FindGameObjectWithTag("Wrench").SetActive(false);
            // do stuff here when you combine the wrench with the water tower
        }
        */
        if (GameObject.Find("Player").GetComponent<Inventory>().checkFor("wrenchButton"))
        {
            GameObject.Find("Player").GetComponent<Inventory>().removeSlot("wrenchButton");
            Destroy(GameObject.Find("M_Key_hanging"));
            Destroy(GameObject.Find("water_tower_future"));

            //instantiate fallen tower
            Vector2 pos = new Vector2(63.72f, -2.41f);
            Instantiate(fallenTower, pos, Quaternion.identity);
            GameObject.Find("watertower_future(Clone)").transform.eulerAngles = new Vector3(0,0,-81.6f);
        }

    }
}
