using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;

    public bool kenaCahaya;

    //Untuk ngurangin jumlah enemy
    public int minus1Enemy;

    public GameObject GameOverPanel;

    public GameObject UIObject;
    public GameObject HPBarCanvas;

    public GameObject Player;
    
    Animator anim;
    Animator animPlayer;
    Collider2D enemyCollider;
    Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator> ();
        animPlayer = Player.GetComponent<Animator> ();
        enemyCollider = GetComponent<Collider2D> ();
        rb = Player.GetComponent<Rigidbody2D> ();
    }

    
    void FixedUpdate()
    {
        if(healthAmount <= 0)
        {
            //Saat enemy mati , maka menuju ke animasi mati
            StartCoroutine(waitDeath());

        }

        if(kenaCahaya == true)
        {
            TakeDamage(0.5f);
        } 
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 40;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        //healthBar.fillAmount = healthAmount / 100;
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        
        if (collision.gameObject.tag == "cahaya")
        {
            kenaCahaya = true;
            //anim.SetBool ("getHit", true);
            //TakeDamage(0.5f);
            //If the GameObject has the same tag as specified, output this message in the console
            //StartCoroutine(cahayaInterval());
        } else {
            TakeDamage(0f);
            //anim.SetBool ("getHit", false);
            //kenaCahaya = false;
        }
        
     

        if (collision.gameObject.tag == "Player")
        {
            //Jika collision dengan player maka restart scene
            StartCoroutine(playerDeath());
        }

    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        
        if (collision.gameObject.tag == "cahaya")
        {
            kenaCahaya = false;
        }
    }


    void enemyDefeat()
    {

    }

    IEnumerator cahayaInterval()
    {
        //TakeDamage(0.1f);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator waitDeath()
    {
        anim.SetBool ("getHit", false);
        anim.SetTrigger ("defeat");

        Destroy(HPBarCanvas);
        
        yield return new WaitForSeconds(0.6f);
        minus1Enemy = PlayerPrefs.GetInt("JumlahEnemy");
        minus1Enemy -= 1;
        

        Destroy(gameObject);
        PlayerPrefs.SetInt("JumlahEnemy", minus1Enemy);
    }

    IEnumerator playerDeath()
    {
        UIObject.SetActive(false);
        Destroy(Player.GetComponent<PLAYERMOVEMENT2>());
        animPlayer.SetBool ("isWalking", false);
        animPlayer.SetTrigger ("death");
        
       
        enemyCollider.enabled = false;

        yield return new WaitForSeconds(1.8f);
        GameOverPanel.SetActive (true);
        Time.timeScale = 0;
        
    }

}