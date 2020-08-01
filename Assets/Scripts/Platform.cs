using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float enableTimer = 0;
    private float enableTimerLimit = 0.2f;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            GetComponent<EdgeCollider2D>().enabled = false;     
            enableTimer = enableTimerLimit;
        }

        enableTimer -= Time.deltaTime;
		if(enableTimer < 0){
            GetComponent<EdgeCollider2D>().enabled = true;
		}
        
    }
}
