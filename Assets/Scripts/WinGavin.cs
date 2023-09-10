using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinGavin : MonoBehaviour
{
    public GameObject GavinWinScreen;

    public void Setup()
    {
        gameObject.SetActive(true);

    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
