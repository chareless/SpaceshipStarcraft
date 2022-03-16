using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    public static int loadedScore;
    public static int loadedHealth;
    public static int loadedLevel;
    public static int loadedWave;
    public static int loadedKill;
    public static int loadedShip;
    public static int loadedHigh;
    public static int loadedArcEndlessHigh;
    public static int loadedArcLaserHigh;
    public static int loadedArcNoGunsHigh;
    public static int loadedCoin;
    public static string loadedMyShips;
    public static void killCheck()
    {
        if (PlayerPrefs.GetInt("Kill")!=0)
        {
            loadedKill = PlayerPrefs.GetInt("Kill");
        }
        else
        {
            loadedKill = 0;
        }
    }

    public static void shipCheck()
    {
        if (PlayerPrefs.GetInt("Ship") != 0)
        {
            loadedShip = PlayerPrefs.GetInt("Ship");
        }
        else
        {
            loadedShip = 0;
        }
    }

    public static void waveCheck()
    {
        if (PlayerPrefs.GetInt("Wave") != 0)
        {
            loadedWave = PlayerPrefs.GetInt("Wave");
        }
        else
        {
            loadedWave = 0;
        }
    }

    public static void levelCheck()
    {
        if (PlayerPrefs.GetInt("Level") != 0)
        {
            loadedLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            loadedLevel = 0;
        }
    }
    public static void healthCheck()
    {
        if (PlayerPrefs.GetInt("Health") != 0)
        {
            loadedHealth = PlayerPrefs.GetInt("Health");
        }
        else
        {
            loadedHealth = 0;
        }
    }

    public static void scoreCheck()
    {
        if (PlayerPrefs.GetInt("Score") != 0)
        {
            loadedScore = PlayerPrefs.GetInt("Score");
        }
        else
        {
            loadedScore = 0;
        }
    }

    public static void highscoreCheck()
    {
        if (PlayerPrefs.GetInt("Highscore") != 0)
        {
            loadedHigh = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            loadedHigh = 0;
        }
    }

    public static void arcadeEndlessScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcEndlessHighscore") != 0)
        {
            loadedArcEndlessHigh = PlayerPrefs.GetInt("ArcEndlessHighscore");
        }
        else
        {
            loadedArcEndlessHigh = 0;
        }
    }

    public static void arcadeLaserScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcLaserHighscore") != 0)
        {
            loadedArcLaserHigh = PlayerPrefs.GetInt("ArcLaserHighscore");
        }
        else
        {
            loadedArcLaserHigh = 0;
        }
    }

    public static void arcadeNoGunsScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcNoGunsHighscore") != 0)
        {
            loadedArcNoGunsHigh = PlayerPrefs.GetInt("ArcNoGunsHighscore");
        }
        else
        {
            loadedArcNoGunsHigh = 0;
        }
    }

    public static void coinCheck()
    {
        if (PlayerPrefs.GetInt("Coin") != 0)
        {
            loadedCoin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            loadedCoin = 0;
        }
    }

    public static void shopCheck()
    {
        if (PlayerPrefs.GetString("MyShips") != "")
        {
            loadedMyShips = PlayerPrefs.GetString("MyShips");
        }
        else
        {
            loadedMyShips = "s1s2";
        }
    }

    public static void loadData()
    {
        scoreCheck();
        shipCheck();
        healthCheck();
        levelCheck();
        killCheck();
        waveCheck();
        highscoreCheck();
        arcadeEndlessScoreCheck();
        arcadeLaserScoreCheck();
        arcadeNoGunsScoreCheck();
        coinCheck();
        shopCheck();
    }

    public void Start()
    {
        loadData();
    }
}
