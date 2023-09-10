using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Howtoplay");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("quit game");
    }
}
