using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomStage2 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject UI;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Stage2Start");
        UI.SetActive(false);
        StartCoroutine(wait4seconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait4seconds()
    {
        yield return new WaitForSeconds(4f);
        UI.SetActive(true);
    }
}
