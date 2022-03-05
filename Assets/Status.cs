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
    public static int ship=1;
    public static int score;
    public GameObject[] players;
    public GameObject gameOverCanvas;
    public static float attackSpeed;
    public AudioClip levelSound;
    public AudioClip boomSound;
    public AudioClip bossSound;
    public AudioClip collisionSound;
    AudioSource sourceAudio;

    void Start()
    {
        if(StartMenu.saveGameFile==false)
        {
            health = maxHealth;
            wave = 1;
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
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    void CreateShip()
    {
        for(int i=0;i<8;i++)
        {
            if(i!=ship-1)
            {
                Destroy(players[i]);
            }
        }
    }

    void Regen()
    {
        health += (maxHealth - health) * 40 / 100;
    }

    void PlayerStats()
    {
        if(playerLevel==1)
        {
            damage = 5;
            attackSpeed = 0.5f;
        }
        if (playerLevel == 2)
        {
            damage = 10;
            attackSpeed = 0.45f;
        }
        if (playerLevel == 3)
        {
            damage = 15;
            attackSpeed = 0.4f;
        }
        if (playerLevel == 4)
        {
            damage = 20;
            attackSpeed = 0.35f;
        }
        if (playerLevel == 5)
        {
            damage = 25;
            attackSpeed = 0.3f;
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
        if (playerLevel == 2 && totalKill == 400)
        {
            playerLevel = 3;
            Regen();
        }
        if (playerLevel == 3 && totalKill == 600)
        {
            playerLevel = 4;
            Regen();
        }
        if (playerLevel == 4 && totalKill == 800)
        {
            playerLevel = 5;
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
            health = 0;
            Destroy(gameObject);
            gameOverCanvas.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemybullet")
        {
            sourceAudio.PlayOneShot(boomSound);
            GetDamage(5);
            Points(-50);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "enemycannon")
        {
            GetDamage(100);
            Points(-200);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemylaser")
        {
            GetDamage(200);
            Points(-500);
        }
        if(collision.gameObject.tag=="enemy")
        {
            sourceAudio.PlayOneShot(collisionSound);
            GetDamage(5*playerLevel);
            DestroyPoints();
        }
    }
}