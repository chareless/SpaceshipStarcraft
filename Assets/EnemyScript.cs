using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D enemyRb;
    public static float speed;
    public float sayac = 2.15f;
    public bool alive = true;
    public int health = 1;
    public bool carpti = false;
    public bool control = false;
    void Start()
    {
        enemyRb = GetComponentInParent<Rigidbody2D>();
        EnemyCreate();
    }

    void EnemyCreate()
    {
        if (Status.wave == 1)
        {
            speed = -16;
        }
        if (Status.wave == 2)
        {
            speed = -16;
        }
        if (Status.wave == 3)
        {
            speed = -16;
        }
        if (Status.wave == 4)
        {
            speed = -18;
        }
        if (Status.wave == 5)
        {
            speed = -18;
        }
        if (Status.wave== 6)
        {
            speed = -18;
        }
        if (Status.wave == 7)
        {
            speed = -20;
        }
        if (Status.wave == 8)
        {
            speed = -20;
        }
        if (Status.wave == 9)
        {
            speed = -20;
        }
        if (Status.wave >= 10)
        {
            speed = -20;
        }
    }

    void Update()
    {
        enemyRb.velocity = new Vector2(0,speed);
        sayac -= Time.deltaTime;
        if(sayac<=0 && alive==true)
        {
            SpawnEnemies.destroyedEnemy++;
            Destroy(gameObject);
        }
        if(health<=0)
        {
            if(carpti==false)
            {
                SpawnEnemies.destroyedEnemy++;
                Status.totalKill++;
                Status.KillPoints();
                alive = false;
                Destroy(gameObject);
                control = true;
            }
           if(carpti==true && control!=true)
           {
                SpawnEnemies.destroyedEnemy++;
                alive = false;
                Destroy(gameObject);
           }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="bullet")
        {
            Destroy(collision.gameObject);
            health -= 1;
        }

        if(collision.gameObject.tag=="myship")
        {
            if (health !=0 )
            {
                carpti = true;
                health -= 1;
            }
        }
    }
}