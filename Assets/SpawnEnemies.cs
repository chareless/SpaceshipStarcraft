using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject endCanvas;
    public GameObject gameOverCanvas;
    public Text waveText;
    public Text infoText;
    public Text timeText;
    public static float spawnRate;
    float nextSpawn = 0.0f;
    public float nextStepSayac = 0;
    public float playTimeSayac = 0;
    public float sayacText = 3;
    public float infoSayac = -1;
    public static int waveCount;
    public static int destroyedEnemy;
    public static int spawnedEnemy;
    public static int completeGame = 0;
    public static bool bossAlive;
    public static bool bossControl;
    public static bool gameEnd;
    public static bool isArcade;
    public string bossName;
    public AudioSource gameMusic;
    public AudioSource bossMusic;
    public AudioClip boss1Music;
    public AudioClip boss2Music;
    public AudioClip boss3Music;
    
    void Start()
    {
        bossMusic.Stop();
        nextStepSayac = 5;
        destroyedEnemy = 0;
        spawnedEnemy = 0;
        bossAlive = false;
        bossControl = true;
        gameEnd = false;
        waveCounts();
        LevelTextUpdate();
    }

    void waveCounts()
    {
        if (Status.wave == 1)
        {
            waveCount = 50;
        }
        if (Status.wave == 2)
        {
            waveCount = 75;
        }
        if (Status.wave == 3)
        {
            waveCount = 100;
        }
        if (Status.wave == 4)
        {
            waveCount = 70;
        }
        if (Status.wave == 5)
        {
            waveCount = 85;
        }
        if (Status.wave == 6)
        {
            waveCount = 100;
        }
        if (Status.wave == 7)
        {
            waveCount = 80;
        }
        if (Status.wave== 8)
        {
            waveCount = 100;
        }
        if (Status.wave == 9)
        {
            waveCount = 120;
        }
        if (Status.wave == 10)
        {
            gameEnd = true;
            endCanvas.SetActive(true);
            completeGame = 1;
            PlayerPrefs.SetInt("End", completeGame);
            PlayerPrefs.Save();
        }
        if(isArcade==true)
        {
            waveCount = 0;
        }
    }

    void LevelTextUpdate()
    {
        if(Status.wave!=10)
        {
            waveText.text = "WAVE " + (Status.wave).ToString();
            sayacText -= Time.deltaTime;
            if (sayacText <= 0)
            {
                waveText.text = "";
            }
        }
        InfoSayac();
    }

    void InfoSayac()
    {
        if(Status.wave==3 && bossAlive==true)
        {
            bossName = "Dimention Gate";
            timeText.text = System.Convert.ToString((int)nextStepSayac);
        }
        if (Status.wave == 6 && bossAlive==true)
        {
            bossName = "Black Worm";
            timeText.text = System.Convert.ToString((int)nextStepSayac);
        }
        if (Status.wave == 9 && bossAlive==true)
        {
            bossName = "Dark Matter";
            timeText.text = System.Convert.ToString((int)nextStepSayac);
        }
        infoText.text = bossName;
        infoSayac -= Time.deltaTime;
        if(infoSayac<=0)
        {
            infoText.text = "";
        }
       
    }

    void Update()
    {
        playTimeSayac += Time.deltaTime;
        if (isArcade != true)
        {
            LevelTextUpdate();
            waveCounts();
            if (Time.time > nextSpawn)
            {
                if (gameEnd != true)
                {
                    nextStepSayac -= Time.deltaTime;
                    if (destroyedEnemy >= waveCount)
                    {
                        if (bossAlive == false && bossControl == true)
                        {
                            if (Status.wave == 3)
                            {
                                bossMusic.clip = boss1Music;
                                bossMusic.Play();
                                gameMusic.Stop();
                                bossAlive = true;
                                infoSayac = 3;
                                nextStepSayac = 150f;
                                Instantiate(boss1, new Vector3(0f, 15f, 0f), transform.rotation);
                            }
                            if (Status.wave == 6)
                            {
                                bossMusic.clip = boss2Music;
                                bossMusic.Play();
                                gameMusic.Stop();
                                bossAlive = true;
                                infoSayac = 3;
                                nextStepSayac = 300f;
                                Instantiate(boss2, new Vector3(12f, 7.5f, 0f), transform.rotation);
                            }
                            if (Status.wave == 9)
                            {
                                bossMusic.clip = boss3Music;
                                bossMusic.Play();
                                gameMusic.Stop();
                                bossAlive = true;
                                infoSayac = 3;
                                nextStepSayac = 500f;
                                Instantiate(boss3, new Vector3(0f, 12f, 0f), transform.rotation);
                            }
                        }
                        if (bossAlive == false)
                        {
                            if (bossMusic.isPlaying == true)
                            {
                                gameMusic.Play();
                                bossMusic.Stop();
                            }
                            bossControl = true;
                            Status.wave++;
                            nextStepSayac = 5f;
                            destroyedEnemy = 0;
                            spawnedEnemy = 0;
                            sayacText = 3;
                            waveCounts();
                            LevelTextUpdate();
                            StartMenu.coin += (int)(playTimeSayac / 10);
                            SaveData.saveData();
                            timeText.text = "";
                        }
                        if (nextStepSayac <= 0 && bossAlive == true)
                        {
                            gameOverCanvas.SetActive(true);
                        }
                    }

                    if (nextStepSayac < 0 && bossAlive == false)
                    {
                        spawnRate = Random.Range(0.75f, 1.5f);
                        nextSpawn = Time.time + spawnRate;
                        int random = Random.Range(-4, 5);
                        int randomShip = Random.Range(0, 3);
                        if (spawnedEnemy <= waveCount)
                        {
                            if (randomShip == 0)
                            {
                                Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                            }
                            if (randomShip == 1)
                            {
                                Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                            }
                            if (randomShip == 2)
                            {
                                Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                            }
                            spawnedEnemy++;
                        }

                        if (spawnedEnemy == waveCount)
                        {
                            nextStepSayac = 10f;
                        }
                    }
                }

            }
        }
        if(isArcade==true)
        {
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                waveText.text = "";
                if (nextStepSayac < 0)
                {
                    if(destroyedEnemy<=50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    if (destroyedEnemy > 50 && destroyedEnemy <=100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    if (destroyedEnemy > 100 && destroyedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    if (destroyedEnemy > 500 && destroyedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    if (destroyedEnemy > 1000 && destroyedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    if (destroyedEnemy > 1500 && destroyedEnemy <=2000)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    if (destroyedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.3f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 2);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;

                    if((int)playTimeSayac % 20==0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
    }
}