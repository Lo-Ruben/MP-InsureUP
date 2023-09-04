using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    // Script to handle when search card info UI should be activated and deactivated
    // Script is attached to canvas

    public GameObject CardInfoUI;
    public AudioSource audiosource;
    public AudioClip click;
    public AudioClip select;
    public void openCardInfo()
    {
        CardInfoUI.SetActive(true);
        audiosource.clip = select;
        audiosource.Play();
    }
    public void closeCardInfo()
    {
        CardInfoUI.SetActive(false);
        audiosource.clip = click;
        audiosource.Play();
    }
}
