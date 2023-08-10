using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    float volumeFloat;
    public Slider SliderUI;
    public AudioMixer musicVolume;

    public void SetVolume(float volume)
    {
        musicVolume.SetFloat("volume", volume);
    }

    private void OnEnable()
    {
        musicVolume.GetFloat("volume", out volumeFloat);
        SliderUI.value = volumeFloat;
    }


}
