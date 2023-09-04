using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public void Back()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }
}
