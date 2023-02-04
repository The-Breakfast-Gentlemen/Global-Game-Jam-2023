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

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started convo! Loaded messages: " + messages.Length);
        DisplayMessage();
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
            isActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
