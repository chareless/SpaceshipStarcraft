using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileSave : MonoBehaviour
{
    public static bool dataControl;
    public static string loadData;
    public static string[] splitData;
    public static string fullData = "";
    public static string ownShips;
    public static int coin;
    public static int gameEnd;
    public static int currentScore;
    public static int currentHealth;
    public static int currentLevel;
    public static int currentWave;
    public static int currentKill;
    public static int currentShip;
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
    public static int totalEnd;
    public static string achs;


    static void GetData()
    {
        ownShips = StartMenu.ownships;
        coin = StartMenu.coin;
        gameEnd = PlayerPrefs.GetInt("End");
        currentScore = PlayerPrefs.GetInt("Score");
        currentHealth = PlayerPrefs.GetInt("Health");
        currentLevel = PlayerPrefs.GetInt("Level");
        currentWave = PlayerPrefs.GetInt("Wave");
        currentKill = PlayerPrefs.GetInt("Kill");
        currentShip = PlayerPrefs.GetInt("Ship");
        loadedHigh = PlayerPrefs.GetInt("Highscore");
        loadedArcEndlessHigh = PlayerPrefs.GetInt("ArcEndlessHighscore");
        loadedArcLaserHigh = PlayerPrefs.GetInt("ArcLaserHighscore");
        loadedArcNoGunsHigh = PlayerPrefs.GetInt("ArcNoGunsHighscore");
        loadedArcOneHPHigh = PlayerPrefs.GetInt("ArcOneHPHighscore");
        loadedArcShockHigh = PlayerPrefs.GetInt("ArcShockHighscore");
        loadedArcRapidfireHigh = PlayerPrefs.GetInt("ArcRapidfireHighscore");
        loadedArcSpeedHigh = PlayerPrefs.GetInt("ArcSpeedHighscore");
        loadedArcDefendHigh = PlayerPrefs.GetInt("ArcDefendHighscore");
        loadedArcMirrorHigh = PlayerPrefs.GetInt("ArcMirrorHighscore");
        loadedArcInsaneHigh = PlayerPrefs.GetInt("ArcInsaneHighscore");
        totalEnd = PlayerPrefs.GetInt("TotalEnd");
        achs = Achievements.achievements;

}
    public static void TotalData()
    {
        GetData();
        fullData = ownShips + ":" + coin + ":" + gameEnd + ":" + currentScore + ":" + currentHealth + ":" + currentLevel +
            ":" + currentWave + ":" + currentKill + ":" + currentShip + ":" + loadedHigh + ":" + loadedArcEndlessHigh +
            ":" + loadedArcLaserHigh + ":" + loadedArcNoGunsHigh + ":" + loadedArcOneHPHigh + ":" + loadedArcShockHigh +
            ":" + loadedArcRapidfireHigh + ":" + loadedArcSpeedHigh + ":" + loadedArcDefendHigh + ":" + loadedArcMirrorHigh +
            ":" + loadedArcInsaneHigh + ":" + totalEnd + ":" + achs;
    }

    public static void SaveFile()
    {
        TotalData();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, fullData);
        stream.Close();
    }

    public static void LoadFile()
    {
        dataControl = false;
        string path = Application.persistentDataPath + "/save.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            loadData = (string)formatter.Deserialize(stream);
            dataControl = true;
            stream.Close();
        }

        if(dataControl)
        {
            splitData = loadData.Split(":");
            StartMenu.ownships = splitData[0];
            StartMenu.coin = Convert.ToInt32(splitData[1]);
            PlayerPrefs.SetInt("End", Convert.ToInt32(splitData[2]));
            PlayerPrefs.SetInt("Score", Convert.ToInt32(splitData[3]));
            PlayerPrefs.SetInt("Health", Convert.ToInt32(splitData[4]));
            PlayerPrefs.SetInt("Level", Convert.ToInt32(splitData[5]));
            PlayerPrefs.SetInt("Wave", Convert.ToInt32(splitData[6]));
            PlayerPrefs.SetInt("Kill", Convert.ToInt32(splitData[7]));
            PlayerPrefs.SetInt("Ship", Convert.ToInt32(splitData[8]));
            PlayerPrefs.SetInt("Highscore", Convert.ToInt32(splitData[9]));
            PlayerPrefs.SetInt("ArcEndlessHighscore", Convert.ToInt32(splitData[10]));
            PlayerPrefs.SetInt("ArcLaserHighscore", Convert.ToInt32(splitData[11]));
            PlayerPrefs.SetInt("ArcNoGunsHighscore", Convert.ToInt32(splitData[12]));
            PlayerPrefs.SetInt("ArcOneHPHighscore", Convert.ToInt32(splitData[13]));
            PlayerPrefs.SetInt("ArcShockHighscore", Convert.ToInt32(splitData[14]));
            PlayerPrefs.SetInt("ArcRapidfireHighscore", Convert.ToInt32(splitData[15]));
            PlayerPrefs.SetInt("ArcSpeedHighscore", Convert.ToInt32(splitData[16]));
            PlayerPrefs.SetInt("ArcDefendHighscore", Convert.ToInt32(splitData[17]));
            PlayerPrefs.SetInt("ArcMirrorHighscore", Convert.ToInt32(splitData[18]));
            PlayerPrefs.SetInt("ArcInsaneHighscore", Convert.ToInt32(splitData[19]));
            PlayerPrefs.SetInt("TotalEnd", Convert.ToInt32(splitData[20]));
            Achievements.achievements = splitData[21];
            PlayerPrefs.Save();
            SaveData.saveData();
            LoadData.loadData();
        }
    }
}