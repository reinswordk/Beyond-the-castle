using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    int test = 4;
    
    Rigidbody2D myRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);

        while(test > 0)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {   

    }

    void Flip()
    {   
        while(test > 0)
        {
            StartCoroutine(waitToFlip());
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);

            StartCoroutine(waitToFlip());
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        }
    }

    IEnumerator waitToFlip()
    {
        yield return new WaitForSeconds(5);
    }

}
