using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class AcidPool : Interactable
{
    public GameObject unstableRoof;
    public GameObject emptyFlask;
    public GameObject acidFlask;

    void Start()
    {
        //put unstable roof on future side   
        if(GameObject.Find("Player").transform.localPosition.y < -25) {
            Vector2 poolPos = new Vector2(transform.localPosition.x, GameObject.Find("Future").transform.localPosition.y - 5.1f);
            Instantiate(unstableRoof, poolPos, Quaternion.identity);
        }
        
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
        Instantiate(emptyFlask, playerPos, Quaternion.identity);
    }

    public override void Interact()
    {
        //if player has empty flask, use it to get acid
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().checkFor("emptyFlaskButton"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().removeSlot("emptyFlaskButton");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
            Instantiate(acidFlask, playerPos, Quaternion.identity);

            GameObject.FindGameObjectWithTag("UnstableGround").SetActive(false);
            
            Destroy(gameObject);
            
            // how come it won't destroy when it's placed in future?
        }
        else
        {
            TriggerDialogue();
        }
    }
}
