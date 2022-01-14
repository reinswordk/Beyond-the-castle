using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    public float speedEnemy;
    float x;
    private bool m_FacingRight = true;
    public bool rightPosition;
    Animator anim;
    Rigidbody2D myRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        anim = GetComponent<Animator> ();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightPosition == false)
        {
            if(Vector2.Distance(transform.position, playerPos.position) < distance)
            {
                if (playerPos.position.x - transform.position.x > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                } else 
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }

                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
                anim.SetBool ("getHit", true);
                //anim.SetBool ("walkBack", false);
            }
            else
            {
            anim.SetBool ("getHit", false);
            
                if( Vector2.Distance(transform.position, currentPos) <= 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.SetBool ("getHit", false);
                    //anim.SetBool ("walkBack", false);
                    

                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    transform.position = Vector2.MoveTowards(transform.position ,currentPos, speedEnemy * Time.deltaTime);
                    anim.SetBool ("getHit", false);
                    //anim.SetBool ("walkBack", true);
                    
                    
                }
            }
        }
        else
        {
            
            if(Vector2.Distance(transform.position, playerPos.position) < distance)
            {
                if (playerPos.position.x - transform.position.x > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                } else 
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }

                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
                anim.SetBool ("getHit", true);
                //anim.SetBool ("walkBack", false);
            }
            else
            {
            anim.SetBool ("getHit", false);
            
                if( Vector2.Distance(transform.position, currentPos) <= 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    anim.SetBool ("getHit", false);
                    //anim.SetBool ("walkBack", false);
                    

                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position ,currentPos, speedEnemy * Time.deltaTime);
                    anim.SetBool ("getHit", false);
                    //anim.SetBool ("walkBack", true);
                    
                    
                }
            }
        }

        
    }
}
