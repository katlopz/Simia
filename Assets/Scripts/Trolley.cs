using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolley : MonoBehaviour
{
    private Animator trolleyAnimator;
    private Rigidbody2D trolleyRigidbody;
    private GameObject player;
    private CircleCollider2D collisionObj;
    private bool trolleyBroken = true;
    // Start is called before the first frame update
    void Start()
    {
        trolleyAnimator = GetComponent<Animator>();
        trolleyRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        collisionObj = transform.GetChild(0).GetComponent<CircleCollider2D>();
        trolleyRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {   
        if(trolleyBroken)
            return;
        //this is to prevent the player from grabbing on to the trolley from the wrong side
        if(player.transform.position.x > transform.position.x)
            collisionObj.enabled = false;
        else
            collisionObj.enabled = true;
        
        trolleyAnimator.SetFloat("speed", trolleyRigidbody.velocity.magnitude);
    }

    public void trolleyFixed()
    {
        trolleyBroken = false;
        trolleyRigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
}
