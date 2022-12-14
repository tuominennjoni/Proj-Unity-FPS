using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject soundPanel;
    public GameObject graphicsPanel;
    public GameObject interfacePanel;
    public GameObject controlPanel;
    public GameObject extraPanel;


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

    public void GoToSettings() 
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenGraphicsPanel()
    {
        graphicsPanel.SetActive(true);
        soundPanel.SetActive(false);
        controlPanel.SetActive(false);
        interfacePanel.SetActive(false);
        extraPanel.SetActive(false);
    }

    public void OpenSoundPanel()
    {
        soundPanel.SetActive(true);
        graphicsPanel.SetActive(false);
        controlPanel.SetActive(false);
        interfacePanel.SetActive(false);
        extraPanel.SetActive(false);
    }


    public void OpenInterfacePanel()
    {
        interfacePanel.SetActive(true);
        soundPanel.SetActive(false);
        controlPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        extraPanel.SetActive(false);
    }

    public void OpenExtraPanel()
    {
        extraPanel.SetActive(true);
        soundPanel.SetActive(false);
        controlPanel.SetActive(false);
        interfacePanel.SetActive(false);
        graphicsPanel.SetActive(false);
    }

    public void OpenControlPanel()
    {
        controlPanel.SetActive(true);
        soundPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        interfacePanel.SetActive(false);
        extraPanel.SetActive(false);
    }
}
