using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Set the time back to 1:
        Time.timeScale = 1;
        //Time.timeScale is back to normal, now load the scene:
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ToCredit()
    {
        SceneManager.LoadScene("CreditTes");
    }

   
}