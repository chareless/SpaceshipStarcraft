using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;
    public GameObject buttonMenuUI;
    
    public void Pause()
    {
        if(GamePaused==false)
        {
            pauseMenuUI.SetActive(true);
            pauseButtonUI.SetActive(false);
            buttonMenuUI.SetActive(false);
            Time.timeScale = 0f;
            GamePaused = true;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            pauseButtonUI.SetActive(true);
            buttonMenuUI.SetActive(true);
            Time.timeScale = 1f;
            GamePaused = false;
        }
    }

    public void MenuButton()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
