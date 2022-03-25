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
    public GameObject laserSpawner;
    public GameObject shockSpawner;
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
    public static int laserTime;
    public static float shockTime;
    public static bool bossAlive;
    public static bool bossControl;
    public static bool gameEnd;
    public static bool isStoryMode;
    public static bool isArcadeEndless;
    public static bool isArcadeLaser;
    public static bool isArcadeShock;
    public static bool isArcadeNoGuns;
    public static bool isArcadeOneHP;
    public static bool isArcadeRapidfire;
    public static bool isArcadeSpeed;
    public static bool isArcadeDefend;
    public static bool isArcadeMirror;
    public static bool isArcadeInsane;
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
        else if (Status.wave == 2)
        {
            waveCount = 75;
        }
        else if (Status.wave == 3)
        {
            waveCount = 100;
        }
        else if (Status.wave == 4)
        {
            waveCount = 70;
        }
        else if (Status.wave == 5)
        {
            waveCount = 85;
        }
        else if (Status.wave == 6)
        {
            waveCount = 100;
        }
        else if (Status.wave == 7)
        {
            waveCount = 80;
        }
        else if (Status.wave== 8)
        {
            waveCount = 100;
        }
        else if (Status.wave == 9)
        {
            waveCount = 120;
        }
        else if (Status.wave == 10)
        {
            gameEnd = true;
            endCanvas.SetActive(true);
            completeGame = 1;
            PlayerPrefs.SetInt("End", completeGame);
            PlayerPrefs.Save();
        }

        if(isStoryMode!=true)
        {
            waveCount = 0;
        }

        if(isArcadeLaser!=true)
        {
            if(isArcadeRapidfire!=true && isArcadeInsane !=true)
            {
                Destroy(laserSpawner);
            }
            
        }
        if(isArcadeShock!=true)
        {
            if(isArcadeRapidfire!=true && isArcadeInsane!=true)
            {
                Destroy(shockSpawner);
            }
            
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

    void ArcadeTextUpdate()
    {
        if(isArcadeEndless==true)
        {
            waveText.text = "Endless Mode".ToString();
        }
        else if(isArcadeLaser==true)
        {
            waveText.text = "Laser Mode".ToString();
        }
        else if(isArcadeNoGuns==true)
        {
            waveText.text = "No Guns Mode".ToString();
        }
        else if(isArcadeOneHP==true)
        {
            waveText.text = "One HP Mode".ToString();
        }
        else if(isArcadeShock==true)
        {
            waveText.text = "Shock Mode".ToString();
        }
        else if (isArcadeRapidfire == true)
        {
            waveText.text = "Rapidfire Mode".ToString();
        }
        else if (isArcadeSpeed == true)
        {
            waveText.text = "Speed Mode".ToString();
        }
        else if (isArcadeDefend == true)
        {
            waveText.text = "Defend Mode".ToString();
        }
        else if (isArcadeMirror == true)
        {
            waveText.text = "Mirror Mode".ToString();
        }
        else if (isArcadeInsane == true)
        {
            waveText.text = "Insane Mode".ToString();
        }
        sayacText -= Time.deltaTime;
        if (sayacText <= 0)
        {
            waveText.text = "";
        }
    }

    void InfoSayac()
    {
        if(Status.wave==3 && bossAlive==true)
        {
            bossName = "Dimention Gate";
            timeText.text = System.Convert.ToString((int)nextStepSayac);
        }
        else if (Status.wave == 6 && bossAlive==true)
        {
            bossName = "Black Worm";
            timeText.text = System.Convert.ToString((int)nextStepSayac);
        }
        else if (Status.wave == 9 && bossAlive==true)
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
        if(isStoryMode == true)
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
        if(isArcadeEndless == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if(spawnedEnemy<=50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <=100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <=1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
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
        if(isArcadeLaser == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                        laserTime = 18;
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                        laserTime = 17;
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                        laserTime = 16;
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                        laserTime = 15;
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                        laserTime = 14;
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                        laserTime = 13;
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                        laserTime = 12;
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <=2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                        laserTime = 11;
                    }
                    else if(spawnedEnemy>2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                        laserTime = 10;
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;
                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeNoGuns == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;
                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeOneHP == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;

                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeShock == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                        shockTime = 1;
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                        shockTime = 1;
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                        shockTime = 1;
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;
                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeRapidfire == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                        laserTime = 18;
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                        laserTime = 17;
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                        laserTime = 16;
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                        laserTime = 15;
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                        laserTime = 14;
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                        laserTime = 13;
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                        laserTime = 12;
                        shockTime = 1;
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                        laserTime = 11;
                        shockTime = 1;
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                        laserTime = 10;
                        shockTime = 1;
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;
                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeSpeed == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;

                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeDefend == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;

                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeMirror == true)
        {
            ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;

                    if ((int)playTimeSayac % 20 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
        if(isArcadeInsane == true)
        {
             ArcadeTextUpdate();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (nextStepSayac < 0)
                {
                    if (spawnedEnemy <= 50)
                    {
                        spawnRate = Random.Range(1.25f, 1.5f);
                        laserTime = 18;
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 50 && spawnedEnemy <= 100)
                    {
                        spawnRate = Random.Range(1f, 1.25f);
                        laserTime = 17;
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 100 && spawnedEnemy <= 500)
                    {
                        spawnRate = Random.Range(0.75f, 1f);
                        laserTime = 16;
                        shockTime = 2;
                    }
                    else if (spawnedEnemy > 500 && spawnedEnemy <= 1000)
                    {
                        spawnRate = Random.Range(0.5f, 0.75f);
                        laserTime = 15;
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1000 && spawnedEnemy <= 1250)
                    {
                        spawnRate = Random.Range(0.4f, 0.5f);
                        laserTime = 14;
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1250 && spawnedEnemy <= 1500)
                    {
                        spawnRate = Random.Range(0.3f, 0.4f);
                        laserTime = 13;
                        shockTime = 1.5f;
                    }
                    else if (spawnedEnemy > 1500 && spawnedEnemy <= 1750)
                    {
                        spawnRate = Random.Range(0.2f, 0.3f);
                        laserTime = 12;
                        shockTime = 1;
                    }
                    else if (spawnedEnemy > 1750 && spawnedEnemy <= 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.2f);
                        laserTime = 11;
                        shockTime = 1;
                    }
                    else if (spawnedEnemy > 2000)
                    {
                        spawnRate = Random.Range(0.1f, 0.1f);
                        laserTime = 10;
                        shockTime = 1;
                    }

                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-3, 5);
                    int randomShip = Random.Range(0, 3);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    else if (randomShip == 2)
                    {
                        Instantiate(ship3, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    spawnedEnemy++;
                    if ((int)playTimeSayac % 30 == 0)
                    {
                        StartMenu.coin += 1;
                        SaveData.saveCoin();
                    }
                }
            }
        }
    }
}