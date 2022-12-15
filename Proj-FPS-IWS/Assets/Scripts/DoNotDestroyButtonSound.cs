using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyButtonSound : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        GameObject[] buttonObj = GameObject.FindGameObjectsWithTag("SoundButton");
        if(buttonObj.Length > 1) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
