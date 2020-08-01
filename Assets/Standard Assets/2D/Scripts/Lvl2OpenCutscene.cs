using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Lvl2OpenCutscene : MonoBehaviour
{
    GameObject player;
    Platformer2DUserControl userControls;
    Animator animator;
    bool playedCutscene = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        userControls = player.GetComponent<Platformer2DUserControl>();
        animator = GameObject.FindGameObjectWithTag("lvl2Door1").GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!playedCutscene)
            StartCoroutine(PlayLvl2OpeningCutscene());
    }

    IEnumerator PlayLvl2OpeningCutscene()
    {
        playedCutscene = true;
        userControls.enabled = false;
        player.SetActive(false);
        animator.SetTrigger("open");
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
        animator.SetTrigger("close");
        yield return new WaitForSeconds(1f);
        userControls.enabled = true;
        Dialogue dialogue = new Dialogue("Monicka", new string[] { "No sign of Dr Fischer here", "Maybe if I replicate the events in the journal,", "I can stop the hominid that way.", "But first I need to find the missing page" });
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Destroy(this);
    }
}
