using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class kidnap : MonoBehaviour
{
    private bool played = false;
    GameObject player;
    Animator animator;
    Platformer2DUserControl userControls;

    private void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player");
        userControls = player.GetComponent<Platformer2DUserControl>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!played)
        StartCoroutine(PlayLvl2Kidnap());
    }

    IEnumerator PlayLvl2Kidnap()
    {
        played = true;
        userControls.enabled = false;
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("cut2");
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("cut3");
        yield return new WaitForSeconds(2f);
        userControls.enabled = true;
        Destroy(gameObject);
    }
}
