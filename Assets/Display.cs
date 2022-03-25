using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public static int frame;
    public static float fpsTimer = 0f;
    public static float pollingTime = 1f;
    public Text fpsText;

    public AudioSource gameMusic;
    public AudioSource bossMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;


    void ShowFPS()
    {
        fpsTimer += Time.deltaTime;
        frame++;
        if (fpsTimer >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frame / fpsTimer);
            fpsText.text = frameRate.ToString() + " FPS";
            fpsTimer -= pollingTime;
            frame = 0;
        }
    }

    void MusicSound()
    {
        gameMusic.volume = PlayerPrefs.GetFloat("MusicValue");
        bossMusic.volume = PlayerPrefs.GetFloat("MusicValue");
        winMusic.volume = PlayerPrefs.GetFloat("MusicValue");
        loseMusic.volume = PlayerPrefs.GetFloat("MusicValue");
    }
    void Update()
    {
        ShowFPS();
        MusicSound();
    }
}
