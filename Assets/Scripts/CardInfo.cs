using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
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
