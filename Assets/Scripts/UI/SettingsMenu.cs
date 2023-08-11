using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    float volumeFloat;
    public Slider mainSliderUI;

    public GameObject muteBGMButtonEnabled;
    public GameObject muteBGMButtonDisabled;
    public AudioMixer musicVolume;

    public void SetVolume(float volume)
    {
        musicVolume.SetFloat("volume", volume);
    }

    private void Update()
    {
        musicVolume.GetFloat("volume", out volumeFloat);
        mainSliderUI.value = volumeFloat;

        if (volumeFloat <= -80)
        {
            muteBGMButtonEnabled.SetActive(true);
            muteBGMButtonDisabled.SetActive(false);

        }
        else if (volumeFloat > -80)
        {
            muteBGMButtonEnabled.SetActive(false);
            muteBGMButtonDisabled.SetActive(true);
        }
    }
    //private void OnEnable()
    //{
    //    musicVolume.GetFloat("volume", out volumeFloat);
    //    mainSliderUI.value = volumeFloat;

    //    if (volumeFloat <= -80)
    //    {
    //        muteBGMButtonEnabled.SetActive(true);
    //        muteBGMButtonDisabled.SetActive(false);

    //    }else if(volumeFloat > -80)
    //    {
    //        muteBGMButtonEnabled.SetActive(false);
    //        muteBGMButtonDisabled.SetActive(true);
    //    }
          
    //}

    public void MuteMusic()
    {
        musicVolume.SetFloat("volume", -80);
        muteBGMButtonEnabled.SetActive(true);
        muteBGMButtonDisabled.SetActive(false);
        
    }

    public void UnmuteMusic()
    {
        musicVolume.SetFloat("volume", 0);
        muteBGMButtonEnabled.SetActive(false);
        muteBGMButtonDisabled.SetActive(true);
    }


}
