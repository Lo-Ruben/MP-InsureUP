using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSingleton : GenericSingleton<BGMSingleton>
{

    public AudioSource mainMenuMusic;
    public AudioSource gameMusic;

    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
        gameMusic.Stop();
    }
    public void PlayGameMusic()
    {
        gameMusic.Play();
        mainMenuMusic.Stop();
    }

}
