using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLobby() 
    {
        SceneManager.LoadScene("Lobby");
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void GoToGame() 
    {
        SceneManager.LoadScene("Game");
    }
}
