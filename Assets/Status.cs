using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Image healthbar;
    public Text scoreText;
    public Text levelText;
    public Text hpText;
    public Text hpTextOnPlayer;
    public Text killText;
    public Text enemyText;
    public Text waveText;
    public Text aSpeedText;
    public Text speedText;
    public Text damageText;
    public static int maxHealth = 1000;
    public static int health;
    public static int wave = 1;
    public static int damage;
    public static int playerLevel = 1;
    public static int lastLevel = 1;
    public static int totalKill = 0;
    public static int lastKill = 0;
    public static int lastBossKill = 0;
    public static int totalBossKill = 0;
    public static int ship;
    public static int score;
    public GameObject[] players;
    public GameObject gameOverCanvas;
    public GameObject particle;
    public static float attackSpeed;
    public AudioClip levelSound;
    public AudioClip boomSound;
    public AudioClip bossSound;
    public AudioClip collisionSound;
    AudioSource sourceAudio;

    void Start()
    {
        Application.targetFrameRate = StartMenu.maxFPS;
        if(StartMenu.saveGameFile==false)
        {
            health = maxHealth;
            if(StartMenu.selectCheck==true)
            {
                wave = StartMenu.selectedWave;
            }
            else
            {
                wave = 1;
            }
            playerLevel = 1;
            lastLevel = 1;
            totalKill = 0;
            lastKill = 0;
            lastBossKill = 0;
            totalBossKill = 0;
            score = 0;
            CreateShip();
        }
        if(StartMenu.saveGameFile==true)
        {
            health = LoadData.loadedHealth;
            ship = LoadData.loadedShip;
            score = LoadData.loadedScore;
            playerLevel = LoadData.loadedLevel;
            wave = LoadData.loadedWave;
            totalKill = LoadData.loadedKill;
            
            CreateShip();
        }
        if(SpawnEnemies.isArcadeOneHP==true)
        {
            health = 1;
        }
        sourceAudio = GetComponentInChildren<AudioSource>();
    }

    void CreateShip()
    {
        for(int i=0;i<StartMenu.maxShipCount;i++)
        {
            if(i!=ship-1)
            {
                Destroy(players[i]);
            }
        }
    }

    void Regen()
    {
        if(SpawnEnemies.isArcadeOneHP!=true)
        {
            health += (maxHealth - health) * 40 / 100;
        }
        
    }

    void PlayerStats()
    {
        if(playerLevel == 1)
        {
            damage = 5;
            attackSpeed = 0.5f;
        }
        else if (playerLevel == 2)
        {
            damage = 10;
            attackSpeed = 0.45f;
        }
        else if (playerLevel == 3)
        {
            damage = 15;
            attackSpeed = 0.4f;
        }
        else if (playerLevel == 4)
        {
            damage = 20;
            attackSpeed = 0.35f;
        }
        else if (playerLevel == 5)
        {
            damage = 25;
            attackSpeed = 0.3f;
        }
        else if (playerLevel == 6)
        {
            damage = 30;
            attackSpeed = 0.25f;
        }
        else if (playerLevel == 7)
        {
            damage = 35;
            attackSpeed = 0.22f;
        }
        else if (playerLevel == 8)
        {
            damage = 40;
            attackSpeed = 0.2f;
        }
    }

    void LabelUpdate()
    {
        scoreText.text = score.ToString();
        hpText.text = health.ToString();
        hpTextOnPlayer.text = "HP: " + health.ToString();
        waveText.text= wave.ToString();
        killText.text = totalKill.ToString();
        levelText.text = playerLevel.ToString();
        speedText.text = Movement.speedValue.ToString();
        aSpeedText.text = (1/attackSpeed).ToString("N2",CultureInfo.CreateSpecificCulture("en-US"));
        damageText.text = damage.ToString();
        enemyText.text = (SpawnEnemies.spawnedEnemy + "/" + SpawnEnemies.waveCount).ToString();
    }

    void LevelUpdate()
    {
        if(playerLevel == 1 && totalKill == 200)
        {
            playerLevel = 2;
            Regen();
        }
        else if(playerLevel == 2 && totalKill == 400)
        {
            playerLevel = 3;
            Regen();
        }
        else if(playerLevel == 3 && totalKill == 600)
        {
            playerLevel = 4;
            Regen();
        }
        else if(playerLevel == 4 && totalKill == 800)
        {
            playerLevel = 5;
            Regen();
        }
        else if(playerLevel == 5 && totalKill == 1000)
        {
            playerLevel = 6;
            Regen();
        }
        else if (playerLevel == 6 && totalKill == 1500)
        {
            playerLevel = 7;
            Regen();
        }
        else if (playerLevel == 7 && totalKill == 2000)
        {
            playerLevel = 8;
            Regen();
        }
    }

    public void SoundUpdate()
    {
        if (totalKill > lastKill)
        {
            sourceAudio.PlayOneShot(boomSound);
            lastKill = totalKill;
        }
        if (totalBossKill > lastBossKill)
        {
            sourceAudio.PlayOneShot(bossSound);
            lastBossKill = totalBossKill;
        }
        if(playerLevel>lastLevel)
        {
            sourceAudio.PlayOneShot(levelSound);
            lastLevel = playerLevel;
        }
    }

    public static void KillPoints()
    {
        score += 15 * wave * playerLevel;
    }

    public static void DestroyPoints()
    {
        score -= 5 * playerLevel;
        if(score<=0)
        {
            score = 0;
        }
    }

    public static void Points(int point)
    {
        score += point;
        if (score <= 0)
        {
            score = 0;
        }
    }

    public static void PointsArcade()
    {
        score += playerLevel;
    }

    public static void DestroyNoGunsPoints()
    {
        score -= 100 * playerLevel;
        if (score <= 0)
        {
            score = 0;
        }
    }
    public static void BossPoints()
    {
        score += 1000 * playerLevel*wave;
    }

    public static void GetDamage(int dmg)
    {
        health -= dmg;
    }
    void Update()
    {
        PlayerStats();
        LabelUpdate();
        LevelUpdate();
        SoundUpdate();

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthbar.fillAmount = (float)health / (float)maxHealth;

        if(health<=0)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            health = 0;
            Destroy(gameObject);
            gameOverCanvas.SetActive(true);
        }

        if(SpawnEnemies.isStoryMode!=true && PauseMenuScript.GamePaused!=true)
        {
            PointsArcade();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemybullet")
        {
            sourceAudio.PlayOneShot(boomSound);
            GetDamage(5);
            Points(-50);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "enemycannon")
        {
            if(SpawnEnemies.isArcadeShock==true || SpawnEnemies.isArcadeRapidfire==true || SpawnEnemies.isArcadeInsane==true)
            {
                GetDamage(50);
                Points(-300);
            }
            else
            {
                GetDamage(100);
                Points(-200);
            }
           
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemylaser")
        {
            if(SpawnEnemies.isArcadeLaser==true || SpawnEnemies.isArcadeRapidfire==true || SpawnEnemies.isArcadeInsane==true)
            {
                GetDamage(100);
                Points(-750);
            }
            else
            {
                GetDamage(200);
                Points(-500);
            }
        }
        if(collision.gameObject.tag=="enemy")
        {
            sourceAudio.PlayOneShot(collisionSound);
            if(SpawnEnemies.isArcadeDefend!=true)
            {
                GetDamage(5 * playerLevel);
            }
            
            if (SpawnEnemies.isArcadeNoGuns==true)
            {
                DestroyNoGunsPoints();
            }
            else
            {
                DestroyPoints();
            }
        }
    }
}