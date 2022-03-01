using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speedValue=10;
    public float speed;

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    public void SagaGit()
    {
        speed = 10f;
    }
    public void SolaGit()
    {
        speed = -10f;
    }
    public void Dur()
    {
        speed = 0;
    }
}
