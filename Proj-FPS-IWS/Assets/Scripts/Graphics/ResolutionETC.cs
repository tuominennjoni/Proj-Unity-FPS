using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ResolutionETC : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    public int selectedResolution;
    public TMP_Text resolutionLabel;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0) 
        {
            vsyncTog.isOn = false;
        }
        else 
        {
            vsyncTog.isOn = true;
        }

        bool foundRes = false;

        for(int i = 0; i < resolutions.Count; i++) {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }

        if(!foundRes) // jos ei ole sopivaa resoluutiota käyttälle, niin haetaan sellainen
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;

            UpdateResLabel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft() 
    {
        selectedResolution--;
        if(selectedResolution < 0) 
        {
            selectedResolution = 0;
        }     
        UpdateResLabel();
    }

    public void ResRight() 
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics() 
    {
        //Screen.fullScreen = fullscreenTog.isOn;

        if(vsyncTog.isOn) 
        {
            QualitySettings.vSyncCount = 1;
        }
        else 
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

    [System.Serializable]
    public class ResItem 
    {
        public int horizontal, vertical;
    }
}
