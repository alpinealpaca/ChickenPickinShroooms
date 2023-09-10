using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseScreen;
    private bool Paused = false;


    void Start()
    {
        PauseScreen.gameObject.SetActive(false);
    }


    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            if (Paused == false)
            {
                Time.timeScale = 0f;
                PauseScreen.gameObject.SetActive(true);
                Paused = true;
                
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseScreen.gameObject.SetActive(false);
        Paused = false;
    }

     public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


    public void ExitGame()
    {
        Application.Quit();
        print("quit game");
        
    }
}
