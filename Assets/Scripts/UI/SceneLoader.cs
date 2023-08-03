using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public DontDestroyAudio audio;

    public void FadeToGame ()
    {
        animator.SetTrigger("FadeOut");     
    }

    public void ChangeMusic()
    {
        audio.mainMenuMusic.Stop();
        audio.gameMusic.Play();
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
