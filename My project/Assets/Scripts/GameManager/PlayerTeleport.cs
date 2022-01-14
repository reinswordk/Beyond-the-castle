using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    public float sec = 14f;

    public void Pindah()
    {
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
    }
} 