using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float Sayac;
    public static float bulletForce = 40f;
    public Transform firePoint;
    public GameObject bullet;
    public AudioClip laserSound;
    AudioSource sourceAudio;
    void Start()
    {
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
            Destroy(bulletr, 0.45f);
            Sayac = Status.attackSpeed;
        }
    }
    void Update()
    {
        Sayac -= Time.deltaTime;
    }
}
