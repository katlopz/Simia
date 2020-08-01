using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        transform.GetChild(0).gameObject.SetActive(false);    
    }
}
