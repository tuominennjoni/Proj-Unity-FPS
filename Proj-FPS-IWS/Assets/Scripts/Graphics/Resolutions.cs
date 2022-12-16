using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Resolutions : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex;
    public Toggle vsyncTog;

    void Start() 
    {
        if(QualitySettings.vSyncCount == 0) 
        {
            vsyncTog.isOn = false;
        }
        else 
        {
            vsyncTog.isOn = true;
        }

        resolutions = Screen.resolutions;

        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i = 0; i < resolutions.Length; i++) {
            if(resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }   
        }

    List<string> options = new List<string>();
    for(int i = 0; i < filteredResolutions.Count; i++) {
        string resolutionOptions = filteredResolutions[i].width + " x " + filteredResolutions[i].height + " | " + filteredResolutions[i].refreshRate + " Hz";
        options.Add(resolutionOptions);
        if(filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height) 
        {
            currentResolutionIndex = i;
        }
    }

    resolutionDropdown.AddOptions(options);
    resolutionDropdown.value = currentResolutionIndex;
    resolutionDropdown.RefreshShownValue();
}

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void SetFullScreen(bool _fullscreen) 
    {
        Screen.fullScreen = _fullscreen;
    }

    public void ApplyGraphics() 
    {
        if(vsyncTog.isOn) 
        {
            QualitySettings.vSyncCount = 1;
        }
        else 
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
