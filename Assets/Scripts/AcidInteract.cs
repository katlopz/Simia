using UnityEngine;

public class AcidInteract : Interactable
{
    public GameObject acidFlask;

    public override void Interact()
    {
        //if player has empty flask, use it to get acid
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().checkFor("emptyFlaskButton"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().removeSlot("emptyFlaskButton");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 playerPos = new Vector2(player.position.x, player.position.y - 1.1f);
            Instantiate(acidFlask, playerPos, Quaternion.identity);
        }
        else
        {
            TriggerDialogue();
        }
    }
}
