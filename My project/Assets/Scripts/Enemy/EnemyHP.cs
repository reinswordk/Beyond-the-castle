using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    //public Image healthBar;
    public float healthAmount = 100;

    public bool kenaCahaya;

    //Untuk ngurangin jumlah enemy
    public int minus1Enemy;

    public GameObject GameOverPanel;

    public GameObject UIObject;

    

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    private void Update()
    {
        if(healthAmount <= 0)
        {
            //Saat enemy mati , maka kurangi jumlah enemy sekarang
            StartCoroutine(waitDeath());
            
            //Application.LoadLevel(Application.loadedLevel);
        }

        if(kenaCahaya == true)
        {
            //TakeDamage(0.1f);
        } 

        if(Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
        }

    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        //healthBar.fillAmount = healthAmount / 100;
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
            //kenaCahaya = true;
            TakeDamage(1f);
            //If the GameObject has the same tag as specified, output this message in the console
            //StartCoroutine(cahayaInterval());
        } else {
            //kenaCahaya = false;
        }

        if (collision.gameObject.tag == "Player")
        {
            //Jika collision dengan player maka restart scene
            GameOverPanel.SetActive (true);
            Time.timeScale = 0;
            UIObject.SetActive(false);
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
        
        yield return new WaitForSeconds(1f);
        minus1Enemy = PlayerPrefs.GetInt("JumlahEnemy");
        minus1Enemy -= 1;
        

        Destroy(gameObject);
        PlayerPrefs.SetInt("JumlahEnemy", minus1Enemy);
    }

}