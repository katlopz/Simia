using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopBehaviour : MonoBehaviour {
    private Inventory inventory;
    public WorkshopInteractable workbench;
    public WorkshopUI panel;
    public GameObject benchSlot1;
    public GameObject benchSlot2;
    public GameObject benchSlot3;
    int createdOne;
    int createdTwo;
    int createdThree;
    private GameObject[] slots;
    private bool[] full;

    // Start is called before the first frame update
    void Start () {
        inventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<Inventory> ();
        slots = CopyItems();
        full = CopyFulls();
        createdOne = 0;
        createdTwo = 0;
        createdThree = 0;

    }

    // Update is called once per frame
    void Update () {
        checkOpen(); //checks the status of the workbench

        if (workbench.getStatus()){
            
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                panel.changeSprite("blue");
            }
        }
    }

    private void checkOpen () {
        if (workbench.getStatus()) {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            slots = CopyItems();
            full = CopyFulls();

            if (full[0]) {
                Slot s1 = slots[0].GetComponent<Slot> ();
                if (createdOne == 0) {
                    Instantiate(s1.getButton(), benchSlot1.transform, false);
                    createdOne ++;
                }
            }

            if (full[1]) {
                Slot s2 = slots[1].GetComponent<Slot>();
                if (createdTwo == 0) {
                    Instantiate(s2.getButton(), benchSlot2.transform, false);
                    createdTwo ++;
                }
            }

            if (full[2]) {
                Slot s3 = slots[2].GetComponent<Slot>();
                if (createdThree == 0) {
                    Instantiate(s3.getButton(), benchSlot3.transform, false);
                    createdThree ++;
                }
            }
        } else 
        {
            Clear();
        }
    }
    public void Clear () {
        if (full[0]) {
            //Destroy(slots[0]);
        }
        if (full[1]) {

        }
        if (full[2]) {

        }
       
        slots = new GameObject[3];
        createdOne = 0;
        createdTwo = 0;
        createdThree = 0;
    }

    public GameObject[] CopyItems () {
        //copy current inventory slots
        return inventory.getSlots();
    }

    public bool[] CopyFulls () {
        //copy current inventory slots
        return inventory.getFull();
    }


}