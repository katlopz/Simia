using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKeyFalling : MonoBehaviour
{
    Vector2 acceleration;
    Vector2 velocity;
    private bool falling;

    // Start is called before the first frame update
    void Start()
    {
        acceleration.Set(0,-0.01f);
        velocity.Set(0,0);
        falling = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localPosition.y<-25 && falling)
        {
            //change the velocity (and acceleration)
            velocity.Set(0.1f, 1.2f);
            falling = false;
        }
        if (transform.localPosition.x > 60 | transform.localPosition.y > 10)
        {
            Destroy(gameObject);
        }

        Debug.Log(velocity.x+", "+velocity.y);

        //update velocity
        Vector2 mVel = velocity;
        velocity.Set(mVel.x + acceleration.x, mVel.y + acceleration.y);

        // update pos
        Vector3 mPos = transform.localPosition;
        float newX = mPos.x + velocity.x;
        float newY = mPos.y + velocity.y;
        transform.position = new Vector3(newX, newY, 0);
    }
}
