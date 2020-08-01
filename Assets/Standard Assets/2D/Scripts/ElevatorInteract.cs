using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class ElevatorInteract : Interactable
{
    private bool ending = false;
    GameObject player;
    Animator animator;
    Platformer2DUserControl userControls;
    public GameObject loadscreen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        userControls = player.GetComponent<Platformer2DUserControl>();
        animator = GameObject.FindGameObjectWithTag("lvl2Door2").GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (!ending)
        {
            dialogue.sentences = new string[] { "I can't leave now.", "I still don't know who the subject is." };
            TriggerDialogue();
        }
        else
        {
            player.GetComponent<Platformer2DUserControl>().enabled = false;
            StartCoroutine(PlayLvl2ClosingCutscene());
            //SceneManager.LoadScene(3);
        }
    }

    public void letLeave()
    {
        ending = true;
    }

    IEnumerator PlayLvl2ClosingCutscene()
    {
        userControls.enabled = false;
        animator.SetTrigger("open");
        yield return new WaitForSeconds(1f);
        player.SetActive(false);
        animator.SetTrigger("close");
        yield return new WaitForSeconds(1f);
        loadscreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level3");
    }
}
