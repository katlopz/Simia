using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetBlocked : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        transform.GetChild(0).gameObject.SetActive(false);    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        transform.GetChild(0).gameObject.SetActive(true);    
    }
}
