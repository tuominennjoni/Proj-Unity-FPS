using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AudioSettings : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    public AudioSource backGroundAudio;
    private float backgroundFloat;

    
    void Awake() 
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);

        backGroundAudio.volume = backgroundFloat;
    }
}
