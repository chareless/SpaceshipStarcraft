using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockSpawner : MonoBehaviour
{
    public float Sayac;
    public static float bulletForce = -2500f;
    public Transform firePoint;
    public GameObject bullet;
    public AudioClip shootSound;
    AudioSource sourceAudio;
    public float randomPlace;
    void Start()
    {
        sourceAudio = gameObject.GetComponent<AudioSource>();
        Sayac = 5f;
    }
    public void Shoots()
    {
        Sayac -= Time.deltaTime;
        if (Sayac <= 0)
        {
            randomPlace = Random.Range(-4.5f, 4.5f);
            firePoint.position += new Vector3(randomPlace, 0,0);
            GameObject bulletr = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
            rgbr.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            sourceAudio.PlayOneShot(shootSound);
            Destroy(bulletr, 1f);
            Sayac = SpawnEnemies.shockTime;
            firePoint.position -= new Vector3(randomPlace, 0, 0);
        }
    }



    void Update()
    {
        Shoots();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "enemy" || collision.gameObject.tag=="enemylaser")
        {
            Destroy(collision.gameObject);
        }
    }
}
