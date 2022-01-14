using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseManager : MonoBehaviour
{
    public GameObject UI;
    public GameObject panelPause;

    void Start()
    {
        
    }
    
    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            UI.SetActive(true);
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
            UI.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene() .buildIndex);
        Time.timeScale = 1;
    }

    public void MenuUtama()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

}
