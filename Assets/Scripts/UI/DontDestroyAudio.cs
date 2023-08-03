using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{

    public AudioSource mainMenuMusic;
    public AudioSource gameMusic;

    void Start()
    {
        
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        CheckPlaying();
    }

    void CheckPlaying()
    {
        if (mainMenuMusic.isPlaying)
        {
            gameMusic.Stop();
        }

        if (gameMusic.isPlaying)
        {
            mainMenuMusic.Stop();
        }
    }
}
