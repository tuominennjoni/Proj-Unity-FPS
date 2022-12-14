using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPS : MonoBehaviour
{
    public Toggle fpsCounterTog;
    public float timer, refresh = 3f;
    public float avgFramerate;
    public string display = "{0} FPS";
    public TMP_Text fpstext;

    void Start() 
    {
        
    }


    void Update() {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int) (1f / timelapse);
        fpstext.text = string.Format(display, avgFramerate.ToString());
    }

    public void ShowFPS(GameObject obj) 
    {
        obj.SetActive(true);
    }

    public void HideFPS(GameObject obj) 
    {
        obj.SetActive(false);

        if(fpsCounterTog.isOn) 
        {
            obj.SetActive(true);
        }
    }
}
