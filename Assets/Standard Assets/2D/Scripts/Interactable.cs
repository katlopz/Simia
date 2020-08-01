using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;

    abstract public void Interact();

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
