using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMinis : MonoBehaviour
{
    public GameObject ship1;
    public GameObject ship2;
    public static float spawnRate = 1.5f;
    float nextSpawn = 0.0f;
    public float nextStepSayac = 2;
    public static bool start = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(start ==true)
        {
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;

                if (nextStepSayac < 0)
                {
                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(-4, 5);
                    int randomShip = Random.Range(0, 2);

                    if (randomShip == 0)
                    {
                        Instantiate(ship1, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                    if (randomShip == 1)
                    {
                        Instantiate(ship2, transform.position - new Vector3(random, 0f, 0f), transform.rotation);
                    }
                }
            }
        }
    }
}