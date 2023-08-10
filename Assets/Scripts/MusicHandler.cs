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
                BGMSingleton.instance.PlayMainMenuMusic();
                break;
            case 1:
                BGMSingleton.instance.PlayMainMenuMusic();
                break;
            case 2:
                BGMSingleton.instance.PlayGameMusic();
                break;
            case 3:
                break;
            default:
                Debug.Log(currentSceneIndex);
                break;
        }


    }
}
