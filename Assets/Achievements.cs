using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public static bool[] unit1Controls = new bool[6];
    public static string achievements = "";
    public static int maxAchCount = 6;
    public static string[] Myachs = new string[10];

    static void AchCheck()
    {
        achievements = LoadData.loadedAchs;
        if(achievements!= "")
        {
            string[] temp = achievements.Split('a');
            int count = 0;
            foreach (string s in temp)
            {
                Myachs[count] = s;
                count++;
            }
            for (int i = 1; i <= maxAchCount; i++)
            {
                for (int j = 0; j < maxAchCount; j++)
                {
                    if (i.ToString() == (Myachs[j]))
                    {
                        unit1Controls[i-1] = true;
                    }
                }
            }
        }
    }
    static void U1T1Control()
    {
        if(unit1Controls[0]==false)
        {
            if (PlayerPrefs.GetInt("End") == 1)
            {
                achievements += "a1";
                SaveData.saveAch();
                unit1Controls[0] = true;
                LoadData.loadData();
            }
        }
    }
    static void U1T2Control()
    {
        if (unit1Controls[1] == false)
        {
            if(PlayerPrefs.GetInt("TotalEnd")==10)
            {
                StartMenu.coin += 500;
                SaveData.saveCoin();
                achievements += "a2";
                SaveData.saveAch();
                unit1Controls[1] = true;
                LoadData.loadData();
            }
        }
    }
    static void U1T3Control()
    {
        if (unit1Controls[2] == false)
        {
            if (LoadData.loadedArcDefendHigh > 0 && LoadData.loadedArcEndlessHigh > 0 && LoadData.loadedArcInsaneHigh > 0
                && LoadData.loadedArcLaserHigh > 0 && LoadData.loadedArcMirrorHigh > 0 && LoadData.loadedArcNoGunsHigh > 0
                && LoadData.loadedArcOneHPHigh > 0 && LoadData.loadedArcRapidfireHigh > 0 && LoadData.loadedArcShockHigh > 0
                && LoadData.loadedArcSpeedHigh > 0)
            {
                StartMenu.coin += 100;
                SaveData.saveCoin();
                achievements += "a3";
                SaveData.saveAch();
                unit1Controls[2] = true;
                LoadData.loadData();
            }
        }

    }
    static void U1T4Control()
    {
        if (unit1Controls[3] == false)
        {
            string[] ships = StartMenu.ownships.Split('s');
            if(ships.Length>5)
            {
                StartMenu.coin += 200;
                SaveData.saveCoin();
                achievements += "a4";
                SaveData.saveAch();
                unit1Controls[3] = true;
                LoadData.loadData();
            }
        }
    }
    static void U1T5Control()
    {
        if (unit1Controls[4] == false)
        {
            if(SpawnEnemies.isStoryMode == true && Status.health == 1000 && Status.ship == 13 && PlayerPrefs.GetInt("End") == 1)
            {
                StartMenu.coin += 500;
                SaveData.saveCoin();
                achievements += "a5";
                SaveData.saveAch();
                unit1Controls[4] = true;
                LoadData.loadData();
            }
        }
    }
    static void U1T6Control()
    {
        if (unit1Controls[5] == false)
        {
            if (SpawnEnemies.isArcadeOneHP == true && Status.totalKill >= 1000)
            {
                StartMenu.coin += 500;
                SaveData.saveCoin();
                achievements += "a6";
                SaveData.saveAch();
                unit1Controls[5] = true;
                LoadData.loadData();
            }
        }
    }


    public static void UnitControl()
    {
        U1T1Control();
        U1T2Control();
        U1T3Control();
        U1T4Control();
        U1T5Control();
        U1T6Control();
    }

    public static void AchControl()
    {
        AchCheck();
        UnitControl();
    }
}
