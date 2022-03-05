using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public float Sayac;
    public float fireSayac;
    public float endSayac;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bullet;
    public GameObject beforeFire;
    public int randShoot;
    public int beforeShoot;
    public bool randCreated;
    public bool bulletCreated;
    public AudioClip laserSound;
    public AudioClip laserFirstSound;
    AudioSource sourceAudio;
    void Start()
    {
        sourceAudio = gameObject.GetComponent<AudioSource>();
        Sayac = 15f;
        fireSayac = 2f;
        endSayac = 2f;
        beforeShoot = 4;
        randCreated = false;
        bulletCreated = false;
    }

    void randomPlace()
    {
        randShoot = Random.Range(0, 3);
        if(randShoot==beforeShoot)
        {
            while (randShoot==beforeShoot)
            {
                randShoot = Random.Range(0, 3);
            }
        }

        if (randShoot == 0 )
        {
            GameObject before = Instantiate(beforeFire, firePoint.position - new Vector3(-0.5f, 0.2f), Quaternion.Euler(0,0,0));
            Destroy(before, 5f);
        }
        if (randShoot == 1 )
        {
            GameObject before = Instantiate(beforeFire, firePoint2.position- new Vector3(0.5f,0.2f), Quaternion.Euler(0, 180, 0));
            Destroy(before, 5f);
        }
        if (randShoot == 2 )
        {
            GameObject before = Instantiate(beforeFire, firePoint3.position - new Vector3(-0.2f, -0.5f), Quaternion.Euler(0, 0, 90));
            Destroy(before, 5f);
        }
        randCreated = true;
        beforeShoot = randShoot;
        sourceAudio.PlayOneShot(laserFirstSound);
    }
    public void Shoots()
    {
        if(bulletCreated==false)
        {
            if(randShoot==0)
            {
                GameObject bulletr = Instantiate(bullet, firePoint.position - new Vector3(0.6f, 13.5f), firePoint.rotation);
                Destroy(bulletr, 3f);
                bulletCreated = true;
            }
            if(randShoot==1)
            {
                GameObject bulletr = Instantiate(bullet, firePoint2.position - new Vector3(0, 13.5f), firePoint.rotation);
                Destroy(bulletr, 3f);
                bulletCreated = true;
            }
            if(randShoot==2)
            {
                GameObject bulletr = Instantiate(bullet, firePoint3.position - new Vector3(0.35f, 13.5f), firePoint.rotation);
                Destroy(bulletr, 3f);
                bulletCreated = true;
            }
            sourceAudio.PlayOneShot(laserSound);
        }
    }
    void Update()
    {
        Sayac -= Time.deltaTime;
        if(Sayac<=10)
        {
            if(randCreated==false)
            {
                randomPlace();
                bulletCreated = false;
            }
            fireSayac -= Time.deltaTime;
            if(fireSayac<=0)
            {
                Shoots();
            }
            if(fireSayac<=-3)
            {
                endSayac -= Time.deltaTime;
            }
            if(endSayac<=0)
            {
                fireSayac = 2f;
                endSayac = 1f;
                Sayac = 10f;
                randCreated = false;
            }
        }
    }
}
