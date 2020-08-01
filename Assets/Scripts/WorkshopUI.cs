using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WorkshopUI : MonoBehaviour
{
    private Inventory inventory;
    public Sprite clear; // clear sprite
    public Sprite blue; // blue sprite
    public Sprite yellow; // yellow sprite
    public Sprite green; // green sprite
    private Image img;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<Inventory>();
        img = gameObject.GetComponent<Image>();
    }

    public void changeSprite(string color)
    {
        if (string.Equals(color, "green"))
        {
            img.overrideSprite = green;
        }
        else if (string.Equals(color, "blue"))
        {
            img.overrideSprite = blue;
        }
        else if (string.Equals(color, "yellow"))
        {
            img.overrideSprite = yellow;
        }
        else 
        {
            img.overrideSprite = clear;
        }
    }
}
