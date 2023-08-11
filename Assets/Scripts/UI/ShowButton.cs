using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public GameObject buttons;
    public GameObject pauseMenu;
    public void ShowButtons()
    {
        buttons.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideButtons()
    {
        buttons.SetActive(false);
    }

    public void HidePause()
    {
        pauseMenu.SetActive(false);
    }
}
