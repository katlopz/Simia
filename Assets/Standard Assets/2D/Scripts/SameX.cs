using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameX : MonoBehaviour
{
    public GameObject connected;

    // Update is called once per frame
    void Update()
    {
        Vector3 thePos = connected.transform.localPosition;
        thePos.x += transform.localPosition.x-connected.transform.localPosition.x;
        connected.transform.localPosition = thePos;
    }
}
