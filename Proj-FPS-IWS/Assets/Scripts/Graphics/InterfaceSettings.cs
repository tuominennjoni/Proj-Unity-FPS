using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceSettings : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentTimeText;
    public Toggle systemClockTog;
    public Toggle fpsCounterTog;
    
    // Update is called once per frame
    void Update()
    {
        currentTimeText.SetText(DateTime.Now.ToString("hh:mm:ss"));
    }

    public void HideSystemClock(GameObject obj) 
    {
        obj.SetActive(false);

        if(systemClockTog.isOn) 
        {
            obj.SetActive(true);
        }
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
