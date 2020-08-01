using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKeyHanging : MonoBehaviour
{
    private GameObject player;
    private bool isKicking = false;
    int kickHash = Animator.StringToHash("Kick");



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //start on hanging animation
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (!isKicking && distance <6.5f)
        {
            //GetComponent<Animator>().SetTrigger("PunchT");
            //cue the kick animation
            isKicking = true;
            StartCoroutine(MKeyKick());
            GetComponent<Animator>().SetTrigger(kickHash);
        }
    }
    

    IEnumerator MKeyKick()
    {
        yield return new WaitForSeconds(0.3f);
        player.transform.GetComponent<PlayerRemote>().hitLeftCutsceneStartNow = true;
        //Debug.Log(player.transform.GetComponent<PlayerRemote>());
        isKicking = false;

        //move back to normal sprite
    }
}
