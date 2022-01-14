using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class OpeningPlayer : MonoBehaviour
{
    public GameObject Opening;
    public GameObject BlackScreen;
    public GameObject Levels;
    public GameObject backButton;
    public float OpeningDuration;
    public int SceneIndex = 2;

    void Start()
    {
        
    }

    public void PlayOpening()
    {
        Opening.SetActive(true);
        BlackScreen.SetActive(true);
        Levels.SetActive(false);
        backButton.SetActive(false);
        StartCoroutine(DestroyOpening());
    }
    

    IEnumerator DestroyOpening()
    {
        yield return new WaitForSeconds(OpeningDuration);
        //Destroy(BlackScreen);
        Destroy(Opening);
        SceneManager.LoadScene(SceneIndex);
    }
}
