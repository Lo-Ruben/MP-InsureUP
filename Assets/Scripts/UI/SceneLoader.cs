using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Use Animation Events
public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");     
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
