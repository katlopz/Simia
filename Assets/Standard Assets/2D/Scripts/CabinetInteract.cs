using UnityEngine;
using UnityStandardAssets._2D;

public class CabinetInteract : Interactable
{
    public GameObject Documents;

    public override void Interact()
    {
        if(GameObject.FindGameObjectWithTag("Documents") == null)
        {
            Vector2 pos = new Vector2(0, 0);
            Instantiate(Documents, pos, Quaternion.identity);

            //stop player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Documents"));

            //allowing player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
        }
        
    }
}
