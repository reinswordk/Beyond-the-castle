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

    public GameObject NPC_Trap;
    public GameObject NPC_Free;
    public GameObject Vcam;
    Animator vcamAnim;

    void OnTriggerEnter2D(Collider2D other)
    {
        //check gameobject tag 
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
        //check gameoject tag
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

    private void Start()
    {
        NPC_Trap.SetActive(true);
        NPC_Free.SetActive(false);
        vcamAnim = Vcam.GetComponent<Animator> ();
    }

    //To call teleport or to start dialog function
    public void Interact()
    {
        //Teleport function
        if (playerInTeleporter == true)
        {
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
        //StartDialogue Function
        else if (playerInNPC == true)
        {
            vcamAnim.SetTrigger ("IsZoomIn");
            FindObjectOfType<DialogueTrigger>().StartDialogue();
            NPC_Free.SetActive(true);
            NPC_Trap.SetActive(false);
        }
    }

    private void Update()
    {
        //Set Active Button when player in NPC Range
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
            //disable interact button
            if(GameObject.Find("InteractButton") != null)
                GameObject.Find("InteractButton").GetComponent<Button>().interactable = false;
        }
        
    }
}
