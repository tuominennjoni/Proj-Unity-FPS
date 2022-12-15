using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject pelaaja;
    Vector3 offset;
    public float tarinaVaihe;
    // Start is called before the first frame update
    void Start()
    {
        offset = pelaaja.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //todo tee tarkistus pelin lopulle
        SeuraaPelaajaa();
    }

    void SeuraaPelaajaa()
    {
        if (pelaaja != null)
        {
            //asetetaan kamera seuraamaan palloa
            Vector3 paikka = transform.position;
            Vector3 tavoitePaikka = pelaaja.transform.position - offset;

            paikka = Vector3.Lerp(paikka, tavoitePaikka, tarinaVaihe * Time.deltaTime);
            transform.position = paikka;
        }
    }
}

