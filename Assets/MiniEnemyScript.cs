using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemyScript : MonoBehaviour
{
    Rigidbody2D enemyRb;
    public static float speed;
    public float sayac = 2;
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
        speed = -12f;
    }

    void Update()
    {
        enemyRb.velocity = new Vector2(0, speed);
        sayac -= Time.deltaTime;
        if (sayac <= 0 && alive == true)
        {
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            if (carpti == false)
            {
                Status.totalKill++;
                Status.KillPoints();
                alive = false;
                Destroy(gameObject);
                control = true;
            }
            if (carpti == true && control != true)
            {
                alive = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            health -= 1;
        }

        if (collision.gameObject.tag == "myship")
        {
            if (health != 0)
            {
                carpti = true;
                health -= 1;
            }
        }

        if (collision.gameObject.tag == "enemycannon")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "enemylaser")
        {
            Destroy(gameObject);
        }
    }
}