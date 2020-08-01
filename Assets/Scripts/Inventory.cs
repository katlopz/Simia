using UnityEngine;
using UnityStandardAssets._2D;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots; 

    //p
    private void Update(){        
        Platformer2DUserControl p = GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer2DUserControl>();
        if(p != null && p.isDropping1 == true)
        {
            drop1();
            p.isDropping1 = false;        
        }
        if(p != null && p.isDropping2 == true)
        {
            drop2();
            p.isDropping2 = false;        
        }
        if(p != null && p.isDropping3 == true)
        {
            drop3();
            p.isDropping3 = false;        
        }
    }

    private void drop1(){
        if(slots[0] != null){
            Slot s1 = slots[0].GetComponent<Slot>();
            s1.DropItem();    
        }
    }
    
    private void drop2(){
        if(slots[1] != null){
            Slot s2 = slots[1].GetComponent<Slot>();
            s2.DropItem();    
        }
    }
    
    private void drop3(){
        if(slots[2] != null){
            Slot s3 = slots[2].GetComponent<Slot>();
            s3.DropItem();    
        }
    }
    //p

    //k
    public bool checkFor(string s)
    {
        for(int i = 0; i<slots.Length; i++)
        {
            if(slots[i].GetComponent<Slot>().hasItem())
            {
                Debug.Log(slots[i].GetComponent<Slot>().getName());
                if (slots[i].GetComponent<Slot>().getName().Equals(s+"(Clone)")) return true;
            }
        }
        return false;
    }

    public bool removeSlot(string s)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<Slot>().hasItem())
            {
                if (slots[i].GetComponent<Slot>().getName().Equals(s+"(Clone)")) 
                {
                    slots[i].GetComponent<Slot>().destroyItem();
                    return true;
                }
            }
        }
        return false;
    }
    //k

    public GameObject[] getSlots(){
        return slots;
    }

    public bool[] getFull(){
        return isFull;
    }
}
