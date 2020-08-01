using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    //reference to current item button in slot
    private GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public bool hasItem()
    {
        if (transform.childCount != 0) return true;
        return false;
    }

    public string getName()
    {
        return transform.GetChild(0).name;
    }

    public void destroyItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void setButton(GameObject button){
        itemButton = button;
    }

    public GameObject getButton(){
        return itemButton;
    }

    public int noOfChildren() {
        return transform.childCount;
    }
}
