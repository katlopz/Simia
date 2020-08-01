using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;

public class DialogueManager : MonoBehaviour
{   
    private Queue<string> sentences;
    private Queue<string> names; // For multi-person dialogues

    public Text nameText;
    public Text dialogueText;

    public GameObject indicator;

    public Animator animator;
    public bool active;

    void Start()
    {
        sentences = new Queue<string>();
        nameText.text = "";
        dialogueText.text = "";
        
        active = false;
        animator.SetBool("active", active);
    }

    // Handles single dialogue interactions (e.g. Simia talking to herself)
    public void StartDialogue(Dialogue dialogue)
    {  
        names = null;
        // Only proceed if the manager is inactive to avoid
        //merged sentences or incorrect formatting
        if (active == false)
        {
             //stop player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
            
            names = null;
            active = true; // manager is engaged
            animator.SetBool("active", active);
            nameText.text = dialogue.name;

            sentences.Clear();
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    // Handles multi person dialogues
    public void StartDialogue(Dialogue[] dialogues)
    {   
        if (active == false)
        {
            int max = 0;
            foreach (Dialogue d in dialogues)
            {
                if (max < d.sentences.Length)
                {
                    max = d.sentences.Length;
                }
            }

            //stop player moving
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = true;
            
            active = true; // manager is engaged
            animator.SetBool("active", active);
            names = new Queue<string>();

            sentences.Clear();
            for (int i = 0; i < max; i++)
            {
                foreach (Dialogue d in dialogues)
                {
                    names.Enqueue(d.name);
                    sentences.Enqueue(d.sentences[i]);
                }
            }

            DisplayNextSentence();
        }
    }

    private void DisplayNextSentence()
    {
        indicator.SetActive(false);
        if (names != null)
        {
            nameText.text = names.Dequeue();
        } 
        StartCoroutine(slowText(sentences.Dequeue()));
    }

   IEnumerator slowText(string sentence)
    {   
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); 
        }
        StartCoroutine(resetText(2));   
    } 

    // clears text after 't' seconds or recalls DisplayDisplayNextSentence
    // if more sentences are present
    IEnumerator resetText(int t)
    {
        // Show push w indicator HERE <----
        indicator.SetActive(true);


        yield return waitForKey(); // wait for this function to return    
        dialogueText.text = "";
        if (sentences.Count == 0 )
        {
            // Re-enable player moving and dialogue manager
            nameText.text = "";
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
            
            // Animates textbox away early but delays the manager
            // from being active so the player has time to move away
            animator.SetBool("active", false);
            yield return new WaitForSeconds(1.0f);
            active = false;
        } else {
            // If extra sentences are present, keep printing
            DisplayNextSentence();
        }
    }

    // Wait for spacebar press
    private IEnumerator waitForKey()
    {
        bool press = false;
        while(!press) 
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                press = true;
            }
            yield return null; 
        }
    }
}
