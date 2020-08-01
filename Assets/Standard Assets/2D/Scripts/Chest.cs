using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets._2D;
public class Chest : Interactable
{
    public GameObject rippedPage;
    public GameObject fixedPage;
    bool opened = false;
    public Sprite openSprite;

    public override void Interact()
    {
        if (opened) return;
        opened = true;
        //give player new journal page

        fixedPage.SetActive(true);
        rippedPage.SetActive(false);

        this.GetComponent<SpriteRenderer>().sprite = openSprite;
    }
}
