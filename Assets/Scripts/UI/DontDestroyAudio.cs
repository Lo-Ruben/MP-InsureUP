using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{

    public AudioSource mainMenuMusic;
    public AudioSource gameMusic;

    void Awake()
    {
        
        DontDestroyOnLoad(transform.gameObject);
    }


}
