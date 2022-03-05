using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public bool stop;
    public static int health;

    void Start()
    {
        stop = false;
        if(Status.wave==3)
        {
            health = 1000;
        }
        if (Status.wave == 6)
        {
            health = 5000;
        }
        if (Status.wave == 9)
        {
            health = 15000;
        }
    }

    void Update()
    {
        if(stop == false)
        {
            if(Status.wave == 3)
            {
                transform.position -= new Vector3(0,5 * Time.deltaTime, 0);
                if (transform.position.y <= 7.5)
                {
                    transform.position = new Vector3(0, 7.5f, 0);
                    stop = true;
                    health = 1000;
                    SpawnMinis.start = true;
                }
            }
            if(Status.wave == 6)
            {
                transform.position -= new Vector3(5 * Time.deltaTime, 0, 0);
                if (transform.position.x <= 0)
                {
                    transform.position = new Vector3(transform.position.x, 7.5f, 0);
                    stop = true;
                    health = 5000;
                    SpawnMinis.start = true;
                }
            }
            if(Status.wave == 9)
            {
                transform.position -= new Vector3(0, 5 * Time.deltaTime, 0);
                if (transform.position.y <= 0)
                {
                    transform.position = new Vector3(0, 0, 0);
                    stop = true;
                    health = 15000;
                    SpawnMinis.start = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= Status.damage;
            Destroy(collision.gameObject);
            Status.Points(25*Status.playerLevel);
            if(health<=0)
            {
                Status.BossPoints();
                Status.totalKill++;
                Status.totalBossKill++;
                SpawnEnemies.bossAlive = false;
                SpawnEnemies.bossControl = false;
                stop = false;
                SpawnMinis.start = false;
                Destroy(gameObject);
            }
        }
    }
}
