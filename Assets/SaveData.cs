using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static int currentScore;
    public static int currentHealth;
    public static int currentLevel;
    public static int currentWave;
    public static int currentKill;
    public static int currentShip;
    public static int Coin;
    public static string MyShips;

    static void saveScore()
    {
        currentScore = Status.score;
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.Save();
    }

    static void saveKill()
    {
        currentKill = Status.totalKill;
        PlayerPrefs.SetInt("Kill", currentKill);
        PlayerPrefs.Save();
    }

    static void saveShip()
    {
        currentShip = Status.ship;
        PlayerPrefs.SetInt("Ship", currentShip);
        PlayerPrefs.Save();
    }

    static void saveHealth()
    {
        currentHealth = Status.health;
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();
    }

    static void saveLevel()
    {
        currentLevel = Status.playerLevel;
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.Save();
    }

    static void saveWave()
    {
        currentWave = Status.wave;
        PlayerPrefs.SetInt("Wave",currentWave);
        PlayerPrefs.Save();
    }

    public static void saveCoin()
    {
        Coin = StartMenu.coin;
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.Save();
    }

    public static void saveMyShips()
    {
        MyShips = StartMenu.ownships;
        PlayerPrefs.SetString("MyShips",MyShips);
        PlayerPrefs.Save();
    }

    public static void saveData()
    {
        saveHealth();
        saveLevel();
        saveWave();
        saveScore();
        saveKill();
        saveShip();
        saveCoin();
        saveMyShips();
        PlayerPrefs.Save();
    }
}
