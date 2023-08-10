using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer musicVolume;
    public void SetVolume(float volume)
     {
            Debug.Log(volume);
            musicVolume.SetFloat("volume", volume);

           
      }


}
