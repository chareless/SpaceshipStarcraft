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
    public static int loadedArcOneHPHigh;
    public static int loadedArcShockHigh;
    public static int loadedArcRapidfireHigh;
    public static int loadedArcSpeedHigh;
    public static int loadedArcDefendHigh;
    public static int loadedArcMirrorHigh;
    public static int loadedArcInsaneHigh;
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

    public static void arcadeOneHPScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcOneHPHighscore") != 0)
        {
            loadedArcOneHPHigh = PlayerPrefs.GetInt("ArcOneHPHighscore");
        }
        else
        {
            loadedArcOneHPHigh = 0;
        }
    }

    public static void arcadeShockScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcShockHighscore") != 0)
        {
            loadedArcOneHPHigh = PlayerPrefs.GetInt("ArcShockHighscore");
        }
        else
        {
            loadedArcShockHigh = 0;
        }
    }

    public static void arcadeRapidfireScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcRapidfireHighscore") != 0)
        {
            loadedArcRapidfireHigh = PlayerPrefs.GetInt("ArcRapidfireHighscore");
        }
        else
        {
            loadedArcRapidfireHigh = 0;
        }
    }

    public static void arcadeSpeedScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcSpeedHighscore") != 0)
        {
            loadedArcSpeedHigh = PlayerPrefs.GetInt("ArcSpeedHighscore");
        }
        else
        {
            loadedArcSpeedHigh = 0;
        }
    }

    public static void arcadeDefendScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcDefendHighscore") != 0)
        {
            loadedArcDefendHigh = PlayerPrefs.GetInt("ArcDefendHighscore");
        }
        else
        {
            loadedArcDefendHigh = 0;
        }
    }

    public static void arcadeMirrorScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcMirrorHighscore") != 0)
        {
            loadedArcMirrorHigh = PlayerPrefs.GetInt("ArcMirrorHighscore");
        }
        else
        {
            loadedArcMirrorHigh = 0;
        }
    }

    public static void arcadeInsaneScoreCheck()
    {
        if (PlayerPrefs.GetInt("ArcInsaneHighscore") != 0)
        {
            loadedArcInsaneHigh = PlayerPrefs.GetInt("ArcInsaneHighscore");
        }
        else
        {
            loadedArcInsaneHigh = 0;
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

    public static void bonusCoinCheck()
    {
        if(PlayerPrefs.GetInt("BonusCoin") == 0)
        {
            if(loadedArcDefendHigh>0 && loadedArcEndlessHigh>0 && loadedArcInsaneHigh>0
                && loadedArcLaserHigh>0 && loadedArcMirrorHigh>0 && loadedArcNoGunsHigh>0
                && loadedArcOneHPHigh>0 && loadedArcRapidfireHigh>0 && loadedArcShockHigh>0
                && loadedArcSpeedHigh>0)
            {
                StartMenu.coin += 100;
                SaveData.saveCoin();
                PlayerPrefs.SetInt("BonusCoin",1);
            }
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
        arcadeOneHPScoreCheck();
        arcadeShockScoreCheck();
        arcadeDefendScoreCheck();
        arcadeSpeedScoreCheck();
        arcadeMirrorScoreCheck();
        arcadeInsaneScoreCheck();
        coinCheck();
        shopCheck();
        bonusCoinCheck();
    }

    public void Start()
    {
        loadData();
    }
}
