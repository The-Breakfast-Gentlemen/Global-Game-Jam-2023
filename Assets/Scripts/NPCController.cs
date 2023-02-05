using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public DialogueTrigger trigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            trigger.StartDialogue();
    }
}
