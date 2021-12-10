using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;

    private bool playerInRange;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }

        /*
        if (playerInRange)
        {
            GameObject.Find("TeleButton").GetComponent<Button>().interactable = true;

        }
        else
        {
            GameObject.Find("TeleButton").GetComponent<Button>().interactable = false;
        }
        */

    }

    public void Pindah()
    {
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            playerInRange = true;
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.CompareTag("Teleporter"))
        {
            playerInRange = false;
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
    */
}
