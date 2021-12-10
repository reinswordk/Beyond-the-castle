using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    
    Rigidbody2D myRigidbody;

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {   
        if(IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        } else {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "cahaya")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            anim.SetBool ("getHit", true);
        } 

    }
}
