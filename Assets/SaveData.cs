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
    }

    static void saveKill()
    {
        currentKill = Status.totalKill;
        PlayerPrefs.SetInt("Kill", currentKill);
    }

    static void saveShip()
    {
        currentShip = Status.ship;
        PlayerPrefs.SetInt("Ship", currentShip);
    }

    static void saveHealth()
    {
        currentHealth = Status.health;
        PlayerPrefs.SetInt("Health", currentHealth);
    }

    static void saveLevel()
    {
        currentLevel = Status.playerLevel;
        PlayerPrefs.SetInt("Level", currentLevel);
    }

    static void saveWave()
    {
        currentWave = Status.wave;
        PlayerPrefs.SetInt("Wave",currentWave);
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
