using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public GameObject settings;
    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");     
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("ChooseLifeGoals");
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


}
