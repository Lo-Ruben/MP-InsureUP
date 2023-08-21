using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    int currentSceneIndex;

    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        switch (currentSceneIndex)
        {
            case 0:
                Debug.Log("MainMenu");
                BGMSingleton.instance.PlayMainMenuMusic();
                break;
            case 1:
                Debug.Log(BGMSingleton.instance.BGMAudioSournce.clip != BGMSingleton.instance.mainMenuMusic);
                if(BGMSingleton.instance.BGMAudioSournce.clip != BGMSingleton.instance.mainMenuMusic)
                {
                    BGMSingleton.instance.PlayMainMenuMusic();
                }
                break;
            case 2:
                Debug.Log("TableScene");
                BGMSingleton.instance.PlayGameMusic();
                break;
            default: 
                break;
        }

        
    }
}
