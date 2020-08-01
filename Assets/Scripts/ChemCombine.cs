using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemCombine : Interactable
{
    public GameObject yellowChem;
    private bool combineable = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Chemical"))
            combineable = true;
        else
            combineable = false;
        Debug.Log(other.tag);
    }

    public override void Interact()
    {
        if (!combineable) return;

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
        Instantiate(yellowChem, playerPos, Quaternion.identity);

        //get rid of blue and green ones
    }
}
