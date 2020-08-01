using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    public GameObject blueChem;
    bool opened = false;
    public Sprite openSprite;

    public override void Interact()
    {
        if (opened) return;
        opened = true;
        //give player new journal page

        //drop blue chem
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
        Instantiate(blueChem, playerPos, Quaternion.identity);

        this.GetComponent<SpriteRenderer>().sprite = openSprite;
    }
}
