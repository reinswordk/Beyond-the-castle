using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYERMOVEMENT : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Joystick mj;
    public float jumpspeed;
    public CharacterController2D controller;
    bool jump = false;
    float horizontalmove;
    float x;
    Animator anim;
    bool crouch = false;
    [Range(1, 10)]
    public float jumpvelocity;

    //Mirror
    public GameObject cahaya;
    public Image mirrorBar;
    public float energyAmount;
    public bool buttonHold;
    public Button MirrorButton;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    private void Update()
    {
        if (DialogueManager.isActive == true)
            return;
        horizontalmove = x = mj.Horizontal * speed;
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        float verticalmove = mj.Vertical * jumpspeed;
        if (verticalmove >= 7f)
        {
            jump = true;
            //GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpvelocity;   
        }
        if (verticalmove > -1f)
        {
            crouch = false;
        }
        else if (verticalmove < -4.5f)
        {
            crouch = true;
        }
        if (verticalmove >= 0f)
        {
            crouch = false;
        }

        if (horizontalmove == 0f)
        {
            anim.SetBool ("isWalking", false);
        }
        else if (horizontalmove > 0f){
			anim.SetBool ("isWalking", true);
		}
        else if (horizontalmove < 0f){
            anim.SetBool ("isWalking", true);
        }  

        if (Input.GetKeyDown(KeyCode.Space))
        {
            defence();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            release();
        }

        //Kurangi energi jika hold button
        if (buttonHold == true)
        {
            //Kurangi energi
            DrainEnergy(0.2f);
        } else {
            //Kalau tidak press button,maka isi energi
            ChargeEnergy(0.1f);
        }

        //Jika energi = 0 , matikan cahaya
        if (energyAmount <= 0)
        {
            MirrorButton.interactable = false;
            release();
        } else {
            MirrorButton.interactable = true;
        }
    }


    private void FixedUpdate()
    {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //Animator Player
    public void defence()
    {
        //Animasi
        anim.SetTrigger ("hit");
        anim.SetBool ("isWalking", false);
        anim.SetBool ("holdMirror", true);

        StartCoroutine(waitToHold());
    }

    public void release()
    {
        //cahaya.SetActive(false);
        anim.SetBool ("isWalking", false);
        anim.SetBool ("holdMirror", false);
        anim.SetBool ("holdingMirror", false);

        //Matikan boolean cahaya
        buttonHold = false;
    }

    public void clikedNothing()
    {
        anim.SetBool ("holdingMirror", false);
    }

    IEnumerator waitToHold()
    {
        yield return new WaitForSeconds(0.22f);
        anim.SetBool ("holdingMirror", true);
        buttonHold = true;
        //cahaya.SetActive(true);
    }

    //Pengurangan energi cahaya
    public void DrainEnergy(float Drain)
    {
        energyAmount -= Drain;
        mirrorBar.fillAmount = energyAmount / 100;
    }

    //Ngisi energy cahaya
    public void ChargeEnergy(float Charge)
    {
        energyAmount += Charge;
        energyAmount = Mathf.Clamp(energyAmount, 0, 100);

        mirrorBar.fillAmount = energyAmount / 100;
    }

}