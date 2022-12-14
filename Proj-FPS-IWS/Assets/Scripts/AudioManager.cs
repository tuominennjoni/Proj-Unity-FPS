using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    //private static readonly string FirstPlay = "FirstPlay";
    private int firstPlayInt;
    [SerializeField] private TMP_Text lobbySoundText = null;
    public Slider backgroundSlider;
    public Slider soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backGroundAudio;


    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = 0.17f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSoundSettings() 
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound() 
    {
        backGroundAudio.volume = backgroundSlider.value;
    }

    public void VolumeSlider(float volume)
    {
        lobbySoundText.text = volume.ToString("0.00");
    }
}
