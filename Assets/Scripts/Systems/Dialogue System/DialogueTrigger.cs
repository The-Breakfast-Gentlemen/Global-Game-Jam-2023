using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public Conversation[] conversations;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(conversations);
    }
}

[System.Serializable]
public class Message 
{
    public int actorId;
    public string message;

}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}

[System.Serializable]
public class Conversation
{
    public Message[] c_messages;
    public Actor[] c_actors;
}