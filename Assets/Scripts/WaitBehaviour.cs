using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaitBehaviour : MonoBehaviour
{
    /** Use:
     *  Import the script object, e.g. WaitBehaviour w;
     *   w.Wait(time, () => {
                Debug.Log("5 seconds is lost forever");
                //do stuff
            });
     **/
    public void Wait(float seconds, Action action)
    {
        StartCoroutine(_wait(seconds, action));
    }
    IEnumerator _wait(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }
}
