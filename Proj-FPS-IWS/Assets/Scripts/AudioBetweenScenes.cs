using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioBetweenScenes : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    public Slider volumeSlider;
    private int firstPlayInt;
    [SerializeField] private TMP_Text lobbySoundText;
    public GameObject ObjectMusic;
    private float backgroundFloat;
    private float MusicVolume = 0f;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("volume");
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
        }
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void SaveSoundSettings() 
    {
        PlayerPrefs.SetFloat(BackgroundPref, volumeSlider.value);
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
    }

    public void VolumePlayer(float volume) 
    {
        MusicVolume = volume;
    }

    public void VolumeSlider(float volume)
    {
        lobbySoundText.text = volume.ToString("0.00");
    }
}
