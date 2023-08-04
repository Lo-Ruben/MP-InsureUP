using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public DontDestroyAudio backgroundMusic;
    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");     
    }

    public void ChangeMusic()
    {
        backgroundMusic.mainMenuMusic.Stop();
        backgroundMusic.gameMusic.Play();
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("ChooseLifeGoals");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
