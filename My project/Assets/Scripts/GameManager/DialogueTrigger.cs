using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    private bool playerInRange;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    

    private void Awake()
    {
        playerInRange = false;

    }

    //private void Update()
    //{
    //    if (playerInRange)
    //    {
    //        GameObject.Find("Trigg").GetComponent<Button>().interactable = true;

    //    }
    //    else
    //    {
    //        GameObject.Find("Trigg").GetComponent<Button>().interactable = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
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
