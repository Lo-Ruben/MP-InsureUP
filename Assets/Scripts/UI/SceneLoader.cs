using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public GameObject settings;
    public GameObject tutorialScreen;
    public AudioSource audioSource;
    public AudioClip click;
    public AudioClip select;
    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");
        audioSource.clip = select;
        audioSource.Play();
    }

    public void LoadGame()
    {
        // Load life goals
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settings.SetActive(true);
        audioSource.clip = select;
        audioSource.Play();
    }

    public void Back()
    {
        settings.SetActive(false);
        audioSource.clip = click;
        audioSource.Play();
    }
 
    public void QuitGame()
    {
        Application.Quit();
        audioSource.Play();
    }
    public void tutorial()
    {
        tutorialScreen.SetActive(true);
        audioSource.clip = select;
        audioSource.Play();
    }
    public void tutorialBack()
    {
        tutorialScreen.SetActive(false);
        audioSource.clip = click;
        audioSource.Play();
    }

}
