using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public static int speed = Convert.ToInt32(StartMenu.speedValue);

    public void Start()
    {
        if(speed==0)
        {
            speed = 2;
        }
    }
    void Update()
    {
            transform.position += new Vector3(0, -5 * Time.deltaTime * speed, 0);
            if (transform.position.y < -33)
            {
                transform.position = new Vector3(transform.position.x, 33, 0);
            }
    }
}
