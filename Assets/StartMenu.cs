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
    public Text arcHighScoreText;
    public Text versionText;
    public Text volumeText;
    public Text fpsText;
    public Text speedText;
    public Text coinText;
    public Button continueButton;
    public Button arcadeButton;
    public Button button60b;
    public Button button90b;
    public Button[] ships;
    public GameObject[] objectShips;
    public Button[] shopShips;
    public Slider volumeSlider;
    public Slider speedSlider;
    public GameObject MainMenuCanvas;
    public GameObject StartMenuCanvas;
    public GameObject OptionsMenuCanvas;
    public GameObject SelectShipCanvas;
    public GameObject DefaultCanvas;
    public GameObject ShopCanvas;
    public AudioSource clickSound;
    public AudioClip nextClip;
    public AudioClip backClip;
    public static int maxFPS;
    public static float volumeValue;
    public static float speedValue;
    public static bool saveGameFile;
    public bool shipClicked;

    public AudioClip purchase;
    public AudioClip cancel;
    public static int coin;
    public static string ownships;
    public static string[] Myships = new string[10];
    public static int ship3Price;
    public static int ship4Price;
    public static int ship5Price;
    public static int ship6Price;
    public static int ship7Price;
    public static int ship8Price;
    public Text ship3PriceText;
    public Text ship4PriceText;
    public Text ship5PriceText;
    public Text ship6PriceText;
    public Text ship7PriceText;
    public Text ship8PriceText;

    void Start()
    {
        maxFPS = 60;
        saveGameFile = false;
        shipClicked = false;
        ownships = "s1s2";
        ship3Price = 200;
        ship4Price = 250;
        ship5Price = 300;
        ship6Price = 400;
        ship7Price = 500;
        ship8Price = 1000000;

        LoadValues();
        versionText.text = Application.version;
        highScoreText.text = LoadData.loadedHigh.ToString();
        arcHighScoreText.text = LoadData.loadedArcHigh.ToString();
        fpsText.text = Application.targetFrameRate.ToString();
        coinText.text = coin.ToString() + " C";
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
        PlayNextButtonSound();
    }

    public void GoShop()
    {
        MainMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        ShopCanvas.SetActive(true);
        PlayNextButtonSound();
    }

    public void QuitGame()
    {
        PlayBackButtonSound();
        Application.Quit();
    }

    public void Settings()
    {
        MainMenuCanvas.SetActive(false);
        OptionsMenuCanvas.SetActive(true);
        if(Application.targetFrameRate==60)
        {
            button60b.interactable = false;
            button90b.interactable = true;
        }
        if (Application.targetFrameRate == 90)
        {
            button90b.interactable = false;
            button60b.interactable = true;
        }
        PlayNextButtonSound();
    }

    public void NewGame()
    {
        StartMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas.SetActive(true);
        PlayNextButtonSound();
        saveGameFile = false;
        SpawnEnemies.isArcade = false;
    }

    public void Continue()
    {
        saveGameFile = true;
        SpawnEnemies.isArcade = false;
        PlayNextButtonSound();
        SceneManager.LoadScene("SampleScene");
    }

    public void BackButton()
    {
        MainMenuCanvas.SetActive(true);
        DefaultCanvas.SetActive(true);
        OptionsMenuCanvas.SetActive(false);
        StartMenuCanvas.SetActive(false);
        SelectShipCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        PlayBackButtonSound();
    }

    public void Button60()
    {
        maxFPS = 60;
        button60b.interactable = false;
        button90b.interactable = true;
        PlayNextButtonSound();
    }

    public void Button90()
    {
        maxFPS = 90;
        button90b.interactable = false;
        button60b.interactable = true;
        PlayNextButtonSound();
    }

    public void SaveButton()
    {
        volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        PlayerPrefs.SetInt("MaxFPS", maxFPS);
        speedValue = speedSlider.value;
        PlayerPrefs.SetFloat("SpeedValue", speedValue);
        PlayerPrefs.Save();
        LoadValues();
        OptionsMenuCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
        PlayNextButtonSound();
    }

    public void ArcadeButton()
    {
        StartMenuCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        SelectShipCanvas.SetActive(true);
        SpawnEnemies.isArcade = true;
        PlayNextButtonSound();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = (volume * 100).ToString("F0");
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
        }
        if (PlayerPrefs.GetInt("End") == 1)
        {
            arcadeButton.interactable = true;
        }
    }

    public void VolumeControl()
    {
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void FPSControl()
    {
        if (PlayerPrefs.GetInt("MaxFPS") != 0)
        {
            maxFPS = PlayerPrefs.GetInt("MaxFPS");
        }
        Application.targetFrameRate = maxFPS;
        fpsText.text = Application.targetFrameRate.ToString();
        if (Application.targetFrameRate == 60)
        {
            button60b.interactable = false;
            button90b.interactable = true;
        }
        if (Application.targetFrameRate == 90)
        {
            button90b.interactable = false;
            button60b.interactable = true;
        }
    }

    public void SpeedControl()
    {
        speedValue = PlayerPrefs.GetFloat("SpeedValue");
        speedSlider.value = speedValue;
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
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 0; j < 10; j++)
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
        if (PlayerPrefs.GetInt("End") == 1)
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
    }

    public void MoneyControl()
    {
        coin = LoadData.loadedCoin;
    }

    public void ship1Button()
    {
        Status.ship = 1;
        shipClicked = true;
        for(int i=0;i<8;i++)
        {
            if(i!=Status.ship-1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }
    public void ship2Button()
    {
        Status.ship = 2;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }
    public void ship3Button()
    {
        Status.ship = 3;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }

    public void ship4Button()
    {
        Status.ship = 4;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }

    public void ship5Button()
    {
        Status.ship = 5;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }

    public void ship6Button()
    {
        Status.ship = 6;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }

    public void ship7Button()
    {
        Status.ship = 7;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
    }

    public void ship8Button()
    {
        Status.ship = 8;
        shipClicked = true;
        for (int i = 0; i < 8; i++)
        {
            if (i != Status.ship - 1)
            {
                ships[i].interactable = false;
            }
        }
        PlayNextButtonSound();
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

    public void LoadValues()
    {
        LoadData.loadData();

        ArcadeControl();

        VolumeControl();

        FPSControl();

        SpeedControl();

        ContinueControl();

        ShipsControl();

        MoneyControl();

        ShopControl();
    }

    public void Update()
    {
        ShipsControl();
        MoneyControl();
        ShopControl();
        if (shipClicked == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
