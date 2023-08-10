using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSingleton : GenericSingleton<BGMSingleton>
{
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioSource BGMAudioSournce;

    public void PlayMainMenuMusic()
    {
        if (BGMAudioSournce.clip != mainMenuMusic)
        {
            BGMAudioSournce.clip = mainMenuMusic;
            BGMAudioSournce.Play();
        }
    }
    public void PlayGameMusic()
    {
        if (BGMAudioSournce.clip != gameMusic)
        {
            BGMAudioSournce.clip = gameMusic;
            BGMAudioSournce.Play();
        }
    }

}
