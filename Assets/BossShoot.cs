using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public float Sayac;
    public float moveSayac;
    public static float bulletForce = -2500f;
    public Transform firePoint;
    public GameObject bullet;
    public AudioClip shootSound;
    AudioSource sourceAudio;
    void Start()
    {
        sourceAudio = gameObject.GetComponent<AudioSource>();
        Sayac = 5f;
        moveSayac = 18f;
    }
    public void Shoots()
    {
        if (Sayac <= 0)
        {
            GameObject bulletr = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
            rgbr.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            sourceAudio.PlayOneShot(shootSound);
            Destroy(bulletr, 1f);
            Sayac = 2f;
        }
    }

    public void MoveBoss()
    {
        if(moveSayac>=10 && moveSayac<=13)
        {
            transform.position -= new Vector3(1.6f*Time.deltaTime, 0, 0);
        }
        if(moveSayac >= 4 && moveSayac <= 9)
        {
            transform.position += new Vector3(1.6f*Time.deltaTime, 0, 0);
        }
        if (moveSayac >= 1 && moveSayac <= 3)
        {
            transform.position -= new Vector3(1.6f * Time.deltaTime, 0, 0);
        }
        if (moveSayac<=0)
        {
            moveSayac = 14;
        }
    }
    void Update()
    {
        Sayac -= Time.deltaTime;
        moveSayac -= Time.deltaTime;
        Shoots();
        MoveBoss();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="bullet" ||collision.gameObject.tag=="enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
