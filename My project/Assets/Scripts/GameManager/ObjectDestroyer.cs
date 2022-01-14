using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject holder;
    void OnTriggerEnter2D(Collider2D col)
    {

        Destroy(holder);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "obstacle")
        {
            Destroy(col.gameObject);
        }
    }

}
