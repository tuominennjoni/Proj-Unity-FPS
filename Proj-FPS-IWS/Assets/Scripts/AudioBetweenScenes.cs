using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioBetweenScenes : MonoBehaviour
{

    public Slider volumeSlider;
    [SerializeField] private TMP_Text lobbySoundText;

    public GameObject ObjectMusic;

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
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
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
