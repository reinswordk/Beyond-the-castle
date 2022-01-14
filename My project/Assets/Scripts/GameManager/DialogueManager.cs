using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public GameObject UIObject;
    public GameObject Cutscene;
    public GameObject vmCamera;
    public float CutSceneDuration;
    public GameObject BlackScreen;
    public GameObject WinObject;
    Animator anim;
    public GameObject ObstacleDuri;
    public GameObject holderbatu;
    public GameObject Kembaran;

    public int Scene;


    public void OpenDialogue(Message[] message, Actor[] actors)
    {
        currentMessages = message;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        anim = vmCamera.GetComponent<Animator>();
        Kembaran.SetActive(true);

        Debug.Log("Started conversation loaded message:" + message.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        //AnimateTextColor();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(messageToDisplay.message));

        UIObject.SetActive(false);
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
            UIObject.SetActive(true);
            BlackScreen.SetActive(true);
            Cutscene.SetActive(true);
            
            ObstacleDuri.SetActive(false);
            anim.SetTrigger ("isZoomOut");

            StartCoroutine(CutSceneWait());
            //StartCoroutine(DelayNextLevel());

        }

    }
    //IEnumerator DelayNextLevel()
    //{
    //    yield return new WaitForSeconds(10);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    IEnumerator TypeSentence(string messageToDisplay)
    {
        float t = 200;
        messageText.text = " ";
        foreach (var letter in messageToDisplay.ToCharArray())
        {
            t += Time.deltaTime;
            messageText.text += letter;
            yield return  null;
        }


    }
    //ini untuk dialog effect fade
    //void AnimateTextColor()
    //{
    //    LeanTween.textAlpha(messageText.rectTransform, 0, 0);
    //    LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    //}
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Untuk mempermudah testing
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    IEnumerator CutSceneWait()
    {
        Destroy(Kembaran);
        yield return new WaitForSeconds(CutSceneDuration);
        Destroy(Cutscene);
        
        Destroy(holderbatu);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(Scene);

        //Destroy(BlackScreen);
    }
}
