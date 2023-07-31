using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;

    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");     
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Table Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
