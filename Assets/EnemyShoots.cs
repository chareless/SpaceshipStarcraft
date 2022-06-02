using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoots : MonoBehaviour
{
    public float Sayac;
    public static float bulletForce = -30f;
    public Transform firePoint;
    public GameObject bullet;
    public int randomShoot;
    public AudioClip laserSound;
    AudioSource sourceAudio;
    void Start()
    {
        randomShoot = Random.Range(0, 100);
        Sayac = 0.3f;
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    public void Shoots()
    {
        if (Sayac <= 0)
        {
            GameObject bulletr = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
            rgbr.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            sourceAudio.PlayOneShot(laserSound);
            Destroy(bulletr, 2f);
            Sayac = 2f;
        }
    }
    void Update()
    {
        Sayac -= Time.deltaTime;

        switch(Status.wave)
        {
            case 1:
                if (randomShoot < 10)
                {
                    Shoots();
                }
                break;
            case 2:
                if (randomShoot < 12)
                {
                    Shoots();
                }
                break;
            case 3:
                if (randomShoot < 15)
                {
                    Shoots();
                }
                break;
            case 4:
                if (randomShoot < 17)
                {
                    Shoots();
                }
                break;
            case 5:
                if (randomShoot < 20)
                {
                    Shoots();
                }
                break;
            case 6:
                if (randomShoot < 22)
                {
                    Shoots();
                }
                break;
            case 7:
                if (randomShoot < 25)
                {
                    Shoots();
                }
                break;
            case 8:
                if (randomShoot < 27)
                {
                    Shoots();
                }
                break;
            case 9:
                if (randomShoot < 30)
                {
                    Shoots();
                }
                break;
        }
    }
}