using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{

    private bool playerInRange;
    private bool playerInTeleporter;
    private bool playerInNPC;

    private GameObject currentTeleporter;
    private Button button;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Teleporter")
        {
            playerInRange = true;
            playerInTeleporter = true;
            currentTeleporter = other.gameObject;
        }       
        else if (other.tag == "NPC")
        {
            playerInRange = true;
            playerInNPC = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Teleporter")
        {
            playerInRange = false;
            playerInTeleporter = false;
            if (other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
        else if (other.tag == "NPC")
        {
            playerInRange = false;
            playerInNPC = false;
        }
    }
    
    public void Interact()
    {
        if (playerInTeleporter == true)
        {
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
        else if (playerInNPC == true)
        {
            FindObjectOfType<DialogueTrigger>().StartDialogue();
        }
    }

    private void Update()
    {
        
        if (playerInRange)
        {
            GameObject InteractButton = GameObject.Find("InteractButton");
            if (InteractButton != null)
            {
                InteractButton.GetComponent<Button>().interactable = true;
            }            

        }
        else
        {
            GameObject.Find("InteractButton").GetComponent<Button>().interactable = false;
        }
        
    }
}
