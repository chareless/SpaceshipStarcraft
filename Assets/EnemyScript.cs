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
    public GameObject particle;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        EnemyCreate();
    }

    void EnemyCreate()
    {
        if (SpawnEnemies.isArcadeSpeed == true || SpawnEnemies.isArcadeInsane == true || SpawnEnemies.isArcadeDefend == true)
        {
            speed = -25;
        }
        else
        {
            switch (Status.wave)
            {
                case 1:
                    speed = -16;
                    break;
                case 2:
                    speed = -16;
                    break;
                case 3:
                    speed = -16;
                    break;
                case 4:
                    speed = -18;
                    break;
                case 5:
                    speed = -18;
                    break;
                case 6:
                    speed = -18;
                    break;
                case 7:
                    speed = -20;
                    break;
                case 8:
                    speed = -20;
                    break;
                case 9:
                    speed = -20;
                    break;
                case 10:
                    speed = -20; ;
                    break;
            }
        }
    }

    void Update()
    {
        enemyRb.velocity = new Vector2(0,speed);
        sayac -= Time.deltaTime;
        if(sayac<=0 && alive==true)
        {
            if(SpawnEnemies.isArcadeDefend!=true && SpawnEnemies.isArcadeInsane!=true)
            {
                SpawnEnemies.destroyedEnemy++;
                Destroy(gameObject);
            }
            else
            {
                SpawnEnemies.destroyedEnemy++;
                Status.GetDamage(5 * Status.playerLevel);
                Destroy(gameObject);
            }

            
            if(SpawnEnemies.isArcadeNoGuns==true && Status.health>0)
            {
                Status.totalKill++;
                Status.KillPoints();
            }

        }
        if(health<=0)
        {
            Instantiate(particle,transform.position,Quaternion.identity);
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
                if(SpawnEnemies.isArcadeDefend==true || SpawnEnemies.isArcadeInsane==true)
                {
                    Status.totalKill++;
                    Status.KillPoints();
                }
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

        if(collision.gameObject.tag=="enemybullet")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "enemylaser")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "enemycannon")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}