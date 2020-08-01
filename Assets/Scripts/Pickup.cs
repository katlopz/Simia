using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Pickup : MonoBehaviour
{
    public GameObject itemButton;
    private Inventory inventory;
    private Animator playerAnim;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    
    void OnTriggerStay2D(Collider2D other)
    {   
        if (other.CompareTag("Player"))
        {
        //p
        Platformer2DUserControl player = other.GetComponent<Platformer2DUserControl>();
        if(player != null && player.isPickingUp == true)
        {            
            player.enabled = false;
            //StartCoroutine(AddItemDelay());
        //p
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                
                if(inventory.isFull[i] == false)
                {
                    playerAnim.SetTrigger("Pickup");
                    //ITEM CAN BE ADDED TO INVENTORY
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    //itemButton added to slot for reference
                    inventory.slots[i].GetComponent<Slot>().setButton(itemButton);

                    Destroy(gameObject);

                    //detroy tree if necessary, could probably put this in a different script
                    //maybe added to seed and then called from here when picked up
                    if(gameObject.CompareTag("Seed"))
                    {
                        GameObject[] tree = GameObject.FindGameObjectsWithTag("Tree");
                        if(tree!=null)
                        {
                            for (int j = 0; j < tree.Length; j++)
                            {
                                Destroy(tree[j]);
                            }
                        }
                    }
                    player.enabled = true;
                    break;
                }
            }
        }
        }
    }

    IEnumerator AddItemDelay(){
        
           for (int i = 0; i < inventory.slots.Length; i++)
            {
                
                if(inventory.isFull[i] == false)
                {
                    yield return new WaitForSeconds(1f);
                    //ITEM CAN BE ADDED TO INVENTORY
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    //itemButton added to slot for reference
                    inventory.slots[i].GetComponent<Slot>().setButton(itemButton);

                    Destroy(gameObject);

                    //detroy tree if necessary, could probably put this in a different script
                    //maybe added to seed and then called from here when picked up
                    if(gameObject.CompareTag("Seed"))
                    {
                        GameObject[] tree = GameObject.FindGameObjectsWithTag("Tree");
                        if(tree!=null)
                        {
                            for (int j = 0; j < tree.Length; j++)
                            {
                                Destroy(tree[j]);
                            }
                        }
                    }
                    playerAnim.enabled = true;
                    break;
                }
            }
        
    }
}
