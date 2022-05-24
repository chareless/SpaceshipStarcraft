using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public static int speed;
    public static int seed;
    public SpriteRenderer backGround;
    public Sprite[] bgs;

    public void Start()
    {
        seed = -3;
        speed = Convert.ToInt32(StartMenu.speedValue);
        backGround.sprite = bgs[StartMenu.savedBG];
    }

    void Update()
    {
        speed= Convert.ToInt32(StartMenu.speedValue);
        if (speed == 0)
        {
            speed = 2;
        }
        transform.position += new Vector3(0, seed * Time.deltaTime * speed, 0);
        if (transform.position.y < -33)
        {
            transform.position = new Vector3(transform.position.x, 49, 0);
        }
    }
}
