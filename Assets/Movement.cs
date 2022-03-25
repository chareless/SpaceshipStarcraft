using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speedValue=10;
    public float speed;
    public float Sayac;
    public static float bulletForce = 40f;
    public Transform firePoint;
    public GameObject bullet;
    public AudioClip laserSound;
    AudioSource sourceAudio;

    public GameObject ship13;
    public static float rotateCounter;

    void Start()
    {
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        RotateShip();
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if(SpawnEnemies.isArcadeNoGuns==true)
        {
            Sayac = 10f;
        }
        Sayac -= Time.deltaTime;
    }

    public void RotateShip()
    {
        if (Status.ship == 13)
        {
            rotateCounter += Time.deltaTime * speed*30;
            ship13.transform.rotation = Quaternion.Euler(0, 0, -rotateCounter);
        }
    }

    public void SagaGit()
    {
        if(SpawnEnemies.isArcadeMirror == true || SpawnEnemies.isArcadeInsane == true )
        {
            speed = -10f;
        }
        else
        {
            speed = 10f;
        }
    }
    public void SolaGit()
    {
        if(SpawnEnemies.isArcadeMirror == true || SpawnEnemies.isArcadeInsane == true )
        {
            speed = 10f;
        }
        else
        {
            speed = -10f;
        }
        
    }
    public void Dur()
    {
        speed = 0;
    }
    public void Shoots()
    {
        if (Sayac <= 0)
        {
            GameObject bulletr = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
            rgbr.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            sourceAudio.PlayOneShot(laserSound);
            Destroy(bulletr, 0.45f);
            Sayac = Status.attackSpeed;
        }
    }
}
