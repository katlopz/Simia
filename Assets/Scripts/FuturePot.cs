using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuturePot : MonoBehaviour
{
    public GameObject grownPlant;
    public Sprite vibrantPlant;

    bool dead;

    public void Start()
    {
        dead = true;
    }

    public void Update()
    {
        if (dead) return;

        Vector3 plantPos = GameObject.FindGameObjectWithTag("FuturePot").transform.position;
        plantPos.x = transform.position.x + (float)0.07;

        GameObject.FindGameObjectWithTag("FuturePot").transform.position = plantPos; 
    }

    public void grow()
    {
        dead = false;
        Debug.Log("GROW");

        float x = transform.position.x + (float)0.07;
        float y = (GameObject.FindGameObjectWithTag("Future").transform.position.y) + (float)3.25; ;
        Vector2 plantPos = new Vector2(x, y);

        Instantiate(grownPlant, plantPos, Quaternion.identity);

        //get rid of old pot
        GameObject deadP = GameObject.FindGameObjectWithTag("DeadPlant");
        deadP.SetActive(false);

        //make plant vibrant
        this.GetComponent<SpriteRenderer>().sprite = vibrantPlant;
    }
}
