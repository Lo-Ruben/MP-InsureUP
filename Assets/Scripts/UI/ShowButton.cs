using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public GameObject buttons;
    public PauseMenu menu;
    public void ShowButtons()
    {
        buttons.SetActive(true);
        menu.paused = true;
        
    }

    public void Paused()
    {
        menu.paused = true;
    }
}
