using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence(dialogue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
