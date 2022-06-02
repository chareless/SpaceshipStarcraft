using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text highScoreText;
    public Text arcEndlessHighScoreText;
    public Text arcLaserHighScoreText;
    public Text arcNoGunsHighScoreText;
    public Text arcOneHPHighScoreText;
    public Text arcShockHighScoreText;
    public Text arcRapidfireHighScoreText;
    public Text arcSpeedHighScoreText;
    public Text arcDefendHighScoreText;
    public Text arcMirrorHighScoreText;
    public Text arcInsaneHighScoreText;
    public Text versionText;
    public Text volumeText;
    public Text musicText;
    public Text speedText;
    public Text coinText;
    public Text ship3PriceText;
    public Text ship4PriceText;
    public Text ship5PriceText;
    public Text ship6PriceText;
    public Text ship7PriceText;
    public Text ship8PriceText;
    public Text ship9PriceText;
    public Text ship10PriceText;
    public Text ship11PriceText;
    public Text ship12PriceText;
    public Text ship13PriceText;
    public Button continueButton;
    public Button arcadeButton;
    public Button selectButton;
    public Button[] ships;
    public Button[] shopShips;
    public Slider volumeSlider;
    public Slider musicSlider;
    public Slider speedSlider;
    public GameObject[] objectShips;
    public GameObject MainMenuCanvas;
    public GameObject StartMenuCanvas;
    public GameObject OptionsMenuCanvas;
    public GameObject SelectShipCanvas1;
    public GameObject SelectShipCanvas2;
    public GameObject DefaultCanvas;
    public GameObject LoadingCanvas;
    public GameObject SelectCanvas;
    public GameObject ShopCanvas1;
    public GameObject ShopCanvas2;
    public GameObject ShopCanvasDefault;
    public GameObject ScoreCanvas1;
    public GameObject ScoreCanvas2;
    public GameObject ArcadeCanvas1;
    public GameObject ArcadeCanvas2;
    public GameObject QuitCanvas;
    public GameObject AchievementCanvas;
    public AudioSource clickSound;
    public AudioSource gameMusic;
    public AudioClip nextClip;
    public AudioClip backClip;
    public AudioClip purchase;
    public AudioClip cancel;
    public static string ownships;
    public static string[] Myships = new string[15];
    public static float volumeValue;
    public static float musicValue;
    public static float speedValue;
    public float timer;
    public static int maxFPS=60;
    public static int coin;
    public static int ship3Price;
    public static int ship4Price;
    public static int ship5Price;
    public static int ship6Price;
    public static int ship7Price;
    public static int ship8Price;
    public static int ship9Price;
    public static int ship10Price;
    public static int ship11Price;
    public static int ship12Price;
    public static int ship13Price;
    public static int maxShipCount = 13;

    public static bool saveGameFile;
    public bool shipClicked;
    public static bool selectCheck;
    public static int selectedWave;

    public GameObject ship13atshop;
    public GameObject ship13atselect;
    public static float rotateCounter;

    public static int currentBG;
    public static int savedBG;
    public Sprite[] bgs;
    public SpriteRenderer backGround;

    public GameObject[] TestInfos;
    public GameObject[] TestButtons;
    public Image[] tests;
    public Image[] infos;
    public GameObject buttonBack;
 
    void Start()
    {
        timer = 0.1f;
        saveGameFile = false;
        shipClicked = false;
        selectCheck = false;
        selectedWave = 0;
        ownships = "s1s2";
        MarketPrice();
        LoadValues();
        versionText.text = Application.version;
        Application.targetFrameRate = maxFPS;
        FileSave.TotalData();
    }

    public void MarketPrice()
    {
        ship3Price = 250;
        ship4Price = 300;
        ship5Price = 350;
        ship6Price = 400;
        ship7Price = 450;
        ship8Price = 1000000;

        ship9Price = 500;
        ship10Price = 550;
        ship11Price = 600;
        ship12Price = 700;
        ship13Price = 1000;
    }

    public void PlayNextButtonSound()
    {
        clickSound.PlayOneShot(nextClip);
    }
    public void PlayBackButtonSound()
    {
        clickSound.PlayOneShot(backClip);
    }
    public void PlayPurchaseSound()
    {
        clickSound.PlayOneShot(purchase);
    }
    public void PlayCancelSound()
    {
        clickSound.PlayOneShot(cancel);
    }

    public void PlayGame()
    {
        MainMenuCanvas.SetActive(false);
        StartMenuCanvas.SetActive(true);
        SpawnEnemies.isStoryMode = false;
        SpawnEnemies.isArcadeEndless = false;
        SpawnEnemies.isArcadeLaser = false;
        SpawnEnemies.isArcadeNoGuns = false;
        SpawnEnemies.isArcadeOneHP = false;
        SpawnEnemies.isArcadeShock = false;
        SpawnEnemies.isArcadeRapidfire = false;
        SpawnEnemies.isArcadeSpeed = false;
        SpawnEnemies.isArcadeDefend = false;
        SpawnEnemies.isArcadeMirror = false;
        SpawnEnemies.isArcadeInsane = false;
        selectCheck = false;
        selectedWave = 0;
        PlayNextButtonSound();
    }
    public void GoShop()
    {
        MainMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        ShopCanvas1.SetActive(true);
        ShopCanvasDefault.SetActive(true);
        PlayNextButtonSound();

    }
    public void QuitGame()
    {
        PlayBackButtonSound();
        Application.Quit();
    }
    public void VoteButton()
    {
        PlayNextButtonSound();
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.saribayirdeniz.SpaceshipStarcraft");
    }
    public void AchievementButton()
    {
        MainMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        AchievementCanvas.SetActive(true);
        PlayNextButtonSound();
    }
    public void Settings()
    {
        currentBG = savedBG;
        MainMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        OptionsMenuCanvas.SetActive(true);
        PlayNextButtonSound();
    }
    public void ShowScores()
    {
        MainMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        ScoreCanvas1.SetActive(true);
        PlayNextButtonSound();
    }
    public void NewGame()
    {
        StartMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        PlayNextButtonSound();
        saveGameFile = false;
        SpawnEnemies.isStoryMode = true;
    }
    public void Continue()
    {
        saveGameFile = true;
        SpawnEnemies.isStoryMode = true;
        PlayNextButtonSound();
        SceneManager.LoadScene("SampleScene");
    }
    public void CancelQuit()
    {
        QuitCanvas.SetActive(false);
        PlayNextButtonSound();
    }
    public void QuitButton()
    {
        QuitCanvas.SetActive(true);
        PlayBackButtonSound();
    }
    public void ArcadeButton()
    {
        StartMenuCanvas.SetActive(false);
        ArcadeCanvas1.SetActive(true);
        PlayNextButtonSound();
        saveGameFile = false;
    }
    public void SelectButton()
    {
        StartMenuCanvas.SetActive(false);
        SelectCanvas.SetActive(true);
        SpawnEnemies.isStoryMode = true;
        saveGameFile = false;
        PlayNextButtonSound();
    }
    public void ToMRCWebSite()
    {
        PlayNextButtonSound();
        Application.OpenURL("https://saribayirdeniz.cf");
    }
    public void ToGameWebSite()
    {
        PlayNextButtonSound();
        Application.OpenURL("http://saribayirdeniz.cf/spaceshipstarcraft.html");
    }


    public void ShopPrevButton()
    {
        if (ShopCanvas1.activeInHierarchy == true)
        {
            ShopCanvas1.SetActive(false);
            MainMenuCanvas.SetActive(true); 
            ShopCanvasDefault.SetActive(false);
            DefaultCanvas.SetActive(true);
        }
        else if (ShopCanvas2.activeInHierarchy == true)
        {
            ShopCanvas1.SetActive(true);
            ShopCanvas2.SetActive(false);
        }
        PlayBackButtonSound();
    }
    public void ShopNextButton()
    {
        if (ShopCanvas1.activeInHierarchy == true)
        {
            ShopCanvas1.SetActive(false);
            ShopCanvas2.SetActive(true);
        }
        else if (ShopCanvas2.activeInHierarchy == true)
        {
            ShopCanvas2.SetActive(false);
            ShopCanvas1.SetActive(true);
        }
        PlayNextButtonSound();
    }

    public void SaveDataButton()
    {
        OptionsMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(true);
        MainMenuCanvas.SetActive(true);
        PlayNextButtonSound();
        FileSave.SaveFile();
    }
    public void LoadDataButton()
    {
        OptionsMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(true);
        MainMenuCanvas.SetActive(true);
        PlayNextButtonSound();
        FileSave.LoadFile();
    }

    public void NextBGButton()
    {
        currentBG++;
        if(currentBG==8)
        {
            currentBG = 0;
        }
        backGround.sprite = bgs[currentBG];
        PlayNextButtonSound();
    }
    public void PrevBGButton()
    {
        currentBG--;
        if (currentBG == -1)
        {
            currentBG = 7;
        }
        backGround.sprite = bgs[currentBG];
        PlayNextButtonSound();

    }

    public void ScorePrevButton()
    {
        if (ScoreCanvas1.activeInHierarchy == true)
        {
            ScoreCanvas1.SetActive(false);
            MainMenuCanvas.SetActive(true);
            DefaultCanvas.SetActive(true);
        }
        else if (ScoreCanvas2.activeInHierarchy == true)
        {
            ScoreCanvas1.SetActive(true);
            ScoreCanvas2.SetActive(false);
        }
        PlayBackButtonSound();
    }
    public void ScoreNextButton()
    {
        if (ScoreCanvas1.activeInHierarchy == true)
        {
            ScoreCanvas1.SetActive(false);
            ScoreCanvas2.SetActive(true);
        }
        else if (ScoreCanvas2.activeInHierarchy == true)
        {
            ScoreCanvas2.SetActive(false);
            ScoreCanvas1.SetActive(true);
        }
        PlayNextButtonSound();
    }

    public void SelectPrevButton()
    {
        if (SelectShipCanvas1.activeInHierarchy == true)
        {
            SelectShipCanvas1.SetActive(false);
            MainMenuCanvas.SetActive(true);
            DefaultCanvas.SetActive(true);
        }
        else if (SelectShipCanvas2.activeInHierarchy == true)
        {
            SelectShipCanvas1.SetActive(true);
            SelectShipCanvas2.SetActive(false);
        }
        PlayBackButtonSound();
    }
    public void SelectNextButton()
    {
        if (SelectShipCanvas1.activeInHierarchy == true)
        {
            SelectShipCanvas1.SetActive(false);
            SelectShipCanvas2.SetActive(true);
        }
        else if (SelectShipCanvas2.activeInHierarchy == true)
        {
            SelectShipCanvas2.SetActive(false);
            SelectShipCanvas1.SetActive(true);
        }
        PlayNextButtonSound();
    }

    public void BackButton()
    {
        backGround.sprite = bgs[savedBG];
        MainMenuCanvas.SetActive(true);
        AchievementCanvas.SetActive(false);
        ArcadeCanvas1.SetActive(false);
        ArcadeCanvas2.SetActive(false);
        DefaultCanvas.SetActive(true);
        OptionsMenuCanvas.SetActive(false);
        StartMenuCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(false);
        SelectShipCanvas2.SetActive(false);
        SelectCanvas.SetActive(false);
        ShopCanvas1.SetActive(false);
        ShopCanvas2.SetActive(false);
        ShopCanvasDefault.SetActive(false);
        ScoreCanvas1.SetActive(false);
        ScoreCanvas2.SetActive(false);
        PlayBackButtonSound();
    }
    public void SaveButton()
    {
        savedBG = currentBG;
        PlayerPrefs.SetInt("BGNo", savedBG);
        volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        speedValue = speedSlider.value;
        PlayerPrefs.SetFloat("SpeedValue", speedValue);
        musicValue = musicSlider.value;
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("ChangeValues", 1);
        LoadValues();
        OptionsMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(true);
        MainMenuCanvas.SetActive(true);
        PlayNextButtonSound();
    }

    public void ArcadePrevButton()
    {
        if (ArcadeCanvas1.activeInHierarchy == true)
        {
            ArcadeCanvas1.SetActive(false);
            MainMenuCanvas.SetActive(true);
        }
        else if (ArcadeCanvas2.activeInHierarchy == true)
        {
            ArcadeCanvas1.SetActive(true);
            ArcadeCanvas2.SetActive(false);
        }
        PlayBackButtonSound();
    }
    public void ArcadeNextButton()
    {
        if (ArcadeCanvas1.activeInHierarchy == true)
        {
            ArcadeCanvas1.SetActive(false);
            ArcadeCanvas2.SetActive(true);
        }
        else if (ArcadeCanvas2.activeInHierarchy == true)
        {
            ArcadeCanvas2.SetActive(false);
            ArcadeCanvas1.SetActive(true);
        }
        PlayNextButtonSound();
    }


    public void Wave1Button()
    {
        selectCheck = true;
        selectedWave = 1;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave2Button()
    {
        selectCheck = true;
        selectedWave = 2;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave3Button()
    {
        selectCheck = true;
        selectedWave = 3;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave4Button()
    {
        selectCheck = true;
        selectedWave = 4;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave5Button()
    {
        selectCheck = true;
        selectedWave = 5;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave6Button()
    {
        selectCheck = true;
        selectedWave = 6;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave7Button()
    {
        selectCheck = true;
        selectedWave = 7;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave8Button()
    {
        selectCheck = true;
        selectedWave = 8;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }
    public void Wave9Button()
    {
        selectCheck = true;
        selectedWave = 9;
        SelectShipCanvas1.SetActive(true);
        SelectCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
    }


    public void ArcadeEndlessModeButton()
    {
        ArcadeCanvas1.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeEndless = true;
        PlayNextButtonSound();
    }
    public void ArcadeLaserModeButton()
    {
        ArcadeCanvas1.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeLaser = true;
        PlayNextButtonSound();
    }
    public void ArcadeShockModeButton()
    {
        ArcadeCanvas1.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeShock = true;
        PlayNextButtonSound();
    }
    public void ArcadeNoGunsModeButton()
    {
        ArcadeCanvas1.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeNoGuns = true;
        PlayNextButtonSound();
    }
    public void ArcadeOneHPModeButton()
    {
        ArcadeCanvas1.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeOneHP = true;
        PlayNextButtonSound();
    }
    public void ArcadeRapidfireModeButton()
    {
        ArcadeCanvas2.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeRapidfire = true;
        PlayNextButtonSound();
    }
    public void ArcadeSpeedModeButton()
    {
        ArcadeCanvas2.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeSpeed = true;
        PlayNextButtonSound();
    }
    public void ArcadeDefendModeButton()
    {
        ArcadeCanvas2.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeDefend = true;
        PlayNextButtonSound();
    }
    public void ArcadeMirrorModeButton()
    {
        ArcadeCanvas2.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeMirror = true;
        PlayNextButtonSound();
    }
    public void ArcadeInsaneModeButton()
    {
        ArcadeCanvas2.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas1.SetActive(true);
        SpawnEnemies.isArcadeInsane = true;
        PlayNextButtonSound();
    }


    public void Test1Button()
    {
        for(int i=0;i<TestInfos.Length;i++)
        {
            TestButtons[i].SetActive(false);
        }
        TestInfos[0].SetActive(true);
        buttonBack.SetActive(false);
        PlayNextButtonSound();
    }
    public void Test2Button()
    {
        for (int i = 0; i < TestInfos.Length; i++)
        {
            TestButtons[i].SetActive(false);
        }
        TestInfos[1].SetActive(true);
        buttonBack.SetActive(false);
        PlayNextButtonSound();
    }
    public void Test3Button()
    {
        for (int i = 0; i < TestInfos.Length; i++)
        {
            TestButtons[i].SetActive(false);
        }
        TestInfos[2].SetActive(true);
        buttonBack.SetActive(false);
        PlayNextButtonSound();
    }
    public void Test4Button()
    {
        for (int i = 0; i < TestInfos.Length; i++)
        {
            TestButtons[i].SetActive(false);
        }
        TestInfos[3].SetActive(true);
        buttonBack.SetActive(false);
        PlayNextButtonSound();
    }
    public void Test5Button()
    {
        for (int i = 0; i < TestInfos.Length; i++)
        {
            TestButtons[i].SetActive(false);
        }
        TestInfos[4].SetActive(true);
        buttonBack.SetActive(false);
        PlayNextButtonSound();
    }
    public void Test6Button()
    {
        for (int i = 0; i < TestInfos.Length; i++)
        {
            TestButtons[i].SetActive(false);
        }
        TestInfos[5].SetActive(true);
        buttonBack.SetActive(false);
        PlayNextButtonSound();
    }
    public void TestBackButton()
    {
        for (int i = 0; i < TestInfos.Length; i++)
        {
            TestButtons[i].SetActive(true);
            TestInfos[i].SetActive(false);
        }
        buttonBack.SetActive(true);
        PlayBackButtonSound();
    }


    public void VolumeSlider(float volume)
    {
        volumeText.text = (volume * 100).ToString("F0");
    }
    public void MusicSlider(float volume)
    {
        musicText.text = (volume * 100).ToString("F0");
    }
    public void SpeedSlider(float speed)
    {
        speedText.text = (speed).ToString("F0") + "x";
    }


    public void ArcadeControl()
    {
        if (PlayerPrefs.GetInt("End") == 0)
        {
            arcadeButton.interactable = false;
            selectButton.interactable = false;
        }
        else if (PlayerPrefs.GetInt("End") == 1)
        {
            arcadeButton.interactable = true;
            selectButton.interactable = true;
        }
    }
    public void VolumeControl()
    {
        if(PlayerPrefs.GetInt("ChangeValues")==1)
        {
            volumeValue = PlayerPrefs.GetFloat("VolumeValue");
            volumeSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }
        else
        {
            volumeValue = 1;
            volumeSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }
        
    }
    public void MusicControl()
    {
        if (PlayerPrefs.GetInt("ChangeValues") == 1)
        {
            musicValue = PlayerPrefs.GetFloat("MusicValue");
            musicSlider.value = musicValue;
            gameMusic.volume = musicValue;
        }
        else
        {
            musicValue = 1;
            musicSlider.value = musicValue;
            gameMusic.volume = musicValue;
        }
            
    }
    public void SpeedControl()
    {
        if(PlayerPrefs.GetInt("ChangeValues")==1)
        {
            speedValue = PlayerPrefs.GetFloat("SpeedValue");
            speedSlider.value = speedValue;
        }
        else
        {
            speedValue = 3;
            speedSlider.value = speedValue;
        }
        
    }
    public void ContinueControl()
    {
        if (LoadData.loadedWave == 0 || LoadData.loadedWave == 1)
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }
    public void ScoreControl()
    {
        highScoreText.text = LoadData.loadedHigh.ToString();
        arcEndlessHighScoreText.text = LoadData.loadedArcEndlessHigh.ToString();
        arcLaserHighScoreText.text = LoadData.loadedArcLaserHigh.ToString();
        arcNoGunsHighScoreText.text = LoadData.loadedArcNoGunsHigh.ToString();
        arcOneHPHighScoreText.text = LoadData.loadedArcOneHPHigh.ToString();
        arcShockHighScoreText.text = LoadData.loadedArcShockHigh.ToString();
        arcRapidfireHighScoreText.text = LoadData.loadedArcRapidfireHigh.ToString();
        arcSpeedHighScoreText.text = LoadData.loadedArcSpeedHigh.ToString();
        arcDefendHighScoreText.text = LoadData.loadedArcDefendHigh.ToString();
        arcMirrorHighScoreText.text = LoadData.loadedArcMirrorHigh.ToString();
        arcInsaneHighScoreText.text = LoadData.loadedArcInsaneHigh.ToString();
    }
    public void ShipsControl()
    {
        ownships = LoadData.loadedMyShips;
        string[] temp = ownships.Split('s');
        int count = 0;
        foreach (string s in temp)
        {
            Myships[count] = s;
            count++;

        }
        for (int i = 1; i <= maxShipCount; i++)
        {
            for (int j = 0; j < maxShipCount; j++)
            {
                if (i.ToString() == (Myships[j]))
                {
                    shopShips[i - 1].interactable = false;
                    objectShips[i - 1].SetActive(true);
                }
            }
        }

    }
    public void ShopControl()
    {
        if(Achievements.unit1Controls[0]==true)
        {
            ship8Price = 0;
        }

        if (shopShips[2].interactable == false)
        {
            ship3Price = 0;
        }
        if (shopShips[3].interactable == false)
        {
            ship4Price = 0;
        }
        if (shopShips[4].interactable == false)
        {
            ship5Price = 0;
        }
        if (shopShips[5].interactable == false)
        {
            ship6Price = 0;
        }
        if (shopShips[6].interactable == false)
        {
            ship7Price = 0;
        }
        if (shopShips[7].interactable == false)
        {
            ship8Price = 0;
        }
        if (shopShips[8].interactable == false)
        {
            ship9Price = 0;
        }
        if (shopShips[9].interactable == false)
        {
            ship10Price = 0;
        }
        if (shopShips[10].interactable == false)
        {
            ship11Price = 0;
        }
        if (shopShips[11].interactable == false)
        {
            ship12Price = 0;
        }
        if (shopShips[12].interactable == false)
        {
            ship13Price = 0;
        }

        if (ship3Price == 0)
        {
            ship3PriceText.text = " ";
        }
        else
        {
            ship3PriceText.text = ship3Price.ToString() + " C";
        }

        if (ship4Price == 0)
        {
            ship4PriceText.text = " ";
        }
        else
        {
            ship4PriceText.text = ship4Price.ToString() + " C";
        }

        if (ship5Price == 0)
        {
            ship5PriceText.text = " ";
        }
        else
        {
            ship5PriceText.text = ship5Price.ToString() + " C";
        }

        if (ship6Price == 0)
        {
            ship6PriceText.text = " ";
        }
        else
        {
            ship6PriceText.text = ship6Price.ToString() + " C";
        }

        if (ship7Price == 0)
        {
            ship7PriceText.text = " ";
        }
        else
        {
            ship7PriceText.text = ship7Price.ToString() + " C";
        }
        if (ship8Price == 0)
        {
            ship8PriceText.text = " ";
        }
        else
        {
            ship8PriceText.text = ship8Price.ToString() + " C";
        }
        if (ship9Price == 0)
        {
            ship9PriceText.text = " ";
        }
        else
        {
            ship9PriceText.text = ship9Price.ToString() + " C";
        }
        if (ship10Price == 0)
        {
            ship10PriceText.text = " ";
        }
        else
        {
            ship10PriceText.text = ship10Price.ToString() + " C";
        }
        if (ship11Price == 0)
        {
            ship11PriceText.text = " ";
        }
        else
        {
            ship11PriceText.text = ship11Price.ToString() + " C";
        }
        if (ship12Price == 0)
        {
            ship12PriceText.text = " ";
        }
        else
        {
            ship12PriceText.text = ship12Price.ToString() + " C";
        }
        if (ship13Price == 0)
        {
            ship13PriceText.text = " ";
        }
        else
        {
            ship13PriceText.text = ship13Price.ToString() + " C";
        }
    }
    public void MoneyControl()
    {
        coin = LoadData.loadedCoin;
        coinText.text = coin.ToString() + " C";
    }
    public void BackGroundControl()
    {
        savedBG = PlayerPrefs.GetInt("BGNo");
        backGround.sprite = bgs[savedBG];
    }
    public void RotateShip()
    {
        rotateCounter += Time.deltaTime * 100;
        ship13atshop.transform.rotation = Quaternion.Euler(0, 0, rotateCounter);
        ship13atselect.transform.rotation = Quaternion.Euler(0, 0, rotateCounter);
    }

    public void Unit1TestControl()
    {
        for (int i=0;i<Achievements.maxAchCount-1;i++)
        {
            if(Achievements.unit1Controls[i]==true)
            {
                tests[i].GetComponent<Image>();
                tests[i].color = new Color(1,0,0.65f,1);

                infos[i].GetComponent<Image>();
                infos[i].color = new Color(1, 0, 0.62f, 1);
            }
        }
    }


    public void ship1Button()
    {
        Status.ship = 1;
        for(int i=0;i<maxShipCount;i++)
        {
            if(i!=Status.ship-1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship2Button()
    {
        Status.ship = 2;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship3Button()
    {
        Status.ship = 3;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship4Button()
    {
        Status.ship = 4;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship5Button()
    {
        Status.ship = 5;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship6Button()
    {
        Status.ship = 6;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship7Button()
    {
        Status.ship = 7;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship8Button()
    {
        Status.ship = 8;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship9Button()
    {
        Status.ship = 9;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship10Button()
    {
        Status.ship = 10;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship11Button()
    {
        Status.ship = 11;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship12Button()
    {
        Status.ship = 12;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }
    public void ship13Button()
    {
        Status.ship = 13;
        for (int i = 0; i < maxShipCount; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
        shipClicked = true;
    }

    public void ship3ShopButton()
    {
        if(coin>=ship3Price)
        {
            ownships += "s3";
            SaveData.saveMyShips();
            coin-=ship3Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship4ShopButton()
    {
        if (coin >= ship4Price)
        {
            ownships += "s4";
            SaveData.saveMyShips();
            coin-= ship4Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship5ShopButton()
    {
        if (coin >= ship5Price)
        {
            ownships += "s5";
            SaveData.saveMyShips();
            coin -= ship5Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship6ShopButton()
    {
        if (coin >= ship6Price)
        {
            ownships += "s6";
            SaveData.saveMyShips();
            coin -= ship6Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship7ShopButton()
    {
        if (coin >= ship7Price)
        {
            ownships += "s7";
            SaveData.saveMyShips();
            coin -= ship7Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship8ShopButton()
    {
        if (coin >= ship8Price)
        {
            ownships += "s8";
            SaveData.saveMyShips();
            coin -= ship8Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship9ShopButton()
    {
        if (coin >= ship9Price)
        {
            ownships += "s9";
            SaveData.saveMyShips();
            coin -= ship9Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship10ShopButton()
    {
        if (coin >= ship10Price)
        {
            ownships += "s10";
            SaveData.saveMyShips();
            coin -= ship10Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship11ShopButton()
    {
        if (coin >= ship11Price)
        {
            ownships += "s11";
            SaveData.saveMyShips();
            coin -= ship11Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship12ShopButton()
    {
        if (coin >= ship12Price)
        {
            ownships += "s12";
            SaveData.saveMyShips();
            coin -= ship12Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }
    public void ship13ShopButton()
    {
        if (coin >= ship13Price)
        {
            ownships += "s13";
            SaveData.saveMyShips();
            coin -= ship13Price;
            SaveData.saveCoin();
            PlayerPrefs.Save();
            PlayPurchaseSound();
            LoadValues();
        }
        else
        {
            PlayCancelSound();
        }
    }


    public void LoadValues()
    {
        LoadData.loadData();

        Achievements.AchControl();

        ArcadeControl();

        VolumeControl();

        SpeedControl();

        MusicControl();

        ContinueControl();

        ScoreControl();

        ShipsControl();

        MoneyControl();

        ShopControl();

        BackGroundControl();

        Unit1TestControl();
    }

    public void Update()
    {
        RotateShip();
        ShipsControl();
        MoneyControl();
        ShopControl();
        Achievements.AchControl();
        Unit1TestControl();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (QuitCanvas.activeInHierarchy == false)
            {
                QuitCanvas.SetActive(true);
            }
            else
            {
                QuitCanvas.SetActive(false);
            }
        }

        if (shipClicked == true)
        {
            LoadingCanvas.SetActive(true);
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}