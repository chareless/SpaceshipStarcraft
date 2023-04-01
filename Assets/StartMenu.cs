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
    public Text[] shipPriceTexts;
    public Button continueButton;
    public Button arcadeButton;
    public Button selectButton;
    public Button[] shopShips;
    public Button[] WaveButtons;
    public Button[] ArcadeButtons;
    public Slider volumeSlider;
    public Slider musicSlider;
    public Slider speedSlider;
    public GameObject[] ships;
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
    public static int coin;
    public int[] shipPrices;
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
        LoadValues();
        versionText.text = Application.version;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        FileSave.TotalData();
        ListenerInitialize();
    }

    public void ListenerInitialize()
    {
        AddSelectShipButtonsListeners();
        AddShopShipButtonsListeners();
        AddSelectWaveButtonsListeners();
        AddTestButtonsListeners();
        AddArcadeButtonsListeners();
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
        volumeSlider.value = volumeValue;
        musicSlider.value = musicValue;
        speedSlider.value = speedValue;
        volumeText.text = (volumeValue * 100).ToString("F0");
        musicText.text = (musicValue * 100).ToString("F0");
        speedText.text = (speedValue).ToString("F0") + "x";
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
                    ships[i - 1].SetActive(true);
                }
            }
        }
    }
    public void ShopControl()
    {
        if(Achievements.unit1Controls[0]==true)
        {
            shipPrices[7] = 0;
        }

        for(int i=0;i<shopShips.Length;i++)
        {
            if (shopShips[i].interactable == false)
            {
                shipPrices[i] = 0;
            }

            if (shipPrices[i] == 0)
            {
                shipPriceTexts[i].text = " ";
            }
            else
            {
                shipPriceTexts[i].text = shipPrices[i].ToString() + " C";
            }
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

    public void AddArcadeButtonsListeners()
    {
        for (int index = 0; index < ArcadeButtons.Length; ++index)
        {
            if (ArcadeButtons[index] != null)
                AddArcadeButtonListener(ArcadeButtons[index].GetComponent<Button>(), index);
        }
    }
    public void AddArcadeButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            ArcadeCanvas1.SetActive(false);
            ArcadeCanvas2.SetActive(false);
            DefaultCanvas.SetActive(false);
            SelectShipCanvas1.SetActive(true);
            switch(index)
            {
                case 0:
                    SpawnEnemies.isArcadeEndless = true;
                    break;
                case 1:
                    SpawnEnemies.isArcadeLaser = true;
                    break;
                case 2:
                    SpawnEnemies.isArcadeShock = true;
                    break;
                case 3:
                    SpawnEnemies.isArcadeNoGuns = true;
                    break;
                case 4:
                    SpawnEnemies.isArcadeOneHP = true;
                    break;
                case 5:
                    SpawnEnemies.isArcadeRapidfire = true;
                    break;
                case 6:
                    SpawnEnemies.isArcadeSpeed = true;
                    break;
                case 7:
                    SpawnEnemies.isArcadeDefend = true;
                    break;
                case 8:
                    SpawnEnemies.isArcadeMirror = true;
                    break;
                case 9:
                    SpawnEnemies.isArcadeInsane = true;
                    break;
            }
           
            PlayNextButtonSound();
        });
    }
    public void AddTestButtonsListeners()
    {
        for (int index = 0; index < TestButtons.Length; ++index)
        {
            if (TestButtons[index] != null)
                AddTestButtonListener(TestButtons[index].GetComponent<Button>(), index);
        }
    }
    public void AddTestButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            for (int i = 0; i < TestInfos.Length; i++)
            {
                TestButtons[i].SetActive(false);
            }
            TestInfos[index].SetActive(true);
            buttonBack.SetActive(false);
            PlayNextButtonSound();
        });
    }
    public void AddSelectWaveButtonsListeners()
    {
        for (int index = 0; index < WaveButtons.Length; ++index)
        {
            if (WaveButtons[index] != null)
                AddSelectWaveButtonListener(WaveButtons[index], index);
        }
    }
    public void AddSelectWaveButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            selectCheck = true;
            selectedWave = index+1;
            SelectShipCanvas1.SetActive(true);
            SelectCanvas.SetActive(false);
            DefaultCanvas.SetActive(false);
            PlayNextButtonSound();
        });
    }
    public void AddSelectShipButtonsListeners()
    {
        for (int index = 0; index < ships.Length; ++index)
        {
            if (ships[index] != null)
                AddSelectShipButtonListener(ships[index].GetComponent<Button>(), index);
        }
    }
    public void AddSelectShipButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            Status.ship = index + 1;
            for (int i = 0; i < maxShipCount; i++)
            {
                if (i != Status.ship - 1)
                {
                    ships[i].GetComponent<Button>().interactable = false;
                }
            }
            PlayNextButtonSound();
            shipClicked = true;
        });
    }
    public void AddShopShipButtonsListeners()
    {
        for (int index = 0; index < shopShips.Length; ++index)
        {
            if (shopShips[index] != null)
                AddShopShipButtonListener(shopShips[index], index);
        }
    }
    public void AddShopShipButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            if (coin >= shipPrices[index])
            {
                ownships += "s" + (index + 1);
                SaveData.saveMyShips();
                coin -= shipPrices[index];
                SaveData.saveCoin();
                PlayerPrefs.Save();
                PlayPurchaseSound();
                LoadValues();
            }
            else
            {
                PlayCancelSound();
            }

        });
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