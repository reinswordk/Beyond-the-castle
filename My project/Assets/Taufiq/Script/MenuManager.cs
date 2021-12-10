using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text toggleMusictxt;

    public Text toggleSfxTxt;

    private void Start()
    {
        if (BgScript.BgInstance.Audio.isPlaying)
        {
            toggleMusictxt.text = "OFF";
        }
        else
        {
            toggleMusictxt.text = "ON";
        }

        // SFX
        if (SFXScript.sfxInstance.musicToggle == true)
        {
            toggleSfxTxt.text = "OFF";
        }
        else
        {
            toggleSfxTxt.text = "ON";
        }
    }

    public void sfxToggle()
    {
        if (SFXScript.sfxInstance.musicToggle == true)
        {
            SFXScript.sfxInstance.musicToggle = false;
            toggleSfxTxt.text = "ON";
        }
        else
        {
            SFXScript.sfxInstance.musicToggle = true;
            toggleSfxTxt.text = "OFF";
        }
    }

    public void MusicToggle()
    {
        if(BgScript.BgInstance.Audio.isPlaying)
        {
            BgScript.BgInstance.Audio.Pause();
            toggleMusictxt.text = "ON";
        }
        else
        {
            BgScript.BgInstance.Audio.Play();
            toggleMusictxt.text = "OFF";
        }
    }
}
