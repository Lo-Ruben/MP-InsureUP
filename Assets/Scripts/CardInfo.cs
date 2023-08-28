using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    // Script to handle when search card info UI should be activated and deactivated
    // Script is attached to canvas

    public GameObject CardInfoUI;
    public void openCardInfo()
    {
        CardInfoUI.SetActive(true);
    }
    public void closeCardInfo()
    {
        CardInfoUI.SetActive(false);
    }
}
