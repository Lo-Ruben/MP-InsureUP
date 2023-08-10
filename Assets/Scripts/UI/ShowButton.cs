using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses animation event
public class ShowButton : MonoBehaviour
{
    public GameObject buttons;
    public void ShowButtons()
    {
        buttons.SetActive(true);
        Time.timeScale = 0f;
    }
}
