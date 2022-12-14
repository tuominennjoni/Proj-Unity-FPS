using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayDate : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI currentTimeText;
    public Toggle systemClockTog;
    
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
}
