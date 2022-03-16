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

    public float timer;

    public Text scoreText;

    public GameObject waveSpawner;
    public GameObject WinSound;
    public GameObject LoseSound;
    public GameObject GameSound;
    public GameObject BossSound;
    public GameObject ButtonMain;
    public GameObject ButtonQuit;

    void Start()
    {
        Status.score += (Status.health) * 5;
        timer = 2f;
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

        if (LoadData.loadedHigh < endScore && SpawnEnemies.isStoryMode==true)
        {
            PlayerPrefs.SetInt("Highscore", endScore);
            PlayerPrefs.Save();
        }

        if (LoadData.loadedArcEndlessHigh < endScore && SpawnEnemies.isArcadeEndless==true)
        {
            PlayerPrefs.SetInt("ArcEndlessHighscore", endScore);
            PlayerPrefs.Save();
        }

        if (LoadData.loadedArcLaserHigh < endScore && SpawnEnemies.isArcadeLaser == true)
        {
            PlayerPrefs.SetInt("ArcLaserHighscore", endScore);
            PlayerPrefs.Save();
        }

        if (LoadData.loadedArcNoGunsHigh < endScore && SpawnEnemies.isArcadeNoGuns == true)
        {
            PlayerPrefs.SetInt("ArcNoGunsHighscore", endScore);
            PlayerPrefs.Save();
        }
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

    void Update()
    {
        timer -= Time.deltaTime;
        endScore = Status.score;
        scoreText.text = endScore.ToString();
        if(timer<=0)
        {
            ButtonMain.SetActive(true);
            ButtonQuit.SetActive(true);
        }
        else
        {
            ButtonMain.SetActive(false);
            ButtonQuit.SetActive(false);
        }
       
    }
}
