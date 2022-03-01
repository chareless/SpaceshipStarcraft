using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
{
    public int endScore;

    public Text scoreText;

    public GameObject waveSpawner;
    public GameObject WinSound;
    public GameObject LoseSound;
    public GameObject GameSound;
    public GameObject BossSound;

    void Start()
    {
        saveScore();
        waveSpawner.SetActive(false);
        if(SpawnEnemies.gameEnd==true)
        {
            WinSound.SetActive(true);
        }
        else
        {
            LoseSound.SetActive(true);  
        }
        Destroy(GameSound);
        Destroy(BossSound);
    }

    void saveScore()
    {
        endScore = Status.score;
        scoreText.text = endScore.ToString();

        if (LoadData.loadedHigh < endScore)
        {
            PlayerPrefs.SetInt("Highscore", endScore);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        endScore = Status.score;
        scoreText.text = endScore.ToString();
    }

    public void menuButton()
    {
        endScore = Status.score;
        scoreText.text = endScore.ToString();
        saveScore();
        SceneManager.LoadScene("StartMenu");
    }
    public void quitButton()
    {
        endScore = Status.score;
        scoreText.text = endScore.ToString();
        saveScore();
        Application.Quit();
    }
}
