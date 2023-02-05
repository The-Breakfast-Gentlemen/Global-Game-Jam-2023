using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public Conversation[] conversations;
    public int activeConversation = 0;
    public GameObject unlockItem;

    public bool isUnlocked = true;

    public void StartDialogue()
    {
        if(!isUnlocked)
            return;

        if(activeConversation >= conversations.Length)
            activeConversation = conversations.Length - 1;

        FindObjectOfType<DialogueManager>().OpenDialogue(conversations, activeConversation);
        if(activeConversation == 0)
            isUnlocked = false;

        activeConversation++;
        
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
