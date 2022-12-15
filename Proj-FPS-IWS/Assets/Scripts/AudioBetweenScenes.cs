using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioBetweenScenes : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string ButtonSoundPref = "ButtonSoundPref";
    
    public Slider volumeSlider;
    public Slider ButtonSlider;
    private int firstPlayInt;
    [SerializeField] private TMP_Text lobbySoundText;
    [SerializeField] private TMP_Text buttonSoundText;

    public GameObject ObjectMusic;
    private float backgroundFloat, buttonSoundFloat;

    private float MusicVolume = 0f;
    private float ButtonVolume = 0f;
    public AudioSource AudioSource;
    public AudioSource AAudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("volume");
        ButtonVolume = PlayerPrefs.GetFloat("buttonVolume");
        AAudioSource.volume = ButtonVolume;
        ButtonSlider.value = ButtonVolume;
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = 0.2f;
            volumeSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            volumeSlider.value = backgroundFloat;

            buttonSoundFloat = PlayerPrefs.GetFloat(ButtonSoundPref);
            ButtonSlider.value = buttonSoundFloat;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);

        AAudioSource.volume = ButtonVolume;
        PlayerPrefs.SetFloat("buttonVolume", ButtonVolume);
    }

    public void SaveSoundSettings() 
    {
        PlayerPrefs.SetFloat(BackgroundPref, volumeSlider.value);
        PlayerPrefs.SetFloat(ButtonSoundPref, ButtonSlider.value);
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
        AudioSource.volume = volumeSlider.value;
        AAudioSource.volume = ButtonSlider.value;
    }

    public void VolumePlayer(float volume) 
    {
        MusicVolume = volume;
    }

    public void ButtonVolumePlayer(float buttonVolume)
    {
        ButtonVolume = buttonVolume;
    } 

    public void VolumeSlider(float volume)
    {
        lobbySoundText.text = volume.ToString("0.00");
    }

    public void ButtonVolumeSlider(float buttonVolume)
    {
        buttonSoundText.text = buttonVolume.ToString("0.00");
    }
}
