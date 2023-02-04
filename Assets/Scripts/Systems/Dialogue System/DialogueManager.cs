using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text textContent;
    public RectTransform backgroundBox;

    Conversation[] currentConversations;
    Message[] currentMessages;
    Actor[] currentActors;
    
    int activeConversation = 0;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Conversation[] conversations)
    {
        currentConversations = conversations;
        currentMessages = currentConversations[activeConversation].c_messages;
        currentActors = currentConversations[activeConversation].c_actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started convo! Loaded messages: " + currentMessages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    void DisplayMessage() 
    {
        Message displayMessage = currentMessages[activeMessage];
        textContent.text = displayMessage.message;

        Actor displayActor = currentActors[displayMessage.actorId];

        actorName.text = displayActor.name;
        actorImage.sprite = displayActor.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length && isActive)
            DisplayMessage();
        else
        {
            Debug.Log("Conversation ended");
            activeConversation++; // DEPRECATE THIS TO USE CUSTOM activeConversation INDEX LATER
            
            isActive = false;
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }
    }
}
