using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public GameObject settings;
    public GameObject tutorialScreen;
    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");     
    }

    public void LoadGame()
    {
        // Load life goals
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void Back()
    {
        settings.SetActive(false);
    }
 
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void tutorial()
    {
        tutorialScreen.SetActive(true);
    }
    public void tutorialBack()
    {
        tutorialScreen.SetActive(false);
    }

}
