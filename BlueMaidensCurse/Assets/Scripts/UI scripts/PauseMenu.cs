using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool Paused = false;

    public GameObject pauseMenuUI;

    public void TogglePause()
    {
        if (Paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Bluemaidenscurse main menu");
    }

    public void QuitGame()
    {
        Debug.Log ("I hope you are proud of yourself");
        Application.Quit();
    }
}
